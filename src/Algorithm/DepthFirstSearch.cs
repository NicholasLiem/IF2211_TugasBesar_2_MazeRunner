using System.Collections.Generic;
using System.Linq;

namespace src {
    public partial class Algorithms {
        public List<Cell> DepthFirstSearch(Graph graph) {

            Stack<Cell> paths = new Stack<Cell>();
            Stack<Cell> availableNodes = new Stack<Cell>();
            HashSet<Cell> visitedNodes = new HashSet<Cell>();
            Stack<Cell> candidatePath = new Stack<Cell>();

            availableNodes.Push(graph.EntryVertex);

            while (availableNodes.Count > 0) {
                Cell currentCell = availableNodes.Pop();

                visitedNodes.Add(currentCell);
                candidatePath.Push(currentCell);
                paths.Push(currentCell);

                currentCell.addVisitedCount();
                
                if (candidatePathHasAllTreasures(candidatePath.Reverse().ToList(), Map.treasureCells)) {
                    return candidatePath.Reverse().ToList();
                }

                bool isDeadEnd = true;
                List<Cell> edges = graph.GetCellNeighbors(currentCell);
                foreach (Cell cell in edges) {
                    if (!visitedNodes.Contains(cell) && !availableNodes.Contains(cell)) {
                        availableNodes.Push(cell);
                        isDeadEnd = false;
                    }
                }

                while(isDeadEnd && paths.Count > 0){
                    Cell lastCell = paths.Pop();
                    candidatePath.Push(lastCell);
                    lastCell.addVisitedCount();
                    List<Cell> lastCellEdges = graph.GetCellNeighbors(lastCell);
                    foreach (Cell cell in lastCellEdges) {
                        if (!paths.Contains(cell) && !visitedNodes.Contains(cell)) {
                            isDeadEnd = false;
                        }
                    }
                }
            }

            return new List<Cell>();
        }

        public void DFSPathPrint(List<Cell> pathToTreasure) {
            System.Console.WriteLine("Path: ");
            foreach (Cell cell in pathToTreasure) {
                cell.printCell();
            }
        }

        public Boolean candidatePathHasAllTreasures(List<Cell> candidatePaths, HashSet<Cell> treasures) {
            int treasureCount = 0;
            foreach (Cell cell in new List<Cell>(candidatePaths.Distinct())) {
                if (cell.getType() == 9) {
                    treasureCount++;
                }
            }
            return treasureCount == treasures.Count;
        }

    }
}
