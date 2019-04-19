
namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node<TValue> : INode<TValue>
        where TValue : IComparable<TValue>
    {

        private readonly TValue value;

        private IDictionary<INode<TValue>, int> edgeDict;


        public Node(TValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(TValue));
            this.value = value;
            this.edgeDict = new Dictionary<INode<TValue>, int>();
        }

        public void AddEdge(INode<TValue> edge, int weight = 0)
        {
            isValidEdge(edge);
            isValidWeight(weight);

            if(!this.edgeDict.ContainsKey(edge))
            {
                this.edgeDict.Add(edge, weight);
            }
        }

        public IEnumerable<INode<TValue>> GetAdjacentEdges() => this.edgeDict.Keys.ToList();

        public int GetInDegrees(INode<TValue> edge)
        {
            isValidEdge(edge);
            return this.edgeDict.Keys.Count(kvp => kvp.GetValue().CompareTo(edge.GetValue()) == 0);
        }

        public TValue GetValue() => this.value;

        public int GetWeight(INode<TValue> edge)
        {
            isValidEdge(edge);
            if (!edgeDict.ContainsKey(edge)) return -1;
            return edgeDict[edge];
        }

        private void isValidEdge(INode<TValue> edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge));
            }        
        }

        private void isValidWeight(int weight)
        {
            if(weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }
        }
    }
}
