using Sebi;

namespace Ignat; 

public interface IGrid
{
    int Rows { get; }
    int Columns { get; }
    bool[,] JsonCells { get; }
    public ICell GetCell(int row, int column);
    public void UpdateCellState(int row, int column, bool newState);
    public int CountLiveNeighbors(int row, int column);
    public void CalculateLiveNeighbors();
    public bool[] GetCellStatus();

    public bool IsGridAlive();
}

