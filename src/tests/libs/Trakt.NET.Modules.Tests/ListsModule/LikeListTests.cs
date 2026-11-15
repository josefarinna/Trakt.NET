using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class LikeListTests
    {
        private const string LikeListUri = $"lists/{ListID}/like";
        private const string ListID = "1248149";
        private const uint TraktListID = 1248149U;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestLikeListWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(LikeListUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.LikeListAsync(TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestLikeListWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"lists/{ListSlug}/like", HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.LikeListAsync(ListSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestLikeListWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"lists/{ListSlug}/like", HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.LikeListAsync(listIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestLikeListWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"lists/{ListSlug}/like", HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.LikeListAsync(list, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestLikeListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(LikeListUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Lists.LikeListAsync(TraktListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestLikeListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(LikeListUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Lists.LikeListAsync(default(TraktListIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.LikeListAsync(default(TraktList)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.LikeListAsync(new TraktListIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.LikeListAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
