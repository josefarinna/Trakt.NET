using System.Text.Json;
using TraktNET;

namespace Trakt.NET.Examples.Serialization;

internal static class SerializationExample
{
    private static readonly JsonSerializerOptions IndentedOptions = new() { WriteIndented = true };

    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Serialization Example");
        Console.WriteLine();

        TraktAuthorization fakeAuthorization = TraktAuthorization.CreateWith(DateTime.UtcNow, 90 * 24 * 3600, "FakeAccessToken", "FakeRefreshToken");

        string fakeAuthorizationJson = JsonSerializer.Serialize(fakeAuthorization, IndentedOptions);

        Console.WriteLine("Serialized Fake Authorization:");
        Console.WriteLine(fakeAuthorizationJson);

        TraktAuthorization? deserializedFakeAuthorization = JsonSerializer.Deserialize<TraktAuthorization>(fakeAuthorizationJson);

        if (deserializedFakeAuthorization != null)
        {
            Console.WriteLine("Deserialized Fake Authorization:");
            Console.WriteLine($"Created (UTC): {deserializedFakeAuthorization.CreatedAt}");
            Console.WriteLine($"Access Scope: {deserializedFakeAuthorization.Scope}");
            Console.WriteLine($"Refresh Possible: {deserializedFakeAuthorization.IsRefreshPossible}");
            Console.WriteLine($"Valid: {deserializedFakeAuthorization.IsValid}");
            Console.WriteLine($"Token Type: {deserializedFakeAuthorization.TokenType}");
            Console.WriteLine($"Access Token: {deserializedFakeAuthorization.AccessToken}");
            Console.WriteLine($"Refresh Token: {deserializedFakeAuthorization.RefreshToken}");
            Console.WriteLine($"Token Expired: {deserializedFakeAuthorization.IsExpired}");
            Console.WriteLine($"Expires in {deserializedFakeAuthorization.ExpiresInSeconds / 3600 / 24} days");
        }

        await Task.CompletedTask;
        Console.WriteLine();
    }
}
