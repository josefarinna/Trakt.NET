using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ReportPersonalListTests
    {
        private const string ReportPersonalListUri = $"users/{Username}/lists/{ListID}/report";
        private const string ReportPersonalListUriWithSlug = $"users/{Username}/lists/{ListSlug}/report";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestReportPersonalListWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUri, HttpStatusCode.Created);

            TraktResponse response = await client.Users.ReportPersonalListAsync(Username, TraktListID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonalListWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Users.ReportPersonalListAsync(Username, ListSlug, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonalListWithIDs()
        {
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Users.ReportPersonalListAsync(Username, listIds, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonalListWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Users.ReportPersonalListAsync(Username, list, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestReportPersonalListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.ReportPersonalListAsync(Username, TraktListID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonalListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Users.ReportPersonalListAsync(Username, default(TraktListIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ReportPersonalListAsync(Username, default(TraktList)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ReportPersonalListAsync(Username, new TraktListIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.ReportPersonalListAsync(Username, 0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.ReportPersonalListAsync(Username, default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReportPersonalListAsync(Username, string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReportPersonalListAsync(default(string)!, ListID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReportPersonalListAsync(string.Empty, ListID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportPersonalListThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonalListUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Users.ReportPersonalListAsync(Username, ListSlug, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Users.ReportPersonalListAsync(Username, ListSlug, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Users.ReportPersonalListAsync(Username, ListSlug, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
