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
            Assert.IsNotNull(name);
        }

        [Test]
        public void GetRandomMaleFirstNameTest()
        {
            string name = humanFactory.GetRandomFirstName(Human.Sex.male);
            TestContext.WriteLine($"Name was: {name}");
            Assert.True(name != null);
        }

        [Test]
        public void GetRandomFemaleFirstNameTest()
        {
            string name = humanFactory.GetRandomFirstName(Human.Sex.female);
            TestContext.WriteLine($"Name was: {name}");
            Assert.True(name != null);
        }

        [Test]
        public void CreateHumanTest()
        {
            Human human = humanFactory.CreateRandomHumanWithDataTest();
            Assert.True(human.firstName != null && human.lastName != null);
        }

        

        [Test]
        public void CreateListOfHumansTest()
        {
            List<Human> list = humanFactory.CreateListOfRandomHumans(5);
            foreach (Human human in list)
            {
                TestContext.WriteLine($"Name was: {human.firstName} ,{human.lastName}");
            }
            Assert.True(list.Count == 5);
        }

        [Test]
        public void GetListOfHealthyHumans()
        {
            List<Human> list = humanFactory.GetListOfHealthyHumans(100);
            List<Human> healthyList = list.FindAll(x => x.diseases.Count == 0);
            Assert.True(list.Count == healthyList.Count);
        }

    }
}