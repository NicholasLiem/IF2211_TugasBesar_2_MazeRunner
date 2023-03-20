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

            List<Cell> solutions = new List<Cell>();
            var start = mapGraph.EntryVertex;
            while (algorithms.TreasureFound < map.TreasureCount)
            {
                foreach (var cell in algorithms.BreathFirstSearch(mapGraph, start))
                {
                    solutions.Add(cell);
                }
                start = solutions.ElementAt(solutions.Count - 1);
            }

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