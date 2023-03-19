using System;

namespace src
{
    public partial class Algorithms
    {
        public List<Cell> BreathFirstSearch(Graph graph)
        {
            var checkedCells = new List<Cell>();

            var start = graph.EntryVertex;

            var solutionSpace = new List<Cell>();
            solutionSpace.Add(start);

            var checkQueue = new Queue<Cell>();
            checkQueue.Enqueue(start);

            while (checkQueue.Count > 0)
            {
                var currCell = checkQueue.Dequeue();

                if (checkedCells.Contains(currCell))
                {
                    continue;
                }

                if (currCell.getType() == 9 && !solutionSpace.Contains(currCell))
                {
                    solutionSpace.Add(currCell);
                }

                checkedCells.Add(currCell);

                foreach (var neighbor in graph.GetCellNeighbors(currCell))
                {
                    if (!checkedCells.Contains(neighbor))
                    {
                        checkQueue.Enqueue(neighbor);
                    }
                }
            }

            return solutionSpace;
        }

        public List<Cell> ShortestPath(Graph graph, List<Cell> solutions)
        {
            var route = new Dictionary<Cell, Cell>();

            var cellQueue = new Queue<Cell>();
            cellQueue.Enqueue(graph.EntryVertex);

            while (cellQueue.Count > 0)
            {
                var currCell = cellQueue.Dequeue();

                foreach (var neighbor in graph.GetCellNeighbors(currCell))
                {
                    if (route.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    route[neighbor] = currCell;
                    cellQueue.Enqueue(neighbor);
                }
            }

            List<Cell> shortestPath = new List<Cell>();

            for (int i = solutions.Count - 1; i > 0; i--)
            {
                var curr = solutions.ElementAt(i);
                while (!curr.Equals(solutions.ElementAt(i - 1)))
                {
                    shortestPath.Add(curr);
                    curr = route[curr];
                }
            }

            shortestPath.Add(graph.EntryVertex);
            shortestPath.Reverse();

            return shortestPath;
        }
    }
}