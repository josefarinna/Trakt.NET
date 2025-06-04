
namespace TraktNet.Objects.Get.Seasons.Implementations
{
    using System.Collections.Generic;

    /// <summary>An image for an item available in only one size.</summary>
    public class TraktSeasonImage : ITraktSeasonImage
    {
        /// <summary>The address to the poster image.<para>Nullable</para></summary>
        public IList<string> Poster { get; set; }

        /// <summary>The address to the thumb image.<para>Nullable</para></summary>
        public IList<string> Thumb { get; set; }
    }
}
