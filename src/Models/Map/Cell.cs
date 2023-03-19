using System;

namespace Maze.Models
{
  public class Cell
  {
    private int _row, _col, _type;
    private bool _visited;

    public Cell(int row, int col)
    {
      _row = row;
      _col = col;
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
  }
}