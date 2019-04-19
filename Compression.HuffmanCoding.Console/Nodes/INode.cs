using System;
namespace Compression.HuffmanCoding.Console
{
    public interface INode<T>
        where T : IComparable<T>
    {
        void AddNode(T value, int frequency);
    }
}
