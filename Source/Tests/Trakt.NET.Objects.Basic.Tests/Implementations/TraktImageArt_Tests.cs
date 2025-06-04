namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktImageArt_Tests
    {
        [Fact]
        public void Test_TraktImage_Default_Constructor()
        {
            var traktImage = new TraktImageArt();

            traktImage.Full.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktImage_From_Json()
        {
            var jsonReader = new ImageArtObjectJsonReader();
            var traktImage = await jsonReader.ReadObjectAsync(JSON) as TraktImageArt;

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        private const string JSON =
            @"{
                ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
              }";
    }
}
