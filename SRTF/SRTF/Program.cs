using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SRTF;
public class Program
{
    public static void Main(string[] args)
    {
        var path = "C:\\Users\\Hamed\\Desktop\\Input.txt";
        string[] lines = File.ReadAllLines(path);
        List<Process> processes = new List<Process>();
        foreach (var line in lines)
        {
            string fiValue = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[0];
            int sValue = Convert.ToInt32(line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int tValue = Convert.ToInt32(line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[2]);
            int fValue = Convert.ToInt32(line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[3]);
            processes.Add(new Process(fiValue, sValue, tValue, fValue));


        };

        SRTFHeapScheduler scheduler = new SRTFHeapScheduler();
        scheduler.ScheduleProcesses(processes);
    }
}