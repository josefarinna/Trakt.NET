namespace TraktNET.Json.Users
{
    public sealed class TraktUserAvatarPostTests
    {
        [Fact]
        public void TestTraktUserAvatarPostConstructor()
        {
            var post = new TraktUserAvatarPost { User = new TraktUserAvatarPostUser { Avatar = "base64" } };
            post.User.ShouldNotBeNull();
            post.User.Avatar.ShouldBe("base64");
        }

        [Fact]
        public void TestTraktUserAvatarPostValidate()
        {
            var traktUserAvatarPost = new TraktUserAvatarPost { User = default! };

            Action act = () => traktUserAvatarPost.Validate();
            act.ShouldThrow<ArgumentException>();

            traktUserAvatarPost.User = new TraktUserAvatarPostUser();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
