using MiracleOfInfectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace MiracleOfInfectionTests
{
    public class TestHelper
    {

        public static void PrintDiseaseLogToTestContext(Disease disease)
        {
            int entry = 1;
            TestContext.WriteLine($"Disease Log:");
            foreach (Disease.DiseaseLog item in disease.diseaseLog)
            {
                TestContext.WriteLine($"\t{entry}. {item.logMessage} ");
                entry += 1;
            }
        }

        public static void PrintHumanListWithSeperateHelathyAndInfectedToTestContext(List<Human> list)
        {
            int rowNumber = 1;
            int healty = 0;
            int sick = 0;
            foreach (var human in list)
            {
                TestContext.WriteLine($"{rowNumber}. {human.firstName} {human.lastName} ");
                if (human.diseases.Count > 0)
                {
                    sick += 1;
                    TestContext.Write($"\tinfected times : {human.infectedTimes} ");
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

        public static void PrintHumanListWithDiseasesToTestContext(List<Human> list)
        {
            int rowNumber = 1;
            foreach (var human in list)
            {
                TestContext.WriteLine($"{rowNumber}. {human.firstName} {human.lastName} ");
                if (human.diseases.Count > 0)
                {
                    TestContext.WriteLine($"\tinfected times : {human.infectedTimes} ");
                    TestContext.Write($"\tDiseases :  ");
                    foreach (Disease disease in human.diseases)
                    {
                        TestContext.Write($"{disease.name} ");
                    }
                    TestContext.WriteLine();
                }
                else
                {

                    TestContext.WriteLine($"\tHas no diseases ");
                }

                rowNumber++;
            }
        }

        public static void PrintHumanListWithNamesOnlyToTestContext(List<Human> list)
        {
            int rowNumber = 1;
            foreach (var human in list)
            {
                TestContext.WriteLine($"{rowNumber}. {human.firstName} {human.lastName} ");
                rowNumber++;
            }

        }

        public void PrintDiseaseLog(Disease disease)
        {
            foreach (Disease.DiseaseLog logEntry in disease.diseaseLog)
            {
                for (int i = 0; i < disease.diseaseLog.Count; i++)
                {
                    TestContext.Write($"{i + 1}. ");
                    TestContext.WriteLine($"message : {logEntry.logMessage}");
                }
            }
        }

        public static void PrintHumanData(Human human)
        {
            TestContext.WriteLine($"Name: {human.fullName}. ");
            TestContext.WriteLine($"\tNumber of Diseases : {human.diseases.Count}");
        }
    }
}
