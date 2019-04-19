namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UnweightedShortestPath<TValue>
        where TValue : IComparable<TValue>
    {
        private static IDictionary<INode<TValue>, Tuple<int, INode<TValue>>> distanceTable;

        private static void BuildDistanceTable(IGraph<TValue> graph, INode<TValue> originEdge)
        {
            distanceTable = new Dictionary<INode<TValue>, Tuple<int, INode<TValue>>>();
            // initialize dictionary
            foreach (var edge in graph.GetEdges())
            {
                distanceTable.Add(edge, Tuple.Create<int, INode<TValue>>(-1, null));
            }

            // initialize start
            distanceTable[originEdge] = Tuple.Create(0, originEdge);

            Queue<INode<TValue>> queue = new Queue<INode<TValue>>();

            queue.Enqueue(originEdge);

            while (queue.Any())
            {
                var currentEdge = queue.Dequeue();
                var currentDistance = distanceTable[currentEdge].Item1;
                foreach (var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    if (distanceTable[adjacentEdge].Item1 == -1)
                    {
                        distanceTable[adjacentEdge] = Tuple.Create(currentDistance + 1, currentEdge);
                        if (adjacentEdge.GetAdjacentEdges().Any())
                        {
                            queue.Enqueue(adjacentEdge);
                        }
                    }
                }
            }
        }

        public static void ShortestPath(IGraph<TValue> graph, TValue origin, TValue destination)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            var originEdge = graph.FindEdge(origin);
            var destinationEdge = graph.FindEdge(destination);
            if (originEdge == null || destinationEdge == null) throw new ArgumentNullException();

            BuildDistanceTable(graph, originEdge);

            List<INode<TValue>> path = new List<INode<TValue>>();          

            var currentEdge = destinationEdge;

            while(currentEdge !=  null && currentEdge != originEdge)
            {
                path.Add(currentEdge);
                currentEdge = distanceTable[currentEdge].Item2;
            }

            if(currentEdge == null)
            {
                Console.WriteLine($"There is no path from {origin} to {destination}");
            } 
            else
            {
                path.Add(originEdge);
                path.Reverse();

                foreach (var edge in path)
                {
                    Console.Write(edge == path.Last() ? "{0}\n" : "{0} -->  ", edge.GetValue());
                }
                Console.WriteLine();
            }
        }
    }
}
