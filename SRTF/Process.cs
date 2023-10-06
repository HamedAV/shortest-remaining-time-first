using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRTF
{
    public class Process
    {
        public string old;
        public string ProcessId { get; set; }
        public int Priority { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public bool IsExecuting { get; set; }

        public Process(string processId, int priority, int arrivalTime, int burstTime)
        {
            old = "";
            ProcessId = processId;
            Priority = priority;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            IsExecuting = false;
        }

        public void Execute(int currentTime)
        {
            if (!string.Equals(old, ProcessId))
                Console.Write($"|{ProcessId} at {currentTime}|");
            old = ProcessId;
        }

        public void DecreaseBurstTime()
        {
            BurstTime--;
        }
    }
}
