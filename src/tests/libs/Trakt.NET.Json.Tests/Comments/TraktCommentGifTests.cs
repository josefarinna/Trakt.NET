namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentGifTests
    {
        [Fact]
        public void TestTraktCommentGifConstructor()
        {
            var commentGif = new TraktCommentGif();

            commentGif.Url.ShouldBeNull();
            commentGif.Slug.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCommentGifFromJson()
        {
            TraktCommentGif? commentGif = await TestUtility.DeserializeJsonAsync<TraktCommentGif>("Comments\\commentgif.json");

            commentGif.ShouldNotBeNull();
            commentGif!.Url.ShouldBe("https://example.com/image.gif");
            commentGif!.Slug.ShouldBe("funny-cat");
        }

        [Fact]
        public async Task TestTraktCommentGifFromJsonWithoutSlug()
        {
            TraktCommentGif? commentGif = await TestUtility.DeserializeJsonAsync<TraktCommentGif>("Comments\\commentgif_minimal.json");

            commentGif.ShouldNotBeNull();
            commentGif!.Url.ShouldBe("https://example.com/image.gif");
            commentGif!.Slug.ShouldBeNull();
        }
    }
}
