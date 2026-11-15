using System.Net;

namespace TraktNET.PeopleModule
{
    public sealed class ReportPersonTests
    {
        private static readonly string ReportPersonUri = $"people/{PersonID}/report";
        private const string ReportPersonUriWithSlug = $"people/{PersonSlug}/report";
        private const string PersonSlug = "bryan-cranston";
        private const uint PersonID = 297737U;

        [Fact]
        public async Task TestReportPersonWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonUri, HttpStatusCode.Created);

            TraktResponse response = await client.People.ReportPersonAsync(PersonID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.People.ReportPersonAsync(PersonSlug, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonUriWithSlug, HttpStatusCode.Created);

            var personIDs = new TraktPersonIDs
            {
                Trakt = PersonID,
                Slug = PersonSlug
            };

            TraktResponse response = await client.People.ReportPersonAsync(personIDs, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiPersonNotFoundException))]
        public async Task TestReportPersonThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonUriWithSlug, statusCode);

            Func<Task<TraktResponse>> act = () => client.People.ReportPersonAsync(PersonSlug, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportPersonThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.People.ReportPersonAsync(default(TraktPersonIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.People.ReportPersonAsync(new TraktPersonIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.ReportPersonAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.People.ReportPersonAsync(default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.ReportPersonAsync(string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.People.ReportPersonAsync("person id", TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportPersonThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportPersonUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.People.ReportPersonAsync(PersonSlug, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.People.ReportPersonAsync(PersonSlug, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.People.ReportPersonAsync(PersonSlug, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
