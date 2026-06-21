#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PersonListsGetRequestTests
    {
        private const string URIPath = "people/123/lists";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktListSortOrder.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktListSortOrder.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListSortOrder.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListSortOrder.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktListSortOrder.Popular, null, null, null, $"{URIPath}/popular")]
        [InlineData(TraktListSortOrder.Popular, null, 10, null, $"{URIPath}/popular?page=10")]
        [InlineData(TraktListSortOrder.Popular, null, null, 20, $"{URIPath}/popular?limit=20")]
        [InlineData(TraktListSortOrder.Popular, null, 10, 20, $"{URIPath}/popular?page=10&limit=20")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.None, null, null, $"{URIPath}/popular")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.None, 10, null, $"{URIPath}/popular?page=10")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.None, null, 20, $"{URIPath}/popular?limit=20")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.None, 10, 20, $"{URIPath}/popular?page=10&limit=20")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.Full, null, null, $"{URIPath}/popular?extended=full")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.Full, 10, null, $"{URIPath}/popular?extended=full&page=10")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.Full, null, 20, $"{URIPath}/popular?extended=full&limit=20")]
        [InlineData(TraktListSortOrder.Popular, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/popular?extended=full&page=10&limit=20")]
        public void TestPersonListsGetRequestHasValidURIPath(TraktNET.TraktListSortOrder? sortOrder, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var personListsGetRequest = new PersonListsGetRequest
            {
                Id = "123",
                SortOrder = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            personListsGetRequest.BuildUri();
            personListsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonListsGetRequestHasValidOAuthRequirement()
        {
            var personListsGetRequest = new PersonListsGetRequest { Id = default! };
            personListsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPersonListsGetRequestIsGetRequest()
        {
            var personListsGetRequest = new PersonListsGetRequest { Id = default! };
            personListsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPersonListsGetRequestHasCorrectRequestObjectType()
        {
            var personListsGetRequest = new PersonListsGetRequest { Id = default! };
            personListsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonListsGetRequestValidate()
        {
            var personListsGetRequest = new PersonListsGetRequest { Id = string.Empty };
            Action act = () => personListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personListsGetRequest = new PersonListsGetRequest { Id = "  " };
            act = () => personListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personListsGetRequest = new PersonListsGetRequest { Id = "id with spaces" };
            act = () => personListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
