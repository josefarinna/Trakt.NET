namespace TraktNET.PostRequests.Auth
{
    public sealed class AuthorizationPollRequestBodyTests
    {
        [Fact]
        public void TestAuthorizationPollRequestBodyToJson()
        {
            var body = new AuthorizationPollRequestBody
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

            string json = body.ToJson();

            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain($"\"code\": \"{TestConstants.MockDeviceCode}\"");
            json.ShouldContain($"\"client_id\": \"{TestConstants.ClientID}\"");
            json.ShouldContain($"\"client_secret\": \"{TestConstants.ClientSecret}\"");
        }

        [Fact]
        public void TestAuthorizationPollRequestBodyValidateSuccess()
        {
            var body = new AuthorizationPollRequestBody
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

            Action act = () => body.Validate();
            act.ShouldNotThrow();
        }

        [Fact]
        public void TestAuthorizationPollRequestBodyValidateThrowsExceptionWhenDeviceIsNull()
        {
            var body = new AuthorizationPollRequestBody
            {
                Device = null!,
                ClientId = TestConstants.ClientID,
                ClientSecret = TestConstants.ClientSecret
            };

            Action act = () => body.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Fact]
        public void TestAuthorizationPollRequestBodyValidateThrowsExceptionWhenDeviceIsExpiredUnused()
        {
            var body = new AuthorizationPollRequestBody
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

            Action act = () => body.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Fact]
        public void TestAuthorizationPollRequestBodyValidateThrowsExceptionWhenDeviceIsInvalid()
        {
            var body = new AuthorizationPollRequestBody
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

            Action act = () => body.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestAuthorizationPollRequestBodyValidateThrowsExceptionWhenClientIdIsInvalid(string? clientId)
        {
            var body = new AuthorizationPollRequestBody
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

            Action act = () => body.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestAuthorizationPollRequestBodyValidateThrowsExceptionWhenClientSecretIsInvalid(string? clientSecret)
        {
            var body = new AuthorizationPollRequestBody
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

            Action act = () => body.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
