namespace Sebi
{
    public class Cell : ICell
    {
        public bool State { get; set; }
        public int Neighbours { get; set; }

        public bool NextState()
        {
            if (this.Neighbours == 3)
                return true;
            else if (this.Neighbours == 2)
                return this.State;
            else
                return false;
        }
    }
}