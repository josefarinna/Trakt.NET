namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an object was not found.</summary>
    public partial class TraktApiObjectNotFoundException : TraktApiNotFoundException
    {
        /// <summary>The not found object ID.</summary>
        public string ObjectID { get; }
    }
}
