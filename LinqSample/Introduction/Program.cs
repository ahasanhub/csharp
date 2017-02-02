using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFileWithoutLinq(path);
            Console.WriteLine("***************************");
            ShowLargeFileWithLinq(path);
            Console.ReadKey();
        }

        private static void ShowLargeFileWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles().OrderByDescending(f => f.Length).Take(5);
                //orderby file.Length descending
                //select file;
            foreach (var file in query)
            {
                Console.WriteLine($"{file.Name,-20}:{file.Length,10:N0}");
            }
        }

        private static void ShowLargeFileWithoutLinq(string path)
        {
            DirectoryInfo directory=new DirectoryInfo(path);
            FileInfo[] files=directory.GetFiles();
            Array.Sort(files,new FileInfoCompare());
            for (int i=0;i<5;i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name, -20}:{file.Length, 10:N0}");
            }
            
        }
    }

    public class FileInfoCompare : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
