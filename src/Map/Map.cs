using System;
namespace src{
    public class Map{
        FileManager fileReader = new FileManager();
        private Cell[,]? cells;
        public static int treasureCount;
        private Graph graph;
        private int size;
        public Map(){    
            treasureCount = 0;
            this.cells = new Cell[0,0];
            fileReader.ReadFile(ref cells);
            this.size = cells.GetLength(0);
            this.graph = Utils.registerVertex(ref cells); 
        }

        public Graph GetGraph(){
            return this.graph;
        }

        public Cell[,] GetCells(){
            return this.cells ?? new Cell[0,0];
        }

        public int GetSize(){
            return this.size;
        }

        public void PrintTreasureCount(){
            Console.WriteLine("Treasure Count: " + treasureCount);
        }

        public void ResetTreasureCount(){
            treasureCount = 0;
        }
    }
}