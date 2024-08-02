namespace TraktNET
{
    public record class TraktUserImages
    {
        public TraktUserImagesAvatar? Avatar { get; set; }
    }

    public record class TraktUserImagesAvatar
    {
        public string? Full { get; set; }
    }
}
