# Serialization

In **Trakt.NET** v2.0, JSON serialization and deserialization utilize high-performance, reflection-free `System.Text.Json` source generation (`JsonSerializerContextFactory`). All model objects (`TraktShow`, `TraktMovie`, `TraktUser`, etc.) are standard C# record classes that integrate seamlessly with `System.Text.Json.JsonSerializer`.

## Serialize

You can serialize any **Trakt.NET** object to a JSON string using `System.Text.Json.JsonSerializer`.

### Single JSON Object
```csharp
using System;
using System.Text.Json;
using TraktNET;

var client = new TraktClient("Your Trakt Client ID");

// Get basic info about a show
TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync("the-last-of-us");
TraktShow show = showResponse.Value;

// Serialize the show object as a JSON string with indentation
string showJson = JsonSerializer.Serialize(show, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(showJson);
```

## Deserialize

### Single JSON Object
```csharp
using System.Text.Json;
using TraktNET;

// Deserialize a show object from a JSON string
TraktShow? show = JsonSerializer.Deserialize<TraktShow>(showJson);
```

### Collection of JSON Objects
```csharp
using System.Collections.Generic;
using System.Text.Json;
using TraktNET;

// Deserialize a list of show objects from a JSON string
List<TraktShow>? shows = JsonSerializer.Deserialize<List<TraktShow>>(showsJson);
```
