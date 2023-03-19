using System;
using src;

namespace BFStest
{
    public class BFStest
    {
        public static void Main(string[] args)
        {
            Cell c1 = new Cell(1, 1, 0);

            Cell c2 = new Cell(2, 2, 9);

            Cell c3 = new Cell(3, 3, 1);

            // Initialize graph
            Graph graph = new Graph(c1);
            graph.AddEdge(c1, c2);
            graph.AddEdge(c1, c3);

            var algorithm = new Algorithms();
            List<Cell> solution = algorithm.Brea(graph);

            Console.WriteLine("solution space : {0}", solution);

            foreach (var vertex in solution)
            {
                Console.WriteLine("shortest path to {0,2}: {1}", vertex, string.Join(", ", shortestPath(vertex)));
            }
        }
    }
}