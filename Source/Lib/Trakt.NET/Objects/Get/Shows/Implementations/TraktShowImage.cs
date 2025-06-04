namespace TraktNet.Objects.Get.Shows.Implementations
{
    using System.Collections.Generic;

    /// <summary>An image for an item available in only one size.</summary>
    public class TraktShowImage : ITraktShowImage
    {
        /// <summary>The address to the fanart image.<para>Nullable</para></summary>
        public IList<string> Fanart { get; set; }

        /// <summary>The address to the poster image.<para>Nullable</para></summary>
        public IList<string> Poster { get; set; }

        /// <summary>The address to the logo image.<para>Nullable</para></summary>
        public IList<string> Logo { get; set; }

        /// <summary>The address to the clearart image.<para>Nullable</para></summary>
        public IList<string> Clearart { get; set; }

        /// <summary>The address to the banner image.<para>Nullable</para></summary>
        public IList<string> Banner { get; set; }

        /// <summary>The address to the thumb image.<para>Nullable</para></summary>
        public IList<string> Thumb { get; set; }
    }
}
