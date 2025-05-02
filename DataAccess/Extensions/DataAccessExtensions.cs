using DataAccess.Dapper;
using DataAccess.Dapper.Interfaces;
using DataAccess.Dapper.Interfaces.Settings;
using DataAccess.Dapper.Interfaces.Settings;
using DataAccess.Dapper.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDapper(this IServiceCollection services)
    {
        services.AddSingleton<IDapperSettings, DapperSettings>();
        services.AddSingleton<IDapperContext, DapperContext>();

        return services;
    }
}