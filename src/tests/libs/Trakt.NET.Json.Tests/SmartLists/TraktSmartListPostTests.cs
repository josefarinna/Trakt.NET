using Shouldly;
using Xunit;

namespace TraktNET.Json.SmartLists
{
    public sealed class TraktSmartListPostTests
    {
        [Fact]
        public void TestTraktSmartListPostDefaultConstructor()
        {
            var post = new TraktSmartListPost();

            post.Name.ShouldBeNull();
            post.Source.ShouldBeNull();
            post.MediaType.ShouldBeNull();
            post.Filters.ShouldBeNull();
            post.Privacy.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListPostValidate()
        {
            var post = new TraktSmartListPost
            {
                Name = "My Smart List",
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // Name validation
            post.Name = null;
            act.ShouldThrow<ArgumentException>();

            post.Name = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.Name = "   ";
            act.ShouldThrow<ArgumentException>();

            post.Name = "My Smart List";

            // Source validation
            post.Source = null;
            act.ShouldThrow<TraktPostValidationException>();

            post.Source = TraktSmartListSource.Unspecified;
            act.ShouldThrow<TraktPostValidationException>();

            post.Source = TraktSmartListSource.Popular;

            // MediaType validation
            post.MediaType = null;
            act.ShouldThrow<TraktPostValidationException>();

            post.MediaType = TraktSmartListMediaType.Unspecified;
            act.ShouldThrow<TraktPostValidationException>();

            post.MediaType = TraktSmartListMediaType.Movies;

            // Privacy validation
            post.Privacy = TraktListPrivacy.Unspecified;
            act.ShouldThrow<TraktPostValidationException>();

            post.Privacy = TraktListPrivacy.Private;
            act.ShouldNotThrow();
        }
    }
}
