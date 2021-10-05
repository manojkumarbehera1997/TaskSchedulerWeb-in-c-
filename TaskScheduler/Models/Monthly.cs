using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler
{
    public class Monthly
    {
        public string StartTrigger { get; set; }
        public string EndTrigger { get; set; }
        public short Month { get; set; }
        public bool LastDay { get; set; }
        public short Days { get; set; }
    }
}
