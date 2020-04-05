using MiracleOfInfectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace MiracleOfInfectionTests
{
    public class DiseaseTests
    {
        public Disease disease;
        public HumanFactory humanFactory;
        [SetUp]
        public void SetUp()
        {
            disease = new Disease();
            humanFactory = new HumanFactory();
        }

        [Test]
        public void CreateDefaultDiseaseTest()
        {
            Disease disease = new Disease();
            Assert.IsTrue(disease.name == "Disease Default" && disease.infectiousness == 10);
        }

        [Test]
        public void CreateDiseaseLogEntry()
        {
            Disease.DiseaseLog entry = Disease.CreateLogEntry("This is a test", 88);
            TestContext.WriteLine($"cycleNumber : {entry.cycleNumber} message : {entry.logMessage}");
            Assert.IsTrue(entry.cycleNumber == 88);
        }

        [Test]
        public void DiseaseDeepCopyTest()
        {
            Disease d1 = new Disease();
            Disease deepCopy = d1.DeepCopy();
            Assert.AreNotEqual(d1, deepCopy);
        }


        [Test]
        public void DiseaseLogIterationsTest()
        {
            List<Human> healthy = humanFactory.CreateListOfRandomHumans(1000);

            //Make Sick
            Human sick = humanFactory.CreateRandomHumanWithDataTest();
            Disease testDisease = new Disease("LoggingFever", 1);
            sick.diseases.Add(testDisease);

            WorkPlace workPlace = new WorkPlace();
            workPlace.AddWorker(sick);
            workPlace.AddWorkers(healthy);
            List<Human> sicks = workPlace.GetInfected();

            TestContext.WriteLine($"---Start ---");
            TestContext.WriteLine($"At the start there is {sicks.Count} infected persons.");
            TestContext.WriteLine($"Infected person is :{workPlace.GetInfected()[0].fullName}");
            TestContext.WriteLine($"Disease is:{sick.diseases[0].name} and it has infectiousness rating {sick.diseases[0].infectiousness} ");
            TestHelper.PrintDiseaseLogToTestContext(sick.diseases[0]);

            int iterations = 5;
            
            for (int i = 0; i < iterations; i++)
            {
                DiseaseManager.RollInfectionAgainnstGroupAndGourp(workPlace.GetInfected(), workPlace.GetHealthy());

                TestContext.WriteLine($"\n*** Day {i + 1} ***");
                TestContext.WriteLine($"sick/healthy ratio is {workPlace.GetInfected().Count} / {workPlace.GetHealthy().Count}");

                foreach (Human human in workPlace.GetInfected())
                {
                    TestContext.WriteLine($"\nName : {human.fullName}");
                    TestContext.WriteLine($"Number of diseases: {human.diseases.Count}");
                    foreach (Disease disease in human.diseases)
                    {
                        foreach (var messega in disease.diseaseLog)
                        {
                            TestContext.WriteLine($"Disease name :{disease.name}");
                            TestContext.WriteLine($"Cloned itself :{disease.timesCopied}");
                            TestHelper.PrintDiseaseLogToTestContext(disease);
                        }
                    }
                }
            }

            TestContext.WriteLine($"\nAfter {iterations-1} iterations sick/healthy ratio is {workPlace.GetInfected().Count} / {workPlace.GetHealthy().Count}");
        }

    }
}
