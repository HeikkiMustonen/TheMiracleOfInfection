using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MiracleOfInfectionLibrary;

namespace MiracleOfInfectionTests
{
    public class HumanTests
    {
        public Human healthyHuman;
        public Human healthyHuman2;
        public Human infectedHuman;
        private HumanFactory humanFactory = new HumanFactory();

        [SetUp]
        public void SetUp()
        {
            healthyHuman = humanFactory.CreateRandomHumanWithDataTest();
            healthyHuman2 = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman = HumanFactory.GetInfectedHuman();

        }

        [Test]
        public void InfectedByHumanTest()
        {
            healthyHuman.InfectedByHuman(infectedHuman, infectedHuman.diseases[0]);
            
            TestContext.WriteLine("diseases log count: "+healthyHuman.diseases.Count);
            TestHelper.PrintDiseaseLogToTestContext(healthyHuman.diseases[0]);
            Assert.IsTrue(healthyHuman.diseases.Count > 0);

        }

    }
}
