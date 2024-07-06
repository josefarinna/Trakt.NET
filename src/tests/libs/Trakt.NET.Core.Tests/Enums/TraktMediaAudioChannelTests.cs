namespace TraktNET.Enums
{
    public sealed class TraktMediaAudioChannelTests
    {
        [Fact]
        public void TestTraktMediaAudioChannelToJson()
        {
            TraktMediaAudioChannel.Unspecified.ToJson().Should().BeNull();
            TraktMediaAudioChannel.Channels10.ToJson().Should().Be("1.0");
            TraktMediaAudioChannel.Channels20.ToJson().Should().Be("2.0");
            TraktMediaAudioChannel.Channels21.ToJson().Should().Be("2.1");
            TraktMediaAudioChannel.Channels30.ToJson().Should().Be("3.0");
            TraktMediaAudioChannel.Channels31.ToJson().Should().Be("3.1");
            TraktMediaAudioChannel.Channels40.ToJson().Should().Be("4.0");
            TraktMediaAudioChannel.Channels41.ToJson().Should().Be("4.1");
            TraktMediaAudioChannel.Channels50.ToJson().Should().Be("5.0");
            TraktMediaAudioChannel.Channels51.ToJson().Should().Be("5.1");
            TraktMediaAudioChannel.Channels512.ToJson().Should().Be("5.1.2");
            TraktMediaAudioChannel.Channels514.ToJson().Should().Be("5.1.4");
            TraktMediaAudioChannel.Channels61.ToJson().Should().Be("6.1");
            TraktMediaAudioChannel.Channels71.ToJson().Should().Be("7.1");
            TraktMediaAudioChannel.Channels712.ToJson().Should().Be("7.1.2");
            TraktMediaAudioChannel.Channels714.ToJson().Should().Be("7.1.4");
            TraktMediaAudioChannel.Channels91.ToJson().Should().Be("9.1");
            TraktMediaAudioChannel.Channels101.ToJson().Should().Be("10.1");
        }

        [Fact]
        public void TestTraktMediaAudioChannelFromJson()
        {
            "unspecified".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Unspecified);
            "1.0".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels10);
            "2.0".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels20);
            "2.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels21);
            "3.0".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels30);
            "3.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels31);
            "4.0".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels40);
            "4.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels41);
            "5.0".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels50);
            "5.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels51);
            "5.1.2".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels512);
            "5.1.4".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels514);
            "6.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels61);
            "7.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels71);
            "7.1.2".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels712);
            "7.1.4".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels714);
            "9.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels91);
            "10.1".ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Channels101);

            string? nullValue = null;
            nullValue.ToTraktMediaAudioChannel().Should().Be(TraktMediaAudioChannel.Unspecified);
        }

        [Fact]
        public void TestTraktMediaAudioChannelDisplayName()
        {
            TraktMediaAudioChannel.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktMediaAudioChannel.Channels10.DisplayName().Should().Be("Channels 1.0");
            TraktMediaAudioChannel.Channels20.DisplayName().Should().Be("Channels 2.0");
            TraktMediaAudioChannel.Channels21.DisplayName().Should().Be("Channels 2.1");
            TraktMediaAudioChannel.Channels30.DisplayName().Should().Be("Channels 3.0");
            TraktMediaAudioChannel.Channels31.DisplayName().Should().Be("Channels 3.1");
            TraktMediaAudioChannel.Channels40.DisplayName().Should().Be("Channels 4.0");
            TraktMediaAudioChannel.Channels41.DisplayName().Should().Be("Channels 4.1");
            TraktMediaAudioChannel.Channels50.DisplayName().Should().Be("Channels 5.0");
            TraktMediaAudioChannel.Channels51.DisplayName().Should().Be("Channels 5.1");
            TraktMediaAudioChannel.Channels512.DisplayName().Should().Be("Channels 5.1.2");
            TraktMediaAudioChannel.Channels514.DisplayName().Should().Be("Channels 5.1.4");
            TraktMediaAudioChannel.Channels61.DisplayName().Should().Be("Channels 6.1");
            TraktMediaAudioChannel.Channels71.DisplayName().Should().Be("Channels 7.1");
            TraktMediaAudioChannel.Channels712.DisplayName().Should().Be("Channels 7.1.2");
            TraktMediaAudioChannel.Channels714.DisplayName().Should().Be("Channels 7.1.4");
            TraktMediaAudioChannel.Channels91.DisplayName().Should().Be("Channels 9.1");
            TraktMediaAudioChannel.Channels101.DisplayName().Should().Be("Channels 10.1");
        }
    }
}
