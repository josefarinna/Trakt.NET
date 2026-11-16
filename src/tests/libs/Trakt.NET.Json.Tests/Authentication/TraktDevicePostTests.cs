namespace TraktNET.Json.Authentication
{
    public sealed class TraktDevicePostTests
    {
        [Fact]
        public void TestTraktDevicePostDefaultConstructor()
        {
            var post = new TraktDevicePost();

            post.ClientID.ShouldBeNull();
        }

        [Fact]
        public void TestTraktDevicePostValidate()
        {
            var post = new TraktDevicePost
            {
                ClientID = "clientId"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // ClientID validation
            post.ClientID = null;
            act.ShouldThrow<ArgumentException>();

            post.ClientID = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientID = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientID = "clientId with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientID = "clientId";
            act.ShouldNotThrow();
        }
    }
}

