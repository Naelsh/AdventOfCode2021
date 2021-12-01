using AdventOfCode2021.Input;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InputHandler inputHandler = new InputHandler();
            
            string input = Console.r;
            string[] array = inputHandler.GetSingleColumnInputToList(input);
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
