using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MiracleOfInfectionLibrary;

namespace MiracleOfInfectionTests
{
    public class WorkPlaceTests
    {

        WorkPlace workPlace;
        HumanFactory humanFactory = new HumanFactory();
        Human human;
        Human infectedHuman;


        [SetUp]
        public void SetUp()
        {
            workPlace = new WorkPlace();
            workPlace.contactRating = 5;
            
            human = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman.diseases.Add(new Disease());
        }

        [Test]
        public void AddWorkerTest()
        {
            workPlace.AddWorker(human);
            List<Human> workers = workPlace.GetWorkers();
            Assert.True(workers.Count == 1);
        }

        [Test]
        public void HasInfectedTrueTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            
            workPlace.AddWorkers(list);
            workPlace.AddWorker(infectedHuman);

            bool hasInfected = workPlace.HasInfectedHumans();
            Assert.True(hasInfected);
        }

        [Test]
        public void GetInfectedFalseTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            workPlace.AddWorkers(list);
            bool hasInfected = workPlace.HasInfectedHumans();
            Assert.IsFalse(hasInfected);
        }

        [Test]
        public void GetHealtyListTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            workPlace.AddWorkers(list);
            Assert.IsTrue(workPlace.GetHealthy().Count == 100);
        }


        [Test]
        public void ConctactCheckTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            workPlace.AddWorkers(list);
            workPlace.AddWorker(infectedHuman);
            workPlace.contactRating = 5;
            int modifier = 10;
            List<Human> contacted = workPlace.ContactCheck(infectedHuman, workPlace.GetHumans(),modifier);
            TestHelper.PrintHumanListWithNamesOnlyToTestContext(contacted);
            Assert.Pass();
        }

        [Test]
        public void InfectionIterationTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(100);
            workPlace.AddWorkers(list);

            Disease disease = new Disease("TurboKuppa", 5);
            Human sick = humanFactory.CreateRandomHumanWithDataTest();
            sick.Infect(disease);
            workPlace.AddWorker(sick);

            workPlace.contactRating = 5;

            for (int i = 0; i < 10; i++)
            {
                TestContext.WriteLine($"Iteration {i} \n");
                
                TestContext.WriteLine("---Healthy -----");
                TestContext.WriteLine(workPlace.GetHealthy().Count);
                TestContext.WriteLine("--- Sick -----");
                TestHelper.PrintHumanListWithNamesOnlyToTestContext(workPlace.GetInfected());

                InfectionTestInWorkPlace(workPlace);
            }

            Assert.Pass();
        }

        public void InfectionTestInWorkPlace(Place place)
        {
            List<Human> infected = place.GetHumans().GetInfected();
            List<Human> healthy = place.GetHumans().GetHealthy();
            foreach (Human sick in infected)
            {
                List<Human> wasInContact = place.ContactCheck(sick, healthy);
                DiseaseManager.RollInfectionAgainsGroup(sick, wasInContact);
            }
        }
    }
}
