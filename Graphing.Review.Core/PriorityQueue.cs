namespace Graphing.Review.Core
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PriorityQueue<TItem>
    {
        private readonly IDictionary<TItem, int> queue;

        public PriorityQueue()
        {
            this.queue = new Dictionary<TItem, int>();
        }

        public void Enqueue(TItem item, int weight)
        {
            this.queue.Add(item, weight);
        }

        public bool Any() => this.queue.Keys.Any();

        public TItem PeekMin()
        {
            if (!queue.Any()) return default(TItem);

            var item = queue.OrderBy(kvp => kvp.Value).FirstOrDefault();
            return item.Key;
        }

        public TItem DequeueMin()
        {
            var item = this.PeekMin();
            this.queue.Remove(item);
            return item;
        }
    }
}
