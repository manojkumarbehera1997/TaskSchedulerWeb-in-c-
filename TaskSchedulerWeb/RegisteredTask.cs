using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskSchedulerWeb
{
    public class RegisteredTask
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Definition { get; set; }
        public string NextRunTime { get; set; }
        public string LastRunTime { get; set; }
        public string LastTaskResult { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }

    }
}