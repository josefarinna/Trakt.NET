using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieCommentsTests
    {
        private const string GetMovieCommentsUriPrefix = "movies";
        private const string GetMovieCommentsUriSuffix = "comments";
        private const string GetMovieCommentsUriWithSlug = GetMovieCommentsUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieCommentsUriSuffix;
        private static readonly string GetMovieCommentsUri = $"{GetMovieCommentsUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieCommentsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithID(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktComment> movieComments = response.Content;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithIDWithOAuth(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktComment> movieComments = response.Content;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithSlug(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktComment> movieComments = response.Content;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithSlugWithOAuth(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktComment> movieComments = response.Content;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithIDs(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktComment> movieComments = response.Content;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithIDsWithOAuth(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, commentSortOrder, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktComment> movieComments = response.Content;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieCommentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Theory]
        [InlineData("es", $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?language=es", "Movies\\moviecomments.json")]
        [InlineData("en", $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?language=en", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithLanguage(string language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.TraktMovieID, language: language, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCommentsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Movies.GetMovieCommentsAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieCommentsAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
