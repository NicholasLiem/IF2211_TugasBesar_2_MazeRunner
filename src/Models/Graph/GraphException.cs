using System;

namespace Maze.Models
{
  public class VertexNotFoundException : Exception
  {
    public VertexNotFoundException() : base("Vertex is not in the graph") { }
  }

  public class DuplicateVertexException : Exception
  {
    public DuplicateVertexException() : base("Vertex is already in the graph") { }
  }
  public class MatrixCellEmptyException : Exception
  {
    public MatrixCellEmptyException() : base("Cells Matrix is empty") { }
  }
}