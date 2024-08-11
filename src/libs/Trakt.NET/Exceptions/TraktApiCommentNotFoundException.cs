namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a comment was not found.</summary>
    public sealed partial class TraktApiCommentNotFoundException : TraktApiObjectNotFoundException
    {
        /// <summary>The not found comment ID.</summary>
        public string CommentID => ObjectID;
    }
}
