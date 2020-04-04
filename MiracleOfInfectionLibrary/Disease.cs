using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MiracleOfInfectionLibrary
{
    public class Disease
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        private int _infectiousness;
        public int infectiousness
        {
            get { return _infectiousness; }
            set { _infectiousness = value; }
        }

        private List<DiseaseLog> _diseaseLog;

        public List<DiseaseLog> diseaseLog
        {
            get { return _diseaseLog; }
            set { _diseaseLog = value; }
        }


        public Disease()
        {
            this.name = "Disease Default";
            this.infectiousness = 10;
        }

        public Disease ShallowCopy()
        {
            return (Disease)this.ShallowCopy();
        }

        public Disease DeepCopy()
        {
            Disease other = (Disease)this.ShallowCopy();
            other.name = this.name;
            other.infectiousness = this.infectiousness;
            return other;
        }

        public DiseaseLog CreateLogEntry(string message, int cycleNumber = 00)
        {
            //00 is default message.
            
            if(message != null)
            {
                DiseaseLog newLogEntry = new DiseaseLog();
                newLogEntry.cycleNumber = cycleNumber;
                newLogEntry.logMessage = message;
                return newLogEntry;
            }
            else
            {
                Debug.Print("There was no message.");
                return new DiseaseLog();
            }
        }

        public struct DiseaseLog
        {
            public int cycleNumber;
            public string logMessage;
        }
               
    }
}
