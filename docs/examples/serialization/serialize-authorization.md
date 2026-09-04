# Serialize Authorization

This example shows how we can serialize a given authorization as JSON data and deserialize the JSON data back to an authorization.

For this example we simply create a fake authorization.

[!code-csharp[](../../codesnippets/examples/serialization/SerializationExample.cs#L15-L15)]

We use [`System.Text.Json.JsonSerializer`](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializer) to serialize the previously created authorization as JSON data.

[!code-csharp[](../../codesnippets/examples/serialization/SerializationExample.cs#L17-L20)]

Then, we use [`System.Text.Json.JsonSerializer`](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializer) to deserialize the JSON data back to a [`TraktAuthorization`](xref:TraktNET.TraktAuthorization) object.

[!code-csharp[](../../codesnippets/examples/serialization/SerializationExample.cs#L22-L36)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/serialization/SerializationExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0/docs/codesnippets/examples/serialization/SerializationExample.cs)__
