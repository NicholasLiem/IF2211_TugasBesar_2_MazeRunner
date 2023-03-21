using Maze.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace Maze.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    public static int rows = 4, cols = 10;
    private int _sliderMax = (rows * cols) - 1;
    private int _rows = rows, _cols = cols;
    private int _iteration = 0;
    private int _steps = 6;
    private int _nodes = 11;
    private double _execTime = 850.9;
    private Cell[,] _cellList = new Cell[rows, cols];
    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindowViewModel()
    {
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          _cellList[i, j] = new Cell(i, j, -1);
          if (i == 0 && j == 0)
          {
            _cellList[i, j].Color = "#FFFFFF";
          }
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
            if (cols * i + j == _iteration)
            {
              temp[i, j] = new Cell(i, j, -1);
              temp[i, j].Color = "#FFFFFF";
            }
            else
            {
              temp[i, j] = new Cell(i, j, -1);
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

    public void HandleSearch()
    {
      Iteration = 0;
      Cell[,] temp = new Cell[rows, cols];
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          temp[i, j] = new Cell(i, j, -1);
          if (i == 0 && j == 0)
          {
            temp[i, j].Color = "#FFFFFF";
          }
        }
      }
      CellList = temp;
    }
  }
}