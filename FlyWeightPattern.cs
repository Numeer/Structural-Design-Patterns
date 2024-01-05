/*The Flyweight uses sharing to support large numbers of 
objects efficiently. Modern web browsers use this technique 
to prevent loading same images twice. When browser loads a web page, 
it traverse through all images on that page. Browser loads all new 
images from Internet and places them the internal cache. For already 
loaded images, a flyweight object is created, which has some unique data 
like position within the page, but everything else is referenced to the cached one.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{

    interface ICharacter
    {
        void Display(string fontFamily, int fontSize, string text);
    }

    // Concrete Flyweight representing a character
    class Character : ICharacter
    {
        private char symbol;

        public Character(char symbol)
        {
            this.symbol = symbol;
        }

        public void Display(string fontFamily, int fontSize, string text)
        {
            Console.WriteLine($"Character '{symbol}' with Font Family: {fontFamily}, Font Size: {fontSize}, Text: '{text}'");
        }
    }

    // Flyweight Factory
    class CharacterFactory
    {
        private Dictionary<char, ICharacter> characters = new Dictionary<char, ICharacter>();

        public ICharacter GetCharacter(char key)
        {
            if (!characters.ContainsKey(key))
            {
                characters[key] = new Character(key);
            }
            return characters[key];
        }
    }

    class TextFormatter
    {
        private CharacterFactory factory = new CharacterFactory();

        public void FormatText(string fontFamily, int fontSize, string text)
        {
            foreach (char c in text)
            {
                ICharacter character = factory.GetCharacter(c);
                character.Display(fontFamily, fontSize, text);
            }
        }
    }

    // Flyweight interface
    interface ITreeElement
    {
        void Display(int x, int y);
    }

    // Concrete Flyweight representing a tree node
    class TreeNode : ITreeElement
    {
        private string name;

        public TreeNode(string name)
        {
            this.name = name;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Node: {name}, Position: ({x}, {y})");
        }
    }

    // Flyweight Factory
    class TreeElementFactory
    {
        private Dictionary<string, ITreeElement> treeElements = new Dictionary<string, ITreeElement>();

        public ITreeElement GetTreeElement(string key)
        {
            if (!treeElements.ContainsKey(key))
            {
                treeElements[key] = new TreeNode(key);
            }
            return treeElements[key];
        }
    }

    class Tree
    {
        private TreeElementFactory factory = new TreeElementFactory();
        private List<Tuple<int, int, string>> treeNodes = new List<Tuple<int, int, string>>();

        public void AddNode(int x, int y, string name)
        {
            treeNodes.Add(new Tuple<int, int, string>(x, y, name));
        }

        public void DisplayTree()
        {
            foreach (var node in treeNodes)
            {
                ITreeElement treeElement = factory.GetTreeElement(node.Item3);
                treeElement.Display(node.Item1, node.Item2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");
            TextFormatter formatter = new TextFormatter();

            // Formatting text using Flyweight pattern
            formatter.FormatText("Arial", 12, "Hello, Flyweight Pattern!");

            Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
            Tree tree = new Tree();

            // Adding nodes to the tree
            tree.AddNode(0, 0, "Node A");
            tree.AddNode(10, 5, "Node B");
            tree.AddNode(20, 10, "Node C");
            tree.AddNode(30, 15, "Node A");

            // Displaying the tree structure using Flyweight pattern
            tree.DisplayTree();

        }
    }

}

