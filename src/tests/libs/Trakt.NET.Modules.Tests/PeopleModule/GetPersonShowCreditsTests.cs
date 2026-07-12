using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetPersonShowCreditsTests
    {
        private const string GetPersonShowCreditsUri = "people/297737/shows";
        private const uint PersonID = 297737U;
        private const string PersonSlug = "harrison-ford";

        [Fact]
        public async Task TestGetPersonShowCredits()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonShowCreditsUri, responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPersonShowCredits responseValue = response.Content;
            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(2);

            TraktPersonShowCreditsCastItem[] cast = [.. responseValue.Cast];

            cast[0].Characters.ShouldNotBeNull();
            cast[0].Characters!.Count.ShouldBe(1);
            cast[0].Characters!.ShouldContain("Jon Snow");
            cast[0].Show.ShouldNotBeNull();
            cast[0].Show!.Title.ShouldBe("Game of Thrones");
            cast[0].Show!.Year.ShouldBe(2011U);
            cast[0].Show!.IDs.ShouldNotBeNull();
            cast[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            cast[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            cast[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            cast[0].Show!.IDs!.TMDB.ShouldBe(1399U);

            cast[1].Characters.ShouldNotBeNull();
            cast[1].Characters!.Count.ShouldBe(1);
            cast[1].Characters!.ShouldContain("Jon Snow");
            cast[1].Show.ShouldNotBeNull();
            cast[1].Show!.Title.ShouldBe("Game of Thrones");
            cast[1].Show!.Year.ShouldBe(2011U);
            cast[1].Show!.IDs.ShouldNotBeNull();
            cast[1].Show!.IDs!.Trakt.ShouldBe(1390U);
            cast[1].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            cast[1].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            cast[1].Show!.IDs!.TMDB.ShouldBe(1399U);

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

            TraktPersonShowCreditsCrewItem[] directing = [.. responseValue.Crew.Directing];

            directing[0].Jobs.ShouldNotBeNull();
            directing[0].Jobs!.Count.ShouldBe(1);
            directing[0].Jobs!.ShouldContain("Director 1");
            directing[0].Show.ShouldNotBeNull();
            directing[0].Show!.Title.ShouldBe("Game of Thrones");
            directing[0].Show!.Year.ShouldBe(2011U);
            directing[0].Show!.IDs.ShouldNotBeNull();
            directing[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            directing[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            directing[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            directing[0].Show!.IDs!.TMDB.ShouldBe(1399U);

            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing!.Count.ShouldBe(2);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting!.Count.ShouldBe(2);
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production!.Count.ShouldBe(2);

            TraktPersonShowCreditsCrewItem[] production = [.. responseValue.Crew.Production];

            production[0].Jobs.ShouldNotBeNull();
            production[0].Jobs!.Count.ShouldBe(1);
            production[0].Jobs!.ShouldContain("Producer 1");
            production[0].Show.ShouldNotBeNull();
            production[0].Show!.Title.ShouldBe("Game of Thrones");
            production[0].Show!.Year.ShouldBe(2011U);
            production[0].Show!.IDs.ShouldNotBeNull();
            production[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            production[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            production[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            production[0].Show!.IDs!.TMDB.ShouldBe(1399U);

            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound!.Count.ShouldBe(2);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects!.Count.ShouldBe(2);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing!.Count.ShouldBe(2);

            TraktPersonShowCreditsCrewItem[] writing = [.. responseValue.Crew.Writing];

            writing[0].Jobs.ShouldNotBeNull();
            writing[0].Jobs!.Count.ShouldBe(1);
            writing[0].Jobs!.ShouldContain("Writer 1");
            writing[0].Show.ShouldNotBeNull();
            writing[0].Show!.Title.ShouldBe("Game of Thrones");
            writing[0].Show!.Year.ShouldBe(2011U);
            writing[0].Show!.IDs.ShouldNotBeNull();
            writing[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            writing[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            writing[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            writing[0].Show!.IDs!.TMDB.ShouldBe(1399U);
        }

        [Fact]
        public async Task TestGetPersonShowCreditsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/shows", responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(PersonSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonShowCreditsWithPersonIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");

            var personIds = new TraktPersonIDs
            {
                Trakt = PersonID
            };

            TraktClient client = ModuleTestUtility.GetClient(GetPersonShowCreditsUri, responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonShowCreditsWithPersonIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");

            var personIds = new TraktPersonIDs
            {
                Slug = PersonSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/shows", responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonShowCreditsWithPersonIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");

            var personIds = new TraktPersonIDs
            {
                Trakt = PersonID,
                Slug = PersonSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/shows", responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonShowCreditsWithPerson()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");

            var person = new TraktPerson
            {
                IDs = new TraktPersonIDs
                {
                    Trakt = PersonID,
                    Slug = PersonSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}/shows", responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(person, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonShowCreditsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\personshowcredits.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonShowCreditsUri}?extended=full", responseContent);
            TraktResponse<TraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(PersonID, TraktExtendedInfo.Full, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPersonShowCredits responseValue = response.Content;
            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast!.Count.ShouldBe(2);

            TraktPersonShowCreditsCastItem[] cast = [.. responseValue.Cast];

            cast[0].Characters.ShouldNotBeNull();
            cast[0].Characters!.Count.ShouldBe(1);
            cast[0].Characters!.ShouldContain("Jon Snow");
            cast[0].Show.ShouldNotBeNull();
            cast[0].Show!.Title.ShouldBe("Game of Thrones");
            cast[0].Show!.Year.ShouldBe(2011U);
            cast[0].Show!.IDs.ShouldNotBeNull();
            cast[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            cast[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            cast[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            cast[0].Show!.IDs!.TMDB.ShouldBe(1399U);

            cast[1].Characters.ShouldNotBeNull();
            cast[1].Characters!.Count.ShouldBe(1);
            cast[1].Characters!.ShouldContain("Jon Snow");
            cast[1].Show.ShouldNotBeNull();
            cast[1].Show!.Title.ShouldBe("Game of Thrones");
            cast[1].Show!.Year.ShouldBe(2011U);
            cast[1].Show!.IDs.ShouldNotBeNull();
            cast[1].Show!.IDs!.Trakt.ShouldBe(1390U);
            cast[1].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            cast[1].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            cast[1].Show!.IDs!.TMDB.ShouldBe(1399U);

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

            TraktPersonShowCreditsCrewItem[] directing = [.. responseValue.Crew.Directing];

            directing[0].Jobs.ShouldNotBeNull();
            directing[0].Jobs!.Count.ShouldBe(1);
            directing[0].Jobs!.ShouldContain("Director 1");
            directing[0].Show.ShouldNotBeNull();
            directing[0].Show!.Title.ShouldBe("Game of Thrones");
            directing[0].Show!.Year.ShouldBe(2011U);
            directing[0].Show!.IDs.ShouldNotBeNull();
            directing[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            directing[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            directing[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            directing[0].Show!.IDs!.TMDB.ShouldBe(1399U);

            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing!.Count.ShouldBe(2);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting!.Count.ShouldBe(2);
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production!.Count.ShouldBe(2);

            TraktPersonShowCreditsCrewItem[] production = [.. responseValue.Crew.Production];

            production[0].Jobs.ShouldNotBeNull();
            production[0].Jobs!.Count.ShouldBe(1);
            production[0].Jobs!.ShouldContain("Producer 1");
            production[0].Show.ShouldNotBeNull();
            production[0].Show!.Title.ShouldBe("Game of Thrones");
            production[0].Show!.Year.ShouldBe(2011U);
            production[0].Show!.IDs.ShouldNotBeNull();
            production[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            production[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            production[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            production[0].Show!.IDs!.TMDB.ShouldBe(1399U);

            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound!.Count.ShouldBe(2);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects!.Count.ShouldBe(2);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing!.Count.ShouldBe(2);

            TraktPersonShowCreditsCrewItem[] writing = [.. responseValue.Crew.Writing];

            writing[0].Jobs.ShouldNotBeNull();
            writing[0].Jobs!.Count.ShouldBe(1);
            writing[0].Jobs!.ShouldContain("Writer 1");
            writing[0].Show.ShouldNotBeNull();
            writing[0].Show!.Title.ShouldBe("Game of Thrones");
            writing[0].Show!.Year.ShouldBe(2011U);
            writing[0].Show!.IDs.ShouldNotBeNull();
            writing[0].Show!.IDs!.Trakt.ShouldBe(1390U);
            writing[0].Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            writing[0].Show!.IDs!.IMDB.ShouldBe("tt0944947");
            writing[0].Show!.IDs!.TMDB.ShouldBe(1399U);
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
        public async Task TestGetPersonShowCreditsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonShowCreditsUri, statusCode);

            Func<Task<TraktResponse<TraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonShowCreditsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonShowCreditsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(default(TraktPersonIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonShowCreditsAsync(default(TraktPerson)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonShowCreditsAsync(new TraktPersonIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonShowCreditsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonShowCreditsAsync(default(string)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.GetPersonShowCreditsAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.GetPersonShowCreditsAsync("person id", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
