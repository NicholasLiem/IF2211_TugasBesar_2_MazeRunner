using System.Collections.Generic;
using System.Linq;
using System;

namespace Maze.Models
{
  public partial class Algorithms
  {
    public List<Cell> DepthFirstSearch(Graph graph, Map map)
    {
      Console.WriteLine("START");

      /* 
          Inisialisasi stack untuk menyimpan jalur yang sudah ditempuh
      */
      Stack<Cell> paths = new Stack<Cell>();
      Stack<Cell> availableNodes = new Stack<Cell>();
      HashSet<Cell> visitedNodes = new HashSet<Cell>();
      Stack<Cell> candidatePath = new Stack<Cell>();

      /* Pendaftaran entryVertex ke dalam availableNodes */
      availableNodes.Push(graph.EntryVertex);

      /* 
          Proses pencarian jalur dengan DFS
      */
      while (availableNodes.Count > 0)
      {
        /* Mengambil cell yang ada di availableNodes */
        Cell currentCell = availableNodes.Pop();

        /* 
            Tambahkan cell di visitedNodes dan candidatePath dan paths
        */
        visitedNodes.Add(currentCell);
        candidatePath.Push(currentCell);
        paths.Push(currentCell);
        currentCell.VisitedCount++;

        foreach (Cell c in candidatePath)
        {
          c.printCell();
        }
        Console.WriteLine("Halo");

        /* Kalau sudah ditemukan solusi, maka keluarkan solusinya */
        if (candidatePathHasAllTreasures(candidatePath.Reverse().ToList(), map.treasureCells))
        {
          return candidatePath.Reverse().ToList();
        }

        /* Cek apakah suatu sel ini adalah dead end*/
        bool isDeadEnd = true;
        List<Cell> edges = graph.GetCellNeighbors(currentCell);
        foreach (Cell cell in edges)
        {
          if (!visitedNodes.Contains(cell) && !availableNodes.Contains(cell))
          {
            availableNodes.Push(cell);
            isDeadEnd = false;
          }
        }

        /* 
            Jika suatu sel adalah dead end, maka hapus sel tersebut dari paths
            dan tambahkan sel tersebut ke candidatePath supaya bisa menambahkan pathsnya
            supaya bisa menambahkan pathsnya menuju backtracking path.
        */

        while (isDeadEnd && paths.Count > 0)
        {
          Cell lastCell = paths.Pop();
          candidatePath.Push(lastCell);
          lastCell.VisitedCount++;
          List<Cell> lastCellEdges = graph.GetCellNeighbors(lastCell);
          foreach (Cell cell in lastCellEdges)
          {
            if (!paths.Contains(cell) && !visitedNodes.Contains(cell))
            {
              isDeadEnd = false;
            }
          }
        }
      }

      return new List<Cell>();
    }

    public void DFSPathPrint(List<Cell> pathToTreasure)
    {
      System.Console.WriteLine("Path: ");
      foreach (Cell cell in pathToTreasure)
      {
        cell.printCell();
      }
    }

    public bool candidatePathHasAllTreasures(List<Cell> candidatePaths, HashSet<Cell> treasures)
    {
      int treasureCount = 0;
      foreach (Cell cell in new List<Cell>(candidatePaths.Distinct()))
      {
        if (cell.Type == 9)
        {
          treasureCount++;
        }
      }
      return treasureCount == treasures.Count;
    }

  }
}
