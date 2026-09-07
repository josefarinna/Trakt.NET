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
            TraktExtendedInfo.All.ToJson().ShouldBe("all");
            TraktExtendedInfo.StreamingRanks.ToJson().ShouldBe("streaming_ranks");
            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.ToJson().ShouldBeNull();
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
            "all".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.All);
            "streaming_ranks".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.StreamingRanks);

            string? nullValue = null;
            nullValue.ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
            "invalid".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
            "".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
        }

        [Fact]
        public void TestTraktExtendedInfoToURI()
        {
            TraktExtendedInfo.None.ToURI().ShouldBe(string.Empty);
            TraktExtendedInfo.Metadata.ToURI().ShouldBe("metadata");
            TraktExtendedInfo.Full.ToURI().ShouldBe("full");
            TraktExtendedInfo.Min.ToURI().ShouldBe("min");
            TraktExtendedInfo.NoSeasons.ToURI().ShouldBe("noseasons");
            TraktExtendedInfo.Progress.ToURI().ShouldBe("progress");
            TraktExtendedInfo.Episodes.ToURI().ShouldBe("episodes");
            TraktExtendedInfo.GuestStars.ToURI().ShouldBe("guest_stars");
            TraktExtendedInfo.Comments.ToURI().ShouldBe("comments");
            TraktExtendedInfo.VIP.ToURI().ShouldBe("vip");
            TraktExtendedInfo.Images.ToURI().ShouldBe("images");
            TraktExtendedInfo.Subgenres.ToURI().ShouldBe("subgenres");
            TraktExtendedInfo.Browsing.ToURI().ShouldBe("browsing");
            TraktExtendedInfo.All.ToURI().ShouldBe("all");
            TraktExtendedInfo.StreamingRanks.ToURI().ShouldBe("streaming_ranks");
            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.ToURI().ShouldBe(string.Empty);
            ((TraktExtendedInfo)16384).ToURI().ShouldBe(string.Empty);
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
            TraktExtendedInfo.All.DisplayName().ShouldBe("All");
            TraktExtendedInfo.StreamingRanks.DisplayName().ShouldBe("Streaming Ranks");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.DisplayName().ShouldBe("Full, VIP");

            TraktExtendedInfo fullAndImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
            fullAndImages.DisplayName().ShouldBe("Full, Images");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.DisplayName().ShouldBe("Full, Comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.DisplayName().ShouldBe("Episodes, Guest Stars");
            ((TraktExtendedInfo)16384).DisplayName().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktExtendedInfoHasFlagSet()
        {
            TraktExtendedInfo.None.HasFlagSet(TraktExtendedInfo.None).ShouldBeTrue();
            TraktExtendedInfo.None.HasFlagSet(TraktExtendedInfo.Full).ShouldBeFalse();
            TraktExtendedInfo full = TraktExtendedInfo.Full;
            full.HasFlagSet(TraktExtendedInfo.None).ShouldBeTrue();
            full.HasFlagSet(TraktExtendedInfo.Full).ShouldBeTrue();
            full.HasFlagSet(TraktExtendedInfo.VIP).ShouldBeFalse();
            TraktExtendedInfo combined = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            combined.HasFlagSet(TraktExtendedInfo.None).ShouldBeTrue();
            combined.HasFlagSet(TraktExtendedInfo.Full).ShouldBeTrue();
            combined.HasFlagSet(TraktExtendedInfo.VIP).ShouldBeTrue();
            combined.HasFlagSet(TraktExtendedInfo.Images).ShouldBeFalse();
            combined.HasFlagSet(TraktExtendedInfo.Full | TraktExtendedInfo.VIP).ShouldBeTrue();
            combined.HasFlagSet(TraktExtendedInfo.Full | TraktExtendedInfo.Images).ShouldBeFalse();
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
            TraktExtendedInfo.All.AsQuery().ShouldBe("extended=all");
            TraktExtendedInfo.StreamingRanks.AsQuery().ShouldBe("extended=streaming_ranks");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.AsQuery().ShouldBe("extended=full,vip");

            TraktExtendedInfo fullAndImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
            fullAndImages.AsQuery().ShouldBe("extended=full,images");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.AsQuery().ShouldBe("extended=full,comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.AsQuery().ShouldBe("extended=episodes,guest_stars");

            TraktExtendedInfo fullAndStreamingRanks = TraktExtendedInfo.Full | TraktExtendedInfo.StreamingRanks;
            fullAndStreamingRanks.AsQuery().ShouldBe("extended=full,streaming_ranks");
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
            JsonSerializer.Serialize(TraktExtendedInfo.Full | TraktExtendedInfo.VIP, options).ShouldBe("null");
            JsonSerializer.Deserialize<TraktExtendedInfo>("\"metadata\"", options).ShouldBe(TraktExtendedInfo.Metadata);
            JsonSerializer.Deserialize<TraktExtendedInfo>("\"\"", options).ShouldBe(TraktExtendedInfo.None);
            JsonSerializer.Deserialize<TraktExtendedInfo>("\"invalid\"", options).ShouldBe(TraktExtendedInfo.None);
        }
    }
}
