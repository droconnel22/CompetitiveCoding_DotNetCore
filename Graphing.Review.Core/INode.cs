namespace Graphing.Review.Core
{

    using System;
    using System.Collections.Generic;

    public interface INode<TValue>
    {
        IEnumerable<INode<TValue>> GetAdjacentEdges();

        TValue GetValue();

        int GetInDegrees(INode<TValue> edge);

        int GetWeight(INode<TValue> edge);

        void AddEdge(INode<TValue> edge, int weight = 0);
    }
}
