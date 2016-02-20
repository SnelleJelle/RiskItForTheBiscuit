using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskItForTheBiscuit.Risk;

namespace RiskItForTheBiscuitTest
{
    [TestClass]
    public class TerritoryTest
    {
        Territory territory;


        [TestInitialize]
        public void Initialize()
        {
            territory = new Territory("test");
        }

        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("test", territory.Name);
        }
    }
}
