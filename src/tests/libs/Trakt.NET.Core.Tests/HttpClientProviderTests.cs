#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#else
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#endif

using System.Runtime.CompilerServices;

namespace TraktNET
{
    public class HttpClientProviderTests
    {
        [Fact]
        public void TestDefaultHttpClientProviderReturnsSameClientForContext()
        {
            var context = TraktContext.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            HttpClient first = context.GetHttpClient();
            HttpClient second = context.GetHttpClient();

            second.ShouldBeSameAs(first);
            first.BaseAddress.ShouldBe(context.BaseUri);
            first.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");
        }

        [Fact]
        public void TestDefaultHttpClientProviderReturnsSeparateAuthorizationClient()
        {
            var context = TraktContext.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            HttpClient apiClient = context.GetHttpClient();
            HttpClient authorizationClient = context.GetHttpClient(baseAuthRequest: true);

            authorizationClient.ShouldNotBeSameAs(apiClient);
            authorizationClient.ShouldBeSameAs(context.GetHttpClient(baseAuthRequest: true));
            authorizationClient.BaseAddress.ShouldBe(context.BaseAuthorizationUri);
            authorizationClient.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");
        }

        [Fact]
        public void TestDefaultHttpClientProviderUsesSeparateClientsPerContext()
        {
            var context1 = TraktContext.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            var context2 = TraktContext.CreateForSandbox(TestConstants.ClientID, TestConstants.ClientSecret);

            HttpClient client1 = context1.GetHttpClient();
            HttpClient client2 = context2.GetHttpClient();

            client2.ShouldNotBeSameAs(client1);
            client1.BaseAddress.ShouldBe(context1.BaseUri);
            client2.BaseAddress.ShouldBe(context2.BaseUri);
        }

        [Fact]
        public void TestDefaultHttpClientProviderDoesNotKeepContextAlive()
        {
            WeakReference contextReference = CreateContextAndUseHttpClient();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            contextReference.IsAlive.ShouldBeFalse();
        }

#if !TRAKT_NET_4XX_FRAMEWORK_TARGET
        [Fact]
        public void TestAddTraktClientCreatesIsolatedContextPerResolvedClient()
        {
            var services = new ServiceCollection();
            services.AddTraktClient(TestConstants.ClientID, TestConstants.ClientSecret, "CustomAgent/1.0");

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            TraktClient client1 = serviceProvider.GetRequiredService<TraktClient>();
            TraktClient client2 = serviceProvider.GetRequiredService<TraktClient>();

            client1.ShouldNotBeSameAs(client2);
            client1.Context.ShouldNotBeSameAs(client2.Context);
            client1.AntiForgeryToken.ShouldNotBe(client2.AntiForgeryToken);

            var auth1 = TraktAuthorization.CreateWith("token-user-1");
            var device1 = new TraktDevice { DeviceCode = "device-user-1" };

            client1.Authorization = auth1;
            client1.CodeVerifier = "verifier-user-1";
            client1.OAuthAuthorizationCode = "code-user-1";
            client1.Device = device1;
            client1.IgnoreOAuthIfOptional = true;

            client2.Authorization.ShouldBeNull();
            client2.CodeVerifier.ShouldBeNull();
            client2.OAuthAuthorizationCode.ShouldBeNull();
            client2.Device.ShouldNotBeSameAs(device1);
            client2.IgnoreOAuthIfOptional.ShouldBeFalse();
            client2.UserAgent.ShouldBe("CustomAgent/1.0");
        }

        [Fact]
        public void TestAddTraktSandboxClientCreatesIsolatedContextPerResolvedClient()
        {
            var services = new ServiceCollection();
            services.AddTraktSandboxClient(TestConstants.ClientID, TestConstants.ClientSecret);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            TraktClient client1 = serviceProvider.GetRequiredService<TraktClient>();
            TraktClient client2 = serviceProvider.GetRequiredService<TraktClient>();

            client1.ShouldNotBeSameAs(client2);
            client1.Context.ShouldNotBeSameAs(client2.Context);

            client1.Authorization = TraktAuthorization.CreateWith("sandbox-token-1");
            client2.Authorization.ShouldBeNull();
        }

        [Fact]
        public void TestAddTraktClientConfiguresBaseAddressAndAcceptHeader()
        {
            var services = new ServiceCollection();
            services.AddTraktClient(TestConstants.ClientID, TestConstants.ClientSecret);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            TraktClient client = serviceProvider.GetRequiredService<TraktClient>();

            HttpClient apiHttpClient = client.Context.GetHttpClient();
            apiHttpClient.BaseAddress.ShouldBe(new Uri(Constants.Api.BaseURL));
            apiHttpClient.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");

            HttpClient authHttpClient = client.Context.GetHttpClient(baseAuthRequest: true);
            authHttpClient.BaseAddress.ShouldBe(new Uri(Constants.Api.BaseAuthorizationURL));
            authHttpClient.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");
        }

        [Fact]
        public void TestAddTraktSandboxClientConfiguresBaseAddressAndAcceptHeader()
        {
            var services = new ServiceCollection();
            services.AddTraktSandboxClient(TestConstants.ClientID, TestConstants.ClientSecret);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            TraktClient client = serviceProvider.GetRequiredService<TraktClient>();

            HttpClient apiHttpClient = client.Context.GetHttpClient();
            apiHttpClient.BaseAddress.ShouldBe(new Uri(Constants.Api.StagingBaseURL));
            apiHttpClient.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");

            HttpClient authHttpClient = client.Context.GetHttpClient(baseAuthRequest: true);
            authHttpClient.BaseAddress.ShouldBe(new Uri(Constants.Api.StagingBaseAuthorizationURL));
            authHttpClient.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");
        }

        [Fact]
        public void TestAddTraktClientWithConfigurationCreatesIsolatedContextAndHeaders()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["TraktNET:ClientID"] = TestConstants.ClientID,
                    ["TraktNET:ClientSecret"] = TestConstants.ClientSecret,
                    ["TraktNET:Sandbox"] = "true"
                })
                .Build();

            var services = new ServiceCollection();
            services.AddTraktClient(configuration);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            TraktClient client1 = serviceProvider.GetRequiredService<TraktClient>();
            TraktClient client2 = serviceProvider.GetRequiredService<TraktClient>();

            client1.Context.ShouldNotBeSameAs(client2.Context);
            client1.ClientID.ShouldBe(TestConstants.ClientID);
            client1.ClientSecret.ShouldBe(TestConstants.ClientSecret);

            HttpClient apiHttpClient = client1.Context.GetHttpClient();
            apiHttpClient.BaseAddress.ShouldBe(new Uri(Constants.Api.StagingBaseURL));
            apiHttpClient.DefaultRequestHeaders.Accept.ShouldContain(h => h.MediaType == "application/json");
        }
#endif

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static WeakReference CreateContextAndUseHttpClient()
        {
            var context = TraktContext.Create(TestConstants.ClientID, TestConstants.ClientSecret);
            _ = context.GetHttpClient();
            _ = context.GetHttpClient(baseAuthRequest: true);
            return new WeakReference(context);
        }
    }
}