using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceViewer
{
    public class SystemData
    {
        private Int64 virtualMemoryTotal;
        private Int64 virtualMemoryUsed;
        private Int64 physicalMemoryTotal;
        private Int64 physicalMemoryUsed;
        private Int64 cpu;

        public Int64 PercentOfVirtualMemory { get; set; }
        public Int64 PercentOfPhysicalMemory { get; set; }
        public Int64 PercentOfCPU { get; set; }

        public SystemData()
        {
            virtualMemoryTotal = 0;
            virtualMemoryUsed = 0;
            physicalMemoryTotal = 0;
            physicalMemoryUsed = 0;
            cpu = 0;

            PercentOfVirtualMemory = 0;
            PercentOfPhysicalMemory = 0;
            PercentOfCPU = 0;
        }

        public void UpdateData(Int64 virtualMemoryUsed, Int64 virtualMemoryTotal,
            Int64 physicalMemoryUsed, Int64 physicalMemoryTotal, Int64 cpu)
        {
            this.virtualMemoryUsed = virtualMemoryUsed;
            this.virtualMemoryTotal = virtualMemoryTotal;
            this.physicalMemoryUsed = physicalMemoryUsed;
            this.physicalMemoryTotal = physicalMemoryTotal;
            this.cpu = cpu;
            RecountData();
        }

        public void UpdateData(Int64 virtualMemoryUsed, Int64 physicalMemoryUsed, Int64 cpu)
        {
            this.virtualMemoryUsed = virtualMemoryUsed;
            this.physicalMemoryUsed = physicalMemoryUsed;
            this.cpu = cpu;
            RecountData();
        }

        private void RecountData()
        {
            PercentOfVirtualMemory = (virtualMemoryTotal == 0) ? (0) : (Convert.ToInt64(((double)virtualMemoryUsed  / (double)virtualMemoryTotal)*100));
            PercentOfPhysicalMemory = (physicalMemoryTotal == 0) ? (0) : (Convert.ToInt64(((double)physicalMemoryUsed / (double)physicalMemoryTotal) * 100));
            PercentOfCPU = cpu;
        }
    }
}
