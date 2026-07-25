using System.Diagnostics.CodeAnalysis;

namespace TraktNET
{
    ///<summary>Creates a Trakt POST request.</summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktPostRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Post, path)
    {
    }
}
