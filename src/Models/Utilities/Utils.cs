using System;
using System.Collections.Generic;

namespace Maze.Models
{
  public partial class Utils
  {
    public static void PrintMap(ref Cell[,] map)
    {
      Console.WriteLine("Map: ");
      for (int i = 0; i < map.GetLength(0); i++)
      {
        for (int j = 0; j < map.GetLength(1); j++)
        {
          map[i, j].printCell();
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    public static Cell findTreasurePositions(ref List<List<int>> treasureList, ref Cell[,] map)
    {
      for (int i = 0; i < map.GetLength(0); i++)
      {
        for (int j = 0; j < map.GetLength(1); j++)
        {
          if (map[i, j].Type == 9)
          {
            List<int> treasurePosition = new List<int>();
            treasurePosition.Add(i);
            treasurePosition.Add(j);
            treasureList.Add(treasurePosition);
          }
        }
      }
      return new Cell(-1, -1, -1);
    }
    public static Cell findEntryPoint(ref Cell[,] map)
    {
      for (int i = 0; i < map.GetLength(0); i++)
      {
        for (int j = 0; j < map.GetLength(1); j++)
        {
          if (map[i, j].Type == 0)
          {
            return map[i, j];
          }
        }
      }
      return new Cell(-1, -1, -1);
    }

    public static Graph registerVertex(ref Cell[,] matrixCell)
    {
      if (matrixCell == null)
        throw new MatrixCellEmptyException();

      Graph graph = new Graph(findEntryPoint(ref matrixCell));

      int numRows = matrixCell.GetLength(0);
      int numCols = matrixCell.GetLength(1);

      for (int i = 0; i < numRows; i++)
      {
        for (int j = 0; j < numCols; j++)
        {
          Cell item = matrixCell[i, j];
          int type = item.Type;
          if (type != 3)
          {
            if (type == 9)
            {
              Map.treasureCount++;
            }
            graph.AddVertex(item);

            if (i < numRows - 1 && matrixCell[i + 1, j].Type != 3)
            {
              graph.AddEdge(item, matrixCell[i + 1, j]);
            }

            if (i > 0 && matrixCell[i - 1, j].Type != 3)
            {
              graph.AddEdge(item, matrixCell[i - 1, j]);
            }

            if (j > 0 && matrixCell[i, j - 1].Type != 3)
            {
              graph.AddEdge(item, matrixCell[i, j - 1]);
            }

            if (j < numCols - 1 && matrixCell[i, j + 1].Type != 3)
            {
              graph.AddEdge(item, matrixCell[i, j + 1]);
            }
          }
        }
      }
      graph.deleteDuplicateAdjacencyValueList();
      return graph;
    }
  }
}