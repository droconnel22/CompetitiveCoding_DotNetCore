namespace Compression.Huffman.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class PriorityQueue<TItem, TValue>
    {
        private readonly IDictionary<TItem, TValue> queue;

        public PriorityQueue()
        {
            queue = new Dictionary<TItem, TValue>();
        }

        public void Enqueue(TItem key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if(!queue.ContainsKey(key))
            {
                queue.Add(key, value);
            }
        }

        public TItem PeekMin()
        {
            if (!queue.Any()) return default(TItem);
            return queue.OrderBy(kvp => kvp.Value).First().Key;
        }
       

        public TItem DequeueMin()
        {
            var key = PeekMin();
            queue.Remove(key);
            return key;
        }

        public int Length() => queue.Keys.Count();
    }
}
