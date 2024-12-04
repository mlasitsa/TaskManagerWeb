using Microsoft.AspNetCore.Mvc;

public class TaskController : Controller
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        var tasks = _taskService.GetTasks();
        return View(tasks);
    }

    [HttpPost]
    public IActionResult Add(string task)
    {
        if (!string.IsNullOrEmpty(task))
        {
            _taskService.AddTask(task);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remove(int index)
    {
        _taskService.RemoveTask(index);
        return RedirectToAction("Index");
    }
}
