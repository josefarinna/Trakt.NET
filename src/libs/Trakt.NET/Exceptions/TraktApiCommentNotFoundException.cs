namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a comment was not found.</summary>
    public sealed partial class TraktApiCommentNotFoundException : TraktApiObjectNotFoundException
    {
        public string CommentId => ObjectId;
    }
}
