using TraktNET;

namespace Trakt.NET.Examples.Helper;

internal static class TraktExceptionExtensions
{
    internal static void WriteAuthorizationInformation(this TraktAuthorization authorization)
    {
        ulong createdAt = authorization.CreatedAt ?? 0;
        DateTime created = DateTime.UnixEpoch.AddSeconds(createdAt);
        Console.WriteLine($"Created (UTC): {created}");
        Console.WriteLine($"Access Scope: {authorization.Scope}");
        Console.WriteLine($"Refresh Possible: {authorization.IsRefreshPossible}");
        Console.WriteLine($"Valid: {authorization.IsValid}");
        Console.WriteLine($"Access Token: {authorization.AccessToken}");
        Console.WriteLine($"Refresh Token: {authorization.RefreshToken}");
        Console.WriteLine($"Token Expired: {authorization.IsExpired}");

        DateTime expirationDate = created.AddSeconds(authorization.ExpiresInSeconds);
        TimeSpan difference = expirationDate - DateTime.UtcNow;

        int days = difference.Days > 0 ? difference.Days : 0;
        int hours = difference.Hours > 0 ? difference.Hours : 0;
        int minutes = difference.Minutes > 0 ? difference.Minutes : 0;

        Console.WriteLine($"Expires in {days} Days, {hours} Hours, {minutes} Minutes");
    }
}
