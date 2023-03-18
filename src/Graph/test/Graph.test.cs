using System;
using System.Collections.Generic;
using src;

namespace GraphTest
{
  public class GraphTest
  {
    public static void Main(string[] args)
    {
      // Initialize some random cells
      Cell c1 = new Cell(1, 1);
      Cell c2 = new Cell(2, 2);
      Cell c3 = new Cell(3, 3);

      // Initialize graph
      Graph graph = new Graph(c1);
      Console.WriteLine("Entry vertex : {0},{1}", graph.EntryVertex.Row, graph.EntryVertex.Col);

      // Try setting a new graph entry vertex
      try
      {
        graph.EntryVertex = c2;
        Console.WriteLine("Entry vertex : {0},{1}", graph.EntryVertex.Row, graph.EntryVertex.Col);
      }
      catch (VertexNotFoundException e)
      {
        Console.WriteLine(e.Message);
      }

      // Adds a vertex and sets it as the new entry vertex
      graph.AddVertex(c2);
      graph.EntryVertex = c2;
      Console.WriteLine("Entry vertex : {0},{1}", graph.EntryVertex.Row, graph.EntryVertex.Col);

      // Try adding the same vertex twice
      try
      {
        graph.AddVertex(c1);
      }
      catch (DuplicateVertexException e)
      {
        Console.WriteLine(e.Message);
      }

      // Add some edges to the graph
      graph.AddEdge(c2, c3);
      graph.AddEdge(c2, c1);

      // Get the entry vertex neighbors
      List<Cell> neighbors = graph.GetCellNeighbors(graph.EntryVertex);
      foreach (Cell vertex in neighbors)
      {
        Console.WriteLine("Neighbor vertex : {0},{1}", vertex.Row, vertex.Col);
      }
    }
  }
}