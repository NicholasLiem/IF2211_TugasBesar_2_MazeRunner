using System;

namespace Maze.Models
{
  public class Cell
  {
    private int _row, _col, _type, _visitedCount;
    private string _color;
    private bool _visited;

    public Cell(int row, int col, int type)
    {
      _row = row;
      _col = col;
      _type = type;
      _color = "#FF0000";
    }
    public int Row
    {
      get { return _row; }
      set { _row = value; }
    }
    public int Col
    {
      get { return _col; }
      set { _col = value; }
    }
    public bool Visited
    {
      get { return _visited; }
      set { _visited = value; }
    }
    public int Type
    {
      get { return _type; }
      set { _type = value; }
    }
    public string Color
    {
      get { return _color; }
      set { _color = value; }
    }
    public int VisitedCount
    {
      get => _visitedCount;
      set => _visitedCount = value;
    }
    public void printCell()
    {
      int Row = _row;
      int Col = _col;
      int Type = _type;
      String Visited = _visited.ToString();
      String typePrint = "";
      switch (Type)
      {
        case 0:
          typePrint = "Titik Awal";
          break;
        case 1:
          typePrint = "Path";
          break;
        case 3:
          typePrint = "Block";
          break;
        case 9:
          typePrint = "Treasure";
          break;
        default:
          typePrint = "Unknown?";
          break;
      }
      Console.WriteLine("[" + Row + "," + Col + "]" + " T: " + typePrint + ", " + "VC: " + _visitedCount + "");
    }
    public bool isEqual(Cell other)
    {
      return _row == other.Row && _col == other.Col && _type == other.Type;
    }
  }
}