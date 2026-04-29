using MVC_BusTicket.Models;
using System.Text.Json;

namespace MVC_BusTicket.Extensions
{
    public static class SessionExtension
    {
        // Adds a extension method directly to the ISession
        public static void SetObjectAsJson(this ISession session, string key, Ticket value)
        {
            // Set the serialized Ticket into the session using the provided key
            session.SetString(key, JsonSerializer.Serialize<Ticket>(value));
        }

        public static Ticket GetObjectFromJson(this ISession session, string key)
        {
            var currentSessionJson = session.GetString(key);
            return currentSessionJson == null ? default : JsonSerializer.Deserialize<Ticket>(currentSessionJson);
        }
    }
}
