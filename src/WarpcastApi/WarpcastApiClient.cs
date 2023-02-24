namespace FarcasterNet.Infrastructure.WarpcastApi;

using System.Collections.Generic;
using System.Net;
using System.Text;
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

    async Task<List<Cast>> ICasts.GetDefaultRecommendedFeed(int limit, string cursor, string appBearer, CancellationToken cancellationToken)
    {
        // make https request to https://api.warpcast.com/v2/default-recommended-feed and parse json response
        var apiUrl = "https://api.warpcast.com/v2/default-recommended-feed";

        // Create the URI builder and add the query parameters
        var uriBuilder = new UriBuilder(apiUrl);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
        query["limit"] = limit.ToString();
        if (cursor != null) query["cursor"] = cursor;
        uriBuilder.Query = query.ToString();
        var requestUrl = uriBuilder.ToString();

        using var client = new HttpClient();

        // FIRST: if "custody" exists, then use that eip191 token to get get app-bearer
        if (!string.IsNullOrWhiteSpace(appBearer))
        {
            //var appBearer = await GetAppBearerToken(custodyBearer, cancellationToken);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appBearer}");

            //// check "me"
            //var _response = await client.GetAsync("https://api.warpcast.com/v2/me", cancellationToken);
            //var _json = await _response.Content.ReadAsStringAsync(cancellationToken);
            //var _jToken = JToken.Parse(_json);
            //var what = _jToken;

        }

        // NOW: go get the list
        var response = await client.GetAsync(requestUrl, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var jToken = JToken.Parse(json)["result"]["feed"];
        var casts = JArray.FromObject(jToken).Select(t => JObject.FromObject(t["cast"]).ToObject<Cast>()).ToList();
        return casts;
    }

    // the problem is the timestamp... the custody and app bearer need to get fetched with same payload
    // so fc-auth can verify they match

    //async Task<string> GetAppBearerToken(string custodyBearer, CancellationToken cancellationToken)
    //{
    //    // https://warpcast.notion.site/Warpcast-v2-API-Documentation-c19a9494383a4ce0bd28db6d44d99ea8#c8290028e8f64238bdd2db8938b29b9b
    //    var authUrl = "https://api.warpcast.com/v2/auth";
    //    using var client = new HttpClient();
    //    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {custodyBearer}");
    //    var jobj = JObject.FromObject(new { method = "generateToken", @params = new { timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() } });
    //    var stringContent = new StringContent(jobj.ToString(), Encoding.UTF8, "application/json");
    //    var response = await client.PutAsync(authUrl, stringContent, cancellationToken);
    //    var json = await response.Content.ReadAsStringAsync(cancellationToken);
    //    var appBearerToken = JToken.Parse(json)["result"]["token"]["secret"].ToString();
    //    return appBearerToken;
    //}

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
