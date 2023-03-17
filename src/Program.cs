// See https://aka.ms/new-console-template for more information
using System;

namespace src{
    public class Program
    {
        public static void Main(string[] args)
    {
        Hehe hehe = new Hehe();
        FileReader fileReader = new FileReader();
        hehe.HelloWorld();
        fileReader.ReadFile();
        Console.WriteLine("Hello, World! goblok");
    }
    }

}