namespace TraktNET
{
    ///<summary>Creates a Trakt DELETE request.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktDeleteRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Delete, path)
    {
    }
}
