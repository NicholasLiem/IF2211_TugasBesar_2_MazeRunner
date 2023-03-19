//using Avalonia;
//using System;

//namespace src{
//public class Program
//{
//public static void Main(string[] args)
//{
//  int [,] mapMatrix = new int[0,0];
//FileManager fileReader = new FileManager();
//Utils Util = new Utils();
//fileReader.ShowFilesInFolder();
//fileReader.ReadFile(ref mapMatrix);
//Util.PrintMap(ref mapMatrix);
//}

//}

//}

using Avalonia;
using System;

namespace Maze
{
  internal class Program
  {
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
  }
}