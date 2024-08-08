using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TraktNET
{
    public static class HttpClientFactoryExtensions
    {
        private const string ConfigurationKeyClientId = "TraktNET:ClientId";
        private const string ConfigurationKeyClientSecret = "TraktNET:ClientSecret";
        private const string ConfigurationKeySandbox = "TraktNET:Sandbox";

        public static IHttpClientBuilder AddTraktClient(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentValidator.ThrowIfNull(configuration);

            string clientId = configuration[ConfigurationKeyClientId] ?? string.Empty;
            string clientSecret = configuration[ConfigurationKeyClientSecret] ?? string.Empty;
            string sandboxValue = configuration[ConfigurationKeySandbox] ?? string.Empty;
            bool useSandbox = false;

            if (bool.TryParse(sandboxValue, out bool sandbox))
            {
                useSandbox = sandbox;
            }

            return useSandbox ? services.AddTraktSandboxClient(clientId, clientSecret) : services.AddTraktClient(clientId, clientSecret);
        }

        public static IHttpClientBuilder AddTraktClient(this IServiceCollection services, string clientId, string clientSecret)
        {
            var context = TraktContext.Create(clientId, clientSecret);
            return services.AddTraktHttpClient(context).AddTypedClient(context);
        }

        public static IHttpClientBuilder AddTraktSandboxClient(this IServiceCollection services, string clientId, string clientSecret)
        {
            var context = TraktContext.CreateForSandbox(clientId, clientSecret);
            return services.AddTraktHttpClient(context).AddTypedClient(context);
        }

        private static IHttpClientBuilder AddTraktHttpClient(this IServiceCollection services, TraktContext context)
            => services.AddHttpClient(context.ID).ConfigureHttpClient(httpClient => httpClient.BaseAddress = context.BaseUri);

        private static IHttpClientBuilder AddTypedClient(this IHttpClientBuilder httpClientBuilder, TraktContext context)
        {
            httpClientBuilder.Services.AddTransient(serviceProvider =>
            {
                IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
                context.HttpClientProvider = new HttpClientFactoryProvider(httpClientFactory);
                return new TraktClient(context);
            });

            return httpClientBuilder;
        }
    }
}
