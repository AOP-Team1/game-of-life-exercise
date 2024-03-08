namespace GameOfLife;
using System;
using static System.Console;
using Francesco;
using Kacper;


public class Program
{

    public static void Main()
    {
        JsonStorage jsonStorage = new JsonStorage();
        Grid grid;
        bool quit = false;
        Clear();
        WriteLine("Welcome to a simple implementation of Conway's game of Life");

        WriteLine("1 - create a new random grid");
        WriteLine("2 - load grid from json");
        int c = GetInputAndValidate(1, 2);

        if (c == 2)
        {
            grid = jsonStorage.Load();      
        }
        else
        {
            // set it to else instead of else if just so vs doesnt get mad
            grid = NewRandomGrid();
        }

        AutomationSim sim = new AutomationSim(grid);
        int counter = 0;

        while(!quit)
        {
            Clear();
            sim.DisplayGrid();
            Console.WriteLine("Press Enter to move on to the next generation");
            Console.ReadLine();
            sim.UpdateGrid();
            counter++;
            if (counter == 100) break;
        }   
    }

    static Grid NewRandomGrid()
    {
        WriteLine("Enter number of rows for the grid (4 - 100)");
        int x = GetInputAndValidate(4, 100);

        WriteLine("Enter number of rows (4 - 100)");
        int y = GetInputAndValidate(4, 100);

        return new Grid(x, y);
    }

    //Validates user input to be an integer. Recieves as argument the lowerLimit and upperLimit (included)
    static int GetInputAndValidate(int lowerLimit, int upperLimit)
    {
        int userInput;
        while(!Int32.TryParse(Console.ReadLine(), out userInput))
        {
            Console.WriteLine($"Given input was invalid, please give a whole number between {lowerLimit} and {upperLimit}");
        }
        if(userInput > upperLimit)
        {
            Console.WriteLine("Given input was too large, it has been rounded down to the upper limit");
            userInput = upperLimit;
        }
        else if(userInput < lowerLimit)
        {
            Console.WriteLine("Given input was too small, it has been rounded down to the lower limit");
            userInput = lowerLimit;
        }

        return userInput;
    }
}
