using System;
using System.Collections.Generic;

namespace src
{
  public class Graph
  {
    private Dictionary<Cell, List<Cell>> _adjacencyList;
    private Cell _entryVertex;

    /// <summary>
    /// User defined class constructor
    /// </summary>
    /// <param name="entryVertex">
    /// Graph vertex used as entry point for graph traversal algorithm
    /// </param>
    public Graph(Cell entryVertex)
    {
      _adjacencyList = new Dictionary<Cell, List<Cell>>();
      _entryVertex = entryVertex;
      _adjacencyList.Add(entryVertex, new List<Cell>());
    }

    /// <summary>
    /// Getter-setter for entry vertex attribute
    /// </summary>
    public Cell EntryVertex
    {
      get { return _entryVertex; }
      set
      {
        if (!_adjacencyList.ContainsKey(value))
        {
          throw new VertexNotFoundException();
        }
        _entryVertex = value;
      }
    }

    /// <summary>
    /// Get a cell's neighboring vertices
    /// </summary>
    /// <returns>
    /// List of a cell's neighboring vertices
    /// </returns>
    public List<Cell> GetCellNeighbors(Cell cell)
    {
      if (!_adjacencyList.ContainsKey(cell))
      {
        // Throw exception
      }
      return _adjacencyList[cell];
    }

    /// <summary>
    /// Adds a vertex to graph
    /// </summary>
    /// <param name="vertex">A new graph vertex</param>
    public void AddVertex(Cell vertex)
    {
      if (!_adjacencyList.ContainsKey(vertex))
      {
        _adjacencyList.Add(vertex, new List<Cell>());
      }
      else
      {
        throw new DuplicateVertexException();
      }
    }

    /// <summary>
    /// Adds an edge to graph
    /// </summary>
    /// <param name="vertex1">First graph vertex</param>
    /// <param name="vertex2">Second graph vertex</param>
    public void AddEdge(Cell vertex1, Cell vertex2)
    {
      if (!_adjacencyList.ContainsKey(vertex1))
      {
        AddVertex(vertex1);
      }

      if (!_adjacencyList.ContainsKey(vertex2))
      {
        AddVertex(vertex2);
      }

      _adjacencyList[vertex1].Add(vertex2);
      _adjacencyList[vertex2].Add(vertex1);
    }
  }
}