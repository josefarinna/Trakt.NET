namespace TraktNET
{
    /// <summary>Represents the avatar data to update for a user.</summary>
    public record class TraktUserAvatarPost
    {
        /// <summary>Gets or sets the user object containing the avatar.</summary>
        public TraktUserAvatarPostUser? User { get; set; }

        public void Validate()
        {
            ArgumentValidator.ThrowIfNull(User);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(User!.Avatar, "user avatar must not be null or empty or only whitespace");
        }
    }
}
