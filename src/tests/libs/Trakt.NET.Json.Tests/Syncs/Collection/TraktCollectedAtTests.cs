using System.Text.Json;

namespace TraktNET.Json.Syncs
{
    public sealed class TraktCollectedAtTests
    {
        [Fact]
        public void TestTraktCollectedAtStaticOptions()
        {
            TraktCollectedAt released = TraktCollectedAt.Released;
            released.IsReleased.ShouldBeTrue();
            released.IsUnknown.ShouldBeFalse();
            released.IsNow.ShouldBeFalse();
            released.HasDateTime.ShouldBeFalse();
            released.DateTime.ShouldBeNull();
            released.Value.ShouldBe("released");
            released.ToString().ShouldBe("released");

            TraktCollectedAt unknown = TraktCollectedAt.Unknown;
            unknown.IsReleased.ShouldBeFalse();
            unknown.IsUnknown.ShouldBeTrue();
            unknown.IsNow.ShouldBeFalse();
            unknown.HasDateTime.ShouldBeFalse();
            unknown.DateTime.ShouldBeNull();
            unknown.Value.ShouldBe("unknown");
            unknown.ToString().ShouldBe("unknown");

            TraktCollectedAt now = TraktCollectedAt.Now;
            now.IsReleased.ShouldBeFalse();
            now.IsUnknown.ShouldBeFalse();
            now.IsNow.ShouldBeTrue();
            now.HasDateTime.ShouldBeFalse();
            now.DateTime.ShouldBeNull();
            now.Value.ShouldBe("now");
            now.ToString().ShouldBe("now");
        }

        [Fact]
        public void TestTraktCollectedAtDateTimeAndImplicitConversions()
        {
            var timestamp = new DateTime(2014, 9, 1, 9, 10, 11, DateTimeKind.Utc);
            TraktCollectedAt collectedAt = timestamp;

            collectedAt.HasDateTime.ShouldBeTrue();
            collectedAt.DateTime.ShouldBe(timestamp);
            collectedAt.IsReleased.ShouldBeFalse();
            collectedAt.IsUnknown.ShouldBeFalse();
            collectedAt.IsNow.ShouldBeFalse();
            collectedAt.Value.ShouldBe("2014-09-01T09:10:11.000Z");
            collectedAt.ToString().ShouldBe("2014-09-01T09:10:11.000Z");

            DateTime? convertedBack = collectedAt;
            convertedBack.ShouldBe(timestamp);

            DateTime? fromReleased = TraktCollectedAt.Released;
            fromReleased.ShouldBeNull();

            var defaultCollectedAt = default(TraktCollectedAt);
            defaultCollectedAt.Value.ShouldBeNull();
            defaultCollectedAt.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktCollectedAtJsonConverter()
        {
            var converter = new TraktCollectedAtJsonConverter();
            converter.CanConvert(typeof(TraktCollectedAt)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCollectedAt.Released, options).ShouldBe("\"released\"");
            JsonSerializer.Serialize(TraktCollectedAt.Unknown, options).ShouldBe("\"unknown\"");
            JsonSerializer.Serialize(TraktCollectedAt.Now, options).ShouldBe("\"now\"");
            JsonSerializer.Serialize(default(TraktCollectedAt), options).ShouldBe("null");

            var timestamp = new DateTime(2014, 9, 1, 9, 10, 11, DateTimeKind.Utc);
            JsonSerializer.Serialize(new TraktCollectedAt(timestamp), options).ShouldBe("\"2014-09-01T09:10:11Z\"");

            JsonSerializer.Deserialize<TraktCollectedAt>("\"released\"", options).ShouldBe(TraktCollectedAt.Released);
            JsonSerializer.Deserialize<TraktCollectedAt>("\"unknown\"", options).ShouldBe(TraktCollectedAt.Unknown);
            JsonSerializer.Deserialize<TraktCollectedAt>("\"now\"", options).ShouldBe(TraktCollectedAt.Now);
            JsonSerializer.Deserialize<TraktCollectedAt>("\"2014-09-01T09:10:11.000Z\"", options).ShouldBe(new TraktCollectedAt(timestamp));
            JsonSerializer.Deserialize<TraktCollectedAt>("\"\"", options).ShouldBe(default);
            JsonSerializer.Deserialize<TraktCollectedAt>("null", options).ShouldBe(default);
        }

        [Fact]
        public void TestTraktSyncCollectionPostMovieSerializeCollectedAt()
        {
            var movie = new TraktSyncCollectionPostMovie
            {
                CollectedAt = TraktCollectedAt.Released,
                IDs = new TraktMovieIDs { Trakt = 1U },
                Audio = TraktMediaAudio.DolbyDigitalPlusAtmos
            };

            string json = TestUtility.SerializeObject(movie);
            json.ShouldContain("\"collected_at\":\"released\"");
            json.ShouldContain("\"audio\":\"dolby_digital_plus_atmos\"");
        }
    }
}

