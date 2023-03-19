using System;

namespace src{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileManager fileReader = new FileManager();
            Utils Util = new Utils();
            Algorithms algorithms = new Algorithms();
            Cell[,] cells = new Cell[0,0];
            fileReader.ShowFilesInFolder();
            fileReader.ReadFile(ref cells);
            Graph graph = Util.registerVertex(ref cells);
            // algorithms.DepthFirstSearch(ref graph);


        }
    }

}