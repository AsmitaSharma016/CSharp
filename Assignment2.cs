//Author: Asmita Sharma 899010
using System;

class Program
{
    static void Main(string[] args)
    {
        double x;

        while (true)
        {
            Console.Write("Enter a real number (or type 'exit' to terminate): "); // Prompts a user to enter a real number

            string input = Console.ReadLine();
            if (input.ToLower() == "exit") // Checks if the user wants to exit
                break;

            if (!double.TryParse(input, out x)) // Checks input is valid real number
            {
                Console.WriteLine("Invalid input. Please enter a valid real number.");
                continue;
            }

            if ((x >= 2 && x < 3) || (x >= 0 && x < 1) || (x >= -10 && x <= -2))
            {
                Console.WriteLine("x belongs to I");
            }
            else
            {
                Console.WriteLine("x does not belong to I");
            }
        }
    }
}
