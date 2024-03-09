namespace Francesco;
using Kacper;
using GameOfLife;
using System.Text.Json;
using Ignat;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class JsonStorage : IStorage
{
    private string filePath = @"..\..\..\grid_data.json";

    public void Save(IGrid grid)
    {
        //string jsonString = JsonSerializer.Serialize(grid, new JsonSerializerOptions() { WriteIndented = true });
        string jsonString = JsonConvert.SerializeObject(grid, Formatting.Indented);
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            outputFile.WriteLine(jsonString);
        }

    }

    public IGrid Load()
    {
        IGrid? grid = null;
        GridStorage? storage;

        using(StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();
            storage = JsonConvert.DeserializeObject<GridStorage>(json);
            if(storage != null) grid = new Grid(storage);
        }

        if (grid == null)
        {
            throw new Exception("Failed to load the file from Json!");
        }
        else return grid;
    }
}
