using Sebi;

namespace Ignat; 

public interface IGrid
{
    int Rows { get; }
    int Columns { get; }
    public Cell GetCell();
    public void UpdateCells();
    public int CountLiveNeighbors(int row, int column);
    public void CalculateLiveNeighbors();
    public bool[] GetCellStatus();

}

