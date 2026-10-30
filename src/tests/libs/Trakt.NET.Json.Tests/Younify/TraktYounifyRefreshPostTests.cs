using Shouldly;
using Xunit;

namespace TraktNET.Json.Younify
{
    public sealed class TraktYounifyRefreshPostTests
    {
        [Fact]
        public void TestTraktYounifyRefreshPostDefaultConstructor()
        {
            var post = new TraktYounifyRefreshPost();

            post.SkipSync.ShouldBeNull();
        }
    }
}
