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
        private static List<Cell> solutionSpace = new List<Cell>();
        // menyimpan cell-cell treasure yang sudah ditemukan
        private static List<Cell> checklist = new List<Cell>();
        // menyimpan list pengecekan pada setiap iterasi bfs
        public List<Cell> CheckList
        {
            get { return checklist; }
        }
        public List<Cell> BreathFirstSearch(Graph graph, Cell start, int treasureCount)
        {
            // Untuk menyimpan cell-cell yang sudah dikunjungi pada saat iterasi
            List<Cell> checkedCells = new List<Cell>();

            // Membuat queue pengunjungan cell dengan elemen list of cell untuk menyimpan rute
            var checkQueue = new Queue<List<Cell>>();
            var checkPath = new List<Cell>();
            checkPath.Add(start);
            checkQueue.Enqueue(checkPath);

            // mulai bfs dengan queue dengan kondisi bahwa queue masih ada atau semua Treasure belum ditemukan
            while (checkQueue.Count > 0 && solutionSpace.Count < treasureCount)
            {
                // Mengambil elemen terakhir dari list untuk dikunjungi
                var currCellList = checkQueue.Dequeue();
                var currCell = currCellList.ElementAt(currCellList.Count - 1);

                // jika sudah pernah di cek, lanjut cell selanjutnya dari list selanjutnya pada queue
                if (checkedCells.Contains(currCell))
                {
                    continue;
                }

                // menandai cell sudah dikunjungi
                checklist.Add(currCell);
                checkedCells.Add(currCell);
                currCell.addVisitedCount();

                // jika cell adalah treasure, akan dilakukan bfs lagi dari treasure tersebut dan jalur akan digabungkan dan menjadi solusi
                if (currCell.getType() == 9 && !currCell.isEqual(start) && !solutionSpace.Contains(currCell))
                {
                    solutionSpace.Add(currCell);

                    List<Cell> nextPath = BreathFirstSearch(graph, currCell, treasureCount);
                    for (int i = 1; i < nextPath.Count; i++)
                    {
                        currCellList.Add(nextPath[i]);
                    }
                    return currCellList;
                }

                // jika bukan treasure, memasukan tetangga dari cell ke queue dengan jalurnya
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

            // mengembalikan list kosong jika queue habis dan tidak menemukan treasure
            return checkPath;
        }
    }
}