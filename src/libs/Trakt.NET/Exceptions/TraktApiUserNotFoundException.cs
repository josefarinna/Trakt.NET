namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an user was not found.</summary>
    public sealed partial class TraktApiUserNotFoundException : TraktApiObjectNotFoundException
    {
        /// <summary>The not found user ID.</summary>
        public string UserID => ObjectID;
    }
}
