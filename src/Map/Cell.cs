using System;

namespace src
{
  public class Cell
  {
    private int _row, _col, _type;
    private bool _visited;

    public Cell(int row, int col, int type)
    {
      _row = row;
      _col = col;
      _type = type;
      _visited = false;
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
    public void printCell()
        {
            int Row = _row;
            int Col = _col;
            int Type = _type;
            String Visited = _visited.ToString();
            String typePrint = "";
            switch(Type){
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
            Console.WriteLine("location: [" + Row + "," + Col+ "]" + " type: " + typePrint + ", " +  "visited: " + Visited);
        }
  }
}