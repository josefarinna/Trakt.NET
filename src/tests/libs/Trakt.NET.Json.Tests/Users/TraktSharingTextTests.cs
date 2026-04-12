namespace TraktNET.Json.Users
{
    public sealed class TraktSharingTextTests
    {
        [Fact]
        public void TestTraktSharingTextDefaultConstructor()
        {
            var sharingText = new TraktSharingText();

            sharingText.Watching.ShouldBeNull();
            sharingText.Watched.ShouldBeNull();
            sharingText.Rated.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSharingTextFromJson()
        {
            TraktSharingText? sharingText = await TestUtility.DeserializeJsonAsync<TraktSharingText>("Users\\sharingtext.json");

            sharingText.ShouldNotBeNull();
            sharingText.Watching.ShouldBe("I'm watching [item]");
            sharingText.Watched.ShouldBe("I just watched [item]");
            sharingText.Rated.ShouldBe("[item] [stars]");
        }
    }
}
