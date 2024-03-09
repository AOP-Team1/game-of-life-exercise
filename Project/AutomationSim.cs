using System;
using Sebi;
using Ignat;
using GameOfLife;
namespace Kacper;

public class AutomationSim(IGrid grid)
{
    private IGrid grid = grid;

    public void UpdateGrid()
    {
        for(int i=0; i<grid.Rows; i++)
        {
            for(int j=0; j<grid.Columns; j++)
            {
                SetCellToNextGeneration(i, j, grid);
            }
        }
    }

    public void DisplayGrid()
    {
        for (int i = 0; i < grid.Rows; i++)
        {
            for (int j = 0; j < grid.Columns; j++)
            {
                Console.Write(grid.GetCell(i, j).State ? "O" : ".");
            }
            Console.WriteLine();
        }
    }

    public void SetCellToNextGeneration(int row, int column, IGrid grid)
    {
        grid.CalculateLiveNeighbors();
        int neighbours = grid.GetCell(row, column).Neighbours;

        if (neighbours < 2 || neighbours > 3) grid.GetCell(row, column).State = false;
        else if (neighbours == 3) grid.GetCell(row, column).State = true;
        // else leave the status of the cell the same
    }

}