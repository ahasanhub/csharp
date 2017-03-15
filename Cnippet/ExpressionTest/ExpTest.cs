using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTest
{
    [TestClass]
    public class ExpTest
    {
        [TestMethod]
        public void Main()
        {
            Expression<Func<int, int, int>> expression = (a, b) => a + b;
            Func<int, int, int> func = expression.Compile();
            var result = func(12,11);
        }
    }
}
