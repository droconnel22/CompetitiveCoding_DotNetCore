namespace Compression.HuffmanCoding.Console
{
    using System;
    using System.Collections.Generic;

    class MainClass
    {
        public static void Main(string[] args)
        {
            var sequenceDist = new Dictionary<char, int>()
            {
                {'a', 5},
                {'b', 9},
                {'c', 12},
                {'d', 13},
                {'e', 16},
                {'f', 45}
            };

            var hoffmanTree = new HoffmanTree();
            hoffmanTree.BuildTree(sequenceDist);
            var encoding = hoffmanTree.DecodeTree();

            Console.ReadLine();
        }
    }


    public class HoffmanNode
    {
        public char Value { get; }
        public int Frequency { get; }
        public HoffmanNode Right { get; set; }
        public HoffmanNode Left { get; set; }

        public HoffmanNode(char value, int frequency)
        {
            this.Frequency = frequency;
            this.Value = value;
            this.Right = null;
            this.Left = null;
        }

        public HoffmanNode(int frequency, HoffmanNode left, HoffmanNode right)
        {
            this.Value = default(char);
            this.Frequency = frequency;
            this.Right = right;
            this.Left = left;
        }
    }

    public class HoffmanTree
    {
        private HoffmanNode root;

        public HoffmanTree()
        {
            root = null;
        }
    }
}
