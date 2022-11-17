using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";

    private DataContainer? dataContainer;

    public ICollection<Post> Posts
    {
        get
        {
            LazyLoadData();
            return dataContainer!.posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LazyLoadData();
            return dataContainer!.users;
        }
    }

    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}