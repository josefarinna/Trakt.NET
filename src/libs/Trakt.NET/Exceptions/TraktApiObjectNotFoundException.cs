namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an object was not found.</summary>
    public partial class TraktApiObjectNotFoundException : TraktApiNotFoundException
    {
        public string ObjectId { get; }
    }
}
