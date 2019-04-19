namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DijkstrasShortestPath2<TValue>
        where TValue : IComparable<TValue>
    {
        private static PriorityQueue2<INode<TValue>, int> priorityQueue;

        private static IDictionary<INode<TValue>, Tuple<int, INode<TValue>>> distanceTable;

        private static void buildDistanceTable(IGraph<TValue> graph, INode<TValue> originEdge)
        {
            // create distance table
            distanceTable = new Dictionary<INode<TValue>, Tuple<int, INode<TValue>>>();

            // populate distance table
            foreach (var edge in graph.GetEdges())
            {
                distanceTable[edge] = new Tuple<int, INode<TValue>>(-1, null);
            }

            // initalize distance table
            distanceTable[originEdge] = new Tuple<int, INode<TValue>>(0, originEdge);

            // create traverse collections
            priorityQueue = new PriorityQueue2<INode<TValue>, int>();

            // initalize priority queue
            priorityQueue.Enqueue(originEdge, 0);

            // traverse graph
            while(priorityQueue.Any())
            {
                var currentEdge = priorityQueue.DequeueMin();
                int currentDistance = distanceTable[currentEdge].Item1;

                foreach (var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    var recordedDistance = distanceTable[adjacentEdge].Item1;
                    var totalDistance = currentDistance + currentEdge.GetWeight(adjacentEdge);

                    if(recordedDistance == -1 || recordedDistance > totalDistance)
                    {
                        distanceTable[adjacentEdge] = new Tuple<int, INode<TValue>>(totalDistance, currentEdge);
                        priorityQueue.Enqueue(adjacentEdge, totalDistance);
                    }
                }
            }
        }

        public static void Search(IGraph<TValue> graph, TValue origin, TValue destination)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            var originEdge = graph.FindEdge(origin);
            var destinationEdge = graph.FindEdge(destination);
            if (originEdge == null || destinationEdge == null) throw new ArgumentNullException();

            buildDistanceTable(graph, originEdge);

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
            }
        }

    }
}
