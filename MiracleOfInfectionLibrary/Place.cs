using System;
using System.Collections.Generic;
using System.Text;

namespace MiracleOfInfectionLibrary
{
    public class Place:IPlace
    {
        public string name;
        /// <summary>
        /// This tell, how often on human is in contact with others in this place.
        /// </summary>
        public int contactRating;


        public virtual List<Human> GetHumans()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns infected from this place.
        /// </summary>
        /// <returns></returns>
        public List<Human> GetInfected()
        {
            throw new NotImplementedException();
        }

        public virtual bool HasInfectedHumans()
        {
            throw new NotImplementedException();
        }

        public virtual List<Human> ContactCheck(Human human,List<Human> others, int contactRatingModifier = 0)
        {
            List<Human> wasInContactWith = new List<Human>();
            Random rnd = new Random();
            others.Remove(human);
            foreach (Human human1 in others)
            {
                int dice = rnd.Next(0, 101);
                if(dice <= this.contactRating + contactRatingModifier)
                {
                    wasInContactWith.Add(human1);         
                }
            }

            return wasInContactWith;
        }
    }
}
