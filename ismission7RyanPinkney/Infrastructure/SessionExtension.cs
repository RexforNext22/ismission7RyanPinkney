// Author Ryan Pinkney
// This is the session extension class
// This code is the default from the video

using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ismission7RyanPinkney.Infrastructure
{
    public static class SessionExtension
    {

        // Static class that sets the JSON
        public static void SetJson(this ISession session, string key, object value)
        {

            session.SetString(key, JsonSerializer.Serialize(value));

        }

        // Static class to get the JSON
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }






    }
}
