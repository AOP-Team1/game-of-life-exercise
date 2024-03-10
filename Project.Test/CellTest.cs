using Xunit;
using Sebi;

namespace Project.Test
{
    public class CellTests
    {
        [Theory]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void NextState_ReturnsCorrectNextState(int neighbours, bool expectedNextState)
        {
            // Arrange
            var cell = new Sebi.Cell
            {
                Neighbours = neighbours
            };

            // Act
            var actualNextState = cell.NextState(neighbours);

            // Assert
            Assert.Equal(expectedNextState, actualNextState);
        }

        [Theory]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void NextState_ReturnsCorrectNextStateForFalseState(int neighbours, bool expectedNextState)
        {
            // Arrange
            var cell = new Sebi.Cell
            {
                State = false,
                Neighbours = neighbours
            };

            // Act
            var actualNextState = cell.NextState(neighbours);

            // Assert
            Assert.Equal(expectedNextState, actualNextState);
        }
    }
}
