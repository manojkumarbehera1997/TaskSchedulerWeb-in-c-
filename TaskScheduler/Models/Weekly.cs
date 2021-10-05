using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler
{
    public class Weekly
    {
        public string Id { get; set; }
        public string StartTrigger { get; set; }
        public string EndTrigger { get; set; }
        public short WeekDays { get; set; }
    }
}
