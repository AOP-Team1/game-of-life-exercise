namespace Kacper;
using GameOfLife;
using Ignat;

public interface IStorage
{
    public IGrid Load();
    public void Save(IGrid grid);
}
