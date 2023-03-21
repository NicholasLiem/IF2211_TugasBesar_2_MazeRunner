using Maze.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System;

namespace Maze.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    private int _sliderMax = 10, _rows = 0, _cols = 0, _gridHeight = 0, _gridWidth = 0, _iteration = 0, _steps = 6, _nodes = 11;
    private string _fileName = "";
    private double _execTime = 850.9;
    private Cell[,] _cellList = new Cell[0, 0];
    private List<Cell> _sequence = new List<Cell>();
    private List<Cell> _path = new List<Cell>();
    private Dictionary<int, string> _sequenceColors = new Dictionary<int, string>();
    private Dictionary<int, string> _pathColors = new Dictionary<int, string>();

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindowViewModel()
    {
      for (int i = 0; i < 0; i++)
      {
        for (int j = 0; j < 0; j++)
        {
          _cellList[i, j] = new Cell(i, j, -1);
          _cellList[i, j].Color = "#FFFFFF";
        }
      }
    }

    public int Steps
    {
      get => _steps;
      set
      {
        _steps = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Steps)));
      }
    }

    public int Nodes
    {
      get => _nodes;
      set
      {
        _nodes = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nodes)));
      }
    }

    public double ExecTime
    {
      get => _execTime;
      set
      {
        _execTime = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExecTime)));
      }
    }

    public Cell[,] CellList
    {
      get => _cellList;
      set
      {
        _cellList = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CellList)));
      }
    }

    public int Rows
    {
      get => _rows;
      set
      {
        _rows = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rows)));
      }
    }

    public int Cols
    {
      get => _cols;
      set
      {
        _cols = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cols)));
      }
    }

    public int Iteration
    {
      get => _iteration;
      set
      {
        _iteration = value;
        Cell[,] temp = new Cell[_rows, _cols];
        for (int i = 0; i < _rows; i++)
        {
          for (int j = 0; j < _cols; j++)
          {
            temp[i, j] = _cellList[i, j];
            temp[i, j].VisitedCount = 0;
          }
        }
        for (int i = 0; i < _sequence.Count; i++)
        {
          for (int j = 0; j < _rows; j++)
          {
            for (int k = 0; k < _cols; k++)
            {
              if (temp[j, k].isEqual(_sequence[i]))
              {
                if (i < _iteration)
                {
                  temp[j, k].VisitedCount++;
                  _changeCellColor(ref temp[j, k], true, true);
                }
                else if (temp[j, k].VisitedCount == 0)
                {
                  // temp[j, k].Color = "#D9D9D9";
                  _changeCellColor(ref temp[j, k], false, true);
                }
                break;
              }
            }
          }
        }
        if (value == _sliderMax)
        {
          for (int i = 0; i < _path.Count; i++)
          {
            for (int j = 0; j < _rows; j++)
            {
              for (int k = 0; k < _cols; k++)
              {
                if (temp[j, k].isEqual(_path[i]))
                {
                  temp[j, k].VisitedCount = 0;
                  break;
                }
              }
            }
          }
          for (int i = 0; i < _path.Count; i++)
          {
            for (int j = 0; j < _rows; j++)
            {
              for (int k = 0; k < _cols; k++)
              {
                if (temp[j, k].isEqual(_path[i]))
                {
                  temp[j, k].VisitedCount++;
                  _changeCellColor(ref temp[j, k], true, false);
                  break;
                }
              }
            }
          }

        }
        CellList = temp;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Iteration)));
      }
    }

    public int SliderMax
    {
      get => _sliderMax;
      set
      {
        _sliderMax = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SliderMax)));
      }
    }

    private int GridHeight
    {
      get => _gridHeight;
      set
      {
        _gridHeight = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridHeight)));
      }
    }

    private int GridWidth
    {
      get => _gridWidth;
      set
      {
        _gridWidth = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridWidth)));
      }
    }

    public string FileName
    {
      get => _fileName;
      set
      {
        _fileName = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SliderMax)));
      }
    }

    private void _changeCellColor(ref Cell currCell, bool isVisited, bool isPath)
    {
      if (currCell.Color != "#FFFFFF")
      {
        if (!isVisited)
        {
          currCell.Color = "#D9D9D9";
        }
        else
        {
          currCell.Color = isPath ? _pathColors[currCell.VisitedCount - 1] : _sequenceColors[currCell.VisitedCount - 1];
        }
      }
    }

    private void _initPathColors(int colorCount)
    {
      // TODO: Remove previous dictionary entries
      int step = (255 - 10) / (colorCount - 1);

      for (int i = 0; i < colorCount; i++)
      {
        int alpha = 255 - i * step;
        int red = 245 - alpha;
        Color temp = Color.FromArgb(alpha, 255, 0, 0);
        _pathColors.Add(i, "#" + temp.A.ToString("X2") + "00FFFF");
      }
    }

    private void _initSequenceColors(int colorCount)
    {
      // TODO: Remove previous dictionary entries
      int step = (255 - 10) / (colorCount - 1);

      for (int i = 0; i < colorCount; i++)
      {
        int alpha = 255 - i * step;
        int red = 245 - alpha;
        Color temp = Color.FromArgb(alpha, 255, 0, 0);
        _sequenceColors.Add(i, "#" + temp.A.ToString("X2") + "FF0000");
      }
    }

    public void HandleSearch()
    {
      FileManager fileReader = new FileManager();
      Map map = new Map(_fileName);

      Rows = map.GetRowSize();
      Cols = map.GetColSize();

      _initPathColors(10);
      _initSequenceColors(3);

      GridHeight = Math.Min(600 / _rows, 600 / _cols) * _rows;
      GridWidth = Math.Min(600 / _rows, 600 / _cols) * _cols;

      _cellList = new Cell[_rows, _cols];
      for (int i = 0; i < _rows; i++)
      {
        for (int j = 0; j < _cols; j++)
        {
          _cellList[i, j] = map.GetCells()[i, j];
          switch (_cellList[i, j].Type)
          {
            case 0:
              _cellList[i, j].Color = "#0000FF";
              break;
            case 1:
              _cellList[i, j].Color = "#D9D9D9";
              break;
            case 3:
              _cellList[i, j].Color = "#FFFFFF";
              break;
            case 9:
              _cellList[i, j].Color = "#00FF00";
              break;
            default:
              _cellList[i, j].Color = "#FFFFFF";
              break;
          }
        }
      }

      Algorithms algorithm = new Algorithms();
      Graph mapGraph = map?.GetGraph() ?? new Graph(new Cell(0, 0, -1));
      _path = algorithm.BreadthFirstSearch(mapGraph, mapGraph.EntryVertex, map.TreasureCount, true, 9);
      // List<List<Cell>> path = algorithm.DepthFirstSearch(mapGraph);
      // algorithm.DFSPathPrint(path);
      // foreach (List<Cell> p in path)
      // {
      //   int treasureCount = p.Count(cell => cell.Type == 9);
      //   if (treasureCount == Map.treasureCount)
      //   {
      //     foreach (Cell cell in p)
      //     {
      //       _sequence.Add(cell);
      //     }
      //   }
      // }
      _sequence = algorithm.CheckList;
      foreach (Cell c in _sequence)
      {
        c.printCell();
      }
      // foreach (Cell c in path)
      // {
      //   Console.WriteLine(c.Row + " " + c.Col);
      // }

      // for (int i = 0; i < path.Count; i++)
      // {
      //   _sequence.Add(path[i]);

      // }
      foreach (Cell p in _path)
      {
        Console.WriteLine(p.Row + " " + p.Col);
      }
      SliderMax = _sequence.Count;

      for (int i = 0; i < _sequence.Count; i++)
      {

        Cell[,] temp = new Cell[_rows, _cols];
        for (int j = 0; j < _rows; j++)
        {
          for (int k = 0; k < _cols; k++)
          {
            temp[j, k] = _cellList[j, k];
          }
        }
        CellList = temp;
      }
      Iteration = _sequence.Count;
    }
  }
}