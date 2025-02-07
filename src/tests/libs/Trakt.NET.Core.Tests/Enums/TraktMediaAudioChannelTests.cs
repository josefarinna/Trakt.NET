namespace TraktNET.Enums
{
    public sealed class TraktMediaAudioChannelTests
    {
        [Fact]
        public void TestTraktMediaAudioChannelToJson()
        {
            TraktMediaAudioChannel.Unspecified.ToJson().ShouldBeNull();
            TraktMediaAudioChannel.Channels10.ToJson().ShouldBe("1.0");
            TraktMediaAudioChannel.Channels20.ToJson().ShouldBe("2.0");
            TraktMediaAudioChannel.Channels21.ToJson().ShouldBe("2.1");
            TraktMediaAudioChannel.Channels30.ToJson().ShouldBe("3.0");
            TraktMediaAudioChannel.Channels31.ToJson().ShouldBe("3.1");
            TraktMediaAudioChannel.Channels40.ToJson().ShouldBe("4.0");
            TraktMediaAudioChannel.Channels41.ToJson().ShouldBe("4.1");
            TraktMediaAudioChannel.Channels50.ToJson().ShouldBe("5.0");
            TraktMediaAudioChannel.Channels51.ToJson().ShouldBe("5.1");
            TraktMediaAudioChannel.Channels512.ToJson().ShouldBe("5.1.2");
            TraktMediaAudioChannel.Channels514.ToJson().ShouldBe("5.1.4");
            TraktMediaAudioChannel.Channels61.ToJson().ShouldBe("6.1");
            TraktMediaAudioChannel.Channels71.ToJson().ShouldBe("7.1");
            TraktMediaAudioChannel.Channels712.ToJson().ShouldBe("7.1.2");
            TraktMediaAudioChannel.Channels714.ToJson().ShouldBe("7.1.4");
            TraktMediaAudioChannel.Channels91.ToJson().ShouldBe("9.1");
            TraktMediaAudioChannel.Channels101.ToJson().ShouldBe("10.1");
        }

        [Fact]
        public void TestTraktMediaAudioChannelFromJson()
        {
            "unspecified".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Unspecified);
            "1.0".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels10);
            "2.0".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels20);
            "2.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels21);
            "3.0".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels30);
            "3.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels31);
            "4.0".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels40);
            "4.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels41);
            "5.0".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels50);
            "5.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels51);
            "5.1.2".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels512);
            "5.1.4".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels514);
            "6.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels61);
            "7.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels71);
            "7.1.2".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels712);
            "7.1.4".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels714);
            "9.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels91);
            "10.1".ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Channels101);

            string? nullValue = null;
            nullValue.ToTraktMediaAudioChannel().ShouldBe(TraktMediaAudioChannel.Unspecified);
        }

        [Fact]
        public void TestTraktMediaAudioChannelDisplayName()
        {
            TraktMediaAudioChannel.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMediaAudioChannel.Channels10.DisplayName().ShouldBe("Channels 1.0");
            TraktMediaAudioChannel.Channels20.DisplayName().ShouldBe("Channels 2.0");
            TraktMediaAudioChannel.Channels21.DisplayName().ShouldBe("Channels 2.1");
            TraktMediaAudioChannel.Channels30.DisplayName().ShouldBe("Channels 3.0");
            TraktMediaAudioChannel.Channels31.DisplayName().ShouldBe("Channels 3.1");
            TraktMediaAudioChannel.Channels40.DisplayName().ShouldBe("Channels 4.0");
            TraktMediaAudioChannel.Channels41.DisplayName().ShouldBe("Channels 4.1");
            TraktMediaAudioChannel.Channels50.DisplayName().ShouldBe("Channels 5.0");
            TraktMediaAudioChannel.Channels51.DisplayName().ShouldBe("Channels 5.1");
            TraktMediaAudioChannel.Channels512.DisplayName().ShouldBe("Channels 5.1.2");
            TraktMediaAudioChannel.Channels514.DisplayName().ShouldBe("Channels 5.1.4");
            TraktMediaAudioChannel.Channels61.DisplayName().ShouldBe("Channels 6.1");
            TraktMediaAudioChannel.Channels71.DisplayName().ShouldBe("Channels 7.1");
            TraktMediaAudioChannel.Channels712.DisplayName().ShouldBe("Channels 7.1.2");
            TraktMediaAudioChannel.Channels714.DisplayName().ShouldBe("Channels 7.1.4");
            TraktMediaAudioChannel.Channels91.DisplayName().ShouldBe("Channels 9.1");
            TraktMediaAudioChannel.Channels101.DisplayName().ShouldBe("Channels 10.1");
        }
    }
}
