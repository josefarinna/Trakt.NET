namespace TraktNET
{
    /// <summary>A collection of IDs for various web services.</summary>
    public interface ITraktIds
    {
        /// <summary>Returns, whether any ID has been set.</summary>
        bool HasAnyID { get; }

        /// <summary>Gets the most reliable ID from those that have been set.</summary>
        /// <returns>The ID as a string or an empty string, if no ID is set.</returns>
        string BestID { get; }
    }
}
