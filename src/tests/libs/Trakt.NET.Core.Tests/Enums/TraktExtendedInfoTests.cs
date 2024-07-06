namespace TraktNET.Enums
{
    public class TraktExtendedInfoTests
    {
        [Fact]
        public void TestTraktExtendedInfoToJson()
        {
            TraktExtendedInfo.None.ToJson().Should().BeEmpty();
            TraktExtendedInfo.Metadata.ToJson().Should().Be("metadata");
            TraktExtendedInfo.Full.ToJson().Should().Be("full");
            TraktExtendedInfo.NoSeasons.ToJson().Should().Be("noseasons");
            TraktExtendedInfo.Episodes.ToJson().Should().Be("episodes");
            TraktExtendedInfo.GuestStars.ToJson().Should().Be("guest_stars");
            TraktExtendedInfo.Comments.ToJson().Should().Be("comments");
            TraktExtendedInfo.VIP.ToJson().Should().Be("vip");
        }

        [Fact]
        public void TestTraktExtendedInfoFromJson()
        {
            string.Empty.ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.None);
            "metadata".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.Metadata);
            "full".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.Full);
            "noseasons".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.NoSeasons);
            "episodes".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.Episodes);
            "guest_stars".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.GuestStars);
            "comments".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.Comments);
            "vip".ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.VIP);

            string? nullValue = null;
            nullValue.ToTraktExtendedInfo().Should().Be(TraktExtendedInfo.None);
        }

        [Fact]
        public void TestTraktExtendedInfoDisplayName()
        {
            TraktExtendedInfo.None.DisplayName().Should().Be("None");
            TraktExtendedInfo.Metadata.DisplayName().Should().Be("Metadata");
            TraktExtendedInfo.Full.DisplayName().Should().Be("Full");
            TraktExtendedInfo.NoSeasons.DisplayName().Should().Be("No Seasons");
            TraktExtendedInfo.Episodes.DisplayName().Should().Be("Episodes");
            TraktExtendedInfo.GuestStars.DisplayName().Should().Be("Guest Stars");
            TraktExtendedInfo.Comments.DisplayName().Should().Be("Comments");
            TraktExtendedInfo.VIP.DisplayName().Should().Be("VIP");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.DisplayName().Should().Be("Full, VIP");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.DisplayName().Should().Be("Full, Comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.DisplayName().Should().Be("Episodes, Guest Stars");
        }

        [Fact]
        public void TestTraktExtendedInfoAsQuery()
        {
            TraktExtendedInfo.None.AsQuery().Should().BeEmpty();
            TraktExtendedInfo.Metadata.AsQuery().Should().Be("extended=metadata");
            TraktExtendedInfo.Full.AsQuery().Should().Be("extended=full");
            TraktExtendedInfo.NoSeasons.AsQuery().Should().Be("extended=noseasons");
            TraktExtendedInfo.Episodes.AsQuery().Should().Be("extended=episodes");
            TraktExtendedInfo.GuestStars.AsQuery().Should().Be("extended=guest_stars");
            TraktExtendedInfo.Comments.AsQuery().Should().Be("extended=comments");
            TraktExtendedInfo.VIP.AsQuery().Should().Be("extended=vip");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.AsQuery().Should().Be("extended=full,vip");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.AsQuery().Should().Be("extended=full,comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.AsQuery().Should().Be("extended=episodes,guest_stars");
        }
    }
}
