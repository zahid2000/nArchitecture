namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
                                                 options.UseSqlServer(
                                                     configuration.GetConnectionString("RentACarCampConnectionString")));
        services.AddScoped<IBrandRepository, BrandRepository>();
        return services;
    }
}
