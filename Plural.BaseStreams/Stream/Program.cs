using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.Create(@"C:\Files\file1.txt"))
            {
                //Position is 0
                long pos = fs.Position;

                //Set the position to 1
                fs.Position = 1;
                byte[] arrayBytes = {100, 101};
                //writes the content of arrayBytes into current position - which is 1
                fs.Write(arrayBytes,0,arrayBytes.Length);
                //positon is now 3 as its advanced by write
                pos = fs.Position;
                fs.Position = 0;
                byte[] readData1 = ReadBytes(fs);
            }
        }

        private static byte[] ReadBytes(System.IO.Stream stream)
        {
            //dataToRead will hold the data read from the stream
            byte[] dataToRead=new byte[stream.Length];
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
