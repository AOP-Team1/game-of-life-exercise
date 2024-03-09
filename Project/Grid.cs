namespace GameOfLife;
using System;
using System.Collections.Generic;
using Sebi;
using Ignat;


public class Grid : IGrid
{
    private readonly List<List<ICell>> cells;

    public int Rows { get; }
    public int Columns { get; }

    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;

        cells = new List<List<ICell>>(Rows);
        for (int i = 0; i < Rows; i++)
        {
            List<ICell> row = new List<ICell>(Columns);
            for (int j = 0; j < Columns; j++)
            {
                row.Add(new Cell());
            }
            cells.Add(row);
        }
    }

    public ICell GetCell(int row, int column)
    {
        if (row >= 0 && row < Rows && column >= 0 && column < Columns)
        {
            return cells[row][column];
        }
        else
        {
            string message = "";
            if (row >= 0 || row < Rows) message += "The specified row was outside of the defined grid!";
            if (column >= 0 || column < Columns) message += " The specified column was outside of the defined grid";
            throw new Exception(message);
        }

    }

 
    public int CountLiveNeighbors(int row, int column)
    {
        int liveNeighbors = 0;

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = column - 1; j <= column + 1; j++)
            {
                if (i == row && j == column)
                    continue;

                if (i >= 0 && i < Rows && j >= 0 && j < Columns)
                {
                    if (cells[i][j].State)
                    {
                        liveNeighbors++;
                    }
                }
            }
        }

        return liveNeighbors;
    }

    public void CalculateLiveNeighbors()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                cells[i][j].Neighbours = CountLiveNeighbors(i, j);
            }
        }
    }

    public bool IsGridAlive()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (cells[i][j].State) return true;
            }
        }

        return false;
    }

    public bool[,] GetCellStatus()
    {
        bool[,] cellStatus = new bool[Rows, Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                cellStatus[i, j] = cells[i][j].State;
            }
        }
        return cellStatus;
    }

    bool[] IGrid.GetCellStatus()
    {
        throw new NotImplementedException();
    }

    public Cell GetCell()
    {
        throw new NotImplementedException();
    }

    public void UpdateCells()
    {
        throw new NotImplementedException();
    }
}
