using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MiracleOfInfectionLibrary
{
    public class DiseaseDataCollector
    {
        public static int eventsReceived = 0;
        public DiseaseDataCollector()
        {
            
            Disease.DiseaseEvent += GotDiseaseEvent;
        }

        static void GotDiseaseEvent(object sender,EventArgs e)
        {
            DiseaseDataCollector.eventsReceived += 1;
        }

    }
}
