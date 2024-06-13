using tv_show.Resolvers;
using tv_show.Services;

namespace tv_show.Extensions;

public static class TvShowCollectionExtension
{
    public static IServiceCollection AddTvShowServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<TvShowDbContext>();
        serviceCollection.AddTransient<TvShowService>();
        serviceCollection.AddTransient<TvProgramService>();
        serviceCollection.AddTransient<TvProgramResolver>();

        return serviceCollection;
    }
}
