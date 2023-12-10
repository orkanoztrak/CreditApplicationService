using Application.Persistence;
using Application.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Core;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlite("DataSource=file::memory:?cache=shared"));
        services.AddScoped<CustomerRepository>();
        services.AddScoped<CreditApplicationRepository>();
        return services;
    }

}
