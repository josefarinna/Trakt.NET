using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetRatingsTests
    {
        private const string GetRatingsUri = $"users/{Username}/ratings";
        private const string Username = "sean";
        private const uint RatingsItemCount = 5U;
        private const uint Page = 2;
        private const uint Limit = 4;
        private const TraktRatingsItemType RatingsItemType = TraktRatingsItemType.Movie;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetRatings()
        {
			string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetRatingsUri, responseContent, 1, 1, 10, RatingsItemCount);
            
            TraktPagedResponse<TraktRatingsItem> response = await client.Users.GetRatingsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetRatingsUri, responseContent, 1, 1, 10, RatingsItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktRatingsItem> response = await client.Users.GetRatingsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/ratings", responseContent, 1, 1, 10, RatingsItemCount);
            
            TraktPagedResponse<TraktRatingsItem> response = await client.Users.GetRatingsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter1()
        {
            uint[] ratingsFilter = [1];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter12()
        {
            uint[] ratingsFilter = [1, 2];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter123()
        {
            uint[] ratingsFilter = [1, 2, 3];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter1234()
        {
            uint[] ratingsFilter = [1, 2, 3, 4];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter12345()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter123456()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter1234567()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter12345678()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter123456789()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter12345678910()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}/{BuildRatingsFilterString(ratingsFilter)}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter1234567891011()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter012345678910()
        {
            uint[] ratingsFilter = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter12345678911()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 11];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndRatingsFilter0123456789()
        {
            uint[] ratingsFilter = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithRatingsFilter()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetRatingsUri, responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, null, ratingsFilter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}?page={Page}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}?limit={Limit}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}?page={Page}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}?limit={Limit}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, null, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}?page={Page}&limit={Limit}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsComplete()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, 1, 1, 10, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsPagingHasPreviousPageAndHasNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingOnlyHasPreviousPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetRatingsPagingOnlyHasNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingNotHasPreviousPageOrHasNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetRatingsPagingGetPreviousPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, RatingsItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingGetNextPage()
        {
            uint[] ratingsFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\ratings.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, RatingsItemCount);

            TraktPagedResponse<TraktRatingsItem> response =
                await client.Users.GetRatingsAsync(Username, RatingsItemType, ratingsFilter, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetRatingsUri}/{RatingsItemType.ToURI()}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, RatingsItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(RatingsItemCount);
            response.Limit.ShouldBe(Limit);
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
        public async Task TestGetRatingsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRatingsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        private static string BuildRatingsFilterString(uint[] ratings) => string.Join(",", ratings);
    }
}
