namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a movie was not found.</summary>
    public sealed partial class TraktApiMovieNotFoundException : TraktApiObjectNotFoundException
    {
        /// <summary>The not found movie ID.</summary>
        public string MovieID => ObjectID;
    }
}
