using System;

namespace src{
    public partial class Utils{
        public void PrintMap(ref int[,] map){
            Console.WriteLine("Map: ");
            for(int i = 0; i < map.GetLength(0); i++){
                for(int j = 0; j < map.GetLength(1); j++){
                    Console.Write(map[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}