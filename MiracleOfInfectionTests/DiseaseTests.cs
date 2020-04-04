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
        [SetUp]
        public void SetUp()
        {
            disease = new Disease();
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
            Disease.DiseaseLog entry = disease.CreateLogEntry("This is a test", 88);
            TestContext.WriteLine($"cycleNumber : {entry.cycleNumber} message : {entry.logMessage}");
            Assert.IsTrue(entry.cycleNumber == 88);
        }

    }
}
