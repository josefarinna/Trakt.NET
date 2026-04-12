namespace TraktNET
{
    /// <summary>
    /// An user hidden items post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktUserHiddenItemsPostShow : TraktUserRemovePostShow
    {
        /// <summary>
        /// An optional list of <see cref="TraktUserHiddenItemsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the hidden items list.
        /// Otherwise, only the specified seasons will be added to the hidden items list.
        /// </para>
        /// </summary>
        public new List<TraktUserHiddenItemsPostShowSeason>? Seasons { get; set; }
    }
}
