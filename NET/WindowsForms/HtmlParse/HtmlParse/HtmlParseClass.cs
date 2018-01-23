﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlParser
{
    public class HtmlTag
    {
        /// <summary>
        /// Name of this tag
        /// </summary>
        public string Name { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Collection of attribute names and values for this tag 标记的属性名称和值的集合
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// True if this tag contained a trailing forward slash 如果此标记包含尾随的斜杠
        /// </summary>
        public bool TrailingSlash { get; set; }
    };

    public class HtmlParseClass
    {
        protected string _html;
        protected int _pos;
        protected bool _scriptBegin;

        public HtmlParseClass(string html)
        {
            Reset(html);
        }

        /// <summary>
        /// Resets the current position to the start of the current document 当前位置重置为当前文档的开始
        /// </summary>
        public void Reset()
        {
            _pos = 0;
        }

        /// <summary>
        /// Sets the current document and resets the current position to the 当前文档设置和重置当前位置到
        /// start of it
        /// </summary>
        /// <param name="html"></param>
        public void Reset(string html)
        {
            _html = html;
            _pos = 0;
        }

        /// <summary>
        /// Indicates if the current position is at the end of the current 是否为文档末尾
        /// document
        /// </summary>
        public bool EOF
        {
            get { return (_pos >= _html.Length); }
        }

        /// <summary>
        /// Parses the next tag that matches the specified tag name 解析下一个标记，它指定标记名称匹配
        /// </summary>
        /// <param name="name">Name of the tags to parse ("*" = parse all tags) 标记的名称解析("*"=解析所有标签)
        /// </param>
        /// <param name="tag">Returns information on the next occurrence of the specified tag or null if none found 返回下一个出现的指定标签上的信息如果未找到，则为null</param>
        /// <returns>True if a tag was parsed or false if the end of the document was reached 文档解析状态成功或失败或到文档末尾</returns>
        public bool ParseNext(string name, out HtmlTag tag)
        {
            tag = null;

            // Nothing to do if no tag specified
            if (String.IsNullOrEmpty(name))
                return false;

            // Loop until match is found or there are no more tags 循环查找匹配项
            while (MoveToNextTag())
            {
                // Skip opening '<'
                Move();

                // Examine first tag character
                char c = Peek();
                if (c == '!' && Peek(1) == '-' && Peek(2) == '-')
                {
                    // Skip over comments 跳过注释
                    const string endComment = "-->";
                    _pos = _html.IndexOf(endComment, _pos);
                    NormalizePosition();
                    Move(endComment.Length);
                }
                else if (c == '/')
                {
                    // Skip over closing tags 跳过关闭标签
                    _pos = _html.IndexOf('>', _pos);
                    NormalizePosition();
                    Move();
                }
                else
                {
                    // Parse tag 解析标签
                    bool result = ParseTag(name, ref tag);

                    // Because scripts may contain tag characters,
                    // we need special handling to skip over
                    // script contents
                    if (_scriptBegin)
                    {
                        const string endScript = "</script";
                        _pos = _html.IndexOf(endScript, _pos,
                          StringComparison.OrdinalIgnoreCase);
                        NormalizePosition();
                        Move(endScript.Length);
                        SkipWhitespace();
                        if (Peek() == '>')
                            Move();
                    }

                    // Return true if requested tag was found
                    if (result)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Parses the contents of an HTML tag. The current position should
        /// be at the first character following the tag's opening less-than
        /// character.
        /// 
        /// Note: We parse to the end of the tag even if this tag was not
        /// requested by the caller. This ensures subsequent parsing takes
        /// place after this tag
        /// </summary>
        /// <param name="name">Name of the tag the caller is requesting,
        /// or "*" if caller is requesting all tags</param>
        /// <param name="tag">Returns information on this tag if it's one
        /// the caller is requesting</param>
        /// <returns>True if data is being returned for a tag requested by
        /// the caller or false otherwise</returns>

        protected bool ParseTag(string name, ref HtmlTag tag)
        {
            // Get name of this tag
            string s = ParseTagName();

            // Special handling
            bool doctype = _scriptBegin = false;
            if (String.Compare(s, "!DOCTYPE", true) == 0)
                doctype = true;
            else if (String.Compare(s, "script", true) == 0)
                _scriptBegin = true;

            // Is this a tag requested by caller?
            bool requested = false;
            if (name == "*" || String.Compare(s, name, true) == 0)
            {
                // Yes, create new tag object
                tag = new HtmlTag();
                tag.Name = s;
                tag.Attributes = new Dictionary<string, string>();
                requested = true;
            }

            // Parse attributes
            SkipWhitespace();
            while (Peek() != '>')
            {
                if (Peek() == '/')
                {
                    // Handle trailing forward slash 处理关闭标签
                    if (requested)
                        tag.TrailingSlash = true;
                    Move();
                    SkipWhitespace();
                    // If this is a script tag, it was closed
                    _scriptBegin = false;
                }
                else
                {
                    // Parse attribute name
                    s = (!doctype) ? ParseAttributeName() : ParseAttributeValue();
                    SkipWhitespace();
                    // Parse attribute value
                    string value = String.Empty;
                    if (Peek() == '=')
                    {
                        Move();
                        SkipWhitespace();
                        value = ParseAttributeValue();
                        SkipWhitespace();
                    }
                    // Add attribute to collection if requested tag
                    if (requested)
                    {
                        // This tag replaces existing tags with same name
                        if (tag.Attributes.Keys.Contains(s))
                            tag.Attributes.Remove(s);
                        tag.Attributes.Add(s, value);
                    }
                }
            }
            // Skip over closing '>'
            Move();

            return requested;
        }

        /// <summary>
        /// Parses a tag name. The current position should be the first
        /// character of the name
        /// </summary>
        /// <returns>Returns the parsed name string</returns>
        protected string ParseTagName()
        {
            int start = _pos;
            while (!EOF && !Char.IsWhiteSpace(Peek()) && Peek() != '>')
                Move();
            return _html.Substring(start, _pos - start);
        }

        /// <summary>
        /// Parses an attribute name. The current position should be the
        /// first character of the name
        /// </summary>
        /// <returns>Returns the parsed name string</returns>
        protected string ParseAttributeName()
        {
            int start = _pos;
            while (!EOF && !Char.IsWhiteSpace(Peek()) && Peek() != '>'
              && Peek() != '=')
                Move();
            return _html.Substring(start, _pos - start);
        }

        /// <summary>
        /// Parses an attribute value. The current position should be the
        /// first non-whitespace character following the equal sign.
        /// 
        /// Note: We terminate the name or value if we encounter a new line.
        /// This seems to be the best way of handling errors such as values
        /// missing closing quotes, etc.
        /// </summary>
        /// <returns>Returns the parsed value string</returns>
        protected string ParseAttributeValue()
        {
            int start, end;
            char c = Peek();
            if (c == '"' || c == '\'')
            {
                // Move past opening quote
                Move();
                // Parse quoted value
                start = _pos;
                _pos = _html.IndexOfAny(new char[] { c, '\r', '\n' }, start);
                NormalizePosition();
                end = _pos;
                // Move past closing quote
                if (Peek() == c)
                    Move();
            }
            else
            {
                // Parse unquoted value
                start = _pos;
                while (!EOF && !Char.IsWhiteSpace(c) && c != '>')
                {
                    Move();
                    c = Peek();
                }
                end = _pos;
            }
            return _html.Substring(start, end - start);
        }

        /// <summary>
        /// Moves to the start of the next tag
        /// </summary>
        /// <returns>True if another tag was found, false otherwise</returns>

        protected bool MoveToNextTag()
        {
            _pos = _html.IndexOf('<', _pos);
            NormalizePosition();
            return !EOF;
        }

        /// <summary>
        /// Returns the character at the current position, or a null
        /// character if we're at the end of the document
        /// </summary>
        /// <returns>The character at the current position</returns>
        public char Peek()
        {
            return Peek(0);
        }

        /// <summary>
        /// Returns the character at the specified number of characters
        /// beyond the current position, or a null character if the
        /// specified position is at the end of the document
        /// </summary>
        /// <param name="ahead">The number of characters beyond the
        /// current position</param>
        /// <returns>The character at the specified position</returns>
        public char Peek(int ahead)
        {
            int pos = (_pos + ahead);
            if (pos < _html.Length)
                return _html[pos];
            return (char)0;
        }

        /// <summary>
        /// Moves the current position ahead one character
        /// </summary>
        protected void Move()
        {
            Move(1);
        }

        /// <summary>
        /// Moves the current position ahead the specified number of characters
        /// </summary>
        /// <param name="ahead">The number of characters to move ahead</param>
        protected void Move(int ahead)
        {
            _pos = Math.Min(_pos + ahead, _html.Length);
        }

        /// <summary>
        /// Moves the current position to the next character that is
        // not whitespace
        /// </summary>
        protected void SkipWhitespace()
        {
            while (!EOF && Char.IsWhiteSpace(Peek()))
                Move();
        }

        /// <summary>
        /// Normalizes the current position. This is primarily for handling
        /// conditions where IndexOf(), etc. return negative values when
        /// the item being sought was not found
        /// </summary>
        protected void NormalizePosition()
        {
            if (_pos < 0)
                _pos = _html.Length;
        }
    }
}