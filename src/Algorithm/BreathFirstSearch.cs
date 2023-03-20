using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System;

namespace src
{
    public partial class Algorithms
    {
        private static int treasureFound = 0;

        public int TreasureFound
        {
            get { return treasureFound; }
            set
            {
                treasureFound = value;
            }
        }
        public List<Cell> BreathFirstSearch(Graph graph, Cell start)
        {
            List<Cell> checkedCells = new List<Cell>();
            var checkQueue = new Queue<List<Cell>>();
            var checkPath = new List<Cell>();
            checkPath.Add(start);
            checkQueue.Enqueue(checkPath);

            while (checkQueue.Count > 0)
            {
                var currCellList = checkQueue.Dequeue();
                var currCell = currCellList.ElementAt(currCellList.Count - 1);

                if (checkedCells.Contains(currCell))
                {
                    continue;
                }

                checkedCells.Add(currCell);

                if (currCell.getType() == 9 && !currCell.isEqual(start))
                {
                    treasureFound += 1;
                    return currCellList;
                }

                foreach (var neighbor in graph.GetCellNeighbors(currCell))
                {
                    if (!checkedCells.Contains(neighbor))
                    {
                        List<Cell> newPath = new List<Cell>();
                        foreach (var elmt in currCellList)
                        {
                            newPath.Add(elmt);
                        }
                        newPath.Add(neighbor);
                        checkQueue.Enqueue(newPath);
                    }
                }
            }

            return checkPath;
        }
    }
}