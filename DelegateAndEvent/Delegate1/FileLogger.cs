using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate1
{
    public class FileLogger
    {
        private FileStream fileStream;
        private StreamWriter streamWriter;

        public FileLogger(string filename)
        {
            fileStream =new FileStream(filename,FileMode.Create);
            streamWriter=new StreamWriter(fileStream);
        }
        //Member function which is used in the delegate
        public void Logger(string message)
        {
            streamWriter.WriteLine(message);
        }

        public void Close()
        {
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
