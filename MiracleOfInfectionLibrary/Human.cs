using System;
using System.Collections.Generic;
using System.Text;

namespace MiracleOfInfectionLibrary
{
    public class Human
    {
        public enum Sex { male = 0, female }
        public int id { get; set; }
        private string  _firstName;

        public string  firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
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

        public string fullName
        {
            get { return (this.firstName.ToString() + " " + this.lastName.ToString()); }
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

        public void InfectedByHuman(Human human, Disease disease)
        {
            infectedTimes += 1;
            Disease shallowCopy = disease.ShallowCopy();
            string msg = ($"Infected by {human.fullName}");
            Disease.DiseaseLog logEnty = Disease.CreateLogEntry($"{msg} ");
            shallowCopy.AddLogEntry(logEnty);
            this.diseases.Add(shallowCopy);
        }


    }
}
