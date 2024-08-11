namespace TraktNET.Json.Shows
{
    public sealed class TraktShowAirsTests
    {
        [Fact]
        public void TestTraktShowAirsConstructor()
        {
            var showAirs = new TraktShowAirs();

            showAirs.Day.Should().BeNull();
            showAirs.Time.Should().BeNull();
            showAirs.Timezone.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktShowAirsFromJson()
        {
            TraktShowAirs? showAirs = await TestUtility.DeserializeJsonAsync<TraktShowAirs>("Shows\\showairs.json");

            showAirs.Should().NotBeNull();

            showAirs!.Day.Should().Be(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            showAirs!.Time.Should().Be(TestUtility.ParseTime("21:00"));
#else
            showAirs!.Time.Should().Be("21:00");
#endif
            showAirs!.Timezone.Should().Be("America/New_York");
        }
    }
}
