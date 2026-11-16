using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class ReportListTests
    {
        private const string ReportListUriWithSlug = $"lists/{ListSlug}/report";
        private const string ReportListUri = $"lists/{ListID}/report";
        private const string ListID = "1248149";
        private const uint TraktListID = 1248149U;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestReportListWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUri, HttpStatusCode.Created);

            TraktResponse response = await client.Lists.ReportListAsync(TraktListID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportListWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Lists.ReportListAsync(ListSlug, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportListWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Lists.ReportListAsync(listIDs, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportListWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Lists.ReportListAsync(list, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestReportListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Lists.ReportListAsync(TraktListID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Lists.ReportListAsync(default(TraktListIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.ReportListAsync(default(TraktList)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.ReportListAsync(new TraktListIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.ReportListAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.ReportListAsync(default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Lists.ReportListAsync(string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportListThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportListUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Lists.ReportListAsync(ListSlug, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Lists.ReportListAsync(ListSlug, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Lists.ReportListAsync(ListSlug, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
