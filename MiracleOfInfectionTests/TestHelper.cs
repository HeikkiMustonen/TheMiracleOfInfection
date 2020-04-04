using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MiracleOfInfectionLibrary;

namespace MiracleOfInfectionTests
{
    public class TestHelper
    {

        public static void PrintHumanListToTestContext(List<Human> list)
        {
            int rowNumber = 1;
            int healty = 0;
            int sick = 0;
            foreach (var human in list)
            {
                TestContext.WriteLine($"{rowNumber}. {human.FirstName} {human.lastName} ");
                if (human.diseases.Count > 0)
                {
                    sick += 1;
                    TestContext.Write($"\tDiseases :  ");
                    foreach (Disease disease in human.diseases)
                    {
                        TestContext.Write($"{disease.name} ");
                    }
                    TestContext.WriteLine();
                }
                else
                {
                    healty += 1;
                    TestContext.WriteLine($"\tHas no diseases ");
                }

                rowNumber++;
            }

            TestContext.Write($"\n there was {healty} healty people and {sick} sick people.  ");
        }
    }
}
