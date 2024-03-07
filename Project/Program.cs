namespace GameOfLife;
using System;
using static System.Console;
using Francesco;


public class Program
{

    public static void Main()
    {
        JsonStorage jsonStorage = new JsonStorage();
        Clear();
        WriteLine("Welcome to a simple implementation of Conway's game of Life");

        WriteLine("1 - create a new random grid");
        WriteLine("2 - load grid from json");
        int c = GetInputAndValidate(1, 2);

        if (c == 1)
        {
            NewRandomGrid();
        }
        if (c == 2)
        {
            LoadGridFromFile();
        }

        void LoadGridFromFile()
        {
            Grid grid = jsonStorage.Load();
        }

        void NewRandomGrid()
        {
            WriteLine("Enter number of rows for the grid (4 - 100)");
            int x = GetInputAndValidate(4, 100);

            WriteLine("Enter number of rows (4 - 100)");
            int y = GetInputAndValidate(4, 100);

            Grid grid = new Grid(x, y);
        }
    }

    //Validates user input to be an integer. Recieves as argument the lowerLimit and upperLimit (included)
    static int GetInputAndValidate(int lowerLimit, int upperLimit)
    {
        return 1;
    }
}
