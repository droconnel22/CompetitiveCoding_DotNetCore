namespace Compression.HuffmanCoding.Console.Nodes
{
    using System;

    public class Node<T> : INode<T>
        where T : IComparable<T>
    {
        public T Value { get; }
        public int Frequency { get; }

        public Node<T> Right { get; private set; }

        public Node<T> Left { get; private set; }

        public Node(T value, int frequency)
        {
            if (value == null) new ArgumentNullException(nameof(value));
            this.Value = value;
            this.Frequency = frequency;
        }

        public void AddNode(T value, int frequency)
        {
            if (this.Value.CompareTo(value) == 0) return;
            if(this.Value.CompareTo(value) < 0)
            {
                if(this.Left == null)
                {
                    this.Left = new Node<T>(value, frequency);
                }
                else
                {
                    this.Left.AddNode(value, frequency);
                }
            }
            else
            {
                if(this.Right == null)
                {
                    this.Right = new Node<T>(value, frequency);
                }
                else
                {
                    this.Right.AddNode(value, frequency);
                }
            }
        }
    }
}
