using System.Reflection.Metadata;

namespace Sebi
{
    public interface ICell
    {
        public bool State {get; set; }
        public int Neighbours {get; set; }
    }
}