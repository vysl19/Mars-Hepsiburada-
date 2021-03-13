using System;
using System.Collections.Generic;

namespace Mars
{
    class Program
    {
        static void Main()
        {
            //Write Upper Cordinates
            Console.WriteLine("Write Upper Cordinates");
            string[] uppercordinates = Console.ReadLine().ToString().Split(' ');
            var maxX = Convert.ToInt32(uppercordinates[0]);
            var maxY = Convert.ToInt32(uppercordinates[1]);
            var inputs = new List<MarsRoverInput>();
            Console.WriteLine("Write Each Rover Inputs");            
            while (true)
            {
                inputs.Add(new MarsRoverInput() { Position = Console.ReadLine(), Instruction = Console.ReadLine() });
                Console.WriteLine("Press x To calculate last position of the rovers or press any other key to continue");
                if (Console.ReadKey().Key == ConsoleKey.X)
                {
                    break;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Outputs ...");
            Console.WriteLine(UiManager.GetLastPositionsOfRovers(inputs, maxX, maxY));
            Console.Read();
        }
    }
}

