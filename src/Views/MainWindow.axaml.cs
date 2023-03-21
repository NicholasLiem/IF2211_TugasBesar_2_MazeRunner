using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Layout;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Maze.ViewModels;

namespace Maze.Views;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    // int rowCount = 4, colCount = 4;

    InitializeComponent();
    DataContext = new MainWindowViewModel();

    // Grid mainGrid = this.GetControl<Grid>("MainGrid");
    // mainGrid.Height = 600;
    // mainGrid.Width = 600;

    // for (int i = 0; i < rowCount; i++)
    // {
    //   mainGrid.RowDefinitions.Add(new RowDefinition(1, GridUnitType.Star));
    // }
    // for (int i = 0; i < colCount; i++)
    // {
    //   mainGrid.ColumnDefinitions.Add(new ColumnDefinition(1, GridUnitType.Star));
    // }


    // for (int i = 0; i < rowCount; i++)
    // {
    //   for (int j = 0; j < colCount; j++)
    //   {
    //     Panel cell = createGridCell(i == j ? "T" : "", new SolidColorBrush(Colors.Gray));

    //     mainGrid.Children.Add(cell);
    //     Grid.SetRow(cell, i);
    //     Grid.SetColumn(cell, j);
    //   }
    // }
  }

  private Panel createGridCell(string text, SolidColorBrush bgColor)
  {
    Panel panel = new Panel();
    panel.Background = bgColor;
    panel.HorizontalAlignment = HorizontalAlignment.Stretch;
    panel.VerticalAlignment = VerticalAlignment.Stretch;
    panel.Margin = new Thickness(4);

    TextBlock textBlock = new TextBlock();
    textBlock.Text = text;
    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
    textBlock.VerticalAlignment = VerticalAlignment.Center;

    panel.Children.Add(textBlock);
    return panel;
  }
}