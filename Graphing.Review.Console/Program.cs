namespace Graphing.Review.Console
{
    using System;
    using Graphing.Review.Core;

    class Program
    {
        static void Main(string[] args)
        {         
            var graph = new Graph<int>(5, true);
            graph.AddEdges(0, 1);
            graph.AddEdges(0, 2);
            graph.AddEdges(1, 2);
            graph.AddEdges(2, 3);
            graph.AddEdges(1, 4);
            graph.Display();
            Console.WriteLine("------------------");
            BreathFirstSearch<int>.Search(graph, 0);
            Console.WriteLine("------------------");
            DepthFirstSearch<int>.Search(graph, graph.FindEdge(0));
            Console.WriteLine("------------------");

            Console.WriteLine("---- Topological Search----");
            var graph2 = new Graph<int>(9, true);
            graph2.AddEdges(0, 1);
            graph2.AddEdges(1, 2);
            graph2.AddEdges(2, 7);
            graph2.AddEdges(2, 4);
            graph2.AddEdges(2, 3);
            graph2.AddEdges(1, 5);
            graph2.AddEdges(5, 6);
            graph2.AddEdges(3, 6);
            graph2.AddEdges(3, 4);
            graph2.AddEdges(6, 8);
            Console.WriteLine("------------------");
            TopologicalSearch<int>.Search(graph2, 0);
            Console.WriteLine("------------------");

            Console.WriteLine("---- Shortest Path Undirected----");
            var pathGraph = new Graph<int>(8);
            pathGraph.AddEdges(0, 1);
            pathGraph.AddEdges(1, 2);
            pathGraph.AddEdges(1, 3);
            pathGraph.AddEdges(2, 3);
            pathGraph.AddEdges(1, 4);
            pathGraph.AddEdges(3, 5);
            pathGraph.AddEdges(5, 4);
            pathGraph.AddEdges(3, 6);
            pathGraph.AddEdges(6, 7);
            pathGraph.AddEdges(0, 7);
            UnweightedShortestPath<int>.ShortestPath(pathGraph, 0, 5);
            UnweightedShortestPath<int>.ShortestPath(pathGraph, 0, 6);
            UnweightedShortestPath<int>.ShortestPath(pathGraph, 7, 4);
            Console.WriteLine("------------------");

            Console.WriteLine("---- Shortest Path Directed----");
            var directedPathGraph = new Graph<int>(8,true);
            directedPathGraph.AddEdges(0, 1);
            directedPathGraph.AddEdges(1, 2);
            directedPathGraph.AddEdges(1, 3);
            directedPathGraph.AddEdges(2, 3);
            directedPathGraph.AddEdges(1, 4);
            directedPathGraph.AddEdges(3, 5);
            directedPathGraph.AddEdges(5, 4);
            directedPathGraph.AddEdges(3, 6);
            directedPathGraph.AddEdges(6, 7);
            directedPathGraph.AddEdges(0, 7);
            UnweightedShortestPath<int>.ShortestPath(directedPathGraph, 0, 5);
            UnweightedShortestPath<int>.ShortestPath(directedPathGraph, 0, 6);
            UnweightedShortestPath<int>.ShortestPath(directedPathGraph, 7, 4);
            Console.WriteLine("------------------");

            Console.WriteLine("---- Dijkstra ----");
            var weightedUnDirectedGraph = new Graph<int>(8,true);
            weightedUnDirectedGraph.AddEdges(0, 1, 1);
            weightedUnDirectedGraph.AddEdges(1, 2, 2);
            weightedUnDirectedGraph.AddEdges(1, 3, 6);
            weightedUnDirectedGraph.AddEdges(2, 3, 2);
            weightedUnDirectedGraph.AddEdges(1, 4, 3);
            weightedUnDirectedGraph.AddEdges(3, 5, 1);
            weightedUnDirectedGraph.AddEdges(5, 4, 5);
            weightedUnDirectedGraph.AddEdges(3, 6, 1);
            weightedUnDirectedGraph.AddEdges(6, 7, 1);
            weightedUnDirectedGraph.AddEdges(0, 7, 8);
            DijkstrasShortestPath<int>.DijkstrasPath(weightedUnDirectedGraph, 0, 5);
            DijkstrasShortestPath<int>.DijkstrasPath(weightedUnDirectedGraph, 4, 7);
            DijkstrasShortestPath<int>.DijkstrasPath(weightedUnDirectedGraph, 7, 0);
            Console.WriteLine("------------------");

            Console.ReadLine();
        }
    }
}
