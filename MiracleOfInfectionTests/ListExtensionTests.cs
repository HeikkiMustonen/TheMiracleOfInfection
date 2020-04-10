using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MiracleOfInfectionLibrary;

namespace MiracleOfInfectionTests
{
    public class ListExtensionTests
    {
  
        public HumanFactory humanFactory = new HumanFactory();
        public List<Human> healthyHumans = new List<Human>();
        public Human sick = new Human();
        public Disease disease = new Disease("List Test Flue",3);

        [SetUp]
        public void SetUp()
        {
            healthyHumans = humanFactory.GetListOfHealthyHumans(100);
            sick.Infect(disease);
        }

        [Test]
        public void HasInfectedTest()
        {
            healthyHumans.Add(sick);
            bool val = healthyHumans.HasInfected();
            Assert.IsTrue(val);
        }

        [Test]
        public void GetInfectedTest()
        {
            healthyHumans.Add(sick);
            int val = healthyHumans.GetInfected().Count;
            Assert.IsTrue(val == 1);
        }

        [Test]
        public void GetHealthyTest()
        {
            int before = healthyHumans.Count;
            healthyHumans.Add(sick);
            int after = healthyHumans.GetHealthy().Count;
            Assert.IsTrue(before == after);
        }

        [Test]
        public void InfectAllTest()
        {
            int before = healthyHumans.Count;
            healthyHumans.InfectAll(disease);
            int after = healthyHumans.GetInfected().Count;
            Assert.IsTrue(before == after);
        }
    }
}
