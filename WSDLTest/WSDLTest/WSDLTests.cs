
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
        [TestCaseSource(typeof(DataSource),nameof(DataSource.GetCountriesAvailableData))]
        public void GetCountriesAvailable(int countryCode,string expectedCode,string expectedDescription)
        {
            var countries= Client.GetCountriesAvailable();
            var actualCode = countries[countryCode].Code;
            var actualDescription = countries[countryCode].Description;
            Assert.AreEqual(expectedCode, actualCode,"Country code doesnt match for index{0}", countryCode);
            Assert.AreEqual(expectedDescription, actualDescription, "Country description doesnt match for index{0}", countryCode);
        }
        /// <summary>
        /// Get holidays for country and check for count
        /// </summary>
        /// <param name="country"></param>
        /// <param name="expectedCount"></param>
        [TestCaseSource(typeof(DataSource), nameof(DataSource.GetHolidaysAvailableData))]
        public void GetHolidayDate(Country country,int expectedCount)
        {
           var holidays= Client.GetHolidaysAvailable(country);
           Assert.AreEqual(holidays.Length, expectedCount);
        }

    }
  
}
