using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MiracleOfInfectionLibrary;

namespace MiracleOfInfectionTests
{
    public class WorkPlaceTests
    {

        WorkPlace defaultWorkPlace;
        HumanFactory humanFactory = new HumanFactory();
        Human human;
        Human infectedHuman;


        [SetUp]
        public void SetUp()
        {
            defaultWorkPlace = new WorkPlace();
            human = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman.diseases.Add(new Disease());
        }

        [Test]
        public void AddWorkerTest()
        {
            defaultWorkPlace.AddWorker(human);
            List<Human> workers = defaultWorkPlace.GetWorkers();
            Assert.True(workers.Count == 1);
        }

        [Test]
        public void HasInfectedTrueTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            
            defaultWorkPlace.AddWorkers(list);
            defaultWorkPlace.AddWorker(infectedHuman);

            bool hasInfected = defaultWorkPlace.HasInfectedHumans();
            Assert.True(hasInfected);
        }

        [Test]
        public void GetInfectedFalseTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            defaultWorkPlace.AddWorkers(list);
            bool hasInfected = defaultWorkPlace.HasInfectedHumans();
            Assert.IsFalse(hasInfected);
        }

        [Test]
        public void GetHealtyListTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            defaultWorkPlace.AddWorkers(list);
            Assert.IsTrue(defaultWorkPlace.GetHealthy().Count == 100);
        }
    }
}
