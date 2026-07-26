# Null Handling

The Trakt API might not return all data, especially when you are not using extended info. Therefore, you should check object properties for null.

```csharp
using TraktNET;

TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync("game-of-thrones");
string? showOverview = showResponse.Content?.Overview;  // will be null without extended info

// with extended info

TraktResponse<TraktShow> showResponseExtended = await client.Shows.GetShowAsync("game-of-thrones", TraktExtendedInfo.Full);
string? showOverviewFull = showResponseExtended.Content?.Overview; // contains overview text
```
