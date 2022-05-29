﻿using System.Text.Json;

namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            if (session is null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or empty.", nameof(key));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            if (session is null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or empty.", nameof(key));
            }

            var sessionData = session.GetString(key);

            return sessionData is null
                ? default
                : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
