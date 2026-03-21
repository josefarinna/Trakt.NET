namespace TraktNET
{
    /// <summary>Represents a Trakt comment object item.</summary>
    public record class TraktCommentItem
    {
        /// <summary>Gets or sets the object type of the comment item.</summary>
        public TraktCommentObjectType? Type { get; set; }

        /// <summary>Gets or sets the comment movie item, if <see cref="Type" /> is set to <see cref="TraktCommentObjectType.Movie" />.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>Gets or sets the comment show item, if <see cref="Type" /> is set to <see cref="TraktCommentObjectType.Show" />.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>Gets or sets the comment season item, if <see cref="Type" /> is set to <see cref="TraktCommentObjectType.Season" />.</summary>
        public TraktSeason? Season { get; set; }

        /// <summary>Gets or sets the comment episode item, if <see cref="Type" /> is set to <see cref="TraktCommentObjectType.Episode" />.</summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>Gets or sets the comment list item, if <see cref="Type" /> is set to <see cref="TraktCommentObjectType.List" />.</summary>
        public TraktList? List { get; set; }
    }
}
