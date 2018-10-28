using Microsoft.VisualStudio.TestTools.UnitTesting;
using BFInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFInterpreter.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void InterpretTest()
        {
            string input = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";
            string expectedResult = "Hello World!\n";

            string actualResult = Program.Interpret(input);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}