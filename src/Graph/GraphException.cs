using System;

namespace src
{
  public class VertexNotFoundException : Exception
  {
    public VertexNotFoundException() : base("Vertex is not in the graph") { }
  }

  public class DuplicateVertexException : Exception
  {
    public DuplicateVertexException() : base("Vertex is already in the graph") { }
  }
}