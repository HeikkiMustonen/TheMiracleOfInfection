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
            bool result = healthyHuman.InfectedByHuman(infectedHuman, infectedHuman.diseases[0]);
            
            TestContext.WriteLine("diseases count: "+healthyHuman.diseases.Count);
            TestHelper.PrintDiseaseLogToTestContext(healthyHuman.diseases[0]);
            Assert.IsTrue(result && healthyHuman.diseases.Count > 0);
        }

        [Test]
        public void InfectedByHumanFalseTest()
        {
            //make sick
            healthyHuman.InfectedByHuman(infectedHuman, infectedHuman.diseases[0]);
            
            //try to give the same disease again.
            bool result = healthyHuman.InfectedByHuman(infectedHuman, infectedHuman.diseases[0]);
            TestContext.WriteLine("diseases count: " + healthyHuman.diseases.Count);
            TestHelper.PrintDiseaseLogToTestContext(healthyHuman.diseases[0]);
            Assert.IsFalse(result && healthyHuman.diseases.Count ==1);
        }

        [Test]
        public void HasDiseaseTrueTest()
        {
            Human human = humanFactory.CreateRandomHumanWithDataTest();
            Disease disease = new Disease();
            human.Infect(disease);
            bool hasDisease = human.HasDisease(disease);
            TestHelper.PrintDiseaseLogToTestContext(disease);
            Assert.IsTrue(hasDisease == true);
        }

        [Test]
        public void HasDiseaseFalseTest()
        {
            Human human = humanFactory.CreateRandomHumanWithDataTest();
            Disease disease = new Disease();
           
            bool hasDisease = human.HasDisease(disease);
            TestHelper.PrintDiseaseLogToTestContext(disease);
            Assert.IsFalse(hasDisease);
        }


    }
}
