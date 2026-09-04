# OAuth Authentication

In this example we authenticate our Trakt.NET client with the OAuth Authentication method to get Trakt authorization, which is required for OAuth requests.

For authentication and authorization requests the Client-ID and Client-Secret are both required.

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L13-L19)]

We can now request authorization by authenticating with the OAuth Authentication method.

The following lines show the steps which are required to get an authorization.

## Create Authorization URL

Create an authorization URL:

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L23-L23)]

## Get Authorization

Trakt.tv returns a PIN code which is needed to get the Trakt authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L36-L49)]

There are some additional steps in this example, which are not required for authenticating. They only show the usage in the context of this example.

## Refresh Authorization

Refreshing an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L54-L70)]

## Revoke Authorization

Revoking an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L75-L82)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/auth/OAuthAuthenticationExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0/docs/codesnippets/examples/auth/OAuthAuthenticationExample.cs)__
