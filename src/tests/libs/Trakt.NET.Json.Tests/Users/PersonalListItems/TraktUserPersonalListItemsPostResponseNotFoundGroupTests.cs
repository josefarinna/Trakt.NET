namespace TraktNET.Json.Users
{
    public sealed class TraktUserPersonalListItemsPostResponseNotFoundGroupTests
    {
        [Fact]
        public void TestTraktUserPersonalListItemsPostResponseNotFoundGroupDefaultConstructor()
        {
            var personalListItemsPostResponseNotFoundGroup = new TraktUserPersonalListItemsPostResponseNotFoundGroup();

            personalListItemsPostResponseNotFoundGroup.Movies.ShouldBeNull();
            personalListItemsPostResponseNotFoundGroup.Shows.ShouldBeNull();
            personalListItemsPostResponseNotFoundGroup.Seasons.ShouldBeNull();
            personalListItemsPostResponseNotFoundGroup.Episodes.ShouldBeNull();
            personalListItemsPostResponseNotFoundGroup.People.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserPersonalListItemsPostResponseNotFoundGroupFromJson()
        {
            TraktUserPersonalListItemsPostResponseNotFoundGroup? personalListItemsPostResponseNotFoundGroup = await TestUtility.DeserializeJsonAsync<TraktUserPersonalListItemsPostResponseNotFoundGroup>("Users\\userpersonallistimtespostresponsenotfoundgroup.json");

            personalListItemsPostResponseNotFoundGroup.ShouldNotBeNull();
            personalListItemsPostResponseNotFoundGroup.Movies.ShouldNotBeNull();
            personalListItemsPostResponseNotFoundGroup.Movies.Count.ShouldBe(2);

            TraktPostResponseNotFoundMovie[] movies = [.. personalListItemsPostResponseNotFoundGroup.Movies];

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

            personalListItemsPostResponseNotFoundGroup.Shows.ShouldNotBeNull();
            personalListItemsPostResponseNotFoundGroup.Shows.Count.ShouldBe(2);

            TraktPostResponseNotFoundShow[] shows = [.. personalListItemsPostResponseNotFoundGroup.Shows];

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

            personalListItemsPostResponseNotFoundGroup.Seasons.ShouldNotBeNull();
            personalListItemsPostResponseNotFoundGroup.Seasons.Count.ShouldBe(2);

            TraktPostResponseNotFoundSeason[] seasons = [.. personalListItemsPostResponseNotFoundGroup.Seasons];

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

            personalListItemsPostResponseNotFoundGroup.Episodes.ShouldNotBeNull();
            personalListItemsPostResponseNotFoundGroup.Episodes.Count.ShouldBe(2);

            TraktPostResponseNotFoundEpisode[] episodes = [.. personalListItemsPostResponseNotFoundGroup.Episodes];

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

            personalListItemsPostResponseNotFoundGroup.People.ShouldNotBeNull();
            personalListItemsPostResponseNotFoundGroup.People.Count.ShouldBe(2);

            TraktPostResponseNotFoundPerson[] people = [.. personalListItemsPostResponseNotFoundGroup.People];

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
