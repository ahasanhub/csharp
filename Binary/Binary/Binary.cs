using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binary
{
    [TestClass]
    public class Binary
    {
        [TestMethod]
        public void BinaryTest()
        {
           var binary=StringToBinary("Hello World");
           Debug.WriteLine(binary);
           string message = BinaryToString(binary);
           Debug.WriteLine(message);
        }

        private string BinaryToString(string binary)
        {
            List<byte> bytes=new List<byte>();
            for (int i = 0; i < binary.Length; i+=8)
            {
                bytes.Add(Convert.ToByte(binary.Substring(i,8),2));
            }
            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        private string StringToBinary(string message)
        {
            StringBuilder sb=new StringBuilder();
            foreach (char c in message.ToCharArray())
            {
                var dfg = Convert.ToString(c, 2);
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
    }
}
