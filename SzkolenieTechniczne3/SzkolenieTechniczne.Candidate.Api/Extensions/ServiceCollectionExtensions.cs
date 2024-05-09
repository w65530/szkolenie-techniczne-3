using Microsoft.Extensions.DependencyInjection;
using SzkolenieTechniczne.Candidate.Api.Services;
using SzkolenieTechniczne.Candidate.Storage;

namespace SzkolenieTechniczne.Candidate.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCandidateServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CandidateService>();
            serviceCollection.AddDbContext<CandidateDbContext, CandidateDbContext>();
            return serviceCollection;
        }
    }
}
