﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiracleOfInfectionLibrary
{
    public class WorkPlace : Place
    {
        private List<Human> _workers = new List<Human>();
        public WorkPlace()
        {
            name = "Company X";
        }

        public void AddWorker(Human human)
        {
            _workers.Add(human);
        }

        public void AddWorkers(List<Human> humans)
        {
            _workers.AddRange(humans);
        }

        public List<Human> GetWorkers()
        {
            return _workers;
        }
        public override List<Human> GetHumans()
        {
            return GetWorkers();
        }

        public override bool HasInfectedHumans()
        {
            List<Human> humans = this.GetWorkers();
            Human sick = humans.Find(x => x.diseases.Count > 0);
            if ( sick != null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public new List<Human> GetInfected()
        {
            List<Human> infected = _workers.FindAll(x => x.diseases.Count > 0);
            return infected;
        }

        public List<Human> GetHealthy()
        {
            List<Human> infected = _workers.FindAll(x => x.diseases.Count <= 0);
            return infected;
        }
    }
}
