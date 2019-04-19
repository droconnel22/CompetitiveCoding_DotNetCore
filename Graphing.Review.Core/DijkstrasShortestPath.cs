namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DijkstrasShortestPath<TValue>
        where TValue : IComparable<TValue>
    {
        private static IDictionary<INode<TValue>, Tuple<int, INode<TValue>>> distanceTable;

        private static PriorityQueue<INode<TValue>> priorityQueue;

        private static void BuildDistanceTable(IGraph<TValue> graph, INode<TValue> originEdge)
        {
            distanceTable = new Dictionary<INode<TValue>, Tuple<int, INode<TValue>>>();

            // initialize distance table
            foreach (var edge in graph.GetEdges())
            {
                distanceTable[edge] = new Tuple<int, INode<TValue>>(-1, null);
            }

            // initalize source
            distanceTable[originEdge] = new Tuple<int, INode<TValue>>(0, originEdge);

            priorityQueue = new PriorityQueue<INode<TValue>>();

            priorityQueue.Enqueue(originEdge, 0);

            while(priorityQueue.Any())
            {
                var currentEdge = priorityQueue.DequeueMin();

                // Distance of the current Edge from the source.
                var currentDistance = distanceTable[currentEdge].Item1;

                foreach(var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    // Distance of the current Edge from the source + the cost of distnace to the adjacent node.                   
                    var totalDistance = currentDistance + currentEdge.GetWeight(adjacentEdge);

                    // The last recorded distance from the neighbor
                    var lastRecordedDistance = distanceTable[adjacentEdge].Item1;

                    if (lastRecordedDistance == -1 || totalDistance < lastRecordedDistance)
                    {
                        distanceTable[adjacentEdge] = new Tuple<int, INode<TValue>>(totalDistance, currentEdge);
                        priorityQueue.Enqueue(adjacentEdge, totalDistance);
                    }
                }
            }
        }

        public static void DijkstrasPath(IGraph<TValue> graph, TValue origin, TValue destination)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            var originEdge = graph.FindEdge(origin);
            var destinationEdge = graph.FindEdge(destination);
            if (originEdge == null || destinationEdge == null) throw new ArgumentNullException();

            BuildDistanceTable(graph, originEdge);

            List<INode<TValue>> path = new List<INode<TValue>>();

            var currentEdge = destinationEdge;

            while (currentEdge != null && currentEdge != originEdge)
            {
                path.Add(currentEdge);
                currentEdge = distanceTable[currentEdge].Item2;
            }

            if (currentEdge == null)
            {
                Console.WriteLine($"There is no weighted path from {origin} to {destination}");
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
