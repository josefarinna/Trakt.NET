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

        [Fact]
        public async Task TestGetUserNotes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetUserNotesUri, responseContent, 1, 1, 10, NotesItemCount);

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
        public async Task TestGetUserNotesWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}",
                responseContent, 1, 1, 10, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response = await client.Users.GetUserNotesAsync(Username, NotesObjectType, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetUserNotesWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetUserNotesUri}/{NotesObjectType.ToURI()}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetUserNotesWithTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetUserNotesUri}/{NotesObjectType.ToURI()}?limit={NotesItemLimit}",
                responseContent, 1, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, null, null, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetUserNotesUri}/{NotesObjectType.ToURI()}?page={Page}&limit={NotesItemLimit}",
                responseContent, Page, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, null, Page, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetUserNotesWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}?extended={ExtendedInfo.ToURI()}&limit={NotesItemLimit}",
                responseContent, 1, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, ExtendedInfo, null, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetUserNotesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={NotesItemLimit}",
                responseContent, Page, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, ExtendedInfo, Page, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}?page={Page}",
                responseContent, Page, 1, 10, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}?limit={NotesItemLimit}",
                responseContent, 1, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, null, null, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}?page={Page}&limit={NotesItemLimit}",
                responseContent, Page, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, null, null, Page, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUserNotesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\notesitems.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetUserNotesUri}/{NotesObjectType.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page={Page}&limit={NotesItemLimit}",
                responseContent, Page, 1, NotesItemLimit, NotesItemCount);

            TraktPagedResponse<TraktNoteItem> response =
                await client.Users.GetUserNotesAsync(Username, NotesObjectType, ExtendedInfo, Page, NotesItemLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)NotesItemCount);
            response.ItemCount.ShouldBe(NotesItemCount);
            response.Limit.ShouldBe(NotesItemLimit);
            response.Page.ShouldBe(Page);
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetUserNotesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetUserNotesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktNoteItem>>> act = () => client.Users.GetUserNotesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
