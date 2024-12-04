# Task Manager Web Application

## Description
The **Task Manager Web Application** is a simple and functional web-based tool for managing tasks. It allows users to add, view, and remove tasks, with the added benefit of persisting tasks across sessions using a JSON file. The project was developed in **ASP.NET Core MVC** and adheres to core software engineering principles such as dependency injection, the decorator pattern, and the single responsibility principle.

---

## Features

### Core Functionality:
- **Add Tasks**: Users can add tasks using the Task Manager page.
- **View Tasks**: Displays a list of all tasks with clear numbering.
- **Remove Tasks**: Allows users to remove tasks by selecting the corresponding "Remove" button.

### Technical Features Implemented:
1. **[10 points] Dependency Injection**:
   - `TaskService` was registered in the dependency injection container and injected into the `TaskController` and `LoggingTaskService`.

2. **[10 points] Single Responsibility Principle**:
   - Separate components for specific tasks:
     - `TaskService` manages task operations.
     - `LoggingTaskService` logs operations without modifying the original service.
     - `TaskController` handles user requests and delegates tasks to services.

3. **[10 points] Asynchronous Methods**:
   - Task saving and loading are implemented using `async` and `await` to ensure non-blocking I/O operations.

4. **[10 points] The Decorator Pattern**:
   - `LoggingTaskService` wraps `TaskService` to log actions like adding, removing, saving, and loading tasks without altering the core service logic.

5. **[10 points] Multiple Web Pages**:
   - A **Home** page with a welcome message and navigation links.
   - A **Task Manager** page to manage tasks.
   - A layout with consistent navigation across all pages.

---

## How the Application Behaves

### Home Page:
- Provides a welcome message and links to the Task Manager.
- Acts as the entry point of the application.

### Task Manager Page:
- Users can:
  - Add tasks by entering text and clicking the "Add Task" button.
  - View the current task list, which updates dynamically.
  - Remove tasks by clicking the "Remove" button next to each task.

### Data Persistence:
- Tasks are saved to a JSON file (`tasks.json`) and automatically loaded when the application starts, ensuring tasks persist across sessions.

### Logging:
- The decorator logs all task operations (add, remove, save, and load) to the terminal for debugging and tracking.

---

## Issues Encountered

1. **Duplicate Task Logging**:
   - Initial implementation caused redundant logs due to multiple calls to `LoadTasksFromFileAsync` and `GetTasks` in the controller.
   - **Fix**: Modified the `TaskController` to load tasks only once during the application's lifecycle.

2. **Task Duplication**:
   - Tasks were being duplicated due to `LoadTasksFromFileAsync` appending tasks to the existing list without clearing it.
   - **Fix**: Added `_tasks.Clear()` in `LoadTasksFromFileAsync` to reset the task list before reloading from the JSON file.

3. **Redundant View Rendering**:
   - Minor issues with re-rendering views unnecessarily.
   - **Fix**: Streamlined controller actions to avoid redundant calls.

---

## Technologies Used
- **Language**: C#
- **Framework**: ASP.NET Core MVC
- **Data Storage**: JSON file (`tasks.json`)
- **Design Patterns**: Dependency Injection, Decorator Pattern
- **Frontend**: HTML and Razor Views

---

## How to Run the Project

1. Clone the repository:
   ```bash
   git clone <[repository-url](https://github.com/mlasitsa/TaskManagerWeb)>
   cd TaskManagerWeb
2. Build and run the project:
   ```bash
   dotnet run
