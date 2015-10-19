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
            try
            {
                if (args.Length == 4)
                    MergeSort.Sort(args[0], args[1], args[2], args[3]);
                if (args.Length == 3)
                    MergeSort.Sort(args[0], args[1], args[2]);
                if (args.Length == 2)
                    MergeSort.Sort(args[0], args[1]);
                else
                    Console.WriteLine("Must be 2 or 3 or 4 arguments");
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
