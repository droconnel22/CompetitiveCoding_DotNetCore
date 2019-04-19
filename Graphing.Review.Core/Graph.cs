
namespace Graphing.Review.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Graph<TValue> : IGraph<TValue>
        where TValue : IComparable<TValue>
    {
        private readonly bool isDirected;

        private readonly int numberOfVerticies;

        private IList<INode<TValue>> edges;

        public Graph(int numberOfVerticies, bool isDirected = false)
        {
            if(numberOfVerticies <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of verticies must be positive");
            }

            this.numberOfVerticies = numberOfVerticies;
            this.isDirected = isDirected;
            this.edges = new List<INode<TValue>>();
        }

        public void AddEdges(TValue value1, TValue value2, int weight = 0)
        {
            isValidValue(value1);
            isValidValue(value2);
            isValidWeight(weight);

            var firstNode = this.FindEdge(value1);
            if(firstNode == null)
            {
                firstNode = new Node<TValue>(value1);
                this.edges.Add(firstNode);
            }

            var secondNode = this.FindEdge(value2);
            if(secondNode == null)
            {
                secondNode = new Node<TValue>(value2);
                this.edges.Add(secondNode);
            }

            firstNode.AddEdge(secondNode);
            if(!this.isDirected)
            {
                secondNode.AddEdge(firstNode);
            }
        }

        public void Display()
        {
            Console.WriteLine();
            foreach (var edge in this.edges)
            {
                foreach (var adjacentEdge in edge.GetAdjacentEdges())
                {
                    Console.WriteLine(this.isDirected ? "{0} --> {1}" : "{0} --- {1}", edge.GetValue(), adjacentEdge.GetValue());
                }
            }

            Console.WriteLine();
        }

        public INode<TValue> FindEdge(TValue value)
        {
            isValidValue(value);
            return this.edges.FirstOrDefault(e => e.GetValue().CompareTo(value) == 0);
        }

        public IEnumerable<INode<TValue>> GetEdges() => this.edges;

        public int GetInDegree(TValue value)
        {
            isValidValue(value);
            int indgree = 0;
            var sourceEdge = this.FindEdge(value);
            if (sourceEdge == null) return indgree;
            foreach (var edge in this.edges)
            {
                indgree += edge.GetInDegrees(sourceEdge);
            }
            return indgree;
        }

        public int GetNumberOfVerticies() => this.numberOfVerticies;

        public bool IsDirected() => this.isDirected;

        private void isValidValue(TValue value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
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
