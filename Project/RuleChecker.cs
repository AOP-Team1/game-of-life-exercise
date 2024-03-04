using System.Collections.Generic;

namespace Kacper;

public static class RuleChecker
{
    int maxGridSize;

    public bool IsCurrentCellAlive(int row, int column, bool[][] grid)
    {
        int neighbours = 0;
        bool running = true;
        int tempRow = row > 0 ? row : row - 1;

        while(running)
        {
            if (column > 0)
            {
                if (grid[tempRow][column - 1]) neighbours++;
            }
            if (grid[tempRow][column]) neighbours++;
            if (column < maxGridSize)
            {
                if (grid[tempRow][column + 1]) neighbours++;
            }

            if (tempRow < maxGridSize && tempRow < row + 1) tempRow++;
            else running = false;
        }

        // Apply rules of the game
        if (neighbours < 2 || neighbours > 3) return false;
        if (neighbours == 3) return true;
        else return true; //cell.state
    }
}