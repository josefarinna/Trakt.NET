using Shouldly;
using Xunit;

namespace TraktNET.Json.SmartLists
{
    public sealed class TraktSmartListTests
    {
        [Fact]
        public void TestTraktSmartListDefaultConstructor()
        {
            var smartList = new TraktSmartList();

            smartList.Name.ShouldBeNull();
            smartList.Privacy.ShouldBeNull();
            smartList.CreatedAt.ShouldBeNull();
            smartList.UpdatedAt.ShouldBeNull();
            smartList.IDs.ShouldBeNull();
            smartList.Images.ShouldBeNull();
            smartList.Source.ShouldBeNull();
            smartList.MediaType.ShouldBeNull();
            smartList.Filters.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSmartListFromJson()
        {
            TraktSmartList? smartList = await TestUtility.DeserializeJsonAsync<TraktSmartList>("SmartLists\\smartlist.json");

            smartList.ShouldNotBeNull();
            smartList.Name.ShouldBe("Sci-Fi Movies");
            smartList.Privacy.ShouldBe(TraktListPrivacy.Public);
            smartList.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-07-17T00:00:00.000Z"));
            smartList.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-07-17T01:00:00.000Z"));

            smartList.IDs.ShouldNotBeNull();
            smartList.IDs.Trakt.ShouldBe(123456U);
            smartList.IDs.Slug.ShouldBe("sci-fi-movies");

            smartList.Images.ShouldNotBeNull();
            smartList.Images.Posters.ShouldNotBeNull();
            smartList.Images.Posters.Count.ShouldBe(1);
            smartList.Images.Posters[0].ShouldBe("https://example.com/poster.jpg");

            smartList.Source.ShouldBe(TraktSmartListSource.Popular);
            smartList.MediaType.ShouldBe(TraktSmartListMediaType.Movies);

            smartList.Filters.ShouldNotBeNull();
            smartList.Filters.Genres.ShouldNotBeNull();
            smartList.Filters.Genres.Length.ShouldBe(1);
            smartList.Filters.Genres[0].ShouldBe("science-fiction");
            smartList.Filters.GenresOperator.ShouldBe(TraktFilterOperator.And);

            smartList.Filters.Subgenres.ShouldNotBeNull();
            smartList.Filters.Subgenres.Length.ShouldBe(1);
            smartList.Filters.Subgenres[0].ShouldBe("time-travel");

            smartList.Filters.Certifications.ShouldNotBeNull();
            smartList.Filters.Certifications.Length.ShouldBe(1);
            smartList.Filters.Certifications[0].ShouldBe("pg-13");

            smartList.Filters.Languages.ShouldNotBeNull();
            smartList.Filters.Languages.Length.ShouldBe(1);
            smartList.Filters.Languages[0].ShouldBe("en");

            smartList.Filters.Countries.ShouldNotBeNull();
            smartList.Filters.Countries.Length.ShouldBe(1);
            smartList.Filters.Countries[0].ShouldBe("us");

            smartList.Filters.Statuses.ShouldNotBeNull();
            smartList.Filters.Statuses.Length.ShouldBe(1);
            smartList.Filters.Statuses[0].ShouldBe("released");

            smartList.Filters.Networks.ShouldNotBeNull();
            smartList.Filters.Networks.Length.ShouldBe(1);
            smartList.Filters.Networks[0].ShouldBe("hbo");

            smartList.Filters.Keywords.ShouldNotBeNull();
            smartList.Filters.Keywords.Length.ShouldBe(2);
            smartList.Filters.Keywords[0].ShouldBe("space");
            smartList.Filters.Keywords[1].ShouldBe("dune");
            smartList.Filters.KeywordsOperator.ShouldBe(TraktFilterOperator.Or);

            smartList.Filters.Watchnow.ShouldNotBeNull();
            smartList.Filters.Watchnow.Length.ShouldBe(1);
            smartList.Filters.Watchnow[0].ShouldBe("netflix");

            smartList.Filters.Years.ShouldNotBeNull();
            smartList.Filters.Years.Length.ShouldBe(2);
            smartList.Filters.Years[0].ShouldBe(2010U);
            smartList.Filters.Years[1].ShouldBe(2020U);

            smartList.Filters.Ratings.ShouldNotBeNull();
            smartList.Filters.Ratings.Length.ShouldBe(2);
            smartList.Filters.Ratings[0].ShouldBe(80U);
            smartList.Filters.Ratings[1].ShouldBe(100U);

            smartList.Filters.Runtimes.ShouldNotBeNull();
            smartList.Filters.Runtimes.Length.ShouldBe(2);
            smartList.Filters.Runtimes[0].ShouldBe(90U);
            smartList.Filters.Runtimes[1].ShouldBe(150U);

            smartList.Filters.ImdbRatings.ShouldNotBeNull();
            smartList.Filters.ImdbRatings.Length.ShouldBe(2);
            smartList.Filters.ImdbRatings[0].ShouldBe(7.5f);
            smartList.Filters.ImdbRatings[1].ShouldBe(9.8f);

            smartList.Filters.RtMeters.ShouldNotBeNull();
            smartList.Filters.RtMeters.Length.ShouldBe(2);
            smartList.Filters.RtMeters[0].ShouldBe(70U);
            smartList.Filters.RtMeters[1].ShouldBe(100U);

            smartList.Filters.RtUserMeters.ShouldNotBeNull();
            smartList.Filters.RtUserMeters.Length.ShouldBe(2);
            smartList.Filters.RtUserMeters[0].ShouldBe(80U);
            smartList.Filters.RtUserMeters[1].ShouldBe(100U);

            smartList.Filters.LetterboxdRatings.ShouldNotBeNull();
            smartList.Filters.LetterboxdRatings.Length.ShouldBe(2);
            smartList.Filters.LetterboxdRatings[0].ShouldBe(3.5f);
            smartList.Filters.LetterboxdRatings[1].ShouldBe(5.0f);

            smartList.Filters.MalRatings.ShouldNotBeNull();
            smartList.Filters.MalRatings.Length.ShouldBe(2);
            smartList.Filters.MalRatings[0].ShouldBe(7.0f);
            smartList.Filters.MalRatings[1].ShouldBe(9.5f);

            smartList.Filters.IgnoreWatched.ShouldBe(true);
            smartList.Filters.IgnoreWatchlisted.ShouldBe(false);
            smartList.Filters.IgnoreWatching.ShouldBe(true);
            smartList.Filters.IgnoreUnreleased.ShouldBe(false);
            smartList.Filters.IgnoreReleased.ShouldBe(true);
            smartList.Filters.IgnoreEnded.ShouldBe(false);
            smartList.Filters.IgnoreAiring.ShouldBe(true);
            smartList.Filters.IgnoreNoReleaseDate.ShouldBe(false);
        }

        [Fact]
        public async Task TestTraktSmartListPostResponseFromJson()
        {
            TraktSmartListPostResponse? response = await TestUtility.DeserializeJsonAsync<TraktSmartListPostResponse>("SmartLists\\smartlist_post_response.json");

            response.ShouldNotBeNull();
            response.IDs.ShouldNotBeNull();
            response.IDs.Trakt.ShouldBe(123U);
            response.IDs.Slug.ShouldBe("abc");
        }
    }
}
