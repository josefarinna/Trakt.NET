namespace TraktNET
{
    /// <summary>A collection of images and image sets for a Trakt user.</summary>
    public record class TraktUserImages
    {
        /// <summary>The avatar image. See also <seealso cref="TraktUserImagesAvatar" />.</summary>
        public TraktUserImagesAvatar? Avatar { get; set; }
    }

    /// <summary>An image for an user available in only one size.</summary>
    public record class TraktUserImagesAvatar
    {
        /// <summary>The address to the full size image.</summary>
        public string? Full { get; set; }
    }
}
