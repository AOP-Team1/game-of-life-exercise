using GameOfLife;
using Ignat;
using Kacper;
using Newtonsoft.Json;
using Sebi;
using Francesco;

namespace Project.Test;

public class JsonStorage : IStorage
{
    private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grid_data.json");

    public void Save(IGrid grid)
    {
        string jsonString = JsonConvert.SerializeObject(grid, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);
    }

    public IGrid Load()
    {
        IGrid? grid = null;
        GridStorage? storage;

        try
        {
            string json = File.ReadAllText(filePath);
            storage = JsonConvert.DeserializeObject<GridStorage>(json);
            if (storage != null) grid = new Grid(storage);
        }
        catch (FileNotFoundException)
        {
            throw new Exception("Failed to load the file from Json!");
        }

        return grid ?? throw new Exception("Failed to load the file from Json!");
    }

    public bool IsValidJson()
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                while (jsonReader.Read())
                {
                    // Reading the JSON without deserializing
                }

                return true;
            }
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}

public class JsonStorageTest
{

    private const string TestFilePath = @"grid_data.json";


    [Fact]
    public void Save_SavesGridToFile()
    {
        var fakeGrid = new FakeGrid();
        var storage = new JsonStorage();

        storage.Save(fakeGrid);

        Console.WriteLine($"File path: {TestFilePath}");
        Assert.True(File.Exists(TestFilePath), "Should Exist After Saving The Grid");

        File.Delete(TestFilePath);
    }

    [Fact]
    public void Load_LoadsGridFromFile()
    {

        var fakeGrid = new FakeGrid();
        var storage = new JsonStorage();
        storage.Save(fakeGrid);

        Console.WriteLine($"File path: {TestFilePath}");
        var loadedGrid = storage.Load();

        Assert.NotNull(loadedGrid);

        File.Delete(TestFilePath);
    }

    [Fact]
    public void Load_ThrowsExceptionIfFileNotFound()
    {
        var storage = new JsonStorage();
        Assert.Throws<Exception>(() => storage.Load());
    }

    [Fact]
    public void IsValidJson_ReturnsTrueForValidJson()
    {
        var storage = new JsonStorage();
        var fakeGrid = new FakeGrid();
        storage.Save(fakeGrid);

        Console.WriteLine($"File path: {TestFilePath}");

        // Act
        var isValidJson = storage.IsValidJson();

        // Assert
        Assert.True(isValidJson, "The JSON should be valid");

        File.Delete(TestFilePath);
    }

    [Fact]
    public void IsValidJson_ReturnsFalseForInvalidJson()
    {
        var storage = new JsonStorage();

        // Write invalid JSON to the file
        File.WriteAllText(TestFilePath, "Invalid JSON");

        // Act
        var isValidJson = storage.IsValidJson();

        // Assert
        Assert.False(isValidJson, "The JSON should be invalid");

        // Cleanup: Delete the temporary file
        File.Delete(TestFilePath);
    }


}


public class FakeGrid : IGrid
{
    public int Rows => 3;
    public int Columns => 3;
    public bool[,] JsonCells { get; } = new bool[3, 3];
    public ICell GetCell(int row, int column) => throw new NotImplementedException();
    public void UpdateCellState(int row, int column, bool newState) => throw new NotImplementedException();
    public int CountLiveNeighbors(int row, int column) => throw new NotImplementedException();
    public void CalculateLiveNeighbors() => throw new NotImplementedException();
    public bool[] GetCellStatus() => throw new NotImplementedException();
    public bool IsGridAlive() => throw new NotImplementedException();

}
