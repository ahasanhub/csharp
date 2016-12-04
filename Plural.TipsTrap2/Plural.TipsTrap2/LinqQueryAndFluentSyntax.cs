using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Plural.TipsTrap2
{
    [TestClass]
    public class LinqQueryAndFluentSyntax
    {
        private static readonly List<string> Names=new List<string> {"Ahasan","Zayn","Shapla"};
        [TestMethod]
        public void SingleOperator()
        {
            var querySyntax = from n in Names
                where n == "Zayn"
                select n;
            var fluentSyntax = Names.Where(n => n == "Zayn");
        }
    }
}
