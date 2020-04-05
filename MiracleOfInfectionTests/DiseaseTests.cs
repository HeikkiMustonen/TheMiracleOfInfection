using System;
using System.Collections.Generic;
using System.Text;
using MiracleOfInfectionLibrary;
using NUnit.Framework;

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
            Assert.IsTrue(disease.name == "Disease Default" && disease.infectiousness ==10);
        }

        [Test]
        public void CreateDiseaseLogEntry()
        {
            Disease.DiseaseLog entry = Disease.CreateLogEntry("This is a test", 88);
            TestContext.WriteLine($"cycleNumber : {entry.cycleNumber} message : {entry.logMessage}");
            Assert.IsTrue(entry.cycleNumber == 88);
        }

        [Test]
        public void DiseaseLogTest()
        {
            List<Human> healthy = humanFactory.CreateListOfRandomHumans(50);
            
            //Make Sick
            Human sick = humanFactory.CreateRandomHumanWithDataTest();
            Disease testDisease = new Disease("Test Log Disease", 4);
            sick.diseases.Add(testDisease);
            
            WorkPlace workPlace = new WorkPlace();
            workPlace.AddWorker(sick);
            workPlace.AddWorkers(healthy);

            TestContext.WriteLine($"--- iteration ---\n");
                
            var normal = workPlace.GetHealthy();
            DiseaseManager.RollInfectionAgainnstGroupAndGourp(workPlace.GetInfected(), workPlace.GetHealthy());
            List<Human> sicks = workPlace.GetInfected();
            TestContext.WriteLine($"After one round Sick person : {sicks.Count}");
            
            foreach (Human human in sicks)
            {
                foreach (Disease disease in human.diseases)
                {
                    if (disease.diseaseLog.Count > 0)
                    {
                        TestContext.WriteLine($"Disease name :{disease.name}");
                        TestContext.WriteLine($"\n{human.fullName}");
                        TestHelper.PrintDiseaseLogToTestContext(disease);
                    }
                }
            }

            DiseaseManager.RollInfectionAgainnstGroupAndGourp(workPlace.GetInfected(), workPlace.GetHealthy());
            TestContext.WriteLine($"\n--- iteration 2 ---\n");
            sicks = workPlace.GetInfected();
            foreach (Human human in sicks)
            {
                foreach (Disease disease in human.diseases)
                {
                    if (disease.diseaseLog.Count > 0)
                    {
                        TestContext.WriteLine($"Disease name :{disease.name}");
                        TestContext.WriteLine($"\n{human.fullName}");
                        TestHelper.PrintDiseaseLogToTestContext(disease);
                    }
                }
            }
            Assert.IsTrue(1 == 1);
        }

    }
}
