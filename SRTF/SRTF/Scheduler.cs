using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRTF
{
    public class SRTFHeapScheduler
    {
        public void ScheduleProcesses(List<Process> processes)
        {
            int currentTime = 0;
            int totalProcesses = processes.Count;
            int executedProcesses = 0;

            var processHeap = new MinHeap<Process>(totalProcesses, new ProcessPriorityBurstTimeComparer());

            while (executedProcesses < totalProcesses)
            {
                // Check if any process has arrived
                for (int i = 0; i < processes.Count; i++)
                {
                    Process process = processes[i];
                    if (!process.IsExecuting && process.ArrivalTime <= currentTime)
                    {
                        processHeap.Insert(process);
                        process.IsExecuting = true;
                    }
                }

                if (!processHeap.IsEmpty())
                {

                    Process selectedProcess = processHeap.GetMin();

                    if (selectedProcess.BurstTime > 0)
                    {

                        selectedProcess.Execute(currentTime);
                        selectedProcess.DecreaseBurstTime();

                        if (selectedProcess.BurstTime > 0)
                        {
                            processHeap.Update(selectedProcess);
                        }
                        else
                        {
                            executedProcesses++;
                            processHeap.RemoveMin();
                        }
                    }
                }

                currentTime++;
            }
        }
    }



}
