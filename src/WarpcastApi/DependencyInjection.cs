namespace FarcasterNet.Infrastructure.WarpcastApi;

using System.Diagnostics.CodeAnalysis;
using SimpleDateTimeProvider;
using Microsoft.Extensions.DependencyInjection;
using FarcasterNet.Domain.Interfaces;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddWarpcastApi(this IServiceCollection services)
    {
        _ = services.AddSingleton<WarpcastApiClient>();

        _ = services.AddSingleton<ICasts>(p => p.GetRequiredService<WarpcastApiClient>());
        _ = services.AddSingleton<IUsers>(x => x.GetRequiredService<WarpcastApiClient>());
        _ = services.AddSingleton<IReactions>(x => x.GetRequiredService<WarpcastApiClient>());

        _ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }
}
