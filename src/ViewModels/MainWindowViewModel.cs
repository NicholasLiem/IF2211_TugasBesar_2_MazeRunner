using Maze.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System.ComponentModel;
using System.Collections.Generic;
// using System.Windows.Threading;
using System;

namespace Maze.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    public static int rows = 3, cols = 10;
    private int _sliderMax = (rows * cols) - 1;
    private int _rows = rows, _cols = cols;
    private int _gridHeight = Math.Min(600 / rows, 600 / cols) * rows;
    private int _gridWidth = Math.Min(600 / rows, 600 / cols) * cols;
    private int _iteration = 0;
    private int _steps = 6;
    private int _nodes = 11;
    private double _execTime = 850.9;
    private Cell[,] _cellList = new Cell[rows, cols];
    private List<Cell> _sequence = new List<Cell>();
    public event PropertyChangedEventHandler? PropertyChanged;
    public Map? map;

    public MainWindowViewModel()
    {
      FileManager fileReader = new FileManager();
      map = new Map("Maze3.txt");

      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          _cellList[i, j] = map.GetCells()[i, j];
          switch (_cellList[i, j].Type)
          {
            case 0:
              _cellList[i, j].Color = "#0000FF";
              break;
            case 1:
              _cellList[i, j].Color = "#D9D9D9";
              _sequence.Add(_cellList[i, j]);
              break;
            case 3:
              _cellList[i, j].Color = "#000000";
              break;
            case 9:
              _cellList[i, j].Color = "#00FF00";
              break;
            default:
              _cellList[i, j].Color = "#000000";
              break;
          }
        }
      }
      _sliderMax = _sequence.Count;
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
    }

    public int Cols
    {
      get => _cols;
    }

    public int Iteration
    {
      get => _iteration;
      set
      {
        _iteration = value;
        Cell[,] temp = new Cell[rows, cols];
        for (int i = 0; i < rows; i++)
        {
          for (int j = 0; j < cols; j++)
          {
            temp[i, j] = _cellList[i, j];
          }
        }
        for (int i = 0; i < _iteration; i++)
        {
          for (int j = 0; j < rows; j++)
          {
            for (int k = 0; k < cols; k++)
            {
              if (temp[j, k].isEqual(_sequence[i]))
              {
                temp[j, k].Color = "#FF0000";
                break;
              }
            }
          }
        }
        for (int i = _iteration; i < _sequence.Count; i++)
        {
          for (int j = 0; j < rows; j++)
          {
            for (int k = 0; k < cols; k++)
            {
              if (temp[j, k].isEqual(_sequence[i]))
              {
                temp[j, k].Color = "#D9D9D9";
                break;
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
    }

    private int GridWidth
    {
      get => _gridWidth;
    }

    public void HandleSearch()
    {
      // Iteration = 0;
      // Cell[,] temp = new Cell[rows, cols];
      // for (int i = 0; i < rows; i++)
      // {
      //   for (int j = 0; j < cols; j++)
      //   {
      //     temp[i, j] = new Cell(i, j, -1);
      //     if (i == 0 && j == 0)
      //     {
      //       temp[i, j].Color = "#FFFFFF";
      //     }
      //   }
      // }
      // CellList = temp;
      Algorithms alg = new Algorithms();
      Graph mapGraph = map?.GetGraph();
      List<Cell> path = alg.BreadthFirstSearch(mapGraph, mapGraph.EntryVertex, false, 9);

      for (int i = 0; i < path.Count; i++)
      {
        Console.WriteLine(path[i].Row);
        Console.WriteLine(path[i].Col);
        Console.WriteLine("Halo");
      }
      // alg.DFSPathPrint(path);

      for (int i = 0; i < _sequence.Count; i++)
      {

        Cell[,] temp = new Cell[rows, cols];
        for (int j = 0; j < rows; j++)
        {
          for (int k = 0; k < cols; k++)
          {
            temp[j, k] = _cellList[j, k];
            if (temp[j, k].isEqual(_sequence[i]))
            {
              temp[j, k].Color = "#FF0000";
            }
          }
        }
        CellList = temp;
      }
      Iteration = _sequence.Count;
    }
  }
}