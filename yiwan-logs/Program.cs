using yiwan_logs;
using yiwan_logs.Controllers;

// solution start
Logger logger = new Logger();
TaskController taskController = new TaskController(1);
TaskController taskController2 = new TaskController(2);

// Arena
DateTime t0 = DateTime.Now;

taskController.HandleTask();
taskController2.HandleTask();
taskController.HandleTask(500);

DateTime t1 = DateTime.Now;
Console.WriteLine($"Time spent running logs : {t1 - t0}");
//