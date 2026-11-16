using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetUserNotesTests
    {
        private const string GetUserNotesUri = $"users/{Username}/notes";
        private const string Username = "sean";
        private const uint Page = 2;
        private const uint NotesItemCount = 2U;
        private const uint NotesItemLimit = 4U;
        private const TraktNotesObjectType NotesObjectType = TraktNotesObjectType.Show;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, GetUserNotesUri)]
        [InlineData(NotesObjectType, null, null, null, $"{GetUserNotesUri}/shows")]
        [InlineData(null, ExtendedInfo, null, null, $"{GetUserNotesUri}?extended=full")]
        [InlineData(null, null, Page, null, $"{GetUserNotesUri}?page=2")]
        [InlineData(null, null, null, NotesItemLimit, $"{GetUserNotesUri}?limit=4")]
        [InlineData(NotesObjectType, ExtendedInfo, Page, NotesItemLimit, $"{GetUserNotesUri}/shows" + $"?extended=full&page=2&limit=4")]
        public async Task TestGetUserNotes(TraktNotesObjectType? notesObjectType, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response = await client.Users.GetUserNotesAsync(Username, notesObjectType, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetUserNotesUri, responseContent, 1, 1, 10, NotesItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktNoteItem> response = await client.Users.GetUserNotesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/notes", responseContent, 1, 1, 10, NotesItemCount);
            
            TraktPagedResponse<TraktNoteItem> response = await client.Users.GetUserNotesAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={NotesItemLimit}",
                responseContent, 2, 5, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, 2, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUserNotesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={NotesItemLimit}",
                responseContent, 2, 2, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, 2, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetUserNotesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={NotesItemLimit}",
                responseContent, 1, 2, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, 1, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUserNotesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={NotesItemLimit}",
                responseContent, 1, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, 1, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetUserNotesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={NotesItemLimit}",
                responseContent, 2, 2, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, 2, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={NotesItemLimit}",
                responseContent, 1, 2, NotesItemLimit, NotesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUserNotesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={NotesItemLimit}",
                responseContent, 1, 2, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, 1, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={NotesItemLimit}",
                responseContent, 2, 2, NotesItemLimit, NotesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetUserNotesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetUserNotesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktNoteItem>>> act = () => client.Users.GetUserNotesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
