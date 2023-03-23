using Maze.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Linq;
using System.IO;

using System;

namespace Maze.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    private int _sliderMax = 10, _rows = 0, _cols = 0, _gridHeight = 0, _gridWidth = 0, _iteration = 0, _steps = 6, _nodes = 11, _iconSize = 0;
    private bool _isDFS = false, _isTSPOn = false, _showData = false;
    private string _fileName = "", _route = "";
    private double _execTime = 850.9;
    private Cell[,] _cellList = new Cell[0, 0];
    private Map? _map;
    private List<Cell> _sequence = new List<Cell>(), _path = new List<Cell>();
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

      _initPathColors(10);
      _initSequenceColors(3);
    }

    // GETTER-SETTER
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
    public int IconSize
    {
      get => _iconSize;
      set
      {
        _iconSize = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconSize)));
      }
    }
    public bool IsDFS
    {
      get => _isDFS;
      set
      {
        _isDFS = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDFS)));
      }
    }
    public bool IsTSPOn
    {
      get => _isTSPOn;
      set
      {
        _isTSPOn = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTSPOn)));
      }
    }
    public bool ShowData
    {
      get => _showData;
      set
      {
        _showData = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowData)));
      }
    }
    public string Route
    {
      get => _route;
      set
      {
        _route = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Route)));
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
            temp[i, j].IsBeingSearched = false;
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
                if (i < _iteration && !temp[j, k].IsBeingSearched)
                {
                  temp[j, k].VisitedCount++;
                  _changeCellColor(ref temp[j, k], true, true);
                }
                else if (i == _iteration)
                {
                  temp[j, k].Color = "#FFFA0D";
                  temp[j, k].IsBeingSearched = true;
                }
                else if (temp[j, k].VisitedCount == 0 && !temp[j, k].IsBeingSearched)
                {
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

    private string _getRoute(List<Cell> path)
    {
      string res = "";

      for (int i = 0; i < path.Count - 1; i++)
      {
        Cell curr = path[i];
        Cell next = path[i + 1];

        if (curr.Row < next.Row && curr.Col == next.Col)
        {
          res += "D";
        }
        else if (curr.Row > next.Row && curr.Col == next.Col)
        {
          res += "U";
        }
        else if (curr.Row == next.Row && curr.Col > next.Col)
        {
          res += "L";
        }
        else if (curr.Row == next.Row && curr.Col < next.Col)
        {
          res += "R";
        }

        if (i < path.Count - 2)
        {
          res += " - ";
        }
      }

      return res;
    }

    public void ChangeDFS()
    {
      IsDFS = !_isDFS;

      Iteration = 0;
      SliderMax = 0;

      Cell[,] temp = new Cell[_rows, _cols];
      for (int i = 0; i < _rows; i++)
      {
        for (int j = 0; j < _cols; j++)
        {
          temp[i, j] = _cellList[i, j];
          temp[i, j].VisitedCount = 0;
          temp[i, j].IsBeingSearched = false;
          temp[i, j].Color = temp[i, j].Type == 3 ? "#FFFFFF" : "#D9D9D9";
        }
      }
      CellList = temp;

      ShowData = false;
      _sequence = new List<Cell>();
      _path = new List<Cell>();
    }

    public void ChangeTSP()
    {
      IsTSPOn = !_isTSPOn;

      Iteration = 0;
      SliderMax = 0;
      ShowData = false;

      Cell[,] temp = new Cell[_rows, _cols];
      for (int i = 0; i < _rows; i++)
      {
        for (int j = 0; j < _cols; j++)
        {
          temp[i, j] = _cellList[i, j];
          temp[i, j].VisitedCount = 0;
          temp[i, j].IsBeingSearched = false;
          temp[i, j].Color = temp[i, j].Type == 3 ? "#FFFFFF" : "#D9D9D9";
        }
      }
      CellList = temp;

      _sequence = new List<Cell>();
      _path = new List<Cell>();
    }

    public void HandleFileInput()
    {
      FileManager fileReader = new FileManager();
      _map = new Map(_fileName);

      Rows = _map.GetRowSize();
      Cols = _map.GetColSize();
      // TODO: Implement divide by zero exception
      int minDimension = Math.Min(700 / Rows, 700 / Cols);
      GridHeight = minDimension * Rows;
      GridWidth = minDimension * Cols;
      IconSize = minDimension / 4;


      Cell[,] temp = new Cell[_rows, _cols];
      for (int i = 0; i < _rows; i++)
      {
        for (int j = 0; j < _cols; j++)
        {
          temp[i, j] = _map.GetCells()[i, j];
          temp[i, j].Color = temp[i, j].Type == 3 ? "#FFFFFF" : "#D9D9D9";
        }
      }

      _sequence = new List<Cell>();
      _path = new List<Cell>();

      CellList = temp;
      Iteration = 0;

      temp = new Cell[_rows, _cols];
      for (int i = 0; i < _rows; i++)
      {
        for (int j = 0; j < _cols; j++)
        {
          temp[i, j] = _cellList[i, j];
          temp[i, j].VisitedCount = 0;
          temp[i, j].IsBeingSearched = false;
          temp[i, j].Color = temp[i, j].Type == 3 ? "#FFFFFF" : "#D9D9D9";
        }
      }
      CellList = temp;

      SliderMax = 0;
      ShowData = false;
    }

    public void HandleSearch()
    {
      Algorithms algorithm = new Algorithms();
      Graph mapGraph = _map?.GetGraph() ?? new Graph(new Cell(0, 0, -1));

      if (_isDFS)
      {
        _path = algorithm.DepthFirstSearch(mapGraph);
        // foreach (List<Cell> p in temp)
        // {
        //   int treasureCount = p.Count(cell => cell.Type == 9);
        //   if (treasureCount == Map.treasureCount)
        //   {
        //     foreach (Cell cell in p)
        //     {
        //       _path.Add(cell);
        //     }
        //   }
        // }
        _sequence = _path;
      }
      else
      {
        _path = algorithm.BreadthFirstSearch(mapGraph, mapGraph.EntryVertex, _map.TreasureCount, _isTSPOn, 9);
        _sequence = algorithm.CheckList;
      }

      SliderMax = _sequence.Count;

      Steps = _path.Count;
      Nodes = _sequence.Count;
      Route = _getRoute(_path);

      // Iteration = _sequence.Count;
      algorithm.CheckList = new List<Cell>();
      algorithm.SolutionSpace = new List<Cell>();
      algorithm.TreasureFound = 0;

      Timer timer = new(interval: 100);
      timer.Elapsed += (sender, e) =>
      {
        if (Iteration == SliderMax)
        {
          timer.Dispose();
        }
        else
        {
          Iteration++;
        }
      };
      timer.Start();

      ShowData = true;
    }
  }
}