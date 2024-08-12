namespace TraktNET
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktRequestParameterAttribute() : Attribute
    {
        public bool UseCacheEfficientDateTime { get; set; }
    }
}
