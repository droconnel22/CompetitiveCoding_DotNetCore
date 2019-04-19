
namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BreathFirstSearch<TValue>
        where TValue : IComparable<TValue>
    {
        public static void Search(IGraph<TValue> graph, TValue origin)
        {
            var startEdge = graph.FindEdge(origin);
            if (startEdge == null) return;

            Queue<INode<TValue>> queue = new Queue<INode<TValue>>();
            IList<INode<TValue>> searched = new List<INode<TValue>>();

            queue.Enqueue(startEdge);
            while (queue.Any())
            {
                var currentEdge = queue.Dequeue();
                if (searched.Contains(currentEdge)) continue;
                Console.WriteLine(currentEdge.GetValue());
                searched.Add(currentEdge);
                foreach(var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    queue.Enqueue(adjacentEdge);
                }
            }
        }
    }
}
