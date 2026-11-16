namespace TraktNET.Json.Users
{
    public sealed class TraktUserCoverPostTests
    {
        [Fact]
        public void TestTraktUserCoverPostConstructor()
        {
            var post = new TraktUserCoverPost { CoverType = TraktCoverType.Movie, CoverID = 123U };
            post.CoverType.ShouldBe(TraktCoverType.Movie);
            post.CoverID.ShouldBe(123U);
        }

        [Fact]
        public void TestTraktUserCoverPostValidate()
        {
            var traktUserCoverPost = new TraktUserCoverPost { CoverType = TraktCoverType.Unspecified, CoverID = 0 };

            Action act = () => traktUserCoverPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            traktUserCoverPost.CoverType = TraktCoverType.Movie;
            traktUserCoverPost.CoverID = 0;
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
