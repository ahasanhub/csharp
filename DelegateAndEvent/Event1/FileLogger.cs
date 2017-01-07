using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event1
{
    //The FileLogger class merely encapsulates the file I/O
    public class FileLogger
    {
        public FileStream fileStream;
        public StreamWriter streamWriter;
        //Constractor
        public FileLogger(string filename)
        {
            fileStream=new FileStream(filename,FileMode.Create);
            streamWriter=new StreamWriter(fileStream);
        }
        //Member Function which is used in the Delegate
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
