namespace TraktNET.Json.Users
{
    public sealed class TraktUserPersonalListItemsRemovePostResponseTests
    {
        [Fact]
        public void TestTraktUserPersonalListItemsRemovePostResponseDefaultConstructor()
        {
            var personalListItemsRemovePostResponse = new TraktUserPersonalListItemsRemovePostResponse();

            personalListItemsRemovePostResponse.Deleted.ShouldBeNull();
            personalListItemsRemovePostResponse.NotFound.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserPersonalListItemsRemovePostResponseFromJson()
        {
            TraktUserPersonalListItemsRemovePostResponse? personalListItemsRemovePostResponse = await TestUtility.DeserializeJsonAsync<TraktUserPersonalListItemsRemovePostResponse>("Users\\userpersonallistimtesremovepostresponse.json");

            personalListItemsRemovePostResponse.ShouldNotBeNull();

            personalListItemsRemovePostResponse.Deleted.ShouldNotBeNull();
            personalListItemsRemovePostResponse.Deleted.Movies.ShouldBe(1U);
            personalListItemsRemovePostResponse.Deleted.Shows.ShouldBe(2U);
            personalListItemsRemovePostResponse.Deleted.Seasons.ShouldBe(3U);
            personalListItemsRemovePostResponse.Deleted.Episodes.ShouldBe(4U);
            personalListItemsRemovePostResponse.Deleted.People.ShouldBe(5U);
            personalListItemsRemovePostResponse.NotFound.ShouldNotBeNull();

            TraktUserPersonalListItemsPostResponseNotFoundGroup notFound = personalListItemsRemovePostResponse.NotFound;
            notFound.Movies.ShouldNotBeNull();
            notFound.Movies.Count.ShouldBe(2);

            TraktPostResponseNotFoundMovie[] movies = [.. notFound.Movies];

            movies[0].ShouldNotBeNull();
            movies[0].IDs.ShouldNotBeNull();
            movies[0].IDs!.Trakt.ShouldBe(94024U);
            movies[0].IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            movies[0].IDs!.IMDB.ShouldBe("tt2488496");
            movies[0].IDs!.TMDB.ShouldBe(140607U);

            movies[1].ShouldNotBeNull();
            movies[1].IDs.ShouldNotBeNull();
            movies[1].IDs!.Trakt.ShouldBe(172687U);
            movies[1].IDs!.Slug.ShouldBe("king-arthur-legend-of-the-sword-2017");
            movies[1].IDs!.IMDB.ShouldBe("tt1972591");
            movies[1].IDs!.TMDB.ShouldBe(274857U);

            // --------------------------------------------------

            notFound.Shows.ShouldNotBeNull();
            notFound.Shows.Count.ShouldBe(2);

            TraktPostResponseNotFoundShow[] shows = [.. notFound.Shows];

            shows[0].ShouldNotBeNull();
            shows[0].IDs.ShouldNotBeNull();
            shows[0].IDs!.Trakt.ShouldBe(1390U);
            shows[0].IDs!.Slug.ShouldBe("game-of-thrones");
            shows[0].IDs!.TVDB.ShouldBe(121361U);
            shows[0].IDs!.IMDB.ShouldBe("tt0944947");
            shows[0].IDs!.TMDB.ShouldBe(1399U);

            shows[1].ShouldNotBeNull();
            shows[1].IDs.ShouldNotBeNull();
            shows[1].IDs!.Trakt.ShouldBe(60300U);
            shows[1].IDs!.Slug.ShouldBe("the-flash-2014");
            shows[1].IDs!.TVDB.ShouldBe(279121U);
            shows[1].IDs!.IMDB.ShouldBe("tt3107288");
            shows[1].IDs!.TMDB.ShouldBe(60735U);

            // --------------------------------------------------

            notFound.Seasons.ShouldNotBeNull();
            notFound.Seasons.Count.ShouldBe(2);

            TraktPostResponseNotFoundSeason[] seasons = [.. notFound.Seasons];

            seasons[0].ShouldNotBeNull();
            seasons[0].IDs.ShouldNotBeNull();
            seasons[0].IDs!.Trakt.ShouldBe(61430U);
            seasons[0].IDs!.TVDB.ShouldBe(279121U);
            seasons[0].IDs!.TMDB.ShouldBe(60523U);

            seasons[1].ShouldNotBeNull();
            seasons[1].IDs.ShouldNotBeNull();
            seasons[1].IDs!.Trakt.ShouldBe(61431U);
            seasons[1].IDs!.TVDB.ShouldBe(578373U);
            seasons[1].IDs!.TMDB.ShouldBe(60524U);

            // --------------------------------------------------

            notFound.Episodes.ShouldNotBeNull();
            notFound.Episodes.Count.ShouldBe(2);

            TraktPostResponseNotFoundEpisode[] episodes = [.. notFound.Episodes];

            episodes[0].ShouldNotBeNull();
            episodes[0].IDs.ShouldNotBeNull();
            episodes[0].IDs!.Trakt.ShouldBe(73640U);
            episodes[0].IDs!.TVDB.ShouldBe(3254641U);
            episodes[0].IDs!.IMDB.ShouldBe("tt1480055");
            episodes[0].IDs!.TMDB.ShouldBe(63056U);
            episodes[1].ShouldNotBeNull();
            episodes[1].IDs.ShouldNotBeNull();
            episodes[1].IDs!.Trakt.ShouldBe(73641U);
            episodes[1].IDs!.TVDB.ShouldBe(3436411U);
            episodes[1].IDs!.IMDB.ShouldBe("tt1668746");
            episodes[1].IDs!.TMDB.ShouldBe(63057U);

            // --------------------------------------------------

            notFound.People.ShouldNotBeNull();
            notFound.People.Count.ShouldBe(2);

            TraktPostResponseNotFoundPerson[] people = [.. notFound.People];

            people[0].ShouldNotBeNull();
            people[0].IDs.ShouldNotBeNull();
            people[0].IDs!.Trakt.ShouldBe(297737U);
            people[0].IDs!.Slug.ShouldBe("bryan-cranston");
            people[0].IDs!.IMDB.ShouldBe("nm0186505");
            people[0].IDs!.TMDB.ShouldBe(17419U);
            people[1].ShouldNotBeNull();
            people[1].IDs.ShouldNotBeNull();
            people[1].IDs!.Trakt.ShouldBe(9486U);
            people[1].IDs!.Slug.ShouldBe("samuel-l-jackson");
            people[1].IDs!.IMDB.ShouldBe("nm0000168");
            people[1].IDs!.TMDB.ShouldBe(2231U);
        }
    }
}
