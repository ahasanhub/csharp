using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Entity
    {
        private static int nextSerialNumber;
        private int serialNumber;

        public Entity()
        {
            serialNumber = nextSerialNumber++;
        }

        public int GetSerialNumber()
        {
            return serialNumber;
        }

        public static int GetNextSerialNumber()
        {
            return nextSerialNumber;
        }

        public static void SetNextSerialNumber(int value)
        {
            nextSerialNumber = value;
        }
    }
}
