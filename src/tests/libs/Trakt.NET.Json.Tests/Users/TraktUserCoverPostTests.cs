namespace TraktNET.Json.Users
{
    public sealed class TraktUserCoverPostTests
    {
        [Fact]
        public void TestTraktUserCoverPostConstructor()
        {
            var post = new TraktUserCoverPost { CoverType = TraktCoverType.Movie, CoverId = 123U };
            post.CoverType.ShouldBe(TraktCoverType.Movie);
            post.CoverId.ShouldBe(123U);
        }

        [Fact]
        public void TestTraktUserCoverPostValidate()
        {
            var traktUserCoverPost = new TraktUserCoverPost { CoverType = TraktCoverType.Unspecified, CoverId = 0 };

            Action act = () => traktUserCoverPost.Validate();
            act.ShouldThrow<ArgumentException>();

            traktUserCoverPost.CoverType = TraktCoverType.Movie;
            traktUserCoverPost.CoverId = 0;
            act.ShouldThrow<ArgumentException>();
        }
    }
}
