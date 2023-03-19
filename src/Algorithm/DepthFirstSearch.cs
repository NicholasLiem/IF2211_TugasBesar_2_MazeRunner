using System;

namespace src{
    public partial class Algorithms{
        public void DepthFirstSearch(ref Graph graph){
            Stack<Cell> availableNodes = new Stack<Cell>();
            Stack<Cell> visitedNodes = new Stack<Cell>();
            availableNodes.Push(graph.EntryVertex);

            while(visitedNodes.Count > 0){
                Cell currentCell = availableNodes.Pop();
                currentCell.addVisitedCount();
                visitedNodes.Push(currentCell);

                List<Cell> neighbors = graph.GetCellNeighbors(currentCell);
                foreach(Cell neighbor in neighbors){
                    if(!visitedNodes.Contains(neighbor)){
                        visitedNodes.Push(neighbor);
                    }
                    
                }
            }
        }
    }
}