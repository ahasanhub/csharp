using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\Files\file1.txt",FileMode.Create,FileAccess.Write))
            {
                fs.WriteByte(100);
                fs.Position = 0;
                if (fs.CanRead)
                {
                    fs.ReadByte();
                }
                
            }
        }

        private static byte[] ReadBytes(System.IO.Stream stream)
        {
            //dataToRead will hold the data read from the stream
            byte[] dataToRead = new byte[stream.Length];
            //this is the number of bytes read. This will be incremented 
            // and eventully will equal the bytes size held by the stream
            int totalBytesRead = 0;
            //this is the number of bytes read in each iteration
            int chunkBytesRead = 1;
            while (totalBytesRead < dataToRead.Length && chunkBytesRead > 0)
            {
                chunkBytesRead = stream.Read(dataToRead, totalBytesRead, dataToRead.Length - totalBytesRead);
                totalBytesRead = totalBytesRead + chunkBytesRead;
            }
            return dataToRead;
        }
    }
}
