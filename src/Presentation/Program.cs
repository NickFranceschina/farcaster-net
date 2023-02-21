using FarcasterNet.Presentation.Endpoints.Authors;
using FarcasterNet.Presentation.Endpoints.Movies;
using FarcasterNet.Presentation.Endpoints.Reviews;
using FarcasterNet.Presentation.Endpoints.Version;
using FarcasterNet.Presentation.Extensions;
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
