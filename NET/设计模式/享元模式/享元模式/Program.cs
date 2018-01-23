using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式
{    
    public abstract class Character
    {
        public int Size { get; set; }
       // public Color Color { get; set; }

        protected char _c;

        public Character()
        {
            Size = 2;
            //Color = Color.Black;
        }

        public override string ToString()
        {
            return string.Format("Character is {0}, Size is {1}", _c, Size.ToString());
        }
    }

    public class CharacterA : Character
    {
        public CharacterA()
        {
            _c = 'A';
        }
    }

    public class CharacterB : Character
    {
        public CharacterB()
        {
            _c = 'B';
        }
    }

    public class CharacterC : Character
    {
        public CharacterC()
        {
            _c = 'C';
        }
    }

    public class CharacterD:Character
    {
        public CharacterD()
        {
            _c = 'D';
        }
    }

    public static class CharacterFactory
    {
        private static Dictionary<string, Character> _characters;

        static CharacterFactory()
        {
            _characters = new Dictionary<string, Character>();
            _characters.Add("a", new CharacterA());
            _characters.Add("b", new CharacterB());
            _characters.Add("c", new CharacterC());
        }

        public static Character GetCharacter(string c)
        {
            if (_characters.ContainsKey(c))
                return _characters[c];
            else
                return null;
        }
        public static void Add(string Name,Character cr)
        {
            _characters.Add(Name, cr);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            //核心思想：当对象已经创建，则不再反复创建，直接使用内存中共享的对象即可。
            Character character = CharacterFactory.GetCharacter("a");
            Console.WriteLine(character.ToString());
            character = CharacterFactory.GetCharacter("b");
            character.Size = 20;
            //character.Color = Color.Red;
            Console.WriteLine(character.ToString());
            character = CharacterFactory.GetCharacter("c");
            character.Size = 15;
            //character.Color = Color.Yellow;
            Console.WriteLine(character.ToString());

            character = CharacterFactory.GetCharacter("d");
            if (character==null)
            {
                CharacterFactory.Add("d", new CharacterD());
                character = CharacterFactory.GetCharacter("d");
            }
            character.Size = 30;
            Console.WriteLine(character.ToString());
            Console.ReadKey();
        }
    }
}
