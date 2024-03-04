using System;
using Sebi;
using Ignat;
using Kacper; 

public class AutomationSim(IGrid grid, int gridWidth, int gridHeight)
{
    private IGrid grid = grid;
    private int gridWidth = gridWidth;
    private int gridHeight = gridHeight;
    // Height -> amount of rows 
    // Width -> amount of columns

    public void UpdateGrid()
    {
        for(int i=0; i<gridHeight; i++)
        {
            for(int j=0; j<gridWidth; j++)
            {
                SetCellToNextGeneration(i, j, grid, gridHeight, gridWidth);
            }
        }
    }

    public void SetCellToNextGeneration(int row, int column, IGrid grid, int gridHeight, int gridWidth)
    {
        int neighbours = 0;
        bool running = true;
        int tempRow = row > 0 ? row : row - 1;

        while (running)
        {
            if (column > 0)
            {
                if (grid[tempRow][column - 1].State) neighbours++;
            }
            if (grid[tempRow][column].State) neighbours++;
            if (column < gridWidth)
            {
                if (grid[tempRow][column + 1].State) neighbours++;
            }

            if (tempRow < gridHeight && tempRow < row + 1) tempRow++;
            else running = false;
        }

        grid[row][column].Neighbours = neighbours;

        // Apply rules of the game
        if (neighbours < 2 || neighbours > 3) grid[row][column].State = false;
        else if (neighbours == 3) grid[row][column].State = true;
        // else leave the status of the cell the same
    }

}