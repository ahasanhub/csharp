using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuncActionPredicate
{
    [TestClass]
    public class Predicate
    {
        [TestMethod]
        public void PredecateTest()
        {
            Predicate<string> isValid = IsDate;
            string date = "1/1/2016";
            Debug.WriteLine(isValid(date) ? "Date is valid" : "Date is invalid");
        }

        private bool IsDate(string date)
        {
            DateTime dt;
            return DateTime.TryParse(date, out dt);
        }

    }
}
