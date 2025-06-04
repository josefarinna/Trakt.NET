namespace TraktNet.Objects.Get.People
{
    using System.Collections.Generic;

    /// <summary>A collection of images and image sets for a Trakt People.</summary>
    public interface ITraktPersonImage
    {
        /// <summary>The address to the headshot image.<para>Nullable</para></summary>
        public IList<string> Headshot { get; set; }

        /// <summary>The address to the fanart image.<para>Nullable</para></summary>
        public IList<string> Fanart { get; set; }
    }
}
