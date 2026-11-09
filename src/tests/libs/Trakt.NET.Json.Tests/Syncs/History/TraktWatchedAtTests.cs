using System.Text.Json;

namespace TraktNET.Json.Syncs
{
    public sealed class TraktWatchedAtTests
    {
        [Fact]
        public void TestTraktWatchedAtStaticOptions()
        {
            TraktWatchedAt released = TraktWatchedAt.Released;
            released.IsReleased.ShouldBeTrue();
            released.IsUnknown.ShouldBeFalse();
            released.IsNow.ShouldBeFalse();
            released.HasDateTime.ShouldBeFalse();
            released.DateTime.ShouldBeNull();
            released.Value.ShouldBe("released");
            released.ToString().ShouldBe("released");

            TraktWatchedAt unknown = TraktWatchedAt.Unknown;
            unknown.IsReleased.ShouldBeFalse();
            unknown.IsUnknown.ShouldBeTrue();
            unknown.IsNow.ShouldBeFalse();
            unknown.HasDateTime.ShouldBeFalse();
            unknown.DateTime.ShouldBeNull();
            unknown.Value.ShouldBe("unknown");
            unknown.ToString().ShouldBe("unknown");

            TraktWatchedAt now = TraktWatchedAt.Now;
            now.IsReleased.ShouldBeFalse();
            now.IsNow.ShouldBeTrue();
            now.IsUnknown.ShouldBeFalse();
            now.HasDateTime.ShouldBeFalse();
            now.DateTime.ShouldBeNull();
            now.Value.ShouldBe("now");
            now.ToString().ShouldBe("now");
        }

        [Fact]
        public void TestTraktWatchedAtDateTimeAndImplicitConversions()
        {
            var timestamp = new DateTime(2014, 9, 1, 9, 10, 11, DateTimeKind.Utc);
            TraktWatchedAt watchedAt = timestamp;

            watchedAt.HasDateTime.ShouldBeTrue();
            watchedAt.DateTime.ShouldBe(timestamp);
            watchedAt.IsReleased.ShouldBeFalse();
            watchedAt.IsUnknown.ShouldBeFalse();
            watchedAt.IsNow.ShouldBeFalse();
            watchedAt.Value.ShouldBe("2014-09-01T09:10:11.000Z");
            watchedAt.ToString().ShouldBe("2014-09-01T09:10:11.000Z");

            DateTime? convertedBack = watchedAt;
            convertedBack.ShouldBe(timestamp);

            DateTime? fromReleased = TraktWatchedAt.Released;
            fromReleased.ShouldBeNull();

            var defaultWatchedAt = default(TraktWatchedAt);
            defaultWatchedAt.Value.ShouldBeNull();
            defaultWatchedAt.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktWatchedAtJsonConverter()
        {
            var converter = new TraktWatchedAtJsonConverter();
            converter.CanConvert(typeof(TraktWatchedAt)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktWatchedAt.Released, options).ShouldBe("\"released\"");
            JsonSerializer.Serialize(TraktWatchedAt.Unknown, options).ShouldBe("\"unknown\"");
            JsonSerializer.Serialize(TraktWatchedAt.Now, options).ShouldBe("\"now\"");
            JsonSerializer.Serialize(default(TraktWatchedAt), options).ShouldBe("null");

            var timestamp = new DateTime(2014, 9, 1, 9, 10, 11, DateTimeKind.Utc);
            JsonSerializer.Serialize(new TraktWatchedAt(timestamp), options).ShouldBe("\"2014-09-01T09:10:11Z\"");

            JsonSerializer.Deserialize<TraktWatchedAt>("\"released\"", options).ShouldBe(TraktWatchedAt.Released);
            JsonSerializer.Deserialize<TraktWatchedAt>("\"unknown\"", options).ShouldBe(TraktWatchedAt.Unknown);
            JsonSerializer.Deserialize<TraktWatchedAt>("\"now\"", options).ShouldBe(TraktWatchedAt.Now);
            JsonSerializer.Deserialize<TraktWatchedAt>("\"2014-09-01T09:10:11.000Z\"", options).ShouldBe(new TraktWatchedAt(timestamp));
            JsonSerializer.Deserialize<TraktWatchedAt>("\"\"", options).ShouldBe(default);
            JsonSerializer.Deserialize<TraktWatchedAt>("null", options).ShouldBe(default);
        }

        [Fact]
        public void TestTraktSyncHistoryPostMovieSerializeWatchedAt()
        {
            var movie = new TraktSyncHistoryPostMovie
            {
                WatchedAt = TraktWatchedAt.Released,
                IDs = new TraktMovieIDs { Trakt = 1U }
            };

            string json = TestUtility.SerializeObject(movie);
            json.ShouldContain("\"watched_at\":\"released\"");

            movie.WatchedAt = TraktWatchedAt.Now;
            json = TestUtility.SerializeObject(movie);
            json.ShouldContain("\"watched_at\":\"now\"");

            movie.WatchedAt = TraktWatchedAt.Unknown;
            json = TestUtility.SerializeObject(movie);
            json.ShouldContain("\"watched_at\":\"unknown\"");

            var timestamp = new DateTime(2014, 9, 1, 9, 10, 11, DateTimeKind.Utc);
            movie.WatchedAt = timestamp;
            json = TestUtility.SerializeObject(movie);
            json.ShouldContain("\"watched_at\":\"2014-09-01T09:10:11Z\"");
        }
    }
}
