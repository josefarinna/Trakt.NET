using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TraktNET
{
    public static class HttpClientFactoryExtensions
    {
        private const string ConfigurationKeyClientID = "TraktNET:ClientID";
        private const string ConfigurationKeyClientSecret = "TraktNET:ClientSecret";
        private const string ConfigurationKeySandbox = "TraktNET:Sandbox";

        /// <summary>
        /// Adds an <see cref="HttpClient" /> instance to the <paramref name="services" /> collection.
        /// Also adds an <see cref="TraktClient" /> instance to the <paramref name="services" /> collection, which uses the
        /// added <see cref="HttpClient" /> instance via <see cref="IHttpClientFactory" />.
        /// The added <see cref="TraktClient" /> instance can than be used via dependency injection.
        /// <para />
        /// <example>
        /// Adding a Trakt client:
        /// <code>
        /// builder.Services.AddTraktClient(builder.Configuration);
        /// </code>
        /// This can than be used with:
        /// <code>
        /// public class ExampleController
        /// {
        ///     private readonly TraktClient _client;
        ///     public ExampleController(TraktClient client)
        ///     {
        ///         _client = client;
        ///     }
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="services">The services collection to which the <see cref="TraktClient" /> is added.</param>
        /// <param name="configuration">
        /// An <see cref="IConfiguration" /> instance which is used to get the values for the <see cref="TraktClient.ClientID" />
        /// and <see cref="TraktClient.ClientSecret" /> values.
        /// </param>
        /// <returns>A <see cref="IHttpClientBuilder" /> instance.</returns>
        /// <remarks>
        /// The value for the client ID in the <paramref name="configuration" /> must be saved with the key "TraktNET:ClientID"
        /// in the configuration root.
        /// <para />
        /// The value for the client secret in the <paramref name="configuration" /> must be saved with the key "TraktNET:ClientSecret"
        /// in the configuration root.
        /// <para />
        /// An optional boolean value with the key "TraktNET:Sandbox" can be set in the configuration root to specify whether
        /// the sandbox environment should be used or not. This defaults to false.
        /// <para />
        /// Each resolved <see cref="TraktClient" /> instance is independent and starts without an authorization, so setting
        /// <see cref="TraktClient.Authorization" /> on one instance doesn't affect the others. To share the authorization,
        /// keep and reuse a single instance.
        /// </remarks>
        public static IHttpClientBuilder AddTraktClient(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentValidator.ThrowIfNull(configuration);

            string clientID = configuration[ConfigurationKeyClientID] ?? string.Empty;
            string clientSecret = configuration[ConfigurationKeyClientSecret] ?? string.Empty;
            string sandboxValue = configuration[ConfigurationKeySandbox] ?? string.Empty;
            bool useSandbox = false;

            if (bool.TryParse(sandboxValue, out bool sandbox))
            {
                useSandbox = sandbox;
            }

            return useSandbox ? services.AddTraktSandboxClient(clientID, clientSecret) : services.AddTraktClient(clientID, clientSecret, null);
        }

        /// <summary>
        /// Adds an <see cref="HttpClient" /> instance to the <paramref name="services" /> collection.
        /// Also adds an <see cref="TraktClient" /> instance to the <paramref name="services" /> collection, which uses the
        /// added <see cref="HttpClient" /> instance via <see cref="IHttpClientFactory" />.
        /// The added <see cref="TraktClient" /> instance can than be used via dependency injection.
        /// <para />
        /// <example>
        /// Adding a Trakt client:
        /// <code>
        /// builder.Services.AddTraktClient("YourClientID", "YourClientSecret");
        /// </code>
        /// This can than be used with:
        /// <code>
        /// public class ExampleController
        /// {
        ///     private readonly TraktClient _client;
        ///     public ExampleController(TraktClient client)
        ///     {
        ///         _client = client;
        ///     }
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="services">The services collection to which the <see cref="TraktClient" /> is added.</param>
        /// <param name="clientID">The value for the <see cref="TraktClient.ClientID" />.</param>
        /// <param name="clientSecret">The value for the <see cref="TraktClient.ClientSecret" />.</param>
        /// <param name="userAgent">The value for the <see cref="TraktClient.UserAgent" />.</param>
        /// <returns>A <see cref="IHttpClientBuilder" /> instance.</returns>
        /// <remarks>
        /// Each resolved <see cref="TraktClient" /> instance is independent and starts without an authorization, so setting
        /// <see cref="TraktClient.Authorization" /> on one instance doesn't affect the others. To share the authorization,
        /// keep and reuse a single instance.
        /// </remarks>
        public static IHttpClientBuilder AddTraktClient(this IServiceCollection services, string clientID, string clientSecret, string? userAgent = null)
        {
            var context = TraktContext.Create(clientID, clientSecret, userAgent);
            return services.AddTraktHttpClient(context).AddTypedClient(() => TraktContext.Create(clientID, clientSecret, userAgent));
        }

        /// <summary>
        /// Adds an <see cref="HttpClient" /> instance to the <paramref name="services" /> collection.
        /// Also adds an <see cref="TraktClient" /> instance to the <paramref name="services" /> collection, which uses the
        /// added <see cref="HttpClient" /> instance via <see cref="IHttpClientFactory" />.
        /// The added <see cref="TraktClient" /> instance can than be used via dependency injection.
        /// <para />
        /// The added <see cref="TraktClient" /> instance uses the sandbox environment.
        /// <para />
        /// <example>
        /// Adding a Trakt client:
        /// <code>
        /// builder.Services.AddTraktSandboxClient("YourClientID", "YourClientSecret");
        /// </code>
        /// This can than be used with:
        /// <code>
        /// public class ExampleController
        /// {
        ///     private readonly TraktClient _client;
        ///     public ExampleController(TraktClient client)
        ///     {
        ///         _client = client;
        ///     }
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="services">The services collection to which the <see cref="TraktClient" /> is added.</param>
        /// <param name="clientID">The value for the <see cref="TraktClient.ClientID" />.</param>
        /// <param name="clientSecret">The value for the <see cref="TraktClient.ClientSecret" />.</param>
        /// <returns>A <see cref="IHttpClientBuilder" /> instance.</returns>
        /// <remarks>
        /// Each resolved <see cref="TraktClient" /> instance is independent and starts without an authorization, so setting
        /// <see cref="TraktClient.Authorization" /> on one instance doesn't affect the others. To share the authorization,
        /// keep and reuse a single instance.
        /// </remarks>
        public static IHttpClientBuilder AddTraktSandboxClient(this IServiceCollection services, string clientID, string clientSecret)
        {
            var context = TraktContext.CreateForSandbox(clientID, clientSecret, null);
            return services.AddTraktHttpClient(context).AddTypedClient(() => TraktContext.CreateForSandbox(clientID, clientSecret, null));
        }

        private static IHttpClientBuilder AddTraktHttpClient(this IServiceCollection services, TraktContext context)
        {
            Uri baseAuthorizationUri = context.BaseAuthorizationUri;
            Uri baseUri = context.BaseUri;

            services.AddHttpClient($"{context.ID}_auth")
                .ConfigureHttpClient(httpClient => HttpClientProvider.ConfigureHttpClient(httpClient, baseAuthorizationUri));

            return services.AddHttpClient(context.ID)
                .ConfigureHttpClient(httpClient => HttpClientProvider.ConfigureHttpClient(httpClient, baseUri));
        }

        private static IHttpClientBuilder AddTypedClient(this IHttpClientBuilder httpClientBuilder, Func<TraktContext> contextFactory)
        {
            string httpClientName = httpClientBuilder.Name;

            httpClientBuilder.Services.AddTransient(serviceProvider =>
            {
                IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
                TraktContext context = contextFactory();
                context.HttpClientProvider = new HttpClientFactoryProvider(httpClientFactory, httpClientName);
                return new TraktClient(context);
            });

            return httpClientBuilder;
        }
    }
}
