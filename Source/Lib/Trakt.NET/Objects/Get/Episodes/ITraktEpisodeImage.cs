namespace TraktNet.Objects.Get.Episodes
{
    using System.Collections.Generic;

    /// <summary>A collection of images and image sets for a Trakt Episode.</summary>
    public interface ITraktEpisodeImage
    {
        /// <summary>The address to the poster image.<para>Nullable</para></summary>
        public IList<string> Screenshot { get; set; }
    }
}
