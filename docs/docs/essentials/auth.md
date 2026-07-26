# Authentication and Authorization

Authentication is necessary if you need to call Trakt API requests that require authorization. Every method in the library that requires authorization indicates this in its method documentation.

The Trakt API provides two methods for authenticating users and both are supported by the library. For more information read the [OAuth Authentication](auth.md#oauth-authentication) and [Device Authentication](auth.md#device-authentication) sections.

## Authorization

Authorization information for the Trakt API contains not only the access token but also a refresh token, that makes it possible to retrieve new authorization information without authenticating the user again and without the need of the user to interact.

The [`TraktAuthorization`](xref:TraktNET.TraktAuthorization) record class represents such authorization information. It also contains the UTC DateTime when it was created and can tell you if it is expired and if the containing authorization information can be [refreshed](auth.md#refresh-authorization). You can get a new TraktAuthorization instance by authenticating the user either with [OAuth](auth.md#oauth-authentication)- or [Device](auth.md#device-authentication)-Authentication.

If you already have an access token (and optionally a refresh token), you can create a new [`TraktAuthorization`](xref:TraktNET.TraktAuthorization) instance in one of the following ways:

```csharp
using TraktNET;

TraktAuthorization authorization = TraktAuthorization.CreateWith("existing access token");

// or

TraktAuthorization authorization = TraktAuthorization.CreateWith("existing access token", "existing refresh token");

// or,
// if you also have the DateTime, when the authorization was created
// and the value, after which the authorization expires

DateTime createdAt = DateTime.UtcNow.AddDays(-30); // 30 days ago
uint expiresInSeconds = 3600 * 24 * 90; // 90 days (default value), has to be in seconds

TraktAuthorization authorization = TraktAuthorization.CreateWith(createdAt, expiresInSeconds, "existing access token");
TraktAuthorization authorization = TraktAuthorization.CreateWith(createdAt, expiresInSeconds, "existing access token", "existing refresh token");
```

And then just pass it to your [`TraktClient`](xref:TraktNET.TraktClient) instance:

```csharp
client.Authorization = authorization;
```

## OAuth Authentication

The workflow for authenticating users with the [traditional OAuth method](https://trakt.docs.apiary.io/#reference/authentication-oauth) is the following:

1. Create an authorization URL: `string authorizationUrl = client.Auth.CreateAuthorizationUrl();`
2. Your users need to visit the `authorizationUrl`'s webpage.
3. Your users need to provide you a PIN code that they get from Trakt.tv.
4. Get authorization with the PIN code provided by your users:

```csharp
using TraktNET;

string code = "12345678"; // PIN code from your users
TraktResponse<TraktAuthorization> authorizationResponse = await client.Auth.GetAuthorizationAsync(code);
TraktAuthorization authorization = authorizationResponse.Content!;
```

> [!NOTE]
> You don't need to pass the returned [`TraktAuthorization`](xref:TraktNET.TraktAuthorization) to your [`TraktClient`](xref:TraktNET.TraktClient) instance. This happens automatically inside the library.

[Here](../../examples/auth/oauth-authentication.md) is an example of how to authenticate a user with OAuth Authentication.

## Device Authentication

The workflow for authenticating users with the [Device method](https://trakt.docs.apiary.io/#reference/authentication-devices) is the following:

1. Create a new [`TraktDevice`](xref:TraktNET.TraktDevice): `TraktResponse<TraktDevice> deviceResponse = await client.Auth.GenerateDeviceAsync();` The returned [`TraktDevice`](xref:TraktNET.TraktDevice) is valid for about ten minutes and contains a device code and a verification URL.
2. Your users need to visit the `device.VerificationUrl` web page and enter the `device.UserCode` on that web page.
3. Simultaneously you need to poll for the new authorization:

```csharp
using TraktNET;

TraktResponse<TraktAuthorization> authorizationResponse = await client.Auth.PollForAuthorizationAsync();
TraktAuthorization authorization = authorizationResponse.Content!;
```

> [!NOTE]
> You don't need to pass the returned [`TraktAuthorization`](xref:TraktNET.TraktAuthorization) to your [`TraktClient`](xref:TraktNET.TraktClient) instance. This happens automatically inside the library.

[Here](../../examples/auth/device-authentication.md) is an example of how to authenticate a user with Device Authentication.

## Refresh Authorization

The Trakt authorization information will be valid for 90 days for each one of your users. You need to refresh the authorization before the current one expires. Your [`TraktAuthorization`](xref:TraktNET.TraktAuthorization) needs to have a valid refresh token set. You can check this with its property `IsRefreshPossible`. To refresh the current authorization, call:

```csharp
using TraktNET;

// Precondition: client.Authorization is already set
TraktResponse<TraktAuthorization> newAuthorizationResponse = await client.Auth.RefreshAuthorizationAsync();
TraktAuthorization newAuthorization = newAuthorizationResponse.Content!;
```

## Revoke Authorization

Revoking the current authorization is also very simple:

```csharp
await client.Auth.RevokeAuthorizationAsync();
```
