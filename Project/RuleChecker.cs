//using System.Collections.Generic;
//using Sebi;

//namespace Kacper;

//public static class RuleChecker
//{
//    public static void SetCellToNextGeneration(int row, int column, List<List<ICell>> grid, int gridHeight, int gridWidth)
//    {
//        int neighbours = 0;
//        bool running = true;
//        int tempRow = row > 0 ? row : row - 1;

//        while(running)
//        {
//            if (column > 0)
//            {
//                if (grid[tempRow][column - 1].State) neighbours++;
//            }
//            if (grid[tempRow][column].State) neighbours++;
//            if (column < gridWidth)
//            {
//                if (grid[tempRow][column + 1].State) neighbours++;
//            }

//            if (tempRow < gridHeight && tempRow < row + 1) tempRow++;
//            else running = false;
//        }

//        grid[row][column].Neighbours = neighbours;

//        // Apply rules of the game
//        if (neighbours < 2 || neighbours > 3) grid[row][column].State = false;
//        else if (neighbours == 3) grid[row][column].State = true;
//        // else leave the status of the cell the same
//    }
//}