using System.Globalization;
using System.Reflection;
using System.Text.Json;

#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace TraktNET
{
    public static class TestUtility
    {
        private static string? _location;

        public static async Task<T?> DeserializeJsonAsync<T>(string jsonFilename) where T : class
        {
            string filepath = GetJsonFilepath(jsonFilename);
            using var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactory.GetContext<T>();
            return await JsonSerializer.DeserializeAsync(stream, typeof(T), jsonSerializerContext) as T;
#else
            return await JsonSerializer.DeserializeAsync<T>(stream, Constants.Json.JsonOptions);
#endif
        }

        public static DateTime ParseUTCDateTime(string dateTime)
            => DateTime.Parse(dateTime, CultureInfo.InvariantCulture).ToUniversalTime();

        public static DateOnly ParseDate(string date) => DateOnly.Parse(date, CultureInfo.InvariantCulture);

        public static TimeOnly ParseTime(string time) => TimeOnly.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);

        private static string GetJsonFilepath(string jsonFilename)
            => Path.Combine(GetLocation(), Path.Combine("JsonData", jsonFilename));

        private static string GetLocation()
        {
            if (!string.IsNullOrWhiteSpace(_location))
                return _location!;

            _location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return _location!;
        }
    }
}
