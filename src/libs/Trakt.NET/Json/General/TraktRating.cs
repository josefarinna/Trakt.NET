namespace TraktNET
{
    /// <summary>A Trakt rating.</summary>
    public record class TraktRating
    {
        /// <summary>The rating value.</summary>
        public float? Rating { get; set; }

        /// <summary>The number of votes for this rating.</summary>
        public uint? Votes { get; set; }

        /// <summary>The rating distribution.</summary>
        public Dictionary<string, uint>? Distribution { get; set; }

        /// <summary>Gets a string representation of the rating, showing the rating value and the vote count.</summary>
        /// <returns>A string representation of the rating, showing the rating value and the vote count.</returns>
        public override string ToString()
        {
            if (Rating.HasValue && Votes.HasValue)
            {
                return $"{Rating.Value.ToInvariantCultureString()}, {Votes.Value.ToInvariantCultureString()}";
            }

            return "Empty";
        }
    }
}
