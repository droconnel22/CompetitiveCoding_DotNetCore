namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UnWeightedShortestPath2<TValue>
        where TValue : IComparable<TValue>
    {
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

            // initalize origin
            distanceTable[originEdge] = new Tuple<int, INode<TValue>>(0, originEdge);


            // creeate traversing collections
            var searched = new List<INode<TValue>>();
            var queue = new Queue<INode<TValue>>();

            // initalize origin
            queue.Enqueue(originEdge);

            while(queue.Any())
            {
                var currentEdge = queue.Dequeue();
                var currentDistance = distanceTable[currentEdge].Item1;
                searched.Add(currentEdge);
                foreach (var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    var neighborDistance = distanceTable[adjacentEdge].Item1;
                    if(neighborDistance == -1)
                    {
                        distanceTable[adjacentEdge] = new Tuple<int, INode<TValue>>(currentDistance + 1, currentEdge);
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
            if (graph is null) throw new ArgumentNullException(nameof(graph));

            var originEdge = graph.FindEdge(origin);
            var destinationEdge = graph.FindEdge(destination);
            if (originEdge is null || destinationEdge is null) throw new Exception($"The Origin {origin} or Destination {destination} does not exists in the graph provided.");

            buildDistanceTable(graph, originEdge);

            var path = new List<INode<TValue>>();

            var currentEdge = destinationEdge;
            while(currentEdge != null && currentEdge != originEdge)
            {
                path.Add(currentEdge);
                currentEdge = distanceTable[currentEdge].Item2;
            }

            if(currentEdge == null)
            {
                Console.WriteLine("No path exists!");
            }
            else
            {
                path.Add(originEdge);
                path.Reverse();
                foreach (var edge in path)
                {
                    Console.Write(edge == path.Last() ? "{0} \n" : "{0} -->", edge.GetValue());
                }
            }
        }
    }
}
