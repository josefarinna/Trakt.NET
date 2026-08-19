using System.Text.Json;

namespace TraktNET.Enums
{
    public class TraktExtendedInfoTests
    {
        [Fact]
        public void TestTraktExtendedInfoToJson()
        {
            TraktExtendedInfo.None.ToJson().ShouldBeEmpty();
            TraktExtendedInfo.Metadata.ToJson().ShouldBe("metadata");
            TraktExtendedInfo.Full.ToJson().ShouldBe("full");
            TraktExtendedInfo.Min.ToJson().ShouldBe("min");
            TraktExtendedInfo.NoSeasons.ToJson().ShouldBe("noseasons");
            TraktExtendedInfo.Progress.ToJson().ShouldBe("progress");
            TraktExtendedInfo.Episodes.ToJson().ShouldBe("episodes");
            TraktExtendedInfo.GuestStars.ToJson().ShouldBe("guest_stars");
            TraktExtendedInfo.Comments.ToJson().ShouldBe("comments");
            TraktExtendedInfo.VIP.ToJson().ShouldBe("vip");
            TraktExtendedInfo.Images.ToJson().ShouldBe("images");
            TraktExtendedInfo.Subgenres.ToJson().ShouldBe("subgenres");
            TraktExtendedInfo.Browsing.ToJson().ShouldBe("browsing");
            ((TraktExtendedInfo)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktExtendedInfoFromJson()
        {
            string.Empty.ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
            "metadata".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Metadata);
            "full".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Full);
            "min".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Min);
            "noseasons".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.NoSeasons);
            "progress".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Progress);
            "episodes".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Episodes);
            "guest_stars".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.GuestStars);
            "comments".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Comments);
            "vip".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.VIP);
            "images".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Images);
            "subgenres".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Subgenres);
            "browsing".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Browsing);

            string? nullValue = null;
            nullValue.ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
            "invalid".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
            "".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
        }

        [Fact]
        public void TestTraktExtendedInfoDisplayName()
        {
            TraktExtendedInfo.None.DisplayName().ShouldBe("None");
            TraktExtendedInfo.Metadata.DisplayName().ShouldBe("Metadata");
            TraktExtendedInfo.Full.DisplayName().ShouldBe("Full");
            TraktExtendedInfo.Min.DisplayName().ShouldBe("Min");
            TraktExtendedInfo.NoSeasons.DisplayName().ShouldBe("No Seasons");
            TraktExtendedInfo.Progress.DisplayName().ShouldBe("Progress");
            TraktExtendedInfo.Episodes.DisplayName().ShouldBe("Episodes");
            TraktExtendedInfo.GuestStars.DisplayName().ShouldBe("Guest Stars");
            TraktExtendedInfo.Comments.DisplayName().ShouldBe("Comments");
            TraktExtendedInfo.VIP.DisplayName().ShouldBe("VIP");
            TraktExtendedInfo.Images.DisplayName().ShouldBe("Images");
            TraktExtendedInfo.Subgenres.DisplayName().ShouldBe("Subgenres");
            TraktExtendedInfo.Browsing.DisplayName().ShouldBe("Browsing");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.DisplayName().ShouldBe("Full, VIP");

            TraktExtendedInfo fullAndImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
            fullAndImages.DisplayName().ShouldBe("Full, Images");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.DisplayName().ShouldBe("Full, Comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.DisplayName().ShouldBe("Episodes, Guest Stars");
        }

        [Fact]
        public void TestTraktExtendedInfoAsQuery()
        {
            TraktExtendedInfo.None.AsQuery().ShouldBeEmpty();
            TraktExtendedInfo.Metadata.AsQuery().ShouldBe("extended=metadata");
            TraktExtendedInfo.Full.AsQuery().ShouldBe("extended=full");
            TraktExtendedInfo.Min.AsQuery().ShouldBe("extended=min");
            TraktExtendedInfo.NoSeasons.AsQuery().ShouldBe("extended=noseasons");
            TraktExtendedInfo.Progress.AsQuery().ShouldBe("extended=progress");
            TraktExtendedInfo.Episodes.AsQuery().ShouldBe("extended=episodes");
            TraktExtendedInfo.GuestStars.AsQuery().ShouldBe("extended=guest_stars");
            TraktExtendedInfo.Comments.AsQuery().ShouldBe("extended=comments");
            TraktExtendedInfo.VIP.AsQuery().ShouldBe("extended=vip");
            TraktExtendedInfo.Images.AsQuery().ShouldBe("extended=images");
            TraktExtendedInfo.Subgenres.AsQuery().ShouldBe("extended=subgenres");
            TraktExtendedInfo.Browsing.AsQuery().ShouldBe("extended=browsing");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.AsQuery().ShouldBe("extended=full,vip");

            TraktExtendedInfo fullAndImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
            fullAndImages.AsQuery().ShouldBe("extended=full,images");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.AsQuery().ShouldBe("extended=full,comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.AsQuery().ShouldBe("extended=episodes,guest_stars");
        }

        [Fact]
        public void TestTraktExtendedInfoJsonConverter()
        {
            var converter = new TraktExtendedInfoJsonConverter();
            converter.CanConvert(typeof(TraktExtendedInfo)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktExtendedInfo.Metadata, options).ShouldBe("\"metadata\"");
            JsonSerializer.Deserialize<TraktExtendedInfo>("\"metadata\"", options).ShouldBe(TraktExtendedInfo.Metadata);
            JsonSerializer.Deserialize<TraktExtendedInfo>("\"\"", options).ShouldBe(TraktExtendedInfo.None);
        }
    }
}
