
namespace Compression.Huffman.Console
{
    using System;
    using Compression.Huffman.Core.HuffmanTree;

    // loss less data compression algorithm
    class Program
    {
        static void Main(string[] args)
        {
            IHuffmanTree<char, int> huffmanTree = new HuffmanTree<char, int>();
            huffmanTree
                .BuildHeap(MapBuilder.GetExample())
                .BuildTree()
                .PrintCodes(huffmanTree.GetRoot())
                .AddSpace()
                .BuildHeap(MapBuilder.GetExample())
                .BuildTree()
                .PrintCodes(huffmanTree.GetRoot());
        }
    }
}
