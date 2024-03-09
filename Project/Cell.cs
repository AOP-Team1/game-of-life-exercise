namespace Sebi
{
    public class Cell : ICell
    {
        public bool State { get; set; }
        public int Neighbours { get; set; }

        public Cell()
        { 
            State = false;
            Neighbours = 0;
        }

        public bool NextState(int Neighbours)
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