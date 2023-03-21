using System;

namespace src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileManager fileReader = new FileManager();
            Algorithms algorithms = new Algorithms();
            Map map = new Map();
            Graph mapGraph = map.GetGraph();
            List<List<Cell>> paths = algorithms.DepthFirstSearch(mapGraph);
            algorithms.DFSPathPrint(paths);

            // tsp toggleable
            List<Cell> solutions = algorithms.BreadthFirstSearch(mapGraph, mapGraph.EntryVertex, false, 9);

            Console.WriteLine("result path  :");
            foreach (var cell in solutions)
            {
                cell.printCell();
            }
            Console.WriteLine();
            map.PrintTreasureCount();
        }
    }
}