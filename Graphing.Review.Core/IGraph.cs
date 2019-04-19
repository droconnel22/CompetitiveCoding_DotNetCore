
namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;

    public interface IGraph<TValue>
    {
        void AddEdges(TValue value1, TValue value2, int weight = 0);

        int GetInDegree(TValue value);

        void Display();

        int GetNumberOfVerticies();       

        bool IsDirected();

        IEnumerable<INode<TValue>> GetEdges();

        INode<TValue> FindEdge(TValue value);
    }
}
