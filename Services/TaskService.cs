using System.Collections.Generic;

public class TaskService
{
    private readonly List<string> _tasks = new();

    public void AddTask(string task)
    {
        _tasks.Add(task);
    }

    public List<string> GetTasks()
    {
        return _tasks;
    }

    public void RemoveTask(int index)
    {
        if (index >= 0 && index < _tasks.Count)
            _tasks.RemoveAt(index);
    }
}
