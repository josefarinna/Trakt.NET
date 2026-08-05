# Quick Start
[![NuGet Package](https://img.shields.io/badge/Latest%20Version%20on%20NuGet-v2.0.0--alpha.1-blue.svg?style=flat)](https://www.nuget.org/packages/Trakt.NET.Ex/2.0.0-alpha.1) [![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT) 

`Trakt.NET` is a modernized, high-performance .NET wrapper library with which developers can build .NET applications that integrate with the [Trakt.tv API](https://docs.trakt.tv/reference).

## Install latest Trakt.NET package

```ps
dotnet add package Trakt.NET.Ex --version 2.0.0-alpha.1
```

## Get basic info about the show "[The Last of Us](https://trakt.tv/shows/the-last-of-us)" (including media images)

```csharp
using System;
using System.Linq;
using System.Text.Json;
using TraktNET;

var client = new TraktClient("Your Trakt Client ID", "Your Trakt Client Secret");

try
{
    TraktExtendedInfo extendedInfo = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
    TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync("the-last-of-us", extendedInfo);

    if (showResponse.IsSuccess && showResponse.HasValue)
    {
        TraktShow show = showResponse.Content!;
        
        Console.WriteLine($"Title: {show.Title}");
        Console.WriteLine($"Year: {show.Year}");
        
        if (show.Images != null)
        {
            Console.WriteLine($"Fanart: {show.Images.Fanart?.FirstOrDefault()}");
            Console.WriteLine($"Poster: {show.Images.Poster?.FirstOrDefault()}");
        }

        Console.WriteLine();

        string json = JsonSerializer.Serialize(show, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
    }
}
catch (TraktException ex)
{
    Console.WriteLine($"Trakt API Error: {ex.Message}");
}
```

### Output

```ps
Title: The Last of Us
Year: 2023
Fanart: https://walter.trakt.tv/images/shows/000/158/947/fanarts/medium/e17e47ef6b.jpg
Poster: https://walter.trakt.tv/images/shows/000/158/947/posters/medium/e17e47ef6b.jpg
```

```json
{
  "title": "The Last of Us",
  "year": 2023,
  "ids": {
    "trakt": 158947,
    "slug": "the-last-of-us",
    "tvdb": 392256,
    "imdb": "tt3581920",
    "tmdb": 100088
  }
}
```

## What can I do with this library?

Some examples that **Trakt.NET** can be used for include:
- Retrieve information about movies and TV shows, including details such as titles, descriptions, ratings, release dates, and full media image URLs
- Track TV shows and movies a user is watching, has watched, or wants to watch
- Recommendations for TV shows and movies based on watch history and social networks
- Build custom TV show and movie lists, including Smart Lists and personal Notes

To use **Trakt.NET**, you will need to [obtain an API key](https://trakt.tv/oauth/applications) from Trakt and follow the guidelines for using the [API](https://docs.trakt.tv/reference).

## Features
- Full Trakt.tv API Coverage & Expanded Modules (Smart Lists, Social Recommendations, Notes, Team, WatchNow, Younify)
- Concrete Record Class Models (`TraktShow`, `TraktMovie`, `TraktEpisode`, etc.) without interface overhead
- Media Image Support across all supported Trakt objects (`TraktExtendedInfo.Images`)
- System.Text.Json Source Generation for zero-reflection serialization (`Trakt.NET.SourceGeneration`)
- Native AOT (`IsAotCompatible`) and Assembly Trimming (`IsTrimmable`) support
- Authentication and Authorization Support (OAuth 2.0 and Device)
- Completely asynchronous architecture

## Supported Platforms
- .NET 6.0, .NET 7.0, .NET 8.0, .NET 9.0, .NET 10.0
- .NET Standard 2.0, .NET Standard 2.1
- .NET Framework >= 4.7.2
- .NET MAUI / iOS / Android / macOS / Mac Catalyst
