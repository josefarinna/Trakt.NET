namespace TraktNet.Objects.Get.Users
{
    using Basic;

    /// <summary>A collection of images and image sets for a Trakt user.</summary>
    public interface ITraktUserImages
    {
        /// <summary>Gets or sets the avatar image. See also <seealso cref="ITraktImageArt" />.<para>Nullable</para></summary>
        ITraktImageArt Avatar { get; set; }
    }
}
