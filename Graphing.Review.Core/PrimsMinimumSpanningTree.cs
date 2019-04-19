namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Prims
    // -> only connected graphs 
    // -> greedy algorithm to find the MST for an unweighted undirected graph
    public class MinimumSpanningTree<TValue>
        where TValue : IComparable<TValue>
    {
        // Prims
        // 1. Pick Random Node
        // 2. Find the lowest weight edge out of that node adjacent neighbors
        // 3. Pick  the lowest weight edge connecting to an UNVISITED edge
        // 4. Add edge to the result
        // 5. Once again, find lowest weight edge out of result set
        // 6. if visited it is not a candidate edge
        // 7. Sum weights of edges in results in set -> global optimum, but finds local
        // distnace table but with edge weight as the distance 

        private static IDictionary<INode<TValue>, Tuple<int, INode<TValue>>> distanceTable;

        private static void BuildDistanceTable(IGraph<TValue> graph, INode<TValue> randomEdge)
        {

            // create distance table
            distanceTable = new Dictionary<INode<TValue>, Tuple<int, INode<TValue>>>();

            // populate distance table
            foreach (var edge in graph.GetEdges())
            {
                distanceTable[edge] = new Tuple<int, INode<TValue>>(-1, null);
            }

            // initalize distance table
            distanceTable[randomEdge] = new Tuple<int, INode<TValue>>(0, randomEdge);

            // create traverse collections
            var searched = new List<INode<TValue>>();
            var priorityQueue = new PriorityQueue2<INode<TValue>, int>();

            // initalize pq
            priorityQueue.Enqueue(randomEdge, 0);

            while(priorityQueue.Any())
            {
                // Dequeue min edge weight
                var currentEdge = priorityQueue.DequeueMin();
                var currentEdgCost = distanceTable[currentEdge].Item1;

                // add to existing 
                searched.Add(currentEdge);

                // check if visited
                if (searched.Contains(currentEdge)) continue;


                if(currentEdge != randomEdge)
                {
                    // stuff
                }

                // Lowest weighted Edge connecting an unvisited node.
                foreach (var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    var edgeCost = currentEdge.GetWeight(adjacentEdge);
                    var recordedCost = distanceTable[adjacentEdge].Item1;
                    var cumlativeEdgeCost = currentEdgCost + edgeCost;

                    if(recordedCost == -1 || cumlativeEdgeCost < recordedCost)
                    {
                        distanceTable[adjacentEdge] = new Tuple<int, INode<TValue>>(cumlativeEdgeCost, currentEdge);
                        priorityQueue.Enqueue(adjacentEdge, cumlativeEdgeCost);
                    }
                }
            }
        }


        public static void PrimsMST(IGraph<TValue> graph, TValue origin, TValue destination)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (graph.IsDirected()) throw new Exception("Prims only works for weighted undirected graphs!");
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
