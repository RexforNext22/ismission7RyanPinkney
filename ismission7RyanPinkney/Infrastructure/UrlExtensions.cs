// Author Ryan Pinkney
// This is my url extension class file with the default code from the video


using System;
using Microsoft.AspNetCore.Http;

namespace ismission7RyanPinkney.Infrastructure
{

    // Static class for the url extension
    public static class UrlExtensions
    {

        public static string PathAndQuery(this HttpRequest request) =>
    request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();

    }
}
