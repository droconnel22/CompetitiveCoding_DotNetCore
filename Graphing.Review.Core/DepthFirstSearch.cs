namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;

    public class DepthFirstSearch<TValue>
        where TValue : IComparable<TValue>
    {
        public static void Search(IGraph<TValue> graph, INode<TValue> currentNode, IList<INode<TValue>> searched = null)
        {
            if(currentNode == null) return;
            if (searched == null) searched = new List<INode<TValue>>();
            if (searched.Contains(currentNode)) return;

            Console.WriteLine(currentNode.GetValue());
            searched.Add(currentNode);
            foreach (var adjacentEdge in currentNode.GetAdjacentEdges())
            {
                Search(graph, adjacentEdge, searched);
            }
        }
    }
}
