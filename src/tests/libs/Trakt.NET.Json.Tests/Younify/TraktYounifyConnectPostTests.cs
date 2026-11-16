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

            post.ServiceID.ShouldBeNull();
            post.ReturnUrl.ShouldBeNull();
        }

        [Fact]
        public void TestTraktYounifyConnectPostValidate()
        {
            var post = new TraktYounifyConnectPost
            {
                ServiceID = "netflix",
                ReturnUrl = "https://trakt.tv/return"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // ServiceID validation
            post.ServiceID = null;
            act.ShouldThrow<ArgumentException>();

            post.ServiceID = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ServiceID = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ServiceID = "netflix";

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
