using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class DeletePersonalListTests
    {
        private readonly string DeletePersonalListUri = $"users/{Username}/lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestDeletePersonalListWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeletePersonalListUri, HttpStatusCode.NoContent);
            
            TraktResponse response = await client.Users.DeletePersonalListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestDeletePersonalListWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", HttpStatusCode.NoContent);
            
            TraktResponse response = await client.Users.DeletePersonalListAsync(Username, ListSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestDeletePersonalListWithIDs()
        {
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", HttpStatusCode.NoContent);
            
            TraktResponse response = await client.Users.DeletePersonalListAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestDeletePersonalListWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", HttpStatusCode.NoContent);
            
            TraktResponse response = await client.Users.DeletePersonalListAsync(Username, list, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestDeletePersonalListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeletePersonalListUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.DeletePersonalListAsync(Username, TraktListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestDeletePersonalListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeletePersonalListUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.DeletePersonalListAsync(Username, default(TraktListIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.DeletePersonalListAsync(Username, default(TraktList)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.DeletePersonalListAsync(Username, new TraktListIDs());
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.DeletePersonalListAsync(Username, 0);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
