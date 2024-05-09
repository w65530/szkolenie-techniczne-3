using System.Net.Http;
using System.Threading.Tasks;

namespace SzkolenieTechniczneGeo.Tests.IntegrationTests.Common.Extensions
{
    public class HttpClientFactory
    {
        public static async Task<HttpClient> Create()
        { return new HttpClient(); }
    }
}
