using System;
using System.Collections.Generic;
using System.Text;

namespace MiracleOfInfectionLibrary
{
    public class HumanFactory
    {
        public string GetRandomFirstName(Human.Sex sex=Human.Sex.male)
        {
            switch (sex)
            {
                case Human.Sex.male:
                    return GetRandomFromStringArray(firstNamesMale);
                    break;
                case Human.Sex.female:
                    return GetRandomFromStringArray(firstNamesFemale);
                    break;
                default:
                    return null;
                    break;
            }
        }

        public static Human GetInfectedHuman()
        {
            HumanFactory hf = new HumanFactory();
            Human human =  hf.CreateRandomHumanWithDataTest();

            human.diseases.Add(new Disease());
            return human;
        }

        public static Human GetInfectedHuman(Disease disease)
        {
            Human human = new Human();
            human.diseases.Add(disease);
            return human;
        }

        public string GetRandomLastName()
        {
            return GetRandomFromStringArray(lastNames);
        }

        public Human CreateRandomHumanWithDataTest()
        {
            Human human = new Human();
            human.sex = GetRandomSex();
            human.firstName = GetRandomFirstName(human.sex);
            human.lastName = GetRandomLastName();
            return human;
        }

        public List<Human> CreateListOfRandomHumans(int amount)
        {
            List<Human> list = new List<Human>();

            for (int i = 0; i < amount; i++)
            {
                list.Add(CreateRandomHumanWithDataTest());
            }

            return list;
        }

        public string GetRandomFromStringArray(string[] array)
        {
            int lenght = array.Length;
            Random rnd = new Random();
            return array[rnd.Next(0, lenght)].ToString();

        }

        public Human.Sex GetRandomSex()
        {
            Random rnd = new Random();
            int s = rnd.Next(0, 2);
            return (Human.Sex) s;
        }

        public List<Human> GetListOfHealthyHumans(int amount)
        {
            List<Human> list = new List<Human>();
            for (int i = 0; i < amount ; i++)
            {
                list.Add(CreateRandomHumanWithDataTest());
            }

            return list;

        }

        private string[] firstNamesMale = 
            { 
            "James", "Kent","Andy","Clay", "Andrew", "Alex", "Alec","Arlo","Arthur","Charlie","Chris","Cliff","Colin","Corey","Tim","Timonthy","Elton","Ernest"
            };

        private string[] firstNamesFemale =
        {
            "Elisabeth","Ilsa","Isla","Helena","Lisa","Anna","Amber","Carol","Delaylah","Susanna"
        };

        private string[] lastNames =
            {
            "Ansley","Barlow","Bentley","Blackwood","Denver","Dalton","Cotton","Dudley","Landon","Kelsey","Kinsley","Eaton","Clifton","Colby","Garfield","Hailey","Oakes"
            };
    }

    
}
