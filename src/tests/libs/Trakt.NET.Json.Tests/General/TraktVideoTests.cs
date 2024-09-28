namespace TraktNET.Json.General
{
    public partial class TraktVideoTests
    {
        [Fact]
        public void TestTraktVideoConstructor()
        {
            var video = new TraktVideo();

            video.Title.Should().BeNull();
            video.Url.Should().BeNull();
            video.Site.Should().BeNull();
            video.Type.Should().BeNull();
            video.Size.Should().BeNull();
            video.Official.Should().BeNull();
            video.PublishedAt.Should().BeNull();
            video.Country.Should().BeNull();
            video.Language.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktVideoFromJson()
        {
            TraktVideo? video = await TestUtility.DeserializeJsonAsync<TraktVideo>("General\\video.json");

            video.Should().NotBeNull();

            video!.Title.Should().Be("Disney+ Promo");
            video!.Url.Should().Be("https://youtube.com/watch?v=3RLT34SwtQc");
            video!.Site.Should().Be("youtube");
            video!.Type.Should().Be(TraktVideoType.Teaser);
            video!.Size.Should().Be(1080U);
            video!.Official.Should().BeTrue();
            video!.PublishedAt.Should().Be(TestUtility.ParseUTCDateTime("2023-08-03T18:00:02.000Z"));
            video!.Country.Should().Be("us");
            video!.Language.Should().Be("en");
        }

        [Fact]
        public async Task TestTraktVideosFromJson()
        {
            IReadOnlyList<TraktVideo>? videos = await TestUtility.DeserializeJsonListAsync<TraktVideo>("General\\videos.json");

            videos.Should().NotBeNull().And.HaveCount(2);

            TraktVideo video = videos![0];

            video.Should().NotBeNull();

            video.Title.Should().Be("Disney+ Promo");
            video.Url.Should().Be("https://youtube.com/watch?v=3RLT34SwtQc");
            video.Site.Should().Be("youtube");
            video.Type.Should().Be(TraktVideoType.Teaser);
            video.Size.Should().Be(1080U);
            video.Official.Should().BeTrue();
            video.PublishedAt.Should().Be(TestUtility.ParseUTCDateTime("2023-08-03T18:00:02.000Z"));
            video.Country.Should().Be("us");
            video.Language.Should().Be("en");

            // --------------------------------------------------------------------------------------------

            video = videos![1];

            video.Should().NotBeNull();

            video.Title.Should().Be("Now Streaming on Disney+");
            video.Url.Should().Be("https://youtube.com/watch?v=D3NpwOB69Ys");
            video.Site.Should().Be("youtube");
            video.Type.Should().Be(TraktVideoType.Teaser);
            video.Size.Should().Be(1080U);
            video.Official.Should().BeTrue();
            video.PublishedAt.Should().Be(TestUtility.ParseUTCDateTime("2023-08-02T16:00:17.000Z"));
            video.Country.Should().Be("us");
            video.Language.Should().Be("en");
        }
    }
}
