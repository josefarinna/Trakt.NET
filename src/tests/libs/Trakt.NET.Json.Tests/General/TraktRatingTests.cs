namespace TraktNET.Json.General
{
    public sealed class TraktRatingTests
    {
        [Fact]
        public void TestTraktRatingConstructor()
        {
            var rating = new TraktRating();

            rating.Rating.ShouldBeNull();
            rating.Votes.ShouldBeNull();
            rating.Distribution.ShouldBeNull();
            rating.Trakt.ShouldBeNull();
            rating.TMDB.ShouldBeNull();
            rating.IMDB.ShouldBeNull();
            rating.Metascore.ShouldBeNull();
            rating.RottenTomatoes.ShouldBeNull();
            rating.Letterboxd.ShouldBeNull();
            rating.MAL.ShouldBeNull();
            rating.ToString().ShouldBe("Empty");

            var ratingItem = new TraktRatingItem();
            ratingItem.Rating.ShouldBeNull();
            ratingItem.Votes.ShouldBeNull();
            ratingItem.Link.ShouldBeNull();

            var metascoreItem = new TraktMetascoreRatingItem();
            metascoreItem.Rating.ShouldBeNull();
            metascoreItem.Link.ShouldBeNull();

            var rottenTomatoesItem = new TraktRottenTomatoesRatingItem();
            rottenTomatoesItem.Rating.ShouldBeNull();
            rottenTomatoesItem.UserRating.ShouldBeNull();
            rottenTomatoesItem.State.ShouldBeNull();
            rottenTomatoesItem.UserState.ShouldBeNull();
            rottenTomatoesItem.Link.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingFromJson()
        {
            TraktRating? rating = await TestUtility.DeserializeJsonAsync<TraktRating>("General\\rating.json");

            rating.ShouldNotBeNull();

            rating!.Rating.ShouldBe(7.96017f);
            rating!.Votes.ShouldBe(18906U);
            rating!.Distribution.ShouldNotBeNull();
            rating!.Distribution!.Count.ShouldBe(10);

            rating!.Distribution!.ShouldBe(new Dictionary<string, uint>
            {
                { "1", 91 },
                { "2", 55 },
                { "3", 66 },
                { "4", 142 },
                { "5", 421 },
                { "6", 1598 },
                { "7", 3699 },
                { "8", 6286 },
                { "9", 3805 },
                { "10", 2734 }
            });

            rating!.Trakt.ShouldBeNull();
            rating!.TMDB.ShouldBeNull();
            rating!.IMDB.ShouldBeNull();
            rating!.Metascore.ShouldBeNull();
            rating!.RottenTomatoes.ShouldBeNull();
            rating!.Letterboxd.ShouldBeNull();
            rating!.MAL.ShouldBeNull();

            rating!.ToString().ShouldBe("7.96017, 18906");
        }

        [Fact]
        public async Task TestTraktRatingExtendedAllFromJson()
        {
            TraktRating? rating = await TestUtility.DeserializeJsonAsync<TraktRating>("General\\rating_extended_all.json");

            rating.ShouldNotBeNull();

            rating!.Rating.ShouldBeNull();
            rating!.Votes.ShouldBeNull();
            rating!.Distribution.ShouldBeNull();

            rating!.Trakt.ShouldNotBeNull();
            rating!.Trakt!.Rating.ShouldBe(8.29481f);
            rating!.Trakt!.Votes.ShouldBe(24789U);
            rating!.Trakt!.Distribution.ShouldNotBeNull();
            rating!.Trakt!.Distribution!.Count.ShouldBe(10);
            rating!.Trakt!.Distribution!.ShouldBe(new Dictionary<string, uint>
            {
                { "1", 143 },
                { "2", 239 },
                { "3", 311 },
                { "4", 528 },
                { "5", 1104 },
                { "6", 2490 },
                { "7", 4890 },
                { "8", 6517 },
                { "9", 4120 },
                { "10", 8567 }
            });

            rating!.TMDB.ShouldNotBeNull();
            rating!.TMDB!.Rating.ShouldBe(8.251f);
            rating!.TMDB!.Votes.ShouldBe(3739U);
            rating!.TMDB!.Link.ShouldBe("https://www.themoviedb.org/movie/1339713");

            rating!.IMDB.ShouldNotBeNull();
            rating!.IMDB!.Rating.ShouldBe(7.9f);
            rating!.IMDB!.Votes.ShouldBe(269113U);
            rating!.IMDB!.Link.ShouldBe("https://www.imdb.com/title/tt37287335");

            rating!.Metascore.ShouldNotBeNull();
            rating!.Metascore!.Rating.ShouldBe(77);
            rating!.Metascore!.Link.ShouldBe("https://www.imdb.com/title/tt37287335/criticreviews");

            rating!.RottenTomatoes.ShouldNotBeNull();
            rating!.RottenTomatoes!.Rating.ShouldBe(94.0f);
            rating!.RottenTomatoes!.UserRating.ShouldBe(94U);
            rating!.RottenTomatoes!.State.ShouldBe("fresh");
            rating!.RottenTomatoes!.UserState.ShouldBe("upright");
            rating!.RottenTomatoes!.Link.ShouldBe("https://www.rottentomatoes.com/m/obsession_2025");

            rating!.Letterboxd.ShouldNotBeNull();
            rating!.Letterboxd!.Rating.ShouldBe(4.12f);
            rating!.Letterboxd!.Votes.ShouldBe(3633569U);
            rating!.Letterboxd!.Link.ShouldBe("https://letterboxd.com/film/obsession-2025");

            rating!.MAL.ShouldNotBeNull();
            rating!.MAL!.Rating.ShouldBeNull();
            rating!.MAL!.Votes.ShouldBe(0U);
            rating!.MAL!.Link.ShouldBeNull();

            rating!.ToString().ShouldBe("8.29481, 24789");
        }
    }
}
