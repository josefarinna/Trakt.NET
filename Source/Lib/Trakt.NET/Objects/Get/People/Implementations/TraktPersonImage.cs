
namespace TraktNet.Objects.Get.People.Implementations
{
    using System.Collections.Generic;

    /// <summary>An image for an item available in only one size.</summary>
    public class TraktPersonImage : ITraktPersonImage
    {
        /// <summary>The address to the headshot image.<para>Nullable</para></summary>
        public IList<string> Headshot { get; set; }

        /// <summary>The address to the fanart image.<para>Nullable</para></summary>
        public IList<string> Fanart { get; set; }
    }
}
