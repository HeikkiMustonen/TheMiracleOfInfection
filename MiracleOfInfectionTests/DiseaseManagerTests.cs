using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MiracleOfInfectionLibrary;

namespace MiracleOfInfectionTests
{
    public class DiseaseManagerTests
    {
        DiseaseManager diseaseManager;
        HumanFactory humanFactory;
        Human healtyHuman;
        Human infectedHuman;
        [SetUp]
        public void SetUp()
        {
            diseaseManager = new DiseaseManager();
            humanFactory = new HumanFactory();
            healtyHuman = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman = humanFactory.CreateRandomHumanWithDataTest();
            infectedHuman.diseases.Add(new Disease());

        }

        

        [Test]
        public void InfectiousnessTest()
        {
            Disease d = new Disease();
            int iterations = 100;
            int t = 0;
            int f = 0;
            for (int i = 0; i < iterations; i++)
            {
                bool result = DiseaseManager.RollInfection(d);
                if (result) t += 1;
                if (!result) f += 1;
                TestContext.WriteLine($"Result with {d.name} was {result}");
            }

            TestContext.WriteLine($"\nThere was {t} infections and {f} was spared.");
        }

        [Test]
        public void RollInfectionAgainsGroupThrowExceptionTest()
        {
            //This test that exeption is thrown is there is no disease in the human.
            Exception e = Assert.Throws<Exception>(delegate { DiseaseManager.RollInfectionAgainsGroup(healtyHuman, null); });
            Assert.IsTrue(e.Message == "There was no diseases in infected person");
        }

        [Test]
        public void RollInfectionAgainsGroupTest()
        {
            List<Human> group = humanFactory.CreateListOfRandomHumans(100);
            
            DiseaseManager.RollInfectionAgainsGroup(infectedHuman, group);

            TestHelper.PrintHumanListToTestContext(group);
        }
    }
}
