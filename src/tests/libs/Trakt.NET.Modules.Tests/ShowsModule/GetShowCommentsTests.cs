using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowCommentsTests
    {
        private const string GetShowCommentsUriPrefix = "shows";
        private const string GetShowCommentsUriSuffix = "comments";
        private const string GetShowCommentsUriWithSlug = GetShowCommentsUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + GetShowCommentsUriSuffix;
        private static readonly string GetShowCommentsUri = $"{GetShowCommentsUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowCommentsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, GetShowCommentsUriWithSlug, "Shows\\showcomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetShowCommentsUriWithSlug, "Shows\\showcomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetShowCommentsUriWithSlug}?extended=full", "Shows\\showcomments.json")]
        [InlineData(null, null, 4U, null, $"{GetShowCommentsUriWithSlug}?page=4", "Shows\\showcomments.json")]
        [InlineData(null, null, null, 20U, $"{GetShowCommentsUriWithSlug}?limit=20", "Shows\\showcomments.json")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, null, $"{GetShowCommentsUriWithSlug}/newest", "Shows\\showcomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 2U, 10U, $"{GetShowCommentsUriWithSlug}/likes?extended=full&page=2&limit=10", "Shows\\showcomments.json")]
        public async Task TestGetShowComments(TraktCommentSortOrder? sortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Shows.GetShowCommentsAsync(TestConstants.Shows.ShowSlug, sortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1u, limit ?? 10u);
        }

        [Fact]
        public async Task TestGetShowCommentsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCommentsUri, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Shows.GetShowCommentsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        [Fact]
        public async Task TestGetShowCommentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCommentsUriWithSlug, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Shows.GetShowCommentsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetShowCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowCommentsUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowCommentsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }



        [Fact]
        public async Task TestGetShowCommentsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showcomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowCommentsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Shows.GetShowCommentsAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowCommentsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
