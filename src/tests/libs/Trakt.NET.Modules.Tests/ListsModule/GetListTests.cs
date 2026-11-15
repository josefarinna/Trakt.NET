using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class GetListTests
    {
        private readonly string GetListUri = $"lists/{ListID}";
        private const uint ListID = 1248149U;
        private const string ListSlug = "marvel-cinematic-universe";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, "lists/1248149")]
        [InlineData(ExtendedInfo, "lists/1248149?extended=full")]
        public async Task TestGetListWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            TraktList responseValue = response.Content;
            responseValue.ShouldNotBeNull();
            responseValue.Name.ShouldBe("MARVEL Cinematic Universe");
            responseValue.Description.ShouldBe("MCU Shows and Movies in chronological order.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(true);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-07-16T14:59:57.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T06:47:38.000Z"));
            responseValue.ItemCount.ShouldBe(218U);
            responseValue.CommentCount.ShouldBe(33U);
            responseValue.Likes.ShouldBe(4668U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(1248149U);
            responseValue.IDs.Slug.ShouldBe("marvel-cinematic-universe");
            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("Donxy");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Donxy");
            responseValue.User.VIP.ShouldBe(false);
            responseValue.User.VIPEP.ShouldBe(true);
            responseValue.User.IDs.ShouldNotBeNull();
            responseValue.User.IDs.Slug.ShouldBe("donxy");
        }

        [Fact]
        public async Task TestGetListWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Lists.GetListAsync(ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = ListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Lists.GetListAsync(listIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestGetListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Lists.GetListAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Lists.GetListAsync(default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

        }
    }
}
