
namespace Compression.Huffman.Console
{
    using System;
    using Compression.Huffman.Core.HuffmanTree;

    public static class HuffmanTreeExtensions
    {
        public static IHuffmanTree<TValue, TWeight> AddSpace<TValue, TWeight>(this IHuffmanTree<TValue, TWeight> self)
        {
            Console.WriteLine("---------");
            return self;
        }
    }
}
