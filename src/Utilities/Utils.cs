using System;

namespace src{
    public partial class Utils{
        public void PrintMap(ref Cell[,] map){
            Console.WriteLine("Map: ");
            for(int i = 0; i < map.GetLength(0); i++){
                for(int j = 0; j < map.GetLength(1); j++){
                    map[i,j].printCell();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Cell findEntryPoint(ref Cell[,] map){
            for(int i = 0; i < map.GetLength(0); i++){
                for(int j = 0; j < map.GetLength(1); j++){
                    if(map[i,j].getType() == 0){
                        return map[i,j];
                    }
                }
            }
            return null;
        }

        public Graph registerVertex(ref Cell[,] matrixCell){
            if (matrixCell == null)
                throw new MatrixCellEmptyException();

            Graph graph = new Graph(findEntryPoint(ref matrixCell));
            
            int numRows = matrixCell.GetLength(0);
            int numCols = matrixCell.GetLength(1);

            for(int i = 0; i < numRows; i++){
                for(int j = 0; j < numCols; j++){
                    if(matrixCell[i,j].getType() != 3){

                        graph.AddVertex(matrixCell[i,j]);
                        
                        // Add edge to bottom cell if it exists and is not a non-path cell
                        if(i < numRows-1 && matrixCell[i+1,j].getType() != 3){
                            graph.AddEdge(matrixCell[i,j], matrixCell[i+1,j]);
                        }
                        
                        // Add edge to above cell if it exists and is not a non-path cell
                        if(i > 0 && matrixCell[i-1,j].getType() != 3){
                            graph.AddEdge(matrixCell[i,j], matrixCell[i-1,j]);
                        }
                        
                        // Add edge to left cell if it exists and is not a non-path cell
                        if(j > 0 && matrixCell[i,j-1].getType() != 3){
                            graph.AddEdge(matrixCell[i,j], matrixCell[i,j-1]);
                        }
                        
                        // Add edge to right cell if it exists and is not a non-path cell
                        if(j < numCols-1 && matrixCell[i,j+1].getType() != 3){
                            graph.AddEdge(matrixCell[i,j], matrixCell[i,j+1]);
                        }
                    }
                }
            }
            graph.deleteDuplicateAdjacencyValueList();
            graph.printAdjacencyList();
            return graph;
        }
    }
}