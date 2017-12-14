
using System;
using System.IO;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WSDLTest.Holiday;

namespace WSDLTest
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class WsdlTests
    {
        public HolidayService2Soap Client;

        // Save info about each test
        public static string TestData = String.Empty;

        // Max time for each test
        public const int TestTimeout = 2000;

        //Path to log with results
        public static string FilePath = @"G:\Report";

        //Action that will be executed before each test
        [SetUp]
        public void SetUp()
        {
            Client = new HolidayService2SoapClient();
        }
        /// <summary>
        /// Get country using index and check description and coutry code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="expectedCode"></param>
        /// <param name="expectedDescription"></param>
        [TestCaseSource(typeof(DataSource), nameof(DataSource.GetCountriesAvailableData)), Timeout(TestTimeout)]
        public void GetCountriesAvailable(int countryCode, string expectedCode, string expectedDescription)
        {
            var countries = Client.GetCountriesAvailable();
            var actualCode = countries[countryCode].Code;
            var actualDescription = countries[countryCode].Description;
            Assert.AreEqual(expectedCode, actualCode, "Country code doesnt match for index{0}", countryCode);
            Assert.AreEqual(expectedDescription, actualDescription, "Country description doesnt match for index{0}", countryCode);
        }
        /// <summary>
        /// Get holidays for country and check for count
        /// </summary>
        /// <param name="country"></param>
        /// <param name="expectedCount"></param>
        [TestCaseSource(typeof(DataSource), nameof(DataSource.GetHolidaysAvailableData)), Timeout(TestTimeout)]
        public void GetHolidayDate(Country country, int expectedCount)
        {
            var holidays = Client.GetHolidaysAvailable(country);
            Assert.AreEqual(holidays.Length, expectedCount);
        }

        //Action that will be executed after each test
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.FailCount == 0)
            {
                TestData += TestContext.CurrentContext.Test.Name + " end with result Pass" + System.Environment.NewLine;
            }
            else
            {
                TestData += TestContext.CurrentContext.Test.Name + " end with result Fail" 
                    + Environment.NewLine + "With Message " + TestContext.CurrentContext.Result.Message + Environment.NewLine+ "Call stack: " + TestContext.CurrentContext.Result.StackTrace + System.Environment.NewLine;
            }
        }
        //Action that will be executed after all test
        [OneTimeTearDown]
        public void FinalTearDown()
        {
            var time = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" +
                       DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            time += ".txt";
            var filepath = Path.Combine(FilePath, time);
            var file = File.CreateText(filepath);
            file.WriteLine(TestData);
            file.Close();
        }
    }

}
