using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PasswordHasherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = Guid.NewGuid();
            var secrate = Guid.NewGuid();
            var hasher = new PasswordHasher();
            var passwordHash = hasher.HashPassword("mzaman9");
            var sd = hasher.VerifyHashedPassword(passwordHash, "mzaman9");
            Console.WriteLine(passwordHash);
        }
    }
}
