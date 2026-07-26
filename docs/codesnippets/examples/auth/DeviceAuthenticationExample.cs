using Trakt.NET.Examples.Helper;
using TraktNET;

namespace Trakt.NET.Examples.Authentication;

internal static class AuthenticationDeviceExample
{
    public static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Device Authentication Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        Console.WriteLine("Please enter your Trakt Client-Secret:");
        string? clientSecret = Console.ReadLine();

        var client = new TraktClient(clientID!, clientSecret!);

        try
        {
            TraktResponse<TraktDevice> deviceResponse = await client.Auth.GenerateDeviceAsync();

            TraktDevice device = deviceResponse.Content!;

            if (device.IsValid)
            {
                Console.WriteLine("-------------- Device created successfully --------------");
                Console.WriteLine($"Device Created (UTC): {device.CreatedAt}");
                Console.WriteLine($"Device Code: {device.DeviceCode}");
                Console.WriteLine($"Device expires in {device.ExpiresInSeconds} seconds");
                Console.WriteLine($"Device Interval: {device.IntervalInSeconds} seconds");
                Console.WriteLine($"Device Expired Unused: {device.IsExpiredUnused}");
                Console.WriteLine($"Device Valid: {device.IsValid}");
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine("You have to authenticate this application.");
                Console.WriteLine($"Please visit the following webpage: {device.VerificationUrl}");
                Console.WriteLine($"Sign in or sign up on that webpage and enter the following code: {device.UserCode}");

                TraktResponse<TraktAuthorization> authorizationResponse = await client.Auth.PollForAuthorizationAsync();

                TraktAuthorization authorization = authorizationResponse.Content!;

                if (authorization.IsValid)
                {
                    Console.WriteLine("-------------- Authentication successful --------------");
                    authorization.WriteAuthorizationInformation();
                    Console.WriteLine("-------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-------------- Authentication failed --------------");
                }

                Console.WriteLine("Do you want to refresh the current authorization? [y/n]:");
                string? yesNo = Console.ReadLine();

                if (yesNo != null && yesNo.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    TraktResponse<TraktAuthorization> newAuthorizationResponse = await client.Auth.RefreshAuthorizationAsync();

                    TraktAuthorization newAuthorization = newAuthorizationResponse.Content!;

                    if (newAuthorization.IsValid)
                    {
                        Console.WriteLine("-------------- Authorization refreshed successfully --------------");
                        newAuthorization.WriteAuthorizationInformation();
                        Console.WriteLine("-------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("-------------- Refreshing Authorization failed --------------");
                    }
                }

                Console.WriteLine("Do you want to revoke your authorization? [y/n]:");
                yesNo = Console.ReadLine();

                if (yesNo != null && yesNo.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    TraktResponse response = await client.Auth.RevokeAuthorizationAsync();

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Authorization revoked successfully");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
        catch (TraktException ex)
        {
            Console.WriteLine("-------------- Trakt Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine();
    }
}
