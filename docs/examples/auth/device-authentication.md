# Device Authentication

In this example we authenticate our Trakt.NET client with the Device Authentication method to get Trakt authorization, which is required for OAuth requests.

For authentication and authorization requests the Client-ID and Client-Secret are both required.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L13-L19)]

We can now request authorization by authenticating with the Device Authentication method.

The following lines show the steps which are required to get an authorization.

## Create a new device

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L23-L25)]

The created device has a verification URL

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L39-L39)]

which the user needs to visit.

Secondly, the created device has a user code

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L40-L40)]

which the user needs to enter on the verification website.

The user needs to visit the verification website and enter the user code.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L38-L40)]

## Poll for Authorization

We poll for authorization.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L42-L55)]

There are some additional steps in this example, which are not required for authenticating. They only show the usage in the context of this example.

## Refresh Authorization

Refreshing an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L60-L76)]

## Revoke Authorization

Revoking an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L81-L88)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/auth/DeviceAuthenticationExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0/docs/codesnippets/examples/auth/DeviceAuthenticationExample.cs)__
