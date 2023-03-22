using System.Collections.Generic;
using System.Linq;

namespace src {
    public partial class Algorithms {
        public List<List<Cell>> DepthFirstSearch(Graph graph) {
            List<List<Cell>> pathToTreasure = new List<List<Cell>>();

            Stack<Cell> availableNodes = new Stack<Cell>();
            HashSet<Cell> visitedNodes = new HashSet<Cell>();

            Stack<Cell> candidatePath = new Stack<Cell>();

            availableNodes.Push(graph.EntryVertex);

            Cell lastTreasure = new Cell(-1, -1, -1);
            
            while (availableNodes.Count > 0) {

                Cell currentCell = availableNodes.Pop();
                visitedNodes.Add(currentCell);
                candidatePath.Push(currentCell);
                List<Cell> edges = graph.GetCellNeighbors(currentCell);

                if (currentCell.getType() == 9) {
                    lastTreasure = currentCell;
                    List<Cell> path = new List<Cell>(candidatePath.Reverse());
                    pathToTreasure.Add(path);
                }

                // bool addToBacktrackingPath = false;
                foreach (Cell cell in edges) {
                    if (!visitedNodes.Contains(cell) && !availableNodes.Contains(cell)) {
                        availableNodes.Push(cell);
                        cell.addVisitedCount();
                        // addToBacktrackingPath = true;
                    }
                }

                // If the current node is not a treasure, backtrack to the last branching node
            //     if (!addToBacktrackingPath) {                    
            //         while (candidatePath.Count > 0
            //                 && !(candidatePath.Peek().Equals(lastTreasure))) {
            //             candidatePath.Pop();
            //         }
            //     }
            }

            return pathToTreasure;
        }


        public void DFSPathPrint(List<List<Cell>> pathToTreasure) {
            int totalTreasureCount = Map.treasureCount;
            System.Console.WriteLine("Path: ");
            foreach (List<Cell> path in pathToTreasure) {
                int treasureCount = path.Count(cell => cell.getType() == 9);
                if (treasureCount == totalTreasureCount) {
                    foreach (Cell cell in path) {
                        cell.printCell();
                    }
                }
            }
        }

    }
}
