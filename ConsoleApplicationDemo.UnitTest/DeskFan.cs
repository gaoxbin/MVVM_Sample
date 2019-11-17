using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplicationDemo;
namespace ConsoleApplicationDemo.UnitTest
{
    [TestClass]
    public class DeskFan
    {
        [TestMethod]
        public void PowerLowerThanZero_OK()
        {
            var fan = new Program.DeskFan(new PowerSupplyLowerThanZeron());
            var expected = "Won't work.";
            var actual = fan.Work();

            Assert.AreEqual(expected, actual);

            
        }

        class PowerSupplyLowerThanZeron : Program.IPowerSupply
        {
            public int GetPower()
            {
                return 0;
            }
        }

    }
}
