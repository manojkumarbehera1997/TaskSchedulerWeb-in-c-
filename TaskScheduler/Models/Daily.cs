using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler
{
    public class Daily
    {
        public string Id { get; set; }
        public string StartTrigger { get; set; }
        public short DaysInterval { get; set; }
    }
}
