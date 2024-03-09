namespace GameOfLife;
using System;
using static System.Console;
using Francesco;
using Kacper;
using Ignat;


public class Program
{

    public static void Main()
    {
        JsonStorage jsonStorage = new JsonStorage();
        IGrid grid;
        bool quit = false;
        Clear();
        WriteLine("Welcome to a simple implementation of Conway's Game of Life");

        WriteLine("1 - Create a new random grid");
        WriteLine("2 - Load a grid from json");
        int c = GetInputAndValidate(1, 2);

        if (c == 2)
        {
            grid = jsonStorage.Load();      
        }
        else // set it to else instead of else if just so vs doesnt get mad that a grid isn't defined
        {   
            grid = NewRandomGrid();
        }

        AutomationSim sim = new AutomationSim(grid);
        int iteration = 0;

        while(!quit)
        {
            Clear();
            sim.DisplayGrid();
            Console.WriteLine($"Current iteration: {iteration}");
            Console.WriteLine("Press Enter to move on to the next generation");
            Console.WriteLine("Press Escape to quit the application");

            ConsoleKeyInfo userInput = Console.ReadKey();
            while(userInput.Key != ConsoleKey.Enter && userInput.Key != ConsoleKey.Escape)
            {
                userInput = Console.ReadKey();
            }

            if (userInput.Key == ConsoleKey.Enter)
            {
                if(!grid.IsGridAlive())
                {
                    Clear();
                    sim.DisplayGrid();
                    Console.WriteLine($"Last iteration: {iteration}");
                    Console.WriteLine("All of the cells on the gird have died, nothing will happen from now on");
                    break;
                }
                sim.UpdateGrid();
                iteration++;
            }
            else break;
        }

        jsonStorage.Save(grid);
        Console.WriteLine("TThank you for using our Game of Life simulation!"); // Double T intentional because it eats the first one for some reason
    }

    static Grid NewRandomGrid()
    {
        WriteLine("Enter number of rows for the grid (4 - 100)");
        int rows = GetInputAndValidate(4, 100);

        WriteLine("Enter number of rows (4 - 100)");
        int columns = GetInputAndValidate(4, 100);

        Grid randomGrid =  new Grid(rows, columns);

        int minimumCells = ((int)Math.Round(Math.Sqrt(rows * columns)));
        Random random = new Random();

        while(minimumCells > 0)
        {
            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < columns; c++)
                {
                    if(random.Next(1, 10) == 1)
                    {
                        randomGrid.UpdateCellState(r, c, true);
                        minimumCells--;
                    }
                }
            }
        }

        return randomGrid;
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
