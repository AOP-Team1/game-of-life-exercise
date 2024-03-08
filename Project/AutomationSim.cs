using System;
using Sebi;
using Ignat;
using Kacper;
using GameOfLife;

public class AutomationSim(IGrid grid, int gridWidth, int gridHeight)
{
    private IGrid grid = grid;

    public void UpdateGrid()
    {
        for(int i=0; i<grid.Rows; i++)
        {
            for(int j=0; j<grid.Columns; j++)
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
                if (grid.GetCell(tempRow, column-1).State) neighbours++;
            }
            if (grid.GetCell(tempRow, column).State) neighbours++;
            if (column < gridWidth)
            {
                if (grid.GetCell(tempRow, column + 1).State) neighbours++;
            }

            if (tempRow < gridHeight && tempRow < row + 1) tempRow++;
            else running = false;
        }

        grid.GetCell(row, column).Neighbours = neighbours;

        // Apply rules of the game
        if (neighbours < 2 || neighbours > 3) grid.GetCell(row, column).State = false;
        else if (neighbours == 3) grid.GetCell(row, column).State = true;
        // else leave the status of the cell the same
    }

}