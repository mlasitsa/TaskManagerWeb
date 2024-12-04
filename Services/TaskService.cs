using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class TaskService : ITaskService
{
    private readonly List<string> _tasks = new();
    private const string FilePath = "tasks.json";

    public void AddTask(string task)
    {
        _tasks.Add(task);
    }

    public List<string> GetTasks()
    {
        return new List<string>(_tasks); // Return a copy to avoid external modification
    }

    public void RemoveTask(int index)
    {
        if (index >= 0 && index < _tasks.Count)
            _tasks.RemoveAt(index);
    }

    public async Task SaveTasksToFileAsync()
    {
        var json = JsonSerializer.Serialize(_tasks);
        await File.WriteAllTextAsync(FilePath, json);
    }

    public async Task LoadTasksFromFileAsync()
    {
        if (File.Exists(FilePath))
        {
            var json = await File.ReadAllTextAsync(FilePath);
            var loadedTasks = JsonSerializer.Deserialize<List<string>>(json);
            if (loadedTasks != null)
            {
                _tasks.Clear(); // Prevent duplication
                _tasks.AddRange(loadedTasks);
            }
        }
    }
}
