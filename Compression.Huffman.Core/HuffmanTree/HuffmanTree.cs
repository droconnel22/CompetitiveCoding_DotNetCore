using System;
using System.Collections.Generic;
using Compression.Huffman.Core.Common;

namespace Compression.Huffman.Core.HuffmanTree
{
    public class HuffmanTree<TValue, TWeight> : IHuffmanTree<TValue, TWeight>
        where TWeight : struct
        where TValue : IComparable<TValue>
      
    {
        private INode<TValue, TWeight> root;

        private readonly PriorityQueue<INode<TValue, TWeight>, TWeight> queue;


        public HuffmanTree()
        {
            this.root = null;
            queue = new PriorityQueue<INode<TValue, TWeight>, TWeight>();
        }

        public IHuffmanTree<TValue, TWeight> BuildHeap(IDictionary<TValue, TWeight> map)
        {
            foreach(var kvp in map)
            {
                queue.Enqueue(new BinaryNode<TValue, TWeight>(kvp.Key, kvp.Value), kvp.Value);
            }
            return this;
        }

        public IHuffmanTree<TValue, TWeight> BuildTree()
        {
           if(queue == null) throw new InvalidOperationException("Heap must be populated first!");


            while(queue.Length() > 1)
            {
                INode<TValue, TWeight> first = queue.DequeueMin();
                INode<TValue, TWeight> second = queue.DequeueMin();
                INode<TValue, TWeight> internalNode = new BinaryNode<TValue, TWeight>(default(TValue), (dynamic)(first.GetFrequency() + (dynamic)second.GetFrequency()));
                queue.Enqueue(internalNode, internalNode.GetFrequency());
            }
            return this;
        }

        public IHuffmanTree<TValue, TWeight> InOrderDisplay(INode<TValue, TWeight> currentNode)
        {
            throw new NotImplementedException();
        }

        public IHuffmanTree<TValue, TWeight> PrintCodes(INode<TValue, TWeight> currentNode, string codeWord = "")
        {
            if (currentNode == null) return this;
            PrintCodes(currentNode.GetLeft(), codeWord + "0");
            if(currentNode.GetValue().CompareTo(default(TValue)) != 0)
            {
                Console.WriteLine($"{currentNode.GetValue()}: {codeWord}");
            }
            PrintCodes(currentNode.GetRight(), codeWord + "1");
            return this;
        }
    }
}
