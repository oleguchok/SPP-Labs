using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSorterLibrary
{
    public static class MergeSort
    {
        private static String pathOfSplits;

        static void Split(String filePath)
        {
            Int32 splitsCounter = 1;
            StreamWriter sw = new StreamWriter(
            String.Format(pathOfSplits + "split{0:d5}.dat", splitsCounter));
            Int64 linesCounter = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    if (++linesCounter % 5000 == 0)
                        Console.WriteLine("{0:f2}% \r",
                            100.0 * sr.BaseStream.Position / sr.BaseStream.Length);

                    sw.WriteLine(sr.ReadLine());

                    if (sw.BaseStream.Length > 100000000 && sr.Peek() >= 0)
                    {
                        sw.Close();
                        sw = new StreamWriter(String.Format(pathOfSplits + 
                            "split{0:d5}.dat", ++splitsCounter));
                    }
                }
            }
            sw.Close();
        }

        static void SortTheChunks()
        {
            foreach (String path in Directory.GetFiles(pathOfSplits, "split*.dat"))
            {
                String[] contents = File.ReadAllLines(path);
                Array.Sort(contents);
                File.WriteAllLines(path, contents);
                contents = null;
                GC.Collect();
            }
        }

        static void MergeTheChunks()
        {
            String[] paths = Directory.GetFiles(pathOfSplits, "split*.dat");
            Int32 numberOfChunks = paths.Length;
        }
    }
}
