using System;

namespace Maze.Models
{
  public class Cell
  {
    private int _row, _col, _type, _totalRow, _totalCol;
    private string _color;
    private bool _visited;

    public Cell(int row, int col)
    {
      _row = row;
      _col = col;
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
    public int TotalRow
    {
      get { return _totalRow; }
      set { _totalRow = value; }
    }
    public int TotalCol
    {
      get { return _totalCol; }
      set { _totalCol = value; }
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
  }
}