namespace TraktNET
{
    /// <summary>
    /// A Trakt collection remove post, containing all movies, shows, seasons and / or episodes,
    /// which should be removed from the user's collection.
    /// </summary>
    public record class TraktSyncCollectionRemovePost : TraktSyncCollectionPost
    {
    }
}
