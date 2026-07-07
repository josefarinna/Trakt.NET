using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TraktNET.UsersModule
{
    public sealed class UpdateSettingsTests
    {
        private const string UpdateSettingsUri = "users/settings";

        [Fact]
        public async Task TestUpdateSettings()
        {
            string responseContent = "{\"user\":{\"username\":\"sean\"},\"browsing\":{\"watchnow\":{\"country\":\"us\",\"favorites\":[\"1\"],\"only_favorites\":true},\"calendar\":{\"period\":\"weekly\",\"layout\":\"list\"},\"spoilers\":{\"episodes\":\"hide\"}}}";

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateSettingsUri, responseContent);

            var post = new TraktUserSettingsPost
            {
                Browsing = new TraktUserSettingsBrowsingPost
                {
                    Watchnow = new TraktUserWatchnowSettings
                    {
                        Country = "us",
                        Favorites = new List<string> { "1" },
                        OnlyFavorites = true
                    }
                }
            };

            TraktResponse<TraktUserSettings> response = await client.Users.UpdateSettingsAsync(post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserSettings responseValue = response.Content;
            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("sean");
            
            responseValue.Browsing.ShouldNotBeNull();
            responseValue.Browsing.Watchnow.ShouldNotBeNull();
            responseValue.Browsing.Watchnow.Country.ShouldBe("us");
            responseValue.Browsing.Watchnow.Favorites.ShouldNotBeNull();
            responseValue.Browsing.Watchnow.Favorites.Count.ShouldBe(1);
            responseValue.Browsing.Watchnow.Favorites[0].ShouldBe("1");
            responseValue.Browsing.Watchnow.OnlyFavorites.ShouldBe(true);

            responseValue.Browsing.Calendar.ShouldNotBeNull();
            responseValue.Browsing.Calendar.Period.ShouldBe("weekly");
            responseValue.Browsing.Calendar.Layout.ShouldBe("list");

            responseValue.Browsing.Spoilers.ShouldNotBeNull();
            responseValue.Browsing.Spoilers.Episodes.ShouldBe("hide");
        }
    }
}
