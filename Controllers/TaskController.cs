using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IActionResult> Index()
    {
        await _taskService.LoadTasksFromFileAsync();
        var tasks = _taskService.GetTasks();
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Add(string task)
    {
        if (!string.IsNullOrEmpty(task))
        {
            _taskService.AddTask(task);
            await _taskService.SaveTasksToFileAsync();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int index)
    {
        _taskService.RemoveTask(index);
        await _taskService.SaveTasksToFileAsync();
        return RedirectToAction("Index");
    }
}
