namespace TraktNET.Json.General
{
    public partial class TraktRatingTests
    {
        [Fact]
        public void TestTraktRatingConstructor()
        {
            var rating = new TraktRating();

            rating.Rating.Should().BeNull();
            rating.Votes.Should().BeNull();
            rating.Distribution.Should().BeNull();
            rating.ToString().Should().Be("Empty");
        }

        [Fact]
        public async Task TestTraktRatingFromJson()
        {
            TraktRating? rating = await TestUtility.DeserializeJsonAsync<TraktRating>("General\\rating.json");

            rating.Should().NotBeNull();

            rating!.Rating.Should().Be(7.96017f);
            rating!.Votes.Should().Be(18906U);
            rating!.Distribution.Should().NotBeNullOrEmpty().And.HaveCount(10).And.BeEquivalentTo(new Dictionary<string, uint>
            {
                { "1", 91 },
                { "2", 55 },
                { "3", 66 },
                { "4", 142 },
                { "5", 421 },
                { "6", 1598 },
                { "7", 3699 },
                { "8", 6286 },
                { "9", 3805 },
                { "10", 2734 }
            });

            rating!.ToString().Should().Be("7.96017, 18906");
        }
    }
}
