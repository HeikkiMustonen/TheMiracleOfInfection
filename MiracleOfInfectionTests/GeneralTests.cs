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
        private DiseaseManager DiseaseManager;
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
        public void PlaceInfectionOne()
        {
            WorkPlace workPlace = new WorkPlace();
            workPlace.AddWorkers(humanFactory.CreateListOfRandomHumans(100));
            Human infected = humanFactory.CreateRandomHumanWithDataTest();

            //add one sick
            Disease disease = new Disease("Test Disease", 5);
            infected.diseases.Add(disease);
            workPlace.AddWorker(infected);

            int iterations = 3;

            for (int i = 0; i <= iterations; i++)
            {
                DiseaseManager.RollInfectionAgainnstGroupAndGourp(workPlace.GetInfected(), workPlace.GetHealthy());

                TestContext.WriteLine($"\n\n------------ Iteration {i+1}. ----------------");
                TestContext.WriteLine($"Healty : {workPlace.GetHealthy().Count}");
                TestContext.WriteLine($"infected : {workPlace.GetInfected().Count}");
                TestContext.WriteLine($"------------ Infected ----------------");
                TestHelper.PrintHumanListWithDiseasesToTestContext(workPlace.GetInfected());
                TestContext.WriteLine($"------------ Healthy ----------------");
                TestHelper.PrintHumanListWithNamesOnlyToTestContext(workPlace.GetHealthy());
            }

            Assert.Pass("This listing is done");
        }

        [Test]
        public void PlaceInfectionTwo()
        {
            WorkPlace workPlace = new WorkPlace();
            workPlace.AddWorkers(humanFactory.CreateListOfRandomHumans(100));
            Human nuhaMies = humanFactory.CreateRandomHumanWithDataTest();

            //add one sick
            Disease nuha = new Disease("Nuha", 2);
            nuhaMies.diseases.Add(nuha);
            workPlace.AddWorker(nuhaMies);

            Human tippuriMies = humanFactory.CreateRandomHumanWithDataTest();
            Disease tippuri = new Disease("Tippuri", 1);
            nuhaMies.diseases.Add(tippuri);
            workPlace.AddWorker(tippuriMies);

            int iterations = 3;

            for (int i = 0; i <= iterations; i++)
            {
                DiseaseManager.RollInfectionAgainnstGroupAndGourp(workPlace.GetInfected(), workPlace.GetHealthy());

                TestContext.WriteLine($"\n\n------------ Iteration {i + 1}. ----------------");
                TestContext.WriteLine($"Healty : {workPlace.GetHealthy().Count}");
                TestContext.WriteLine($"infected : {workPlace.GetInfected().Count}");
                TestContext.WriteLine($"------------ Infected ----------------");
                TestHelper.PrintHumanListWithDiseasesToTestContext(workPlace.GetInfected());
                TestContext.WriteLine($"------------ Healthy ----------------");
                TestHelper.PrintHumanListWithNamesOnlyToTestContext(workPlace.GetHealthy());
            }
        }
    }
}
