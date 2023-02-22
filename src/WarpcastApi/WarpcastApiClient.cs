namespace FarcasterNet.Infrastructure.WarpcastApi;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FarcasterNet.Domain.Interfaces;
using FarcasterNet.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WarpcastApiClient : ICasts, IUsers, IReactions
{
    Task<bool> ICasts.CastExists(string castHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<Cast> ICasts.GetCastById(string castHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<List<Cast>> ICasts.GetCasts(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    async Task<List<Cast>> ICasts.GetDefaultRecommendedFeed(int limit, string cursor, CancellationToken cancellationToken)
    {
        // make https request to https://client.warpcast.com/v2/default-recommended-feed and parse json response
        var apiUrl = "https://client.warpcast.com/v2/default-recommended-feed";

        // Create the URI builder and add the query parameters
        var uriBuilder = new UriBuilder(apiUrl);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
        query["limit"] = limit.ToString();
        if (cursor != null) query["cursor"] = cursor;
        uriBuilder.Query = query.ToString();
        var requestUrl = uriBuilder.ToString();

        using var client = new HttpClient();
        // client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        var response = await client.GetAsync(requestUrl, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var jToken = JToken.Parse(json)["result"]["feed"];
        var casts = JArray.FromObject(jToken).Select(t => JObject.FromObject(t["cast"]).ToObject<Cast>()).ToList();
        return casts;
    }

    Task<Reaction> IReactions.GetReactionById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<List<Reaction>> IReactions.GetReactions(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<User> IUsers.GetUserById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<List<User>> IUsers.GetUsers(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<bool> IReactions.ReactionExists(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<bool> IUsers.UserExists(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
