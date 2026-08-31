namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationPollPostTests
    {
        [Fact]
        public void TestTraktAuthorizationPollPostDefaultConstructor()
        {
            var post = new TraktAuthorizationPollPost();

            post.Device.ShouldBeNull();
            post.Code.ShouldBeNull();
            post.ClientId.ShouldBeNull();
            post.ClientSecret.ShouldBeNull();
        }

        [Fact]
        public void TestTraktAuthorizationPollPostCodeProperty()
        {
            var post = new TraktAuthorizationPollPost();

            // When Device is null, Code returns the manually set value
            post.Code = "customCode";
            post.Code.ShouldBe("customCode");

            // When Device is set, Code returns Device.DeviceCode
            post.Device = new TraktDevice
            {
                DeviceCode = TestConstants.MockDeviceCode
            };
            post.Code.ShouldBe(TestConstants.MockDeviceCode);

            // When Device is cleared, Code returns the backing field value
            post.Device = null;
            post.Code.ShouldBe("customCode");
        }

        [Fact]
        public void TestTraktAuthorizationPollPostValidateSuccess()
        {
            var post = new TraktAuthorizationPollPost
            {
                Device = new TraktDevice
                {
                    DeviceCode = TestConstants.MockDeviceCode,
                    UserCode = TestConstants.MockUserCode,
                    VerificationUrl = TestConstants.DeviceVerificationURL,
                    ExpiresIn = TestConstants.DeviceExpiresIn,
                    Interval = TestConstants.DeviceInterval
                },
                ClientId = TestConstants.ClientID,
                ClientSecret = TestConstants.ClientSecret
            };

            Action act = () => post.Validate();
            act.ShouldNotThrow();
        }

        [Fact]
        public void TestTraktAuthorizationPollPostValidateThrowsExceptionWhenDeviceIsNull()
        {
            var post = new TraktAuthorizationPollPost
            {
                Device = null!,
                ClientId = TestConstants.ClientID,
                ClientSecret = TestConstants.ClientSecret
            };

            Action act = () => post.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Fact]
        public void TestTraktAuthorizationPollPostValidateThrowsExceptionWhenDeviceIsExpiredUnused()
        {
            var post = new TraktAuthorizationPollPost
            {
                Device = new TraktDevice
                {
                    DeviceCode = TestConstants.MockDeviceCode,
                    UserCode = TestConstants.MockUserCode,
                    VerificationUrl = TestConstants.DeviceVerificationURL,
                    ExpiresIn = 0,
                    Interval = TestConstants.DeviceInterval
                },
                ClientId = TestConstants.ClientID,
                ClientSecret = TestConstants.ClientSecret
            };

            Action act = () => post.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Fact]
        public void TestTraktAuthorizationPollPostValidateThrowsExceptionWhenDeviceIsInvalid()
        {
            var post = new TraktAuthorizationPollPost
            {
                Device = new TraktDevice
                {
                    DeviceCode = "",
                    UserCode = TestConstants.MockUserCode,
                    VerificationUrl = TestConstants.DeviceVerificationURL,
                    ExpiresIn = TestConstants.DeviceExpiresIn,
                    Interval = TestConstants.DeviceInterval
                },
                ClientId = TestConstants.ClientID,
                ClientSecret = TestConstants.ClientSecret
            };

            Action act = () => post.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("client id with spaces")]
        public void TestTraktAuthorizationPollPostValidateThrowsExceptionWhenClientIdIsInvalid(string? clientId)
        {
            var post = new TraktAuthorizationPollPost
            {
                Device = new TraktDevice
                {
                    DeviceCode = TestConstants.MockDeviceCode,
                    UserCode = TestConstants.MockUserCode,
                    VerificationUrl = TestConstants.DeviceVerificationURL,
                    ExpiresIn = TestConstants.DeviceExpiresIn,
                    Interval = TestConstants.DeviceInterval
                },
                ClientId = clientId!,
                ClientSecret = TestConstants.ClientSecret
            };

            Action act = () => post.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("client secret with spaces")]
        public void TestTraktAuthorizationPollPostValidateThrowsExceptionWhenClientSecretIsInvalid(string? clientSecret)
        {
            var post = new TraktAuthorizationPollPost
            {
                Device = new TraktDevice
                {
                    DeviceCode = TestConstants.MockDeviceCode,
                    UserCode = TestConstants.MockUserCode,
                    VerificationUrl = TestConstants.DeviceVerificationURL,
                    ExpiresIn = TestConstants.DeviceExpiresIn,
                    Interval = TestConstants.DeviceInterval
                },
                ClientId = TestConstants.ClientID,
                ClientSecret = clientSecret!
            };

            Action act = () => post.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

