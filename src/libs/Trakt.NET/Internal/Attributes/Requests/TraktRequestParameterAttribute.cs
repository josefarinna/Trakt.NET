using System.Diagnostics.CodeAnalysis;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktRequestParameterAttribute() : Attribute
    {
        public bool UseCacheEfficientDateTime { get; set; }
    }
}
