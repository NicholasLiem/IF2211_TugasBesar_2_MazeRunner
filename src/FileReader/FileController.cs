using System;
using System.IO;

namespace src{
    public partial class FileReader{
        public void ReadFile(){
            string basePath = Directory.GetCurrentDirectory();
            Console.WriteLine("Base directory: " + basePath);

            Console.WriteLine("Enter the name of a text file in the 'test' folder:");
            string? fileName = Console.ReadLine();

            while(fileName == null || fileName == ""){
                Console.WriteLine("Please enter a valid file name:");
                fileName = Console.ReadLine();
            }

            string filePath = Path.Combine(basePath, "test", fileName);

            if (File.Exists(filePath) && Path.GetExtension(filePath) == ".txt")
            {
                Console.WriteLine("Selected file: " + filePath);
                string fileContents = File.ReadAllText(filePath);
                Console.WriteLine("File contents: " + fileContents);
            }
            else
            {
                Console.WriteLine("Invalid file path or file type.");
            }
        }
    }
}
