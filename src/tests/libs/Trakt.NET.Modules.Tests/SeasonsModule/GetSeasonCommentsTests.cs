using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonCommentsTests
    {
        private const string GetSeasonCommentsUriPrefix = "shows";
        private const string GetSeasonCommentsUriSuffix = "comments";
        private const uint SeasonNumber = 1U;
        private const string GetSeasonCommentsUriWithSlug = GetSeasonCommentsUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/seasons/1/" + GetSeasonCommentsUriSuffix;
        private static readonly string GetSeasonCommentsUri = $"{GetSeasonCommentsUriPrefix}/{TestConstants.Shows.ShowID}/seasons/1/{GetSeasonCommentsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, GetSeasonCommentsUriWithSlug, "Seasons\\seasoncomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetSeasonCommentsUriWithSlug, "Seasons\\seasoncomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetSeasonCommentsUriWithSlug}?extended=full", "Seasons\\seasoncomments.json")]
        [InlineData(null, null, 4U, null, $"{GetSeasonCommentsUriWithSlug}?page=4", "Seasons\\seasoncomments.json")]
        [InlineData(null, null, null, 20U, $"{GetSeasonCommentsUriWithSlug}?limit=20", "Seasons\\seasoncomments.json")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, null, $"{GetSeasonCommentsUriWithSlug}/newest", "Seasons\\seasoncomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 2U, 10U, $"{GetSeasonCommentsUriWithSlug}/likes?extended=full&page=2&limit=10", "Seasons\\seasoncomments.json")]
        public async Task TestGetSeasonComments(TraktCommentSortOrder? sortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.ShowSlug, SeasonNumber, sortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1u, limit ?? 10u);
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonCommentsUri, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.ShowID, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        [Fact]
        public async Task TestGetSeasonCommentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonCommentsUriWithSlug, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktComment> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            IReadOnlyList<TraktComment> comments = response.Content!;

            // Primer comentario
            comments[0].ID.ShouldBe(7149524U);
            comments[0].Comment.ShouldBe("Comment content 1.");
            comments[0].User.ShouldNotBeNull();
            comments[0].User!.Username.ShouldBe("user1");
            comments[0].UserStats.ShouldNotBeNull();
            comments[0].UserStats!.Rating.ShouldBe(9U);

            // Segundo comentario
            comments[1].ID.ShouldBe(7149524U);
            comments[1].Comment.ShouldBe("Comment content 2.");
            comments[1].User.ShouldNotBeNull();
            comments[1].User!.Username.ShouldBe("user2");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetSeasonCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonCommentsUriWithSlug, statusCode);

            try
            {
                await client.Seasons.GetSeasonCommentsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }



        [Fact]
        public async Task TestGetSeasonCommentsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasoncomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonCommentsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonCommentsAsync(ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
