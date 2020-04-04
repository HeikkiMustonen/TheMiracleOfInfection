using System;
using System.Collections.Generic;
using System.Text;

namespace MiracleOfInfectionLibrary
{
    public class Place:IPlace
    {
        public string name;

        public virtual List<Human> GetHumans()
        {
            throw new NotImplementedException();
        }

        public List<Human> GetInfected()
        {
            throw new NotImplementedException();
        }

        public virtual bool HasInfectedHumans()
        {
            throw new NotImplementedException();
        }

    }
}
