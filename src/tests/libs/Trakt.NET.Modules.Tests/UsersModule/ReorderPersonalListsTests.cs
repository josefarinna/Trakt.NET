using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ReorderPersonalListsTests
    {
        private const string ReorderPersonalListsUri = $"users/{Username}/lists/reorder";
        private const string Username = "sean";
        private readonly List<uint> ReorderedCustomLists = [823, 224, 88768, 356456, 245, 2, 890];

        [Fact]
        public async Task TestReorderPersonalLists()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistsreorderpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListsUri, responseContent);
            
            TraktResponse<TraktListItemsReorderPostResponse> response = await client.Users.ReorderPersonalListsAsync(Username, ReorderedCustomLists, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktListItemsReorderPostResponse responseValue = response.Content;

            responseValue.Updated.ShouldBe(6U);
            responseValue.SkippedIDs.ShouldNotBeNull();
            responseValue.SkippedIDs.Count.ShouldBe(1);
            responseValue.SkippedIDs.ShouldBeEquivalentTo(new List<uint> { 2 });
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestReorderPersonalListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListsUri, statusCode);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListsAsync(Username, ReorderedCustomLists, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListsExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListsAsync(null!, ReorderedCustomLists, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListsAsync(string.Empty, ReorderedCustomLists, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListsAsync("user name", ReorderedCustomLists, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListsAsync(Username, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
