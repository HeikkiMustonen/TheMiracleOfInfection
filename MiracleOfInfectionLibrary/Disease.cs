using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MiracleOfInfectionLibrary
{
    public class Disease
    {

        #region "properties"

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

        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _timesCopied;

        public int timesCopied
        {
            get { return _timesCopied; }
            set { _timesCopied = value; }
        }

        #endregion

        #region events

        public static event EventHandler DiseaseEvent;

        protected virtual void OnDiseaseEvent(DiseaseEventArgs e=null)
        {
            EventHandler handler = DiseaseEvent;
            handler?.Invoke(this, e);
        }

        public class DiseaseEventArgs : EventArgs
        {
            public int PlaceHolderData { get; set; }
            
        }

        public void EventTester()
        {
            DiseaseEventArgs e = new DiseaseEventArgs();
            e.PlaceHolderData = 2;
            OnDiseaseEvent(e);
        }
        
        #endregion

        public Disease()
        {
            this.name = "Disease Default";
            this.infectiousness = 10;
            this.diseaseLog = new List<DiseaseLog>();
            this.id = 0;
        }

        public Disease(string name, int infectiousness)
        {
            this.name = name;
            this.infectiousness = infectiousness;
            this.diseaseLog = new List<DiseaseLog>();
            this.id = 0;
        }

        public Disease DeepCopy()
        {
            Disease other = new Disease();
            other.name = this.name.ToString();
            other.infectiousness = (int)this.infectiousness;
            other.diseaseLog = this.diseaseLog.FindAll(x => x.Equals(x));
            other.timesCopied = (int)this.timesCopied+1;



            return other;
        }

        public static DiseaseLog CreateLogEntry(string message, int cycleNumber = 00)
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

        public void AddLogEntry(DiseaseLog enty)
        {
            this.diseaseLog.Add(enty);
            OnDiseaseEvent();
        }
               
    }
}
