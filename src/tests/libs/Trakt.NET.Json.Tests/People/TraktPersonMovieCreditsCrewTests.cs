namespace TraktNET.Json.People
{
    public sealed class TraktPersonMovieCreditsCrewTests
    {
        [Fact]
        public void TestTraktPersonMovieCreditsCrewDefaultConstructor()
        {
            var creditsCrew = new TraktPersonMovieCreditsCrew();

            creditsCrew.Production.ShouldBeNull();
            creditsCrew.Art.ShouldBeNull();
            creditsCrew.Crew.ShouldBeNull();
            creditsCrew.CostumeAndMakeup.ShouldBeNull();
            creditsCrew.Directing.ShouldBeNull();
            creditsCrew.Writing.ShouldBeNull();
            creditsCrew.Sound.ShouldBeNull();
            creditsCrew.Camera.ShouldBeNull();
            creditsCrew.Lighting.ShouldBeNull();
            creditsCrew.VisualEffects.ShouldBeNull();
            creditsCrew.Editing.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonMovieCreditsCrewFromJson()
        {
            TraktPersonMovieCreditsCrew? creditsCrew = await TestUtility.DeserializeJsonAsync<TraktPersonMovieCreditsCrew>("People\\personmoviecreditscrew.json");

            creditsCrew.ShouldNotBeNull();
            creditsCrew.Production.ShouldNotBeNull();
            creditsCrew.Production.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] productionCrew = [.. creditsCrew.Production];

            productionCrew[0].ShouldNotBeNull();
            productionCrew[0].Jobs.ShouldNotBeNull();
            productionCrew[0].Jobs!.Count.ShouldBe(1);
            productionCrew[0].Jobs!.ShouldContain("Producer 1");
            productionCrew[0].Movie.ShouldNotBeNull();
            productionCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            productionCrew[0].Movie!.Year.ShouldBe(2015U);
            productionCrew[0].Movie!.IDs.ShouldNotBeNull();
            productionCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            productionCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            productionCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            productionCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            productionCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            productionCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            productionCrew[0].Movie!.Released.ShouldBeNull();
            productionCrew[0].Movie!.Runtime.ShouldBeNull();
            productionCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            productionCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            productionCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            productionCrew[0].Movie!.Rating.ShouldBeNull();
            productionCrew[0].Movie!.Votes.ShouldBeNull();
            productionCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            productionCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            productionCrew[0].Movie!.Genres.ShouldBeNull();
            productionCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            productionCrew[1].ShouldNotBeNull();
            productionCrew[1].Jobs.ShouldNotBeNull();
            productionCrew[1].Jobs!.Count.ShouldBe(1);
            productionCrew[1].Jobs!.ShouldContain("Producer 2");
            productionCrew[1].Movie.ShouldNotBeNull();
            productionCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            productionCrew[1].Movie!.Year.ShouldBe(2015U);
            productionCrew[1].Movie!.IDs.ShouldNotBeNull();
            productionCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            productionCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            productionCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            productionCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            productionCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            productionCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            productionCrew[1].Movie!.Released.ShouldBeNull();
            productionCrew[1].Movie!.Runtime.ShouldBeNull();
            productionCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            productionCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            productionCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            productionCrew[1].Movie!.Rating.ShouldBeNull();
            productionCrew[1].Movie!.Votes.ShouldBeNull();
            productionCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            productionCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            productionCrew[1].Movie!.Genres.ShouldBeNull();
            productionCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Art.ShouldNotBeNull();
            creditsCrew.Art.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] artCrew = [.. creditsCrew.Art];

            artCrew[0].ShouldNotBeNull();
            artCrew[0].Jobs.ShouldNotBeNull();
            artCrew[0].Jobs!.Count.ShouldBe(1);
            artCrew[0].Jobs!.ShouldContain("Art Director 1");
            artCrew[0].Movie.ShouldNotBeNull();
            artCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            artCrew[0].Movie!.Year.ShouldBe(2015U);
            artCrew[0].Movie!.IDs.ShouldNotBeNull();
            artCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            artCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            artCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            artCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            artCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            artCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            artCrew[0].Movie!.Released.ShouldBeNull();
            artCrew[0].Movie!.Runtime.ShouldBeNull();
            artCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            artCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            artCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            artCrew[0].Movie!.Rating.ShouldBeNull();
            artCrew[0].Movie!.Votes.ShouldBeNull();
            artCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            artCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            artCrew[0].Movie!.Genres.ShouldBeNull();
            artCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            artCrew[1].ShouldNotBeNull();
            artCrew[1].Jobs.ShouldNotBeNull();
            artCrew[1].Jobs!.Count.ShouldBe(1);
            artCrew[1].Jobs!.ShouldContain("Art Director 2");
            artCrew[1].Movie.ShouldNotBeNull();
            artCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            artCrew[1].Movie!.Year.ShouldBe(2015U);
            artCrew[1].Movie!.IDs.ShouldNotBeNull();
            artCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            artCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            artCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            artCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            artCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            artCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            artCrew[1].Movie!.Released.ShouldBeNull();
            artCrew[1].Movie!.Runtime.ShouldBeNull();
            artCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            artCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            artCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            artCrew[1].Movie!.Rating.ShouldBeNull();
            artCrew[1].Movie!.Votes.ShouldBeNull();
            artCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            artCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            artCrew[1].Movie!.Genres.ShouldBeNull();
            artCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Crew.ShouldNotBeNull();
            creditsCrew.Crew.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] crew = [.. creditsCrew.Crew];

            crew[0].ShouldNotBeNull();
            crew[0].Jobs.ShouldNotBeNull();
            crew[0].Jobs!.Count.ShouldBe(1);
            crew[0].Jobs!.ShouldContain("Crew Member 1");
            crew[0].Movie.ShouldNotBeNull();
            crew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            crew[0].Movie!.Year.ShouldBe(2015U);
            crew[0].Movie!.IDs.ShouldNotBeNull();
            crew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            crew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            crew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            crew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            crew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            crew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            crew[0].Movie!.Released.ShouldBeNull();
            crew[0].Movie!.Runtime.ShouldBeNull();
            crew[0].Movie!.UpdatedAt.ShouldBeNull();
            crew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            crew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            crew[0].Movie!.Rating.ShouldBeNull();
            crew[0].Movie!.Votes.ShouldBeNull();
            crew[0].Movie!.Language.ShouldBeNullOrEmpty();
            crew[0].Movie!.AvailableTranslations.ShouldBeNull();
            crew[0].Movie!.Genres.ShouldBeNull();
            crew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            crew[1].ShouldNotBeNull();
            crew[1].Jobs.ShouldNotBeNull();
            crew[1].Jobs!.Count.ShouldBe(1);
            crew[1].Jobs!.ShouldContain("Crew Member 2");
            crew[1].Movie.ShouldNotBeNull();
            crew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            crew[1].Movie!.Year.ShouldBe(2015U);
            crew[1].Movie!.IDs.ShouldNotBeNull();
            crew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            crew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            crew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            crew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            crew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            crew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            crew[1].Movie!.Released.ShouldBeNull();
            crew[1].Movie!.Runtime.ShouldBeNull();
            crew[1].Movie!.UpdatedAt.ShouldBeNull();
            crew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            crew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            crew[1].Movie!.Rating.ShouldBeNull();
            crew[1].Movie!.Votes.ShouldBeNull();
            crew[1].Movie!.Language.ShouldBeNullOrEmpty();
            crew[1].Movie!.AvailableTranslations.ShouldBeNull();
            crew[1].Movie!.Genres.ShouldBeNull();
            crew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.CostumeAndMakeup.ShouldNotBeNull();
            creditsCrew.CostumeAndMakeup.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] costumeAndMakeupCrew = [.. creditsCrew.CostumeAndMakeup];

            costumeAndMakeupCrew[0].ShouldNotBeNull();
            costumeAndMakeupCrew[0].Jobs.ShouldNotBeNull();
            costumeAndMakeupCrew[0].Jobs!.Count.ShouldBe(1);
            costumeAndMakeupCrew[0].Jobs!.ShouldContain("Costume Designer");
            costumeAndMakeupCrew[0].Movie.ShouldNotBeNull();
            costumeAndMakeupCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            costumeAndMakeupCrew[0].Movie!.Year.ShouldBe(2015U);
            costumeAndMakeupCrew[0].Movie!.IDs.ShouldNotBeNull();
            costumeAndMakeupCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            costumeAndMakeupCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            costumeAndMakeupCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            costumeAndMakeupCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            costumeAndMakeupCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie!.Released.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.Runtime.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie!.Rating.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.Votes.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.Genres.ShouldBeNull();
            costumeAndMakeupCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            costumeAndMakeupCrew[1].ShouldNotBeNull();
            costumeAndMakeupCrew[1].Jobs.ShouldNotBeNull();
            costumeAndMakeupCrew[1].Jobs!.Count.ShouldBe(1);
            costumeAndMakeupCrew[1].Jobs!.ShouldContain("Make Up Artist");
            costumeAndMakeupCrew[1].Movie.ShouldNotBeNull();
            costumeAndMakeupCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            costumeAndMakeupCrew[1].Movie!.Year.ShouldBe(2015U);
            costumeAndMakeupCrew[1].Movie!.IDs.ShouldNotBeNull();
            costumeAndMakeupCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            costumeAndMakeupCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            costumeAndMakeupCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            costumeAndMakeupCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            costumeAndMakeupCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie!.Released.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.Runtime.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie!.Rating.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.Votes.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.Genres.ShouldBeNull();
            costumeAndMakeupCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Directing.ShouldNotBeNull();
            creditsCrew.Directing.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] directingCrew = [.. creditsCrew.Directing];

            directingCrew[0].ShouldNotBeNull();
            directingCrew[0].Jobs.ShouldNotBeNull();
            directingCrew[0].Jobs!.Count.ShouldBe(1);
            directingCrew[0].Jobs!.ShouldContain("Director 1");
            directingCrew[0].Movie.ShouldNotBeNull();
            directingCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            directingCrew[0].Movie!.Year.ShouldBe(2015U);
            directingCrew[0].Movie!.IDs.ShouldNotBeNull();
            directingCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            directingCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            directingCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            directingCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            directingCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            directingCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            directingCrew[0].Movie!.Released.ShouldBeNull();
            directingCrew[0].Movie!.Runtime.ShouldBeNull();
            directingCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            directingCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            directingCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            directingCrew[0].Movie!.Rating.ShouldBeNull();
            directingCrew[0].Movie!.Votes.ShouldBeNull();
            directingCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            directingCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            directingCrew[0].Movie!.Genres.ShouldBeNull();
            directingCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            directingCrew[1].ShouldNotBeNull();
            directingCrew[1].Jobs.ShouldNotBeNull();
            directingCrew[1].Jobs!.Count.ShouldBe(1);
            directingCrew[1].Jobs!.ShouldContain("Director 2");
            directingCrew[1].Movie.ShouldNotBeNull();
            directingCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            directingCrew[1].Movie!.Year.ShouldBe(2015U);
            directingCrew[1].Movie!.IDs.ShouldNotBeNull();
            directingCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            directingCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            directingCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            directingCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            directingCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            directingCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            directingCrew[1].Movie!.Released.ShouldBeNull();
            directingCrew[1].Movie!.Runtime.ShouldBeNull();
            directingCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            directingCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            directingCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            directingCrew[1].Movie!.Rating.ShouldBeNull();
            directingCrew[1].Movie!.Votes.ShouldBeNull();
            directingCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            directingCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            directingCrew[1].Movie!.Genres.ShouldBeNull();
            directingCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Writing.ShouldNotBeNull();
            creditsCrew.Writing.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] writingCrew = [.. creditsCrew.Writing];

            writingCrew[0].ShouldNotBeNull();
            writingCrew[0].Jobs.ShouldNotBeNull();
            writingCrew[0].Jobs!.Count.ShouldBe(1);
            writingCrew[0].Jobs!.ShouldContain("Writer 1");
            writingCrew[0].Movie.ShouldNotBeNull();
            writingCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            writingCrew[0].Movie!.Year.ShouldBe(2015U);
            writingCrew[0].Movie!.IDs.ShouldNotBeNull();
            writingCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            writingCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            writingCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            writingCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            writingCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            writingCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            writingCrew[0].Movie!.Released.ShouldBeNull();
            writingCrew[0].Movie!.Runtime.ShouldBeNull();
            writingCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            writingCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            writingCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            writingCrew[0].Movie!.Rating.ShouldBeNull();
            writingCrew[0].Movie!.Votes.ShouldBeNull();
            writingCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            writingCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            writingCrew[0].Movie!.Genres.ShouldBeNull();
            writingCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            writingCrew[1].ShouldNotBeNull();
            writingCrew[1].Jobs.ShouldNotBeNull();
            writingCrew[1].Jobs!.Count.ShouldBe(1);
            writingCrew[1].Jobs!.ShouldContain("Writer 2");
            writingCrew[1].Movie.ShouldNotBeNull();
            writingCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            writingCrew[1].Movie!.Year.ShouldBe(2015U);
            writingCrew[1].Movie!.IDs.ShouldNotBeNull();
            writingCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            writingCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            writingCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            writingCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            writingCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            writingCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            writingCrew[1].Movie!.Released.ShouldBeNull();
            writingCrew[1].Movie!.Runtime.ShouldBeNull();
            writingCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            writingCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            writingCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            writingCrew[1].Movie!.Rating.ShouldBeNull();
            writingCrew[1].Movie!.Votes.ShouldBeNull();
            writingCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            writingCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            writingCrew[1].Movie!.Genres.ShouldBeNull();
            writingCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Sound.ShouldNotBeNull();
            creditsCrew.Sound.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] soundCrew = [.. creditsCrew.Sound];

            soundCrew[0].ShouldNotBeNull();
            soundCrew[0].Jobs.ShouldNotBeNull();
            soundCrew[0].Jobs!.Count.ShouldBe(1);
            soundCrew[0].Jobs!.ShouldContain("Sound Designer 1");
            soundCrew[0].Movie.ShouldNotBeNull();
            soundCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            soundCrew[0].Movie!.Year.ShouldBe(2015U);
            soundCrew[0].Movie!.IDs.ShouldNotBeNull();
            soundCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            soundCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            soundCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            soundCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            soundCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            soundCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            soundCrew[0].Movie!.Released.ShouldBeNull();
            soundCrew[0].Movie!.Runtime.ShouldBeNull();
            soundCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            soundCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            soundCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            soundCrew[0].Movie!.Rating.ShouldBeNull();
            soundCrew[0].Movie!.Votes.ShouldBeNull();
            soundCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            soundCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            soundCrew[0].Movie!.Genres.ShouldBeNull();
            soundCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            soundCrew[1].ShouldNotBeNull();
            soundCrew[1].Jobs.ShouldNotBeNull();
            soundCrew[1].Jobs!.Count.ShouldBe(1);
            soundCrew[1].Jobs!.ShouldContain("Sound Designer 2");
            soundCrew[1].Movie.ShouldNotBeNull();
            soundCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            soundCrew[1].Movie!.Year.ShouldBe(2015U);
            soundCrew[1].Movie!.IDs.ShouldNotBeNull();
            soundCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            soundCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            soundCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            soundCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            soundCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            soundCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            soundCrew[1].Movie!.Released.ShouldBeNull();
            soundCrew[1].Movie!.Runtime.ShouldBeNull();
            soundCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            soundCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            soundCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            soundCrew[1].Movie!.Rating.ShouldBeNull();
            soundCrew[1].Movie!.Votes.ShouldBeNull();
            soundCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            soundCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            soundCrew[1].Movie!.Genres.ShouldBeNull();
            soundCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Camera.ShouldNotBeNull();
            creditsCrew.Camera.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] cameraCrew = [.. creditsCrew.Camera];

            cameraCrew[0].ShouldNotBeNull();
            cameraCrew[0].Jobs.ShouldNotBeNull();
            cameraCrew[0].Jobs!.Count.ShouldBe(1);
            cameraCrew[0].Jobs!.ShouldContain("Camera Man 1");
            cameraCrew[0].Movie.ShouldNotBeNull();
            cameraCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            cameraCrew[0].Movie!.Year.ShouldBe(2015U);
            cameraCrew[0].Movie!.IDs.ShouldNotBeNull();
            cameraCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            cameraCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            cameraCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            cameraCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            cameraCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            cameraCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            cameraCrew[0].Movie!.Released.ShouldBeNull();
            cameraCrew[0].Movie!.Runtime.ShouldBeNull();
            cameraCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            cameraCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            cameraCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            cameraCrew[0].Movie!.Rating.ShouldBeNull();
            cameraCrew[0].Movie!.Votes.ShouldBeNull();
            cameraCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            cameraCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            cameraCrew[0].Movie!.Genres.ShouldBeNull();
            cameraCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            cameraCrew[1].ShouldNotBeNull();
            cameraCrew[1].Jobs.ShouldNotBeNull();
            cameraCrew[1].Jobs!.Count.ShouldBe(1);
            cameraCrew[1].Jobs!.ShouldContain("Camera Man 2");
            cameraCrew[1].Movie.ShouldNotBeNull();
            cameraCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            cameraCrew[1].Movie!.Year.ShouldBe(2015U);
            cameraCrew[1].Movie!.IDs.ShouldNotBeNull();
            cameraCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            cameraCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            cameraCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            cameraCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            cameraCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            cameraCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            cameraCrew[1].Movie!.Released.ShouldBeNull();
            cameraCrew[1].Movie!.Runtime.ShouldBeNull();
            cameraCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            cameraCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            cameraCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            cameraCrew[1].Movie!.Rating.ShouldBeNull();
            cameraCrew[1].Movie!.Votes.ShouldBeNull();
            cameraCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            cameraCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            cameraCrew[1].Movie!.Genres.ShouldBeNull();
            cameraCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Lighting.ShouldNotBeNull();
            creditsCrew.Lighting.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] lightingCrew = [.. creditsCrew.Lighting];

            lightingCrew[0].ShouldNotBeNull();
            lightingCrew[0].Jobs.ShouldNotBeNull();
            lightingCrew[0].Jobs!.Count.ShouldBe(1);
            lightingCrew[0].Jobs!.ShouldContain("Light Technician 1");
            lightingCrew[0].Movie.ShouldNotBeNull();
            lightingCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            lightingCrew[0].Movie!.Year.ShouldBe(2015U);
            lightingCrew[0].Movie!.IDs.ShouldNotBeNull();
            lightingCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            lightingCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            lightingCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            lightingCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            lightingCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            lightingCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            lightingCrew[0].Movie!.Released.ShouldBeNull();
            lightingCrew[0].Movie!.Runtime.ShouldBeNull();
            lightingCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            lightingCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            lightingCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            lightingCrew[0].Movie!.Rating.ShouldBeNull();
            lightingCrew[0].Movie!.Votes.ShouldBeNull();
            lightingCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            lightingCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            lightingCrew[0].Movie!.Genres.ShouldBeNull();
            lightingCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            lightingCrew[1].ShouldNotBeNull();
            lightingCrew[1].Jobs.ShouldNotBeNull();
            lightingCrew[1].Jobs!.Count.ShouldBe(1);
            lightingCrew[1].Jobs!.ShouldContain("Light Technician 2");
            lightingCrew[1].Movie.ShouldNotBeNull();
            lightingCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            lightingCrew[1].Movie!.Year.ShouldBe(2015U);
            lightingCrew[1].Movie!.IDs.ShouldNotBeNull();
            lightingCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            lightingCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            lightingCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            lightingCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            lightingCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            lightingCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            lightingCrew[1].Movie!.Released.ShouldBeNull();
            lightingCrew[1].Movie!.Runtime.ShouldBeNull();
            lightingCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            lightingCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            lightingCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            lightingCrew[1].Movie!.Rating.ShouldBeNull();
            lightingCrew[1].Movie!.Votes.ShouldBeNull();
            lightingCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            lightingCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            lightingCrew[1].Movie!.Genres.ShouldBeNull();
            lightingCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.VisualEffects.ShouldNotBeNull();
            creditsCrew.VisualEffects.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] vfxCrew = [.. creditsCrew.VisualEffects];

            vfxCrew[0].ShouldNotBeNull();
            vfxCrew[0].Jobs.ShouldNotBeNull();
            vfxCrew[0].Jobs!.Count.ShouldBe(1);
            vfxCrew[0].Jobs!.ShouldContain("VFX Artist 1");
            vfxCrew[0].Movie.ShouldNotBeNull();
            vfxCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            vfxCrew[0].Movie!.Year.ShouldBe(2015U);
            vfxCrew[0].Movie!.IDs.ShouldNotBeNull();
            vfxCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            vfxCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            vfxCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            vfxCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            vfxCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            vfxCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            vfxCrew[0].Movie!.Released.ShouldBeNull();
            vfxCrew[0].Movie!.Runtime.ShouldBeNull();
            vfxCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            vfxCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            vfxCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            vfxCrew[0].Movie!.Rating.ShouldBeNull();
            vfxCrew[0].Movie!.Votes.ShouldBeNull();
            vfxCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            vfxCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            vfxCrew[0].Movie!.Genres.ShouldBeNull();
            vfxCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            vfxCrew[1].ShouldNotBeNull();
            vfxCrew[1].Jobs.ShouldNotBeNull();
            vfxCrew[1].Jobs!.Count.ShouldBe(1);
            vfxCrew[1].Jobs!.ShouldContain("VFX Artist 2");
            vfxCrew[1].Movie.ShouldNotBeNull();
            vfxCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            vfxCrew[1].Movie!.Year.ShouldBe(2015U);
            vfxCrew[1].Movie!.IDs.ShouldNotBeNull();
            vfxCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            vfxCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            vfxCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            vfxCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            vfxCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            vfxCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            vfxCrew[1].Movie!.Released.ShouldBeNull();
            vfxCrew[1].Movie!.Runtime.ShouldBeNull();
            vfxCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            vfxCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            vfxCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            vfxCrew[1].Movie!.Rating.ShouldBeNull();
            vfxCrew[1].Movie!.Votes.ShouldBeNull();
            vfxCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            vfxCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            vfxCrew[1].Movie!.Genres.ShouldBeNull();
            vfxCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();

            creditsCrew.Editing.ShouldNotBeNull();
            creditsCrew.Editing.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] editingCrew = [.. creditsCrew.Editing];

            editingCrew[0].ShouldNotBeNull();
            editingCrew[0].Jobs.ShouldNotBeNull();
            editingCrew[0].Jobs!.Count.ShouldBe(1);
            editingCrew[0].Jobs!.ShouldContain("Editor 1");
            editingCrew[0].Movie.ShouldNotBeNull();
            editingCrew[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            editingCrew[0].Movie!.Year.ShouldBe(2015U);
            editingCrew[0].Movie!.IDs.ShouldNotBeNull();
            editingCrew[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            editingCrew[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            editingCrew[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            editingCrew[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
            editingCrew[0].Movie!.Tagline.ShouldBeNullOrEmpty();
            editingCrew[0].Movie!.Overview.ShouldBeNullOrEmpty();
            editingCrew[0].Movie!.Released.ShouldBeNull();
            editingCrew[0].Movie!.Runtime.ShouldBeNull();
            editingCrew[0].Movie!.UpdatedAt.ShouldBeNull();
            editingCrew[0].Movie!.Trailer.ShouldBeNullOrEmpty();
            editingCrew[0].Movie!.Homepage.ShouldBeNullOrEmpty();
            editingCrew[0].Movie!.Rating.ShouldBeNull();
            editingCrew[0].Movie!.Votes.ShouldBeNull();
            editingCrew[0].Movie!.Language.ShouldBeNullOrEmpty();
            editingCrew[0].Movie!.AvailableTranslations.ShouldBeNull();
            editingCrew[0].Movie!.Genres.ShouldBeNull();
            editingCrew[0].Movie!.Certification.ShouldBeNullOrEmpty();

            editingCrew[1].ShouldNotBeNull();
            editingCrew[1].Jobs.ShouldNotBeNull();
            editingCrew[1].Jobs!.Count.ShouldBe(1);
            editingCrew[1].Jobs!.ShouldContain("Editor 2");
            editingCrew[1].Movie.ShouldNotBeNull();
            editingCrew[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            editingCrew[1].Movie!.Year.ShouldBe(2015U);
            editingCrew[1].Movie!.IDs.ShouldNotBeNull();
            editingCrew[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            editingCrew[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            editingCrew[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            editingCrew[1].Movie!.IDs!.TMDB.ShouldBe(140607U);
            editingCrew[1].Movie!.Tagline.ShouldBeNullOrEmpty();
            editingCrew[1].Movie!.Overview.ShouldBeNullOrEmpty();
            editingCrew[1].Movie!.Released.ShouldBeNull();
            editingCrew[1].Movie!.Runtime.ShouldBeNull();
            editingCrew[1].Movie!.UpdatedAt.ShouldBeNull();
            editingCrew[1].Movie!.Trailer.ShouldBeNullOrEmpty();
            editingCrew[1].Movie!.Homepage.ShouldBeNullOrEmpty();
            editingCrew[1].Movie!.Rating.ShouldBeNull();
            editingCrew[1].Movie!.Votes.ShouldBeNull();
            editingCrew[1].Movie!.Language.ShouldBeNullOrEmpty();
            editingCrew[1].Movie!.AvailableTranslations.ShouldBeNull();
            editingCrew[1].Movie!.Genres.ShouldBeNull();
            editingCrew[1].Movie!.Certification.ShouldBeNullOrEmpty();
        }

        private const string JSON =
            @"{
                ""production"": [
                  {
                    ""jobs"": [
                      ""Producer 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Art Director 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Art Director 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Costume Designer""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make Up Artist""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera Man 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera Man 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor 1""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor 2""
                    ],
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  }
                ]
              }";
    }
}
