using System;
namespace src{
    public class Map{
        FileManager fileReader = new FileManager();
        private Cell[,]? cells;
        public static int treasureCount;
        private Graph graph;
        private int rowSize;
        private int colSize;
        public static List<List<int>> treasureList = new List<List<int>>();
        public Map(){    
            treasureCount = 0;
            this.cells = new Cell[0,0];
            fileReader.ReadFile(ref cells);
            this.rowSize = cells.GetLength(0);
            this.colSize = cells.GetLength(1);
            this.graph = Utils.registerVertex(ref cells); 
            Utils.findTreasurePositions(ref treasureList, ref cells);
        }

        public Graph GetGraph(){
            return this.graph;
        }

        public Cell[,] GetCells(){
            return this.cells ?? new Cell[0,0];
        }

        public int GetRowSize(){
            return this.rowSize;
        }

        public int GetColSize(){
            return this.colSize;
        }

        public void PrintTreasureCount(){
            Console.WriteLine("Treasure Count: " + treasureCount);
        }

        public void ResetTreasureCount(){
            treasureCount = 0;
        }
    }
}