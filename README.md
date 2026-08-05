# Trakt.NET (Extended & Modernized Fork)

> **Note**: This repository is a modernized, high-performance fork of `Trakt.NET`. It introduces full support for media image retrieval across Trakt.tv endpoints, source-generated `System.Text.Json` serialization, Native AOT & Trimming compatibility, concrete C# record data models (no interfaces), support for modern .NET runtimes (.NET 6 through .NET 10), and new API modules (Smart Lists, Social Recommendations, Notes, Team, WatchNow, Younify, Plex integration).

[![NuGet Package](https://img.shields.io/badge/Latest%20Version%20on%20NuGet-v2.0.0--alpha.1-blue.svg?style=flat)](https://www.nuget.org/packages/Trakt.NET.Ex/2.0.0-alpha.1)
[![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT)
[![codecov](https://codecov.io/github/josefarinna/Trakt.NET/graph/badge.svg?token=R66P6V55FL)](https://codecov.io/github/josefarinna/Trakt.NET)

### Overview

`Trakt.NET` is a comprehensive .NET wrapper library that enables developers to build applications integrating with the [Trakt.tv API](https://trakt.docs.apiary.io/#).

Key capabilities include:
- Fetching rich metadata for movies, TV shows, seasons, episodes, and people (including full media image URLs).
- Tracking user watch histories, scrobbles, ratings, and watchlists.
- Recommending TV shows and movies based on watch history and social recommendations.
- Managing custom lists, smart lists, notes, comments, and personal collections.

To use this library, you will need a Client ID and Client Secret from your [Trakt.tv API Application](https://trakt.tv/oauth/applications).

### Features

- **Full Trakt.tv API Coverage**: Supports all core Trakt.tv v2 endpoints including newly added API modules.
- **Concrete Record Data Models**: Replaced all `ITrakt...` interfaces with strongly-typed C# `record class` models (`TraktShow`, `TraktMovie`, `TraktEpisode`, etc.) for zero allocation overhead and better performance.
- **Media Image Support**: Fetch image metadata for movies, shows, seasons, episodes, people, users, and lists via `TraktExtendedInfo.Images`.
- **System.Text.Json Source Generation**: Built-in source generator (`Trakt.NET.SourceGeneration`) delivering zero-reflection, high-performance JSON serialization using standard `System.Text.Json`.
- **Native AOT & Trimming Support**: Compatible with Native AOT compilation (`IsAotCompatible`) and assembly trimming (`IsTrimmable`) for lightweight deployments.
- **Modern .NET Target Frameworks**: Native support for .NET 6.0, .NET 7.0, .NET 8.0, .NET 9.0, and .NET 10.0, alongside .NET Standard 2.0 / 2.1 and .NET Framework.
- **Authentication & Authorization**: OAuth 2.0 and Device Code Authentication flow support.
- **Asynchronous Architecture**: `async`/`await` pattern used across all API requests.

### Supported API Modules

Below is the list of supported API modules available via `TraktClient`:

| Module | Property | Description |
|---|---|---|
| **Auth** | `client.Auth` | OAuth 2.0 and Device authentication flows |
| **Calendar** | `client.Calendar` | User & global show/movie release calendars |
| **Certifications** | `client.Certifications` | Movie & show content certification ratings |
| **Checkins** | `client.Checkins` | Check-in to movies and episodes |
| **Comments** | `client.Comments` | Post, update, like, and retrieve comments & reviews |
| **Countries / Genres / Languages** | `client.Countries` / `Genres` / `Languages` | Reference lookup data |
| **Episodes & Seasons** | `client.Episodes` / `client.Seasons` | Episode and season metadata, progress, and images |
| **Lists** | `client.Lists` | Public and popular custom lists |
| **Media** | `client.Media` | Media metadata lookups |
| **Movies & Shows** | `client.Movies` / `client.Shows` | Movie and TV show details, trending, recommendations, images |
| **Networks** | `client.Networks` | TV network lists |
| **Notes** *(New)* | `client.Notes` | Attach and manage personal user notes on Trakt items |
| **People** | `client.People` | Actors, directors, crew metadata and credits |
| **Recommendations** | `client.Recommendations` | Personalized movie & show recommendations |
| **Scrobble** | `client.Scrobble` | Real-time playback status tracking (start, pause, stop) |
| **Search** | `client.Search` | Search by query or ID (IMDb, TMDB, TVDB) |
| **Smart Lists** *(New)* | `client.SmartLists` | Create, manage, and filter Smart Lists |
| **Social Recommendations** *(New)* | `client.SocialRecommendations` | Friend & social network media recommendations |
| **Sync** | `client.Sync` | Sync watch history, ratings, collection, favorites, and watchlist |
| **Team** *(New)* | `client.Team` | Trakt Team staff and contributor information |
| **Users** | `client.Users` | User profiles, Plex settings integration, limits, and stats |
| **WatchNow** *(New / Notice)* | `client.Watchnow` | Streaming availability and sources *(Note: Provided for API visibility/completeness; availability may vary or be non-functional depending on Trakt backend support)* |
| **Younify** *(New)* | `client.Younify` | Younify integration management |

> [!NOTE]
> **WatchNow Disclaimer**: The `client.Watchnow` module methods are implemented for API completeness and visibility. Depending on Trakt.tv's API status and client access tier, some WatchNow endpoints may return empty results or be non-functional.

### Supported Platforms

| Platform | Supported Versions |
|---|---|
| **.NET Runtimes** | .NET 6.0, .NET 7.0, .NET 8.0, .NET 9.0, .NET 10.0 |
| **.NET Standard** | .NET Standard 2.0, .NET Standard 2.1 |
| **.NET Framework** | .NET Framework >= 4.7.2 |
| **Mobile & Cross-Platform** | .NET MAUI, Android, iOS, macOS, Mac Catalyst |

### Quickstart

#### Installation

Install the package via the .NET CLI:

```bash
dotnet add package Trakt.NET.Ex --version 2.0.0-alpha.1
```

#### Code Example

```csharp
using System;
using System.Linq;
using System.Text.Json;
using TraktNET;

var client = new TraktClient("Your Trakt Client ID");

try
{
    // Request show information with extended image info
    TraktExtendedInfo extendedInfo = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
    TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync("the-last-of-us", extendedInfo);
    TraktShow show = showResponse.Value;
    
    Console.WriteLine($"Title: {show.Title}");
    Console.WriteLine($"Year: {show.Year}");
    
    if (show.Images != null)
    {
        Console.WriteLine($"Fanart: {show.Images.Fanart?.FirstOrDefault()}");
        Console.WriteLine($"Poster: {show.Images.Poster?.FirstOrDefault()}");
    }

    // High-performance JSON serialization using System.Text.Json
    string json = JsonSerializer.Serialize(show, new JsonSerializerOptions { WriteIndented = true });
    Console.WriteLine(json);
}
catch (TraktException ex)
{
    Console.WriteLine($"Trakt API Error: {ex.Message}");
}
```

### Documentation

- [Changelogs](Changelogs/v2.0.0-alpha.1.md)
- [Official Trakt API Documentation](https://docs.trakt.tv/)

### License

```text
The MIT License (MIT)

Copyright (c) 2016 - 2026 Henrik Fröhling and Contributors

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
