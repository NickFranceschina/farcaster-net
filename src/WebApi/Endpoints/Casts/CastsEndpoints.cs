namespace FarcasterNet.WebApi.Endpoints.Authors;

using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using Bogus.DataSets;
using Errors;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Entities = Application.Casts.Entities;
using Queries = Application.Casts.Queries;

[ExcludeFromCodeCoverage]
public static class CastsEndpoints
{
    public static WebApplication MapCastEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/api/default-feed",
                async (IMediator mediator, [FromHeader(Name = "FC-BEARER-TOKEN")] string custodyBearer) =>
                    Results.Ok(await mediator.Send(new Queries.GetDefaultRecommendedCastsQuery { Auth = custodyBearer })))
            .WithTags("Casts")
            .WithMetadata(new SwaggerOperationAttribute("Default Recommended Feed", "\n    GET /default-feed"))
            .Produces<List<Entities.Cast>>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status500InternalServerError, contentType: MediaTypeNames.Application.Json);

        return app;
    }
}
