# Calendar Filter

In this example we create a filter to refine calendar shows results.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilterExample.cs#L12-L15)]

The following lines create a new filter for specific genres and year.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilterExample.cs#L17-L21)]

Get all new calendar shows filtered with the above created filter.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilterExample.cs#L25-L38)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/parameters/filter/CalendarFilterExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0-alpha.1/docs/codesnippets/examples/parameters/filter/CalendarFilterExample.cs)__
