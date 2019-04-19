
namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TopologicalSearch2<TValue>
    {
        private static IDictionary<INode<TValue>, int> inDegreeDict;

        public static void Search(IGraph<TValue> graph, TValue origin)
        {
            if (graph is null) throw new ArgumentNullException(nameof(graph));

            var originEdge = graph.FindEdge(origin);
            if (originEdge is null) throw new ArgumentNullException(nameof(origin));

            inDegreeDict = new Dictionary<INode<TValue>, int>();

            var queue = new Queue<INode<TValue>>();

            foreach (var edge in graph.GetEdges())
            {
                int inDegree = graph.GetInDegree(edge.GetValue());
                inDegreeDict[edge] = inDegree;
                if(inDegree == 0) {
                    queue.Enqueue(edge);                
                }
            }

            // initalize
            var path = new List<INode<TValue>>();

            while(queue.Any())
            {
                var currentEdge = queue.Dequeue();
                path.Add(currentEdge);

                foreach (var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    inDegreeDict[adjacentEdge]--;
                    if(inDegreeDict[adjacentEdge] == 0)
                    {
                        queue.Enqueue(adjacentEdge);
                    }
                }
            }

            if(path.Count != graph.GetNumberOfVerticies())
            {
                Console.WriteLine("No path exists");
            }
            else
            {
                foreach (var edge in path)
                {
                    Console.Write(edge == path.Last() ? "{0} \n" : "{0} --> ", edge.GetValue());
                }
            }
        }
    }
}
