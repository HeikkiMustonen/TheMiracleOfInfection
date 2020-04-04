using System;
using System.Collections.Generic;
using System.Text;

namespace MiracleOfInfectionLibrary
{
    public class Human
    {
        public enum Sex { male = 0, female }
        public int id { get; set; }
        private string  firstName;

        public string  FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private List<Disease> _diseases;

        public List<Disease> diseases
        {
            get { return _diseases; }
            set { _diseases = value; }
        }

        private int _infectedTimes;

        public int infectedTimes
        {
            get { return _infectedTimes; }
            set { _infectedTimes = value; }
        }

        public Human()
        {
            diseases = new List<Disease>();
        }


        public string lastName { get; set; }
        public Sex sex { get; set; }
        public int age { get; set; }


        public void Infect(Disease disease)
        {
            infectedTimes += 1;
            this.diseases.Add(disease);
        }

        
    }
}
