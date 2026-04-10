using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetPersonMovieCreditsTests
    {
        private const string GetPersonMovieCreditsUri = "people/297737/movies";
        private const uint PersonID = 297737U;
        private const string PersonSlug = "harrison-ford";

        [Fact]
        public async Task TestGetPersonMovieCredits()
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
        public async Task TestGetPersonMovieCreditsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithPersonIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            var personIds = new TraktPersonIDs
            {
                Trakt = PersonID
            };

            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, responseContent);
            TraktResponse<TraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsWithPersonIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personmoviecredits.json");

            var personIds = new TraktPersonIDs
            {
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
        public async Task TestGetPersonMovieCreditsWithPersonIds()
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetPersonMovieCreditsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, statusCode);

            Func<Task<TraktResponse<TraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonMovieCreditsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonMovieCreditsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(default(TraktPersonIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonMovieCreditsAsync(default(TraktPerson)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonMovieCreditsAsync(new TraktPersonIDs());
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonMovieCreditsAsync(0);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
