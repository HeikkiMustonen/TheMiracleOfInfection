using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MiracleOfInfectionLibrary
{
    public class DiseaseManager
    {
        public static bool RollInfection(Disease disease)
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 101);
            if (disease.infectiousness >= roll)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RollInfectionAgainsGroup(Human infected, List<Human> healthyList)
        {
            if (infected.diseases.Count <= 0)
            {
                throw new Exception("There was no diseases in infected person");
            }
            else
            {
                Disease disease = infected.diseases[0];
                foreach (Human human in healthyList)
                {
                    if (RollInfection(disease))
                    {
                        human.diseases.Add(disease);
                    }
                }
            }
        }

        public static void RollInfectionAgainnstGroupAndGourp(List<Human> infectedList, List<Human> healthyList)
        {
            foreach (var infected in infectedList)
            {
                Disease disease = infected.diseases[0];
                foreach (var healthy in healthyList)
                {
                    if (RollInfection(infected.diseases[0]))
                    {
                        //if infected
                        healthy.Infect(disease);
                    }
                }
            }            
        }



        public virtual bool HasInfectedHumans(List<Human> list)
        {
            throw new NotImplementedException();
        }

    }
}

