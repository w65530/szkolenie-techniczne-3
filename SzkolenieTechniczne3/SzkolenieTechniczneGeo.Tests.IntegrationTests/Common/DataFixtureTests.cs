using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SzkolenieTechniczneGeo.Tests.IntegrationTests.Common
{
    public abstract class DataFixtureTests : IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            try
            {
                await PrepareTestDataAsync();
            }
            catch
            {
                await DisposeAsync();
                throw;
            }
        }

        public async Task DisposeAsync()
        {
            await CleanUpTestDataAsync();
        }

        protected abstract Task PrepareTestDataAsync();

        protected abstract Task CleanUpTestDataAsync();
    }
}
