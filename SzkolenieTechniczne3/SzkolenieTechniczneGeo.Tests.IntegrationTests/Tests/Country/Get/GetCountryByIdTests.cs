using System.Threading.Tasks;
using SzkolenieTechniczneGeo.Tests.IntegrationTests.Common;
using SzkolenieTechniczneGeo.Tests.IntegrationTests.Common.Attributes;
using SzkolenieTechniczneGeo.Tests.IntegrationTests.Common.Enums;

namespace SzkolenieTechniczneGeo.Tests.IntegrationTests.Tests.Country.Get
{
    [TestTarget(TestTargetType.Endpoint, "GET /geo/countries/{id}")]
    public class GetCountryByIdTests : DataFixtureTests
    {
        protected override Task CleanUpTestDataAsync()
        {
            throw new System.NotImplementedException();
        }

        protected override Task PrepareTestDataAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
