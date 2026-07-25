using System.Diagnostics.CodeAnalysis;

namespace TraktNET
{
    ///<summary>Creates a Trakt GET request.</summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktGetRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Get, path)
    {
    }
}
