using System.Collections;
using System.Collections.Generic;
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

                if (currCell.Type == 9 && !solutionSpace.Contains(currCell))
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

        public Func<Cell> ShortestPath(Graph graph)
        {
            var route = new Dictionary<Cell, Cell>();

            var cellQueue = new Queue<Cell>();

            while (vertexQueue.Count > 0)
            {
                var currCell = cellQueue.Dequeue();

                foreach (var neighbor in graph.GetCellNeighbors[currCell])
                {
                    if (route.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    route[neighbor] = currCell;
                    cellQueue.Enqueue(neighbor);
                }
            }

            Func shortestPath = v =>
            {
                var path = new List<Cell>();

                var curr = v;
                while (!curr.Equals(graph.EntryVertex))
                {
                    path.Add(curr);
                    curr = route[curr];
                }

                path.Add(graph.EntryVertex);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }
    }
}