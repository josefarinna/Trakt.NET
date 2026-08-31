namespace TraktNET.Json.Authentication
{
    public sealed class TraktDevicePostTests
    {
        [Fact]
        public void TestTraktDevicePostDefaultConstructor()
        {
            var post = new TraktDevicePost();

            post.ClientId.ShouldBeNull();
        }

        [Fact]
        public void TestTraktDevicePostValidate()
        {
            var post = new TraktDevicePost
            {
                ClientId = "clientId"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // ClientId validation
            post.ClientId = null;
            act.ShouldThrow<ArgumentException>();

            post.ClientId = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientId = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientId = "clientId with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientId = "clientId";
            act.ShouldNotThrow();
        }
    }
}

