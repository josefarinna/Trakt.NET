using Shouldly;
using Xunit;

namespace TraktNET.Json.Younify
{
    public sealed class TraktYounifyRefreshServicePostTests
    {
        [Fact]
        public void TestTraktYounifyRefreshServicePostDefaultConstructor()
        {
            var post = new TraktYounifyRefreshServicePost();

            post.ServiceID.ShouldBeNull();
            post.SkipSync.ShouldBeNull();
        }

        [Fact]
        public void TestTraktYounifyRefreshServicePostValidate()
        {
            var post = new TraktYounifyRefreshServicePost
            {
                ServiceID = "netflix",
                SkipSync = true
            };

            Action act = () => post.Validate();
            act.ShouldNotThrow();

            post.ServiceID = null;
            act.ShouldThrow<ArgumentException>();

            post.ServiceID = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ServiceID = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ServiceID = "netflix";
            act.ShouldNotThrow();
        }
    }
}
