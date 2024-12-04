using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskService
{
    void AddTask(string task);
    List<string> GetTasks();
    void RemoveTask(int index);
    Task SaveTasksToFileAsync();
    Task LoadTasksFromFileAsync();
}
