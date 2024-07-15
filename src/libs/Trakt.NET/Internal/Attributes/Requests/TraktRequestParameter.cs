namespace TraktNET
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktRequestParameter() : Attribute
    {
    }
}
