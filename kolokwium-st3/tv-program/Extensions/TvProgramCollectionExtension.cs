using tv_program.Services;

namespace tv_program.Extensions;

public static class TvProgramCollectionExtension
{
    public static IServiceCollection AddTvProgramServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<TvProgramDbContext>();
        serviceCollection.AddTransient<TvProgramService>();

        return serviceCollection;
    }
}