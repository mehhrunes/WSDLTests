using System;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WSDLTest.Holiday;

namespace WSDLTest
{
    [TestFixture]
    public class WSDLTests
    {
        public HolidayService2Soap client;

        [SetUp]
        public void SetUp()
        {
            client = new HolidayService2SoapClient();
        }
        [Test]
        public void GetCountriesAvailable()
        {
           var countries= client.GetCountriesAvailable();
            
        }
        
    }
}
