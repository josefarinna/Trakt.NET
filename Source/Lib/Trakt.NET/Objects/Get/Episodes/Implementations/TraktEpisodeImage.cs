
namespace TraktNet.Objects.Get.Episodes.Implementations
{
    using System.Collections.Generic;

    /// <summary>An image for an item available in only one size.</summary>
    public class TraktEpisodeImage : ITraktEpisodeImage
    {
        /// <summary>The address to the screenshot image.<para>Nullable</para></summary>
        public IList<string> Screenshot { get; set; }
    }
}
