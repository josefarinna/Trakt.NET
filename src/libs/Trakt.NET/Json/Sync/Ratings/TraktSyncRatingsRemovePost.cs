namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings remove post, containing all movies, shows, seasons and / or episodes,
    /// which should be removed from the user's ratings.
    /// </summary>
    public record class TraktSyncRatingsRemovePost : TraktSyncRatingsPost
    {
    }
}
