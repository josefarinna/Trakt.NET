#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserActivitiesGetRequestTests
    {
        private const string URIPath = "users/123/friends/activities";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestUserActivitiesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new UserActivitiesGetRequest
            {
                Id = "123",
                TypePath = TraktUserSocialActivityType.Friends.AsPathParameter(),
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserActivitiesGetRequestHasValidOAuthRequirement()
        {
            var request = new UserActivitiesGetRequest { Id = default!, TypePath = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserActivitiesGetRequestIsGetRequest()
        {
            var request = new UserActivitiesGetRequest { Id = default!, TypePath = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserActivitiesGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserActivitiesGetRequest { Id = default!, TypePath = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserActivitiesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            var request = new UserActivitiesGetRequest
            {
                Id = "123",
                TypePath = TraktUserSocialActivityType.Friends.AsPathParameter(),
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?query=batman", UriKind.Relative));
        }

        [Fact]
        public void TestUserActivitiesGetRequestValidate()
        {
            var request = new UserActivitiesGetRequest { Id = string.Empty, TypePath = "friends" };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserActivitiesGetRequest { Id = "  ", TypePath = "friends" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserActivitiesGetRequest { Id = "id with spaces", TypePath = "friends" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserActivitiesGetRequest { Id = "123", TypePath = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserActivitiesGetRequest { Id = "123", TypePath = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserActivitiesGetRequest { Id = "123", TypePath = "type with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
