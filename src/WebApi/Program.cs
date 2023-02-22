using FarcasterNet.WebApi.Endpoints.Authors;
using FarcasterNet.WebApi.Endpoints.Movies;
using FarcasterNet.WebApi.Endpoints.Reviews;
using FarcasterNet.WebApi.Endpoints.Version;
using FarcasterNet.WebApi.Extensions;
using Serilog;

var builder = WebApplication
                .CreateBuilder(args)
                .ConfigureBuilder();
var app = builder
            .Build()
            .ConfigureApplication();

_ = app.MapVersionEndpoints();
_ = app.MapAuthorEndpoints();
_ = app.MapMovieEndpoints();
_ = app.MapReviewEndpoints();

// farcaster endpoints
_ = app.MapCastEndpoints();

try
{
    Log.Information("Starting host");
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
