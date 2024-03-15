using GameOfLife;
using Ignat;
using Kacper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Test
{
    public class AutomationSimTest
    {

        [Fact]
        public void UpdateCellFutureGenerationUpdatesCorrectly()
        {
            IGrid testingGrid = new Grid(3, 3);
            AutomationSim testAutomationSim = new AutomationSim(testingGrid);
            testingGrid.UpdateCellState(0, 0, true);
            testingGrid.UpdateCellState(0, 1, true);
            testingGrid.UpdateCellState(0, 2, true);
            testingGrid.UpdateCellState(1, 0, false);
            testingGrid.UpdateCellState(1, 1, true);
            testingGrid.UpdateCellState(1, 2, false);
            testingGrid.UpdateCellState(2, 0, false);
            testingGrid.UpdateCellState(2, 1, false);
            testingGrid.UpdateCellState(2, 2, false);

            /*
            The grid is:
            1 1 1
            0 1 0
            0 0 0
            So the expected future state of the cell in the middle (1, 1) is to be alive since it has 3 neighbours
            */

            testAutomationSim.UpdateCellFutureGeneration(1, 1, testingGrid);
            Assert.True(testingGrid.GetCell(1, 1).FutureState);
        }

        [Fact]
        public void SetCellToNextGenerationDoesntModifyOtherCells()
        {
            IGrid testingGrid = new Grid(3, 3);
            AutomationSim testAutomationSim = new AutomationSim(testingGrid);
            testingGrid.UpdateCellState(0, 0, false);
            testingGrid.UpdateCellState(0, 1, false);
            testingGrid.UpdateCellState(0, 2, false);
            testingGrid.UpdateCellState(1, 0, false);
            testingGrid.UpdateCellState(1, 1, false);
            testingGrid.UpdateCellState(1, 2, false);
            testingGrid.UpdateCellState(2, 0, false);
            testingGrid.UpdateCellState(2, 1, false);
            testingGrid.UpdateCellState(2, 2, false);

            testingGrid.GetCell(0, 0).FutureState = true;
            // every cell is dead so there are no external factors that could change the state of the cell
            // the future state of the cell is set manually so only the function evaluating this condition can be tested
            testAutomationSim.SetCellToNextGeneration(0, 0, testingGrid);

            Assert.False(testingGrid.GetCell(0, 1).State);
            Assert.False(testingGrid.GetCell(0, 2).State);
            Assert.False(testingGrid.GetCell(1, 0).State);
            Assert.False(testingGrid.GetCell(1, 1).State);
            Assert.False(testingGrid.GetCell(1, 2).State);
            Assert.False(testingGrid.GetCell(2, 0).State);
            Assert.False(testingGrid.GetCell(2, 1).State);
            Assert.False(testingGrid.GetCell(2, 2).State);
        }

        [Fact]
        public void SetCellToNextGenerationSetsRightValue()
        {
            IGrid testingGrid = new Grid(3, 3);
            AutomationSim testAutomationSim = new AutomationSim(testingGrid);
            testingGrid.UpdateCellState(0, 0, false);
            testingGrid.UpdateCellState(0, 1, false);
            testingGrid.UpdateCellState(0, 2, false);
            testingGrid.UpdateCellState(1, 0, false);
            testingGrid.UpdateCellState(1, 1, false);
            testingGrid.UpdateCellState(1, 2, false);
            testingGrid.UpdateCellState(2, 0, false);
            testingGrid.UpdateCellState(2, 1, false);
            testingGrid.UpdateCellState(2, 2, false);

            testingGrid.GetCell(0, 0).FutureState = true;
            // every cell is dead so there are no external factors that could change the state of the cell
            // the future state of the cell is set manually so only the function evaluating this condition can be tested
            testAutomationSim.SetCellToNextGeneration(0, 0, testingGrid);
            Assert.True(testingGrid.GetCell(0, 0).State);
        }

    }
}
