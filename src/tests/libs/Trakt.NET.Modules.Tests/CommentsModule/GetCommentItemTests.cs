using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentItemTests
    {
        private readonly string GetCommentItemUri = $"comments/{CommentID}/item";
        private const uint CommentID = 190U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, "comments/190/item")]
        [InlineData(ExtendedInfo, "comments/190/item?extended=full")]
        public async Task TestGetCommentItem(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentitem.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCommentItem> response = await client.Comments.GetCommentItemAsync(CommentID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            TraktCommentItem responseValue = response.Content;
            responseValue.Type.ShouldBe(TraktCommentObjectType.Movie);
            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            responseValue.Movie.Year.ShouldBe(2015U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs.Trakt.ShouldBe(94024U);
            responseValue.Show.ShouldNotBeNull();
            responseValue.Show.Title.ShouldBe("Game of Thrones");
            responseValue.Show.Year.ShouldBe(2011U);
            responseValue.Show.IDs.ShouldNotBeNull();
            responseValue.Show.IDs.Trakt.ShouldBe(1390U);
            responseValue.Season.ShouldNotBeNull();
            responseValue.Season.Number.ShouldBe(1U);
            responseValue.Season.IDs.ShouldNotBeNull();
            responseValue.Season.IDs.Trakt.ShouldBe(61430U);
            responseValue.Episode.ShouldNotBeNull();
            responseValue.Episode.Number.ShouldBe(1U);
            responseValue.Episode.Season.ShouldBe(1U);
            responseValue.Episode.Title.ShouldBe("Winter Is Coming");
            responseValue.Episode.IDs.ShouldNotBeNull();
            responseValue.Episode.IDs.Trakt.ShouldBe(73640U);
            responseValue.List.ShouldNotBeNull();
            responseValue.List.Name.ShouldBe("Star Wars in machete order");
            responseValue.List.IDs.ShouldNotBeNull();
            responseValue.List.IDs.Trakt.ShouldBe(55U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestGetCommentItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentItemUri, statusCode);

            Func<Task<TraktResponse<TraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
