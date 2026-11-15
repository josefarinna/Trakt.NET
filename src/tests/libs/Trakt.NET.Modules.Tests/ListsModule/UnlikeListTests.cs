using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class UnlikeListTests
    {
        private const string UnlikeListUri = $"lists/{ListID}/like";
        private const string ListID = "1248149";
        private const uint TraktListID = 1248149U;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestUnlikeListWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnlikeListUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.UnlikeListAsync(TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUnlikeListWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"lists/{ListSlug}/like", HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.UnlikeListAsync(ListSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUnlikeListWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"lists/{ListSlug}/like", HttpStatusCode.NoContent);
            TraktResponse response = await client.Lists.UnlikeListAsync(listIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUnlikeListWithList()
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
            TraktResponse response = await client.Lists.UnlikeListAsync(list, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestUnlikeListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnlikeListUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Lists.UnlikeListAsync(TraktListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUnlikeListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnlikeListUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Lists.UnlikeListAsync(default(TraktListIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.UnlikeListAsync(default(TraktList)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.UnlikeListAsync(new TraktListIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.UnlikeListAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
