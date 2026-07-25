using System.Diagnostics.CodeAnalysis;

namespace TraktNET
{
    ///<summary>Creates a Trakt PUT request.</summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktPutRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Put, path)
    {
    }
}
