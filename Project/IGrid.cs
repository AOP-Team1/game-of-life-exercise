namespace Ignat; 

public interface IGrid
{
    int Rows { get; }
    int Columns { get; }
    public void UpdateCells();
    bool[] GetCellStatus();
}

