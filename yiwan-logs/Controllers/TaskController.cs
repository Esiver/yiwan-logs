using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yiwan_logs.Controllers
{
    internal class TaskController
    {
        int Id { get; set; }
        Logger Logger { get; set; }
        


        public TaskController(int id) 
        {
            this.Id = id;
            this.Logger = new Logger();
        }

        public void handleTask(int tasks = 10000) 
        {
            for (int i = 0; i < tasks; i++)
            {
                this.Logger.TryLogAsync($"logging from logger id {this.Id} - task entry {i}", Logger.Level.Info);
            }
        }
    }
}
