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

        /// <summary>
        /// Gives disease to Human
        /// 
        /// </summary>
        /// <param name="human"></param>
        /// <param name="disease"></param>
        /// <returns>Returns true if was infected succesfully, didn't have this disease before.</returns>
        public bool InfectedByHuman(Human human, Disease disease)
        {
            //if already has this disease.
            if (this.HasDisease(disease)) return false;
            infectedTimes += 1;

            //Make a new oobject out of disease
            Disease deepCopy = disease.DeepCopy();

            //Add log entry to disease
            string msg = ($"Got this From {human.fullName}");
            Disease.DiseaseLog logEnty = Disease.CreateLogEntry($"{msg}");
            deepCopy.AddLogEntry(logEnty);
            
            this.diseases.Add(deepCopy);
            return true;
        }

        public bool HasDisease(Disease disease)
        {
            if(this.diseases.Find(x => x.id == disease.id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HasDisease()
        {
            if (this.diseases.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
