using System;

namespace src{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cell [,] mapMatrix = new Cell[0,0];
            FileManager fileReader = new FileManager();
            Utils Util = new Utils();
            fileReader.ShowFilesInFolder();
            fileReader.ReadFile(ref mapMatrix);
            Util.PrintMap(ref mapMatrix);
        }
    }

}