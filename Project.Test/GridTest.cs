using GameOfLife;
using Sebi;


namespace Project.Test
{
    public class GridTests
    {
        [Fact]
        public void Constructor_InitializesGridWithCorrectSize()
        {
            // Arrange
            int rows = 3;
            int columns = 3;

            // Act
            var grid = new GameOfLife.Grid(rows, columns);

            // Assert
            Assert.Equal(rows, grid.Rows);
            Assert.Equal(columns, grid.Columns);
        }

        [Fact]
        public void GetCell_ReturnsCorrectCell()
        {
            // Arrange
            var grid = new GameOfLife.Grid(3, 3);

            // Act
            var cell = grid.GetCell(1, 2);

            // Assert
            Assert.NotNull(cell);
            Assert.False(cell.State);
        }

        [Fact]
        public void UpdateCellState_UpdatesCellState()
        {
            // Arrange
            var grid = new GameOfLife.Grid(3, 3);

            // Act
            grid.UpdateCellState(1, 2, true);
            var updatedCell = grid.GetCell(1, 2);

            // Assert
            Assert.True(updatedCell.State);
        }

        [Fact]
        public void CountLiveNeighbors_ReturnsCorrectCount()
        {
            // Arrange
            var grid = new GameOfLife.Grid(3, 3);

            // Set some cells to be alive
            grid.UpdateCellState(0, 1, true);
            grid.UpdateCellState(1, 1, true);
            grid.UpdateCellState(1, 2, true);

            // Act
            var liveNeighbors = grid.CountLiveNeighbors(0, 0);

            // Assert
            Assert.Equal(2, liveNeighbors);
        }

        [Fact]
        public void CalculateLiveNeighbors_CalculatesLiveNeighborsForAllCells()
        {
            // Arrange
            int rows = 3;
            int columns = 3;

            // Create a grid with some initial live cells
            Grid grid = new Grid(rows, columns);
            grid.UpdateCellState(0, 0, true);
            grid.UpdateCellState(0, 1, true);
            grid.UpdateCellState(1, 0, true);

            // Act
            grid.CalculateLiveNeighbors();

            // Assert
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int expectedLiveNeighbors = CalculateExpectedLiveNeighbors(grid, i, j);
                    Assert.Equal(expectedLiveNeighbors, grid.GetCell(i, j).Neighbours);
                }
            }
        }

        private int CalculateExpectedLiveNeighbors(Grid grid, int row, int col)
        {
            int liveNeighbors = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int neighborRow = row + i;
                    int neighborCol = col + j;

                    // Skip the current cell
                    if (i == 0 && j == 0)
                        continue;

                    // Check boundaries to avoid index out of range
                    if (neighborRow >= 0 && neighborRow < grid.Rows && neighborCol >= 0 && neighborCol < grid.Columns)
                    {
                        if (grid.GetCell(neighborRow, neighborCol).State)
                        {
                            liveNeighbors++;
                        }
                    }
                }
            }

            return liveNeighbors;
        }

    }
}