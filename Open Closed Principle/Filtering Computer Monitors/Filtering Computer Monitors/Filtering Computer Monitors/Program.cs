using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering_Computer_Monitors
{
    public enum Screen
    {
        WideScreen,
        CurvedScreen
    }
    public enum MonitorType
    {
        OLED,
        LCD,
        LED
    }
    public class ComputerMonitor
    {
        public string Name { get; set; }
        public MonitorType Type { get; set; }
        public Screen Screen { get; set; }
    }

    public interface ISpecification<in T>
    {
        bool IsSatisfied(T item);
    }

    public interface IFilter<T>
    {
        List<T> Filter(IEnumerable<T> monitors, ISpecification<T> specification);
    }

    public class MonitorTypeSpecification : ISpecification<ComputerMonitor>
    {
        private readonly MonitorType _type;

        public MonitorTypeSpecification(MonitorType type)
        {
            _type = type;
        }

        public bool IsSatisfied(ComputerMonitor item) => item.Type == _type;
    }

    public class MonitorFilter : IFilter<ComputerMonitor>
    {
        public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors, ISpecification<ComputerMonitor> specification) =>
            monitors.Where(m => specification.IsSatisfied(m)).ToList();
    }


    /*public class MonitorFilter
    {
        public List<ComputerMonitor> FilterByType(IEnumerable<ComputerMonitor> monitors, MonitorType type) =>
            monitors.Where(m => m.Type == type).ToList();

        public List<ComputerMonitor> FilterByScreen(IEnumerable<ComputerMonitor> monitors, Screen screen) =>
            monitors.Where(x => x.Screen == screen).ToList();
    }*/


    class Program
    {
        static void Main(string[] args)
        {
            var monitors = new List<ComputerMonitor>
            {
                new ComputerMonitor { Name = "Samsung S345", Screen = Screen.CurvedScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Philips P532", Screen = Screen.WideScreen, Type = MonitorType.LCD },
                new ComputerMonitor { Name = "LG L888", Screen = Screen.WideScreen, Type = MonitorType.LED },
                new ComputerMonitor { Name = "Samsung S999", Screen = Screen.WideScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Dell D2J47", Screen = Screen.CurvedScreen, Type = MonitorType.LCD }
            };

            var filter = new MonitorFilter();

            //upcasting
            //polymorphism
            var lcdMonitors = filter.Filter(monitors, new MonitorTypeSpecification(MonitorType.LCD));
            Console.WriteLine("All LCD monitors");
            foreach (var monitor in lcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }
        }
    }
}
