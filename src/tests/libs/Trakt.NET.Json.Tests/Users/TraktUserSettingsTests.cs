namespace TraktNET.Json.Users
{
    public sealed class TraktUserSettingsTests
    {
        [Fact]
        public void TestTraktUserSettingsDefaultConstructor()
        {
            var userSettings = new TraktUserSettings();

            userSettings.User.ShouldBeNull();
            userSettings.Account.ShouldBeNull();
            userSettings.Connections.ShouldBeNull();
            userSettings.SharingText.ShouldBeNull();
            userSettings.Limits.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSettingsFromJson()
        {
            TraktUserSettings? userSettings = await TestUtility.DeserializeJsonAsync<TraktUserSettings>("Users\\usersettings.json");

            userSettings.ShouldNotBeNull();

            userSettings.User.ShouldNotBeNull();
            userSettings.User.Username.ShouldBe("sean");
            userSettings.User.Private.ShouldBe(false);
            userSettings.User.Name.ShouldBe("Sean Rudford");
            userSettings.User.VIP.ShouldBe(true);
            userSettings.User.VIPEP.ShouldBe(true);
            userSettings.User.IDs.ShouldNotBeNull();
            userSettings.User.IDs.Slug.ShouldBe("sean");
            userSettings.User.IDs.UUID.ShouldBe("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            userSettings.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            userSettings.User.Location.ShouldBe("SF");
            userSettings.User.About.ShouldBe("I have all your cassette tapes.");
            userSettings.User.Gender.ShouldBe(TraktGender.Male);
            userSettings.User.Age.ShouldBe(35U);
            userSettings.User.Images.ShouldNotBeNull();
            userSettings.User.Images.Avatar.ShouldNotBeNull();
            userSettings.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            userSettings.User.VIPOG.ShouldBe(true);
            userSettings.User.VIPYears.ShouldBe(5U);
            userSettings.User.VIPCoverImage.ShouldBe("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");

            userSettings.Account.ShouldNotBeNull();
            userSettings.Account.Timezone.ShouldBe("America/Los_Angeles");
            userSettings.Account.DateFormat.ShouldBe(TraktDateFormat.DayMonthYear);
            userSettings.Account.Time24Hr.ShouldBe(true);
            userSettings.Account.CoverImage.ShouldBe("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userSettings.Account.Token.ShouldBe("60fa34c4f5e7f093ecc5a2d16d691e24");

            userSettings.Connections.ShouldNotBeNull();
            userSettings.Connections.Twitter.ShouldBe(true);
            userSettings.Connections.Mastodon.ShouldBe(true);
            userSettings.Connections.Google.ShouldBe(true);
            userSettings.Connections.Tumblr.ShouldBe(true);
            userSettings.Connections.Medium.ShouldBe(true);
            userSettings.Connections.Slack.ShouldBe(true);
            userSettings.Connections.Facebook.ShouldBe(true);
            userSettings.Connections.Apple.ShouldBe(true);
            userSettings.Connections.Microsoft.ShouldBe(true);

            userSettings.SharingText.ShouldNotBeNull();
            userSettings.SharingText.Watching.ShouldBe("I'm watching [item]");
            userSettings.SharingText.Watched.ShouldBe("I just watched [item]");
            userSettings.SharingText.Rated.ShouldBe("[item] [stars]");

            userSettings.Limits.ShouldNotBeNull();
            userSettings.Limits.List.ShouldNotBeNull();
            userSettings.Limits.List.Count.ShouldBe(9999U);
            userSettings.Limits.List.ItemCount.ShouldBe(10000U);
            userSettings.Limits.Watchlist.ShouldNotBeNull();
            userSettings.Limits.Watchlist.ItemCount.ShouldBe(10000U);
            userSettings.Limits.Recommendations.ShouldNotBeNull();
            userSettings.Limits.Recommendations.ItemCount.ShouldBe(50U);
        }

        private const string JSON =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";
    }
}
