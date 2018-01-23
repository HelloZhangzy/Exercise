using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备记录模式
{
    public class Document
    {
        public string Content { get; set; }

        public DocumentVersion CreateMemento()
        {
            return new DocumentVersion(Content);
        }

        public void SetMemento(DocumentVersion documentVersion)
        {
            Content = documentVersion.Content;
        }
    }

    public class DocumentVersion
    {
        public string Content { get; set; }

        public DocumentVersion(string content)
        {
            Content = content;
        }
    }
    public class Caretaker
    {
        private Dictionary<int, DocumentVersion> _mementoList = new Dictionary<int, DocumentVersion>();

        public DocumentVersion GetDocumentVersion(int versionID)
        {
            return _mementoList[versionID];
        }

        public void AddDocumentVersion(DocumentVersion documentVersion)
        {
            int maxVersionID = _mementoList.Keys.Count == 0 ? 0 : _mementoList.Keys.Max();
            _mementoList.Add(maxVersionID + 1, documentVersion);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
