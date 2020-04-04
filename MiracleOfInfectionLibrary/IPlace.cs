using System;
using System.Collections.Generic;
using System.Text;

namespace MiracleOfInfectionLibrary
{
    interface IPlace
    {
        abstract List<Human> GetHumans();
        abstract bool HasInfectedHumans();

        abstract List<Human> GetInfected();
    }
}
