using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler
{
    public class MonthlyDOW
    {
        public string Id { get; set; }
        public string StartTrgger { get; set; }
        public string EndTrigger { get; set; }
        public short Month { get; set; }
        public bool LastWeek { get; set; }
        public short Week { get; set; }
        public short Days { get; set; }

    }
}
