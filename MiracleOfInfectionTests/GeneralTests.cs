using System;
using System.Collections.Generic;
using System.Text;
using MiracleOfInfectionLibrary;
using NUnit.Framework;

namespace MiracleOfInfectionTests
{
    public class GeneralTests
    {
        private HumanFactory humanFactory;
        private Disease defaultDisease;
        private Human healthyHuman;
        private Human infectedHuman;
        private WorkPlace defaultWorkplace;
        [SetUp]
        public void SetUp()
        {
            humanFactory = new HumanFactory();
            defaultDisease = new Disease();
            healthyHuman = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman.diseases.Add(defaultDisease);
            defaultWorkplace = new WorkPlace();
        }

        [Test]
        public void WorkplaceInfection()
        {
            int iterations = 3;
            defaultWorkplace.AddWorkers(humanFactory.CreateListOfRandomHumans(100));
            defaultWorkplace.AddWorker(infectedHuman);                      
        }
    }
}
