#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
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