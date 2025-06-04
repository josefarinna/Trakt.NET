namespace TraktNet.Objects.Get.Seasons
{
    using System.Collections.Generic;

    /// <summary>A collection of images and image sets for a Trakt Season.</summary>
    public interface ITraktSeasonImage
    {
        /// <summary>The address to the poster image.<para>Nullable</para></summary>
        public IList<string> Poster { get; set; }

        /// <summary>The address to the thumb image.<para>Nullable</para></summary>
        public IList<string> Thumb { get; set; }
    }
}
