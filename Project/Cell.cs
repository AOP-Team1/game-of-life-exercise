namespace Sebi
{
    public class Cell : ICell
    {
        public bool State {get; set; }
        public int Neighbours {get; set; }

        public bool NextState(int Neighbours)
        {
            if(this.Neighbours == 3)
                return true;
            else 
                return false;
        }
    }
}