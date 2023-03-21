using System;
using System.IO;

namespace Maze.Models
{
  public partial class FileManager
  {
    static string basePath = Directory.GetCurrentDirectory();
    public void ReadFile(ref Cell[,] cells, string fileName)
    {

      // Console.WriteLine("Enter the name of a text file in the 'test' folder:");
      // string? fileName = Console.ReadLine();

      // while (fileName == null || fileName == "")
      // {
      //   Console.WriteLine("Please enter a valid file name:");
      //   fileName = Console.ReadLine();
      // }

      string filePath = Path.Combine(basePath, "test", fileName);

      if (File.Exists(filePath) && Path.GetExtension(filePath) == ".txt")
      {
        // K : Titik Awal (0)
        // T : Treasure (9)
        // R : Grid Lintasan (1)
        // X : Grid Non-Lintasan (3)

        string[] lines = File.ReadAllLines(filePath);
        cells = new Cell[lines.Length, lines[0].Split(' ').Length];
        for (int i = 0; i < lines.Length; i++)
        {
          string[] row = lines[i].Split(' ');

          for (int j = 0; j < row.Length; j++)
          {
            string textItem = row[j];
            int type = -1;
            switch (textItem)
            {
              case "K":
                type = 0;
                break;
              case "T":
                type = 9;
                break;
              case "R":
                type = 1;
                break;
              case "X":
                type = 3;
                break;
              default:
                Console.WriteLine("Simbol tidak dikenali");
                break;
            }
            cells[i, j] = new Cell(i, j, type);
          }
        }
      }
      else
      {
        Console.WriteLine("Invalid file path or file type.");
      }
    }
    public void ShowFilesInFolder()
    {
      try
      {
        Console.WriteLine("Files in folder 'test': ");
        string[] files = Directory.GetFiles(Path.Combine(basePath, "test"), "*.txt");
        foreach (string file in files)
        {
          Console.WriteLine(Path.GetFileName(file));
        }
        Console.WriteLine();
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }
  }
}
