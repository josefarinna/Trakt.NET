using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class GetNoteItemTests
    {
        private const ulong NoteID = 190UL;
        private readonly string GetNoteItemUri = $"notes/{NoteID}/item";

        [Fact]
        public async Task TestGetNoteItem()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\noteitempost.json");

            TraktClient client = ModuleTestUtility.GetClient(GetNoteItemUri, responseContent, null, null, null, null);

            TraktResponse<TraktNoteItem> response = await client.Notes.GetNoteItemAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktNoteItem note = response.Content!;
            note.AttachedTo.ShouldNotBeNull();
            note.AttachedTo.Type.ShouldBe(TraktNotesObjectType.Movie);
            note.Type.ShouldBe(TraktListItemType.Movie);
            
            note.Movie.ShouldNotBeNull();
            note.Movie.Title.ShouldBe("Batman Begins");
            note.Movie.Year.ShouldBe(2005U);
            note.Movie.IDs.ShouldNotBeNull();
            note.Movie.IDs.Trakt.ShouldBe(1U);
            note.Movie.IDs.Slug.ShouldBe("batman-begins-2005");
            note.Movie.IDs.IMDB.ShouldBe("tt0372784");
            note.Movie.IDs.TMDB.ShouldBe(272U);
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
        public async Task TestGetNoteItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetNoteItemUri, statusCode);

            Func<Task<TraktResponse<TraktNoteItem>>> act = () => client.Notes.GetNoteItemAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
