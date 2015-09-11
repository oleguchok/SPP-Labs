﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSorterLibrary
{
    public static class MergeSort
    {
        private class Pair<T1, T2>
        {
            public T1 Item1 { get; set; }
            public T2 Item2 { get; set; }
        }

        private static String pathOfSplits = Directory.GetCurrentDirectory();

        public static void Sort(String fileToSort, String userPathOfSplits,
            String pathOfSortFile)
        {
            pathOfSplits = userPathOfSplits;
            SortExecute(fileToSort, pathOfSplits, pathOfSortFile);
        }

        public static void Sort(String fileToSort, String pathOfSortFile)
        {
            SortExecute(fileToSort, pathOfSplits, pathOfSortFile);
        }

        private static void SortExecute(String fileToSort, String userPathOfSplits,
            String pathOfSortFile)
        {
            Split(fileToSort, userPathOfSplits);
            SortTheChunks(userPathOfSplits);
            MergeTheChunks(userPathOfSplits, pathOfSortFile);
        }

        static void Split(String filePath, String pathOfSplits)
        {
            try
            {
                Int32 splitsCounter = 1;
                StreamWriter sw = new StreamWriter(
                String.Format(pathOfSplits + "\\split{0:d5}.dat", splitsCounter));
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.Peek() >= 0)
                    {
                        sw.WriteLine(sr.ReadLine());

                        if (sw.BaseStream.Length > 10000000 && sr.Peek() >= 0)
                        {
                            sw.Close();
                            sw = new StreamWriter(String.Format(pathOfSplits +
                                "split{0:d5}.dat", ++splitsCounter));
                        }
                    }
                }
                sw.Close();
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        static void SortTheChunks(String pathOfSplits)
        {
            try
            {
                foreach (String path in Directory.GetFiles(pathOfSplits, "split*.dat"))
                {
                    String[] contents = File.ReadAllLines(path);
                    Array.Sort(contents);
                    File.WriteAllLines(path, contents);
                    contents = null;
                    GC.Collect();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static void MergeTheChunks(String pathOfSplits, String pathOfSortFile)
        {
            try
            {
                String[] paths = Directory.GetFiles(pathOfSplits, "split*.dat");
                Pair<StreamReader, String>[] chunks = GetInitializedPairOfReaders(paths);
                var index = 0;
                using (StreamWriter sw = new StreamWriter(pathOfSortFile))
                {
                    while (chunks.Length != 0)
                    {
                        index = GetSortStringIndexFromPairs(chunks);
                        sw.WriteLine(chunks[index].Item2);
                        chunks = GetNextElementAndFixReader(chunks, index);
                    }
                }

                DeleteFiles(paths);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static Pair<StreamReader, String>[] GetNextElementAndFixReader(
            Pair<StreamReader, String>[] chunks, Int32 index)
        {
            chunks[index].Item2 = GetLineFromReader(chunks[index].Item1);
            return CleanFromEmptyPairs(chunks);
        }

        private static Int32 GetSortStringIndexFromPairs(Pair<StreamReader, String>[] chunks)
        {
            Int32 temp = 0;
            for (Int32 i = 1; i < chunks.Length; i++)
            {
                if (chunks[i].Item2.CompareTo(chunks[temp].Item2) < 0)
                    temp = i;
            }
            return temp;
        }

        private static Pair<StreamReader, String>[] GetInitializedPairOfReaders(String[] paths)
        {
            Pair<StreamReader, String>[] pairs = new Pair<StreamReader, String>[paths.Length];
            for(var i = 0; i < paths.Length; i++)
            {
                pairs[i] = new Pair<StreamReader, String>();
                pairs[i].Item1 = new StreamReader(paths[i]);
                pairs[i].Item2 = GetLineFromReader(pairs[i].Item1);
            }
            return CleanFromEmptyPairs(pairs);
        }

        private static Pair<StreamReader, String>[] CleanFromEmptyPairs(Pair<StreamReader, String>[] pairs)
        {
            pairs = CloseReaders(pairs);            
            return pairs.Where(x => x.Item2 != null).ToArray();
        }

        private static Pair<StreamReader, String>[] CloseReaders(Pair<StreamReader, String>[] pairs)
        {
            foreach (var pair in pairs)
                if (pair.Item2 == null)
                    pair.Item1.Close();
            return pairs;
        }

        private static String GetLineFromReader(StreamReader sr)
        {
            if (sr.Peek() >= 0)
                return sr.ReadLine();
            else
                return null;
        }

        private static void DeleteFiles(string[] paths)
        {
            foreach(String path in paths)
            {
                File.Delete(path);
            }
        }

    }

}
