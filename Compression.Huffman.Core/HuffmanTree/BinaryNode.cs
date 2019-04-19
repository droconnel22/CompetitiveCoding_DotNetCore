
namespace Compression.Huffman.Core.HuffmanTree
{

    using System;

    public class BinaryNode<TValue, TWeight> : INode<TValue, TWeight>
        where TValue : IComparable<TValue>
        where TWeight : struct
    {


        private readonly TValue value;

        private readonly TWeight weight;

        private INode<TValue, TWeight> rightNode;

        private INode<TValue, TWeight> leftNode;

        public BinaryNode(TValue value, TWeight frequency)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
           
            this.value = value;
            this.weight = frequency;
            this.leftNode = null;
            this.rightNode = null;
        }

        public BinaryNode(TWeight frequency, INode<TValue, TWeight> leftNode, INode<TValue, TWeight> rightNode)
        {

            this.value = default(TValue);
            this.weight = frequency;
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }

        public void AddValue(TValue value)
        {
            throw new NotImplementedException();
        }

        public TWeight GetFrequency() => this.weight;

        public INode<TValue, TWeight> GetLeft() => this.leftNode;

        public INode<TValue, TWeight> GetRight() => this.rightNode;

        public TValue GetValue() => this.value;
    }
}
