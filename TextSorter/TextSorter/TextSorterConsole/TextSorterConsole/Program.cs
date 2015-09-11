using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSorterLibrary;

namespace TextSorterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort.Sort("c:\\OLEGDATA\\tt.txt", "c:\\OLEGDATA\\", "c:\\OLEGDATA\\sort.txt");
            StreamReader sr = new StreamReader("c:\\OLEGDATA\\sort.txt");
            while (sr.Peek() > 0)
            {
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine("----");
            }
            sr.Close();
        }
    }
}
