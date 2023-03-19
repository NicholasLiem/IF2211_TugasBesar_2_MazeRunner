using System;

namespace src{
    public partial class Algorithms{
        public void DepthFirstSearch(ref Graph graph){
            Stack<Cell> availableNodes = new Stack<Cell>();
            Stack<Cell> visitedNodes = new Stack<Cell>();
            availableNodes.Push(graph.EntryVertex);

            while(availableNodes.Count() > 0){
                Cell currentCell = availableNodes.Pop();
                currentCell.printCell();
                visitedNodes.Push(currentCell);
                List<Cell> edges = graph.GetCellNeighbors(currentCell);
                foreach(Cell cell in edges){
                    if(!visitedNodes.Contains(cell) && !availableNodes.Contains(cell)){
                        availableNodes.Push(cell);
                    }
                }
            }
        }
    }
}