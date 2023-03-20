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
            var solutions = algorithms.BreathFirstSearch(mapGraph);
            var shortestPath = algorithms.ShortestPath(mapGraph, solutions);

            Console.Write("path : ");
            foreach (var cell in shortestPath)
            {
                Console.Write("[{1,0}, {1,0}], ", cell.getRow(), cell.getCol());
            }
            Console.WriteLine();
            map.PrintTreasureCount();
        }
    }
}