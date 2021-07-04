using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Making_the_Code_Even_Better
{
    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int SpentHours { get; set; }
    }

    public interface IEntryManager<T>
    {
        void AddEntry(T entry);
        void RemoveAT(int index);
    }

    public class WorkReport : IEntryManager<WorkReportEntry>
    {
        private readonly List<WorkReportEntry> _entries;
        public WorkReport()
        {
            _entries = new List<WorkReportEntry>();
        }
        public void AddEntry(WorkReportEntry entry)
        {
            _entries.Add(entry);
        }
        public void RemoveAT(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries.Select(x => $"Code : {x.ProjectCode} , Name : {x.ProjectName} , Hours : {x.SpentHours}"));
        }

    }

    public class FileSaver
    {
        public void SaveToFile(string directoryPath, string fileName, string content)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.AppendAllText(Path.Combine(directoryPath, fileName), contents: content);
        }
    }

    public class ScheduleTask
    {
        public int TaskId { get; set; }
        public string Content { get; set; }
        public DateTime ExecuteOn { get; set; }

    }

    public class Scheduler : IEntryManager<ScheduleTask>
    {
        private readonly List<ScheduleTask> _tasks;
        public Scheduler()
        {
            _tasks = new List<ScheduleTask>();
        }

        public void AddEntry(ScheduleTask entry) => _tasks.Add(entry);

        public void RemoveAT(int index) => _tasks.RemoveAt(index);

        public override string ToString() =>
            string.Join(Environment.NewLine, _tasks.Select(x => $"Task with id: {x.TaskId} with content: {x.Content} is going to be executed on: {x.ExecuteOn}"));
    }


    class Program
    {
        static void Main(string[] args)
        {
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });

            var scheduler = new Scheduler();
            scheduler.AddEntry(new ScheduleTask { TaskId = 1, Content = "Do something now.", ExecuteOn = DateTime.Now.AddDays(5) });
            scheduler.AddEntry(new ScheduleTask { TaskId = 2, Content = "Don't forget to...", ExecuteOn = DateTime.Now.AddDays(2) });

            Console.WriteLine(report.ToString());
            Console.WriteLine(scheduler.ToString());

            var fileSaver = new FileSaver();
            fileSaver.SaveToFile(@"c:\test1", "WorkReport.txt", report.ToString());

        }
    }
}
