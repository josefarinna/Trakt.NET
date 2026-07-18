using Shouldly;
using Xunit;

namespace TraktNET.Json.Younify
{
    public sealed class TraktYounifyConnectPostTests
    {
        [Fact]
        public void TestTraktYounifyConnectPostDefaultConstructor()
        {
            var post = new TraktYounifyConnectPost();

            post.ServiceId.ShouldBeNull();
            post.ReturnUrl.ShouldBeNull();
        }

        [Fact]
        public void TestTraktYounifyConnectPostValidate()
        {
            var post = new TraktYounifyConnectPost
            {
                ServiceId = "netflix",
                ReturnUrl = "https://trakt.tv/return"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // ServiceId validation
            post.ServiceId = null;
            act.ShouldThrow<ArgumentException>();

            post.ServiceId = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ServiceId = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ServiceId = "netflix";

            // ReturnUrl validation
            post.ReturnUrl = null;
            act.ShouldThrow<ArgumentException>();

            post.ReturnUrl = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ReturnUrl = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ReturnUrl = "https://trakt.tv/return";
            act.ShouldNotThrow();
        }
    }
}
