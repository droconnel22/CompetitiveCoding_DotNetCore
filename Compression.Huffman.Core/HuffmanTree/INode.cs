namespace Compression.Huffman.Core.HuffmanTree
{
    using System;

    public interface INode<TValue, TWeight>
    {
        INode<TValue, TWeight> GetLeft();

        INode<TValue, TWeight> GetRight();

        TValue GetValue();

        TWeight GetFrequency();

        void AddValue(TValue value);
    }
}
