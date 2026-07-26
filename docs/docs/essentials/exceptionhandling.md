# Exception Handling

**Trakt.NET** uses exceptions extensively. Every exception in the library inherits from [`TraktException`](xref:TraktNET.TraktException). That means you don't need to catch every single exception thrown by the library, only [`TraktException`](xref:TraktNET.TraktException):

## Usage

The library usage looks like this:

```csharp
using TraktNET;

try
{
    var response = await client.Shows.GetShowAsync("game-of-thrones");
}
catch (TraktException ex)
{
    Console.WriteLine($"Exception message: {ex.Message}");
    Console.WriteLine($"Status code: {ex.StatusCode}");
}
```

If you want to catch a specific exception, the usage looks like this:

```csharp
try
{
    var response = await client.Movies.GetMovieAsync("unknown-slug");
}
catch (TraktMovieNotFoundException ex) // Specific exception thrown when a movie is not found
{
    // Do something with the exception
} 
catch (TraktException ex) // Base exception type
{
    // Do something with the exception
}
```

## Argument Exceptions

Exceptions to be aware of before requests are sent include [`ArgumentNullException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception), [`ArgumentException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) and [`ArgumentOutOfRangeException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception). They are thrown if invalid arguments are passed to library methods.

> [!NOTE]
> Trakt.NET checks all input parameters before any actual Trakt API request is made.

## Not Found Exceptions

For every possible Trakt media object (show, movie, person, etc.), there is also an exception if the object was not found, e.g. a call to

```csharp
using TraktNET;

TraktResponse<TraktShow> show = await client.Shows.GetShowAsync("unknown-slug");
```

could throw a [`TraktShowNotFoundException`](xref:TraktNET.TraktShowNotFoundException).

Each not-found exception has a property `ObjectId` that tells you the ID which was not found.

For more information on responses see the [Responses Section](responses.md).

## Rate Limit Exception

Rate limits can be caught with the exception [`TraktRateLimitException`](xref:TraktNET.TraktRateLimitException).
This exception provides detailed information about the rate limit.

## Failed VIP Validation Exception

The Trakt.tv API provides requests which can only be used by VIP users.
If a non-VIP user tries to use such a request, a [`TraktFailedVIPValidationException`](xref:TraktNET.TraktFailedVIPValidationException) is thrown.
This exception provides an `UpgradeURL` where the user can sign up for Trakt.tv VIP.

## User Account Limit Exception

A [`TraktUserAccountLimitException`](xref:TraktNET.TraktUserAccountLimitException) is thrown when a user has exceeded their account limits, such as list counts, item counts, etc.

## Locked User Account Exception

If an OAuth authorized user has a locked user account, a [`TraktLockedUserAccountException`](xref:TraktNET.TraktLockedUserAccountException) is thrown.

## Request Validation Exception

Any argument given to a module method is validated before actually executing the request.
If an ID is not valid, a [`TraktRequestValidationException`](xref:TraktNET.TraktRequestValidationException) is thrown.

## Post Validation Exception

For post requests where data is sent to the Trakt.tv API, a [`TraktPostValidationException`](xref:TraktNET.TraktPostValidationException) might be thrown if the post object contains invalid data.
