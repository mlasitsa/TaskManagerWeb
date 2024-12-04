using System.Collections.Generic;
using System.Threading.Tasks;
using System;

public class LoggingTaskService : ITaskService
{
    private readonly ITaskService _innerService;

    public LoggingTaskService(ITaskService innerService)
    {
        _innerService = innerService;
    }

    public void AddTask(string task)
    {
        Console.WriteLine($"[LOG] Adding task: {task}");
        _innerService.AddTask(task);
    }

    public List<string> GetTasks()
    {
        Console.WriteLine("[LOG] Retrieving tasks");
        return _innerService.GetTasks();
    }

    public void RemoveTask(int index)
    {
        Console.WriteLine($"[LOG] Removing task at index: {index}");
        _innerService.RemoveTask(index);
    }

    public async Task SaveTasksToFileAsync()
    {
        Console.WriteLine("[LOG] Saving tasks to file");
        await _innerService.SaveTasksToFileAsync();
    }

    public async Task LoadTasksFromFileAsync()
    {
        Console.WriteLine("[LOG] Loading tasks from file");
        await _innerService.LoadTasksFromFileAsync();
    }
}
 