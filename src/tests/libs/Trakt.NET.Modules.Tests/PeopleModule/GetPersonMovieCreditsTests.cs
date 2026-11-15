using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetPersonMovieCreditsTests
    {
        private const string GetPersonMovieCreditsUri = "people/297737/movies";
        private const uint PersonID = 297737U;
        private const string PersonSlug = "harrison-ford";

        [Fact]
        public async Task TestGetPersonMovieCreditsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPersonMovieCredits responseValue = response.Content;
            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(2);

            TraktPersonMovieCreditsCastItem[] cast = [.. responseValue.Cast];

            cast[0].Characters.ShouldNotBeNull();
            cast[0].Characters!.Count.ShouldBe(1);
            cast[0].Characters!.ShouldContain("Rey");
            cast[0].Movie.ShouldNotBeNull();
            cast[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            cast[0].Movie!.Year.ShouldBe(2015U);
            cast[0].Movie!.IDs.ShouldNotBeNull();
            cast[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            cast[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            cast[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            cast[0].Movie!.IDs!.TMDB.ShouldBe(140607U);

            cast[1].Characters.ShouldNotBeNull();
            cast[1].Characters!.Count.ShouldBe(1);
            cast[1].Characters!.ShouldContain("Han Solo");
            cast[1].Movie.ShouldNotBeNull();
            cast[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            cast[1].Movie!.Year.ShouldBe(2015U);
            cast[1].Movie!.IDs.ShouldNotBeNull();
            cast[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            cast[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            cast[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            cast[1].Movie!.IDs!.TMDB.ShouldBe(140607U);

            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art!.Count.ShouldBe(2);
            responseValue.Crew.Camera.ShouldNotBeNull();
            responseValue.Crew.Camera!.Count.ShouldBe(2);
            responseValue.Crew.CostumeAndMakeup.ShouldNotBeNull();
            responseValue.Crew.CostumeAndMakeup!.Count.ShouldBe(2);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew!.Count.ShouldBe(2);
            responseValue.Crew.Directing.ShouldNotBeNull();
            responseValue.Crew.Directing!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] directing = [.. responseValue.Crew.Directing];

            directing[0].Jobs.ShouldNotBeNull();
            directing[0].Jobs!.Count.ShouldBe(1);
            directing[0].Jobs!.ShouldContain("Director 1");
            directing[0].Movie.ShouldNotBeNull();
            directing[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            directing[0].Movie!.Year.ShouldBe(2015U);
            directing[0].Movie!.IDs.ShouldNotBeNull();
            directing[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            directing[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            directing[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            directing[0].Movie!.IDs!.TMDB.ShouldBe(140607U);

            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing!.Count.ShouldBe(2);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting!.Count.ShouldBe(2);
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] production = [.. responseValue.Crew.Production];

            production[0].Jobs.ShouldNotBeNull();
            production[0].Jobs!.Count.ShouldBe(1);
            production[0].Jobs!.ShouldContain("Producer 1");
            production[0].Movie.ShouldNotBeNull();
            production[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            production[0].Movie!.Year.ShouldBe(2015U);
            production[0].Movie!.IDs.ShouldNotBeNull();
            production[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            production[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            production[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            production[0].Movie!.IDs!.TMDB.ShouldBe(140607U);

            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound!.Count.ShouldBe(2);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects!.Count.ShouldBe(2);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] writing = [.. responseValue.Crew.Writing];

            writing[0].Jobs.ShouldNotBeNull();
            writing[0].Jobs!.Count.ShouldBe(1);
            writing[0].Jobs!.ShouldContain("Writer 1");
            writing[0].Movie.ShouldNotBeNull();
            writing[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            writing[0].Movie!.Year.ShouldBe(2015U);
            writing[0].Movie!.IDs.ShouldNotBeNull();
            writing[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            writing[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            writing[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            writing[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/movies", responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(PersonSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            var personIds = new TraktPersonIDs
            {
                Trakt = PersonID,
                Slug = PersonSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/movies", responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithPerson()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            var person = new TraktPerson
            {
                IDs = new TraktPersonIDs
                {
                    Trakt = PersonID,
                    Slug = PersonSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/movies", responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(person, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonMovieCreditsUri}?extended=full", responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(PersonID, TraktExtendedInfo.Full, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPersonMovieCredits responseValue = response.Content;
            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCastItem[] cast = [.. responseValue.Cast];

            cast[0].Characters.ShouldNotBeNull();
            cast[0].Characters!.Count.ShouldBe(1);
            cast[0].Characters!.ShouldContain("Rey");
            cast[0].Movie.ShouldNotBeNull();
            cast[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            cast[0].Movie!.Year.ShouldBe(2015U);
            cast[0].Movie!.IDs.ShouldNotBeNull();
            cast[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            cast[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            cast[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            cast[0].Movie!.IDs!.TMDB.ShouldBe(140607U);

            cast[1].Characters.ShouldNotBeNull();
            cast[1].Characters!.Count.ShouldBe(1);
            cast[1].Characters!.ShouldContain("Han Solo");
            cast[1].Movie.ShouldNotBeNull();
            cast[1].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            cast[1].Movie!.Year.ShouldBe(2015U);
            cast[1].Movie!.IDs.ShouldNotBeNull();
            cast[1].Movie!.IDs!.Trakt.ShouldBe(94024U);
            cast[1].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            cast[1].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            cast[1].Movie!.IDs!.TMDB.ShouldBe(140607U);

            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art!.Count.ShouldBe(2);
            responseValue.Crew.Camera.ShouldNotBeNull();
            responseValue.Crew.Camera!.Count.ShouldBe(2);
            responseValue.Crew.CostumeAndMakeup.ShouldNotBeNull();
            responseValue.Crew.CostumeAndMakeup!.Count.ShouldBe(2);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew!.Count.ShouldBe(2);
            responseValue.Crew.Directing.ShouldNotBeNull();
            responseValue.Crew.Directing!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] directing = [.. responseValue.Crew.Directing];

            directing[0].Jobs.ShouldNotBeNull();
            directing[0].Jobs!.Count.ShouldBe(1);
            directing[0].Jobs!.ShouldContain("Director 1");
            directing[0].Movie.ShouldNotBeNull();
            directing[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            directing[0].Movie!.Year.ShouldBe(2015U);
            directing[0].Movie!.IDs.ShouldNotBeNull();
            directing[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            directing[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            directing[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            directing[0].Movie!.IDs!.TMDB.ShouldBe(140607U);

            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing!.Count.ShouldBe(2);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting!.Count.ShouldBe(2);
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] production = [.. responseValue.Crew.Production];

            production[0].Jobs.ShouldNotBeNull();
            production[0].Jobs!.Count.ShouldBe(1);
            production[0].Jobs!.ShouldContain("Producer 1");
            production[0].Movie.ShouldNotBeNull();
            production[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            production[0].Movie!.Year.ShouldBe(2015U);
            production[0].Movie!.IDs.ShouldNotBeNull();
            production[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            production[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            production[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            production[0].Movie!.IDs!.TMDB.ShouldBe(140607U);

            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound!.Count.ShouldBe(2);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects!.Count.ShouldBe(2);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing!.Count.ShouldBe(2);

            TraktPersonMovieCreditsCrewItem[] writing = [.. responseValue.Crew.Writing];

            writing[0].Jobs.ShouldNotBeNull();
            writing[0].Jobs!.Count.ShouldBe(1);
            writing[0].Jobs!.ShouldContain("Writer 1");
            writing[0].Movie.ShouldNotBeNull();
            writing[0].Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            writing[0].Movie!.Year.ShouldBe(2015U);
            writing[0].Movie!.IDs.ShouldNotBeNull();
            writing[0].Movie!.IDs!.Trakt.ShouldBe(94024U);
            writing[0].Movie!.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            writing[0].Movie!.IDs!.IMDB.ShouldBe("tt2488496");
            writing[0].Movie!.IDs!.TMDB.ShouldBe(140607U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiPersonNotFoundException))]
        public async Task TestGetPersonMovieCreditsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, statusCode);

            Func<Task<TraktResponse<TraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(default(TraktPersonIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonMovieCreditsAsync(default(TraktPerson)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonMovieCreditsAsync(new TraktPersonIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonMovieCreditsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonMovieCreditsAsync(default(string)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.GetPersonMovieCreditsAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.GetPersonMovieCreditsAsync("person id", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
