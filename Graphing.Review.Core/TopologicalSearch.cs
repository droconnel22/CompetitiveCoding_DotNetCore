namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TopologicalSearch<TValue>
        where TValue : IComparable<TValue>
    {
        private static IDictionary<INode<TValue>, int> inDegreeDict;      

        public static void Search(IGraph<TValue> graph, TValue origin)
        {
            var originEdge = graph.FindEdge(origin);
            if (originEdge == null) return;


            Queue<INode<TValue>> queue = new Queue<INode<TValue>>();

            inDegreeDict = new Dictionary<INode<TValue>, int>();

            foreach (INode<TValue> edge in graph.GetEdges())
            {
                int indegree = graph.GetInDegree(edge.GetValue());
                inDegreeDict.Add(edge, indegree);
                if (indegree == 0)
                {
                    queue.Enqueue(edge);
                }
            }

            IList<INode<TValue>> searched = new List<INode<TValue>>();
            while(queue.Any())
            {
                var currentEdge = queue.Dequeue();
                searched.Add(currentEdge);
                foreach (var adjacentEdge in currentEdge.GetAdjacentEdges())
                {
                    inDegreeDict[adjacentEdge]--;
                    if(inDegreeDict[adjacentEdge] == 0)
                    {
                        queue.Enqueue(adjacentEdge);
                    }
                }
            }

            if(searched.Count != graph.GetNumberOfVerticies())
            {
                throw new Exception("A cycle exists in the graph!");
            }

            foreach (var edge in searched)
            {
                Console.Write(edge == searched.Last() ? " {0}" : "{0} --> ", edge.GetValue());
            }
            Console.WriteLine();
        }
    }
}
