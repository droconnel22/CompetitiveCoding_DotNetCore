namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PriorityQueue2<TKey, TWeight>
        where TWeight : struct, IComparable<TWeight>
        
    {
        private readonly IDictionary<TKey, TWeight> queue;

        public PriorityQueue2()
        {
            queue = new Dictionary<TKey, TWeight>();
        }

        public void Enqueue(TKey key, TWeight weight)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));          

            if(!queue.ContainsKey(key))
            {
                queue.Add(key, weight);
            }
        }

        public TKey Peek()
        {
            if (!this.queue.Any()) return default(TKey);
            var peekKVP = this.queue.OrderBy(kvp => kvp.Value).First();
            return peekKVP.Key;
        }

        public TKey DequeueMin()
        {
            var peekKey = this.Peek();
            this.queue.Remove(peekKey);
            return peekKey;
        }

        public bool Any() => this.queue.Keys.Any();
    }
}
