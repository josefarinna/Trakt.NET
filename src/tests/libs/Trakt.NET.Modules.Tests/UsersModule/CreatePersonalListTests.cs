using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class CreatePersonalListTests
    {
        private const string CreatePersonalListUri = $"users/{Username}/lists";
        private const string Username = "sean";
        private const string ListName = "new list";
        private const string Description = "list description";
        private const TraktListPrivacy Privacy = TraktListPrivacy.Public;
        private const bool DisplayNumbers = true;
        private const bool AllowComments = true;

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData(Description, null, null, null)]
        [InlineData(null, Privacy, null, null)]
        [InlineData(null, null, DisplayNumbers, null)]
        [InlineData(null, null, null, AllowComments)]
        [InlineData(Description, Privacy, DisplayNumbers, AllowComments)]
        public async Task TestCreatePersonalList(string? description, TraktListPrivacy? privacy, bool? displayNumbers, bool? allowComments)
        {
            var createListPost = new TraktUserPersonalListPost
            {
                Name = ListName,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreatePersonalListUri, responseContent);
            
            TraktResponse<TraktList> response = await client.Users.CreatePersonalListAsync(Username, createListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestCreatePersonalListThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var createListPost = new TraktUserPersonalListPost
            {
                Name = ListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreatePersonalListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.CreatePersonalListAsync(Username, createListPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
