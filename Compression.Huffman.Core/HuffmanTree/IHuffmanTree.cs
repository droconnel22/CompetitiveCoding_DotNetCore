namespace Compression.Huffman.Core.HuffmanTree
{ 
    using System;
    using System.Collections.Generic;

    public interface IHuffmanTree<TValue, TWeight>
    {
        INode<TValue, TWeight> GetRoot();

        IHuffmanTree<TValue, TWeight> BuildHeap(IDictionary<TValue, TWeight> map);

        IHuffmanTree<TValue, TWeight> BuildTree();

        IHuffmanTree<TValue, TWeight> InOrderDisplay(INode<TValue, TWeight> currentNode);

        IHuffmanTree<TValue, TWeight> PrintCodes(INode<TValue, TWeight> currentNode, string codeWord = "");
    }
}
