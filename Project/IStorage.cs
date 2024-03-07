namespace Kacper;
using GameOfLife;

public interface IStorage
{
    public Grid Load();
    public void Save();
}
