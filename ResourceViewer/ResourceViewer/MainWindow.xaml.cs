using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ResourceViewer
{
    public partial class MainWindow : Window
    {
        SystemData sd = new SystemData();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void Start()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            Int64 vmu = Convert.ToInt64(VirtualMemoryUsed());
            Int64 vmt = Convert.ToInt64(VirtualMemoryTotal());
            Int64 pmu = Convert.ToInt64(PhysicalMemoryUsed());
            Int64 pmt = Convert.ToInt64(PhysicalMemoryTotal());
            Int64 cpu = Convert.ToInt64(CPUUsed());

            sd.UpdateData(vmu, vmt, pmu, pmt, cpu);
            VisualiseValue();
        }

        private void VisualiseValue()
        {
            ProgressBarUsedVirtualMemory.Value = sd.PercentOfVirtualMemory;
            ProgressBarUsedPhysicalMemory.Value = sd.PercentOfPhysicalMemory;
            ProgressBarCPU.Value = sd.PercentOfCPU;
        }

        [DllImport("MonitoringLib", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static int sum(int a, int b);

        [DllImport("MonitoringLib", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static double VirtualMemoryTotal();

        [DllImport("MonitoringLib", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static double VirtualMemoryUsed();

        [DllImport("MonitoringLib", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static double PhysicalMemoryTotal();

        [DllImport("MonitoringLib", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static double PhysicalMemoryUsed();

        [DllImport("MonitoringLib", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static double CPUUsed();
    }
}
