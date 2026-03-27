using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class AddRatedEpisodeNoteTests
    {
        private const string AddNoteUri = "notes";

        [Fact]
        public async Task TestAddRatedEpisodeNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, responseContent, null, null, null, null);

            var episode = new TraktEpisode
            {
                IDs = new TraktEpisodeIDs
                {
                    Trakt = 16U
                }
            };
            string notes = "I am the danger!";

            TraktResponse<TraktNote> response = await client.Notes.AddRatedEpisodeNoteAsync(episode, notes, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktNote note = response.Content;
            note.ID.ShouldBe(190U);
            note.Privacy.ShouldBe(TraktListPrivacy.Private);
            note.Spoiler.ShouldBe(false);
            note.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-12T20:10:18.000Z"));
            note.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-12T20:10:56.000Z"));

            note.User.ShouldNotBeNull();
            note.User.Username.ShouldBe("justin");
            note.User.Private.ShouldBe(false);
            note.User.Name.ShouldBe("Justin Nemeth");
            note.User.VIP.ShouldBe(true);
            note.User.VIPEP.ShouldBe(false);

            note.User.IDs.ShouldNotBeNull();
            note.User.IDs.Slug.ShouldBe("justin");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        [InlineData((HttpStatusCode)426, typeof(TraktApiVIPValidationException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestAddRatedEpisodeNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, statusCode);

            var episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddRatedEpisodeNoteAsync(episode, "Notes", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddRatedEpisodeNoteThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, HttpStatusCode.Created);
            var episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddRatedEpisodeNoteAsync(null!, "Notes");
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Notes.AddRatedEpisodeNoteAsync(episode, null!);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddRatedEpisodeNoteAsync(episode, string.Empty);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
