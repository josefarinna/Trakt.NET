using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// An user personal list items post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktUserPersonalListItemsPostShow : TraktUserRemovePostShow
    {
        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the personal list.
        /// Otherwise, only the specified seasons and / or episodes will be added to the personal list.
        /// </para>
        /// </summary>
        public new List<TraktUserPersonalListItemsPostShowSeason>? Seasons { get; set; }

        /// <summary>Gets or sets the show notes.</summary>
        public string? Notes { get; set; }
    }
}
