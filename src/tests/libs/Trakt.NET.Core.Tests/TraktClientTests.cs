namespace TraktNET
{
    public class TraktClientTests
    {
        [Fact]
        public void TestTraktClientWithClientIDAndSecret()
        {
            var client = new TraktClient(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID.ShouldBe(TestConstants.ClientID);
            client.ClientSecret.ShouldBe(TestConstants.ClientSecret);
            client.UserAgent.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void TestTraktClientWithUserAgent()
        {
            const string customUserAgent = "CustomUserAgent/1.0";
            var client = new TraktClient(TestConstants.ClientID, TestConstants.ClientSecret, customUserAgent);

            client.ClientID.ShouldBe(TestConstants.ClientID);
            client.ClientSecret.ShouldBe(TestConstants.ClientSecret);
            client.UserAgent.ShouldBe(customUserAgent);
        }

        [Fact]
        public void TestTraktClientCreate()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID.ShouldBe(TestConstants.ClientID);
            client.ClientSecret.ShouldBe(TestConstants.ClientSecret);
            client.UserAgent.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void TestTraktClientCreateWithUserAgent()
        {
            const string customUserAgent = "CustomUserAgent/1.0";
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret, customUserAgent);

            client.ClientID.ShouldBe(TestConstants.ClientID);
            client.ClientSecret.ShouldBe(TestConstants.ClientSecret);
            client.UserAgent.ShouldBe(customUserAgent);
        }

        [Fact]
        public void TestTraktClientCreateForSandbox()
        {
            var client = TraktClient.CreateForSandbox(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID.ShouldBe(TestConstants.ClientID);
            client.ClientSecret.ShouldBe(TestConstants.ClientSecret);
            client.UserAgent.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void TestTraktClientCreateForSandboxWithUserAgent()
        {
            const string customUserAgent = "CustomUserAgent/1.0";
            var client = TraktClient.CreateForSandbox(TestConstants.ClientID, TestConstants.ClientSecret, customUserAgent);

            client.ClientID.ShouldBe(TestConstants.ClientID);
            client.ClientSecret.ShouldBe(TestConstants.ClientSecret);
            client.UserAgent.ShouldBe(customUserAgent);
        }

        [Fact]
        public void TestTraktClientThrowsArgumentNullExceptionWhenContextIsNull()
        {
            Action act = () => _ = new TraktClient(null!);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TestTraktClientProperties()
        {
            var client = new TraktClient(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID = "newClientID";
            client.ClientID.ShouldBe("newClientID");

            client.ClientSecret = "newClientSecret";
            client.ClientSecret.ShouldBe("newClientSecret");

            client.OAuthAuthorizationCode = "authCode123";
            client.OAuthAuthorizationCode.ShouldBe("authCode123");

            var authorization = new TraktAuthorization { AccessToken = "accessToken" };
            client.Authorization = authorization;
            client.Authorization.ShouldBe(authorization);

            var device = new TraktDevice { DeviceCode = "deviceCode" };
            client.Device = device;
            client.Device.ShouldBe(device);

            client.AntiForgeryToken.ShouldNotBeNullOrEmpty();

            client.IgnoreOAuthIfOptional = true;
            client.IgnoreOAuthIfOptional.ShouldBeTrue();

            client.UserAgent = "NewUserAgent/2.0";
            client.UserAgent.ShouldBe("NewUserAgent/2.0");

            var customHttpClientProvider = new DefaultHttpClientProvider();
            client.HttpClientProvider = customHttpClientProvider;
            client.HttpClientProvider.ShouldBe(customHttpClientProvider);
        }

        [Fact]
        public void TestTraktClientModules()
        {
            var client = new TraktClient(TestConstants.ClientID, TestConstants.ClientSecret);

            client.Auth.ShouldNotBeNull();
            client.Calendar.ShouldNotBeNull();
            client.Certifications.ShouldNotBeNull();
            client.Checkins.ShouldNotBeNull();
            client.Comments.ShouldNotBeNull();
            client.Countries.ShouldNotBeNull();
            client.Episodes.ShouldNotBeNull();
            client.Genres.ShouldNotBeNull();
            client.Languages.ShouldNotBeNull();
            client.Lists.ShouldNotBeNull();
            client.Media.ShouldNotBeNull();
            client.Movies.ShouldNotBeNull();
            client.Networks.ShouldNotBeNull();
            client.Notes.ShouldNotBeNull();
            client.People.ShouldNotBeNull();
            client.Recommendations.ShouldNotBeNull();
            client.Scrobble.ShouldNotBeNull();
            client.Search.ShouldNotBeNull();
            client.Seasons.ShouldNotBeNull();
            client.Shows.ShouldNotBeNull();
            client.SmartLists.ShouldNotBeNull();
            client.SocialRecommendations.ShouldNotBeNull();
            client.Sync.ShouldNotBeNull();
            client.Team.ShouldNotBeNull();
            client.Users.ShouldNotBeNull();
            client.Watchnow.ShouldNotBeNull();
            client.Younify.ShouldNotBeNull();
        }
    }
}

