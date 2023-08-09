using System.Net;
using System.Net.Http.Headers;

namespace Commerce.Browse.Service.Domain.Extensions
{
    public static class HttpExtensions
    {
        //private static HttpResponseMessage CreateOkResponse<T>(this HttpRequestMessage req, HttpStatusCode statusCode, T content)
        //{
        //    var httpResponseMessage = new HttpResponseMessage();

        //    HttpResponseMessage response = httpResponseMessage.Content.<T>(statusCode, content);
        //    response.Headers.CacheControl = new CacheControlHeaderValue()
        //    {
        //        NoCache = true,
        //        NoStore = true,
        //        MaxAge = TimeSpan.FromSeconds(0),
        //        MustRevalidate = true,
        //    };

        //    return response;

        //}

    }
}
