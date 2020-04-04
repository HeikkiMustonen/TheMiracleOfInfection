using NUnit.Framework;
using System.Collections.Generic;
using MiracleOfInfectionLibrary;


namespace MiracleOfInfectionTests
{
    public class HumanFactoryTests
    {
        public HumanFactory humanFactory;
        [SetUp]
        public void Setup()
        {
            humanFactory = new HumanFactory();
        }

        [Test]
        public void GetRandomFirstNameTest()
        {
            string name = humanFactory.GetRandomFirstName();
            TestContext.WriteLine($"Name was: {name}");
            Assert.Pass("Name was not null.",name != null);
        }

        [Test]
        public void GetRandomMaleFirstNameTest()
        {
            string name = humanFactory.GetRandomFirstName(Human.Sex.male);
            TestContext.WriteLine($"Name was: {name}");
            Assert.Pass("Name was not null.", name != null);
        }

        [Test]
        public void GetRandomFemaleFirstNameTest()
        {
            string name = humanFactory.GetRandomFirstName(Human.Sex.female);
            TestContext.WriteLine($"Name was: {name}");
            Assert.Pass("Name was not null.", name != null);
        }

        [Test]
        public void CreateHumanTest()
        {
            Human human = humanFactory.CreateRandomHumanWithDataTest();
            Assert.Pass("Human created with first and last name.", human.FirstName != null && human.lastName != null);
        }

        [Test]
        public void CreateListOfHumansTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(5);
            foreach (Human human in list)
            {
                TestContext.WriteLine($"Name was: {human.FirstName} ,{human.lastName}");
            }
            Assert.Pass("Human created with first and last name.", list.Count == 5);
        }


    }
}