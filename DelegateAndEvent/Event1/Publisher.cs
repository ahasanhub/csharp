using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event1
{
    public delegate string MyDel(string str);
    public class Publisher
    {
        public event MyDel MyEvent;
        public Publisher()
        {
            MyEvent+=WelcomeUser;
        }

        public string WelcomeUser(string username)
        {
           return $"Welcome {username}";
        }
    }
}
