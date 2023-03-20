using System;

namespace src{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileManager fileReader = new FileManager();
            Algorithms algorithms = new Algorithms();
            Map map = new Map();
            Graph mapGraph = map.GetGraph();
            List<List<Cell>> pathToTreasure = algorithms.DepthFirstSearch(mapGraph);
            algorithms.DFSPathPrint(pathToTreasure);
        }
    }

}