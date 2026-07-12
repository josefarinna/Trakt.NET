using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class GetPersonTests
    {
        private const string GetPersonUri = $"people/297737";
        private const string PersonSlug = "bryan-cranston";
        private const uint PersonID = 297737U;

        [Fact]
        public async Task TestGetPerson()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\person_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonUri, responseContent);
            TraktResponse<TraktPerson> response = await client.People.GetPersonAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPerson responseValue = response.Content;

            responseValue.Name.ShouldBe("Bryan Cranston");
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(297737U);
            responseValue.IDs.Slug.ShouldBe("bryan-cranston");
            responseValue.IDs.IMDB.ShouldBe("nm0186505");
            responseValue.IDs.TMDB.ShouldBe(17419U);
        }

        [Fact]
        public async Task TestGetPersonWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\person_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}", responseContent);
            TraktResponse<TraktPerson> response = await client.People.GetPersonAsync(PersonSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonWithPersonIdsTraktID()
        {
            var personIds = new TraktPersonIDs
            {
                Trakt = PersonID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\person_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonUri, responseContent);
            TraktResponse<TraktPerson> response = await client.People.GetPersonAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonWithPersonIdsSlug()
        {
            var personIds = new TraktPersonIDs
            {
                Slug = PersonSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\person_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}", responseContent);
            TraktResponse<TraktPerson> response = await client.People.GetPersonAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonWithPersonIds()
        {
            var personIds = new TraktPersonIDs
            {
                Trakt = PersonID,
                Slug = PersonSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\person_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"people/{PersonSlug}", responseContent);
            TraktResponse<TraktPerson> response = await client.People.GetPersonAsync(personIds, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("People\\person_full.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonUri}?extended=full", responseContent);
            TraktResponse<TraktPerson> response = await client.People.GetPersonAsync(PersonID, TraktExtendedInfo.Full, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPerson responseValue = response.Content;

            responseValue.Name.ShouldBe("Bryan Cranston");
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(297737U);
            responseValue.IDs.Slug.ShouldBe("bryan-cranston");
            responseValue.IDs.IMDB.ShouldBe("nm0186505");
            responseValue.IDs.TMDB.ShouldBe(17419U);
            responseValue.Biography.ShouldBe("Bryan Lee Cranston (born March 7, 1956) is an American actor, director, and producer who is mainly known for portraying Walter White in the AMC crime drama series Breaking Bad (2008–2013) and Hal in the Fox sitcom Malcolm in the Middle (2000–2006).");
            DateTime birthDay = TestUtility.ParseUTCDateTime("1956-03-07T00:00:00Z");
#if NET7_0_OR_GREATER
            responseValue.Birthday.ShouldBe(TestUtility.ParseDate("1956-03-07"));
#else
            responseValue.Birthday.ShouldBe(birthDay);
#endif
            responseValue.Death.ShouldBeNull();
            DateTime today = DateTime.Now;
            int age = Math.Abs(today.Year - birthDay.Year);

            if (today < birthDay.AddYears(age))
                age--;
            responseValue.Age.ShouldBe(age);
            responseValue.Birthplace.ShouldBe("Hollywood, Los Angeles, California, USA");
            responseValue.Homepage.ShouldBe("http://www.bryancranston.com/");
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
        public async Task TestGetPersonThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonUri, statusCode);

            Func<Task<TraktResponse<TraktPerson>>> act = () => client.People.GetPersonAsync(PersonID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPerson>>> act = () => client.People.GetPersonAsync(default(TraktPersonIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonAsync(new TraktPersonIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonAsync(default(string)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.GetPersonAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.GetPersonAsync("person id", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
