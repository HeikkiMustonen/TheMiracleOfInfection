using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiracleOfInfectionLibrary
{
    public static class ListExpansions
    {
        public static bool HasInfected(this List<Human> humans)
        {
            if(humans.Find(x => x.IsInfected()) != null){
                return true;
            }
            return false;
        }

        public static List<Human> GetInfected(this List<Human> humans)
        {
            return humans.FindAll(x => x.diseases.Count > 0).ToList();
        }

        public static List<Human> GetHealthy(this List<Human> humans)
        {
            return humans.FindAll(x => x.diseases.Count == 0).ToList();
        }

        public static void InfectAll(this List<Human> humans, Disease disease)
        {
            foreach (Human human in humans)
            {
                human.Infect(disease);
            }
        }

    }


}
