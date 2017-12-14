using System.Collections;
using NUnit.Framework;
using WSDLTest.Holiday;

namespace WSDLTest
{
    public class DataSource
    {
        public static IEnumerable GetHolidaysAvailableData
        {

            get
            {
                //Fix numbers on site
                yield return new TestCaseData(Country.Canada, 1);
                yield return new TestCaseData(Country.GreatBritain, 2);
                yield return new TestCaseData(Country.IrelandNorthern, 3);
                yield return new TestCaseData(Country.IrelandRepublicOf,4);
                yield return new TestCaseData(Country.Scotland, 5);
                yield return new TestCaseData(Country.UnitedStates, 6);
            }
        }

        public static object[] GetCountriesAvailableData =
        {
            new object[] {0, "Canada", "Canada" },
            //Fill array of objects
        };
    }

   
}
