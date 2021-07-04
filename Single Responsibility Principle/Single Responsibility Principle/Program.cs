using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Unicode;

namespace Single_Responsibility_Principle
{
    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int SpentHours { get; set; }
    }

    public class WorkReport
    {
        private readonly List<WorkReportEntry> _entries;
        public WorkReport()
        {
            _entries = new List<WorkReportEntry>();
        }
        public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);

        public void RemoveEntryAt(int index) => _entries.RemoveAt(index);

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries.Select(x => $"Code : {x.ProjectCode} , Name : {x.ProjectName} , Hours : {x.SpentHours}"));
        }

    }
    public class FileSaver
    {
        public void SaveToFile(string directoryPath, string fileName,string textToWrite)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), contents: textToWrite.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry() { ProjectCode = "12345", ProjectName = "Identity", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry() { ProjectCode = "8db5", ProjectName = "Logging", SpentHours = 6 });

            Console.WriteLine(report.ToString());

            var saver = new FileSaver();
            saver.SaveToFile(@"c:\test1", "WorkReport.txt",report.ToString());
        }
    }
}
