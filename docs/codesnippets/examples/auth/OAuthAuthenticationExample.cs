using Trakt.NET.Examples.Helper;
using TraktNET;

namespace Trakt.NET.Examples.Authentication;

internal static class AuthenticationOAuthExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - OAuth Authentication Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        Console.WriteLine("Please enter your Trakt Client-Secret:");
        string? clientSecret = Console.ReadLine();

        var client = new TraktClient(clientID!, clientSecret!);

        try
        {
            string authorizationUrl = client.Auth.CreateAuthorizationUrl();

            if (!string.IsNullOrEmpty(authorizationUrl))
            {
                Console.WriteLine("You have to authenticate this application.");
                Console.WriteLine("Please visit the following webpage:");
                Console.WriteLine($"{authorizationUrl}\n");

                Console.WriteLine("Enter the PIN code from Trakt.tv:");
                string? code = Console.ReadLine();

                if (!string.IsNullOrEmpty(code))
                {
                    TraktResponse<TraktAuthorization> authorizationResponse = await client.Auth.GetAuthorizationAsync(code);

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
