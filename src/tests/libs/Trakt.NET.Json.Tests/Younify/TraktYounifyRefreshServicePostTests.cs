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

            post.ServiceId.ShouldBeNull();
            post.SkipSync.ShouldBeNull();
        }

        [Fact]
        public void TestTraktYounifyRefreshServicePostValidate()
        {
            var post = new TraktYounifyRefreshServicePost
            {
                ServiceId = "netflix",
                SkipSync = true
            };

            Action act = () => post.Validate();
            act.ShouldNotThrow();

            post.ServiceId = null;
            act.ShouldThrow<ArgumentException>();

            post.ServiceId = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ServiceId = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ServiceId = "netflix";
            act.ShouldNotThrow();
        }
    }
}
