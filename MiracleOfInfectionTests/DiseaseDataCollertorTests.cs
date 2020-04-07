using System;
using System.Collections.Generic;
using System.Text;
using MiracleOfInfectionLibrary;
using NUnit.Framework;

namespace MiracleOfInfectionTests
{
    public class DiseaseDataCollertorTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void EventTest()
        {
            DiseaseDataCollector ddc = new DiseaseDataCollector();
            Disease d = new Disease();
            Disease.DiseaseLog logEntry = new Disease.DiseaseLog();
            logEntry.cycleNumber = 1;
            logEntry.logMessage = "Testing the thing";
            d.AddLogEntry(logEntry);

            Assert.IsTrue(DiseaseDataCollector.eventsReceived == 1);
        }

    }
}
