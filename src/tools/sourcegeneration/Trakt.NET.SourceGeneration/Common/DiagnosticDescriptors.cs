using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Common
{
    internal static class DiagnosticDescriptors
    {
        private const string EnumsCategory = "Trakt.NET.SourceGeneration.Enums";
        private const string RequestsCategory = "Trakt.NET.SourceGeneration.Requests";

        public static DiagnosticDescriptor InvalidQueryNameValue { get; } = new(
            id: "TRAKTNET1001",
            title: "Invalid query name value for Trakt enum.",
            messageFormat: "Query name value for Trakt enum is null or empty.",
            category: EnumsCategory,
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static DiagnosticDescriptor InvalidDisplayNameValue { get; } = new(
            id: "TRAKTNET1002",
            title: "Invalid display name value for Trakt enum member.",
            messageFormat: "Display name for Trakt enum member is null or not of type 'string'.",
            category: EnumsCategory,
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static DiagnosticDescriptor InvalidJsonValue { get; } = new(
            id: "TRAKTNET1003",
            title: "Invalid json value for Trakt enum member.",
            messageFormat: "Json value for Trakt enum member is null or not of type 'string'.",
            category: EnumsCategory,
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static DiagnosticDescriptor InvalidQuerySupportAndQueryNameCombination { get; } = new(
            id: "TRAKTNET1004",
            title: "Invalid query support and query name combination",
            messageFormat: "Query support is enabled but query name is null or empty.",
            category: EnumsCategory,
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static DiagnosticDescriptor InvalidRequestUriPathValue { get; } = new(
            id: "TRAKTNET1005",
            title: "Invalid URI path for Trakt request",
            messageFormat: "URI path for Trakt request is null, empty or not of type 'string'.",
            category: RequestsCategory,
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);
    }
}
