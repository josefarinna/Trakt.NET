using System.Diagnostics.CodeAnalysis;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktRequestQueryAttribute(string? queryName = null) : Attribute
    {
        public string? QueryName { get; } = queryName;

        public bool UseCacheEfficientDateTime { get; set; }
    }
}
