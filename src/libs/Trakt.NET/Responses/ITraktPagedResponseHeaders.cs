namespace TraktNET
{
    public interface ITraktPagedResponseHeaders
    {
        uint? PageCount { get; }

        uint? ItemCount { get; }
    }
}
