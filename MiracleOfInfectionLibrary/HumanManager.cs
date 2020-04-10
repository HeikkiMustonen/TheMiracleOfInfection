using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace MiracleOfInfectionLibrary
{
    public class HumanManager
    {
        public List<Human> allHumans = new List<Human>();

        public static bool GroupIsHealthy(List<Human> group)
        {
            bool result = true;
            foreach (Human human in group)
            {
                if (human.IsInfected())
                {
                    return false;
                }
            }
            return result;
        }

    }



}
