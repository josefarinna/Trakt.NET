namespace TraktNET
{
    /// <summary>Represents user profile avatar data to update.</summary>
    public record class TraktUserAvatarPostUser
    {
        /// <summary>Gets or sets the avatar image data in base64.</summary>
        public string? Avatar { get; set; }
    }
}
