namespace TraktNET.Json.Authentication
{
    public sealed class TraktDeviceTests
    {
        [Fact]
        public void TestTraktDeviceConstructor()
        {
            var device = new TraktDevice();

            device.DeviceCode.Should().BeNull();
            device.UserCode.Should().BeNull();
            device.VerificationUrl.Should().BeNull();
            device.ExpiresIn.Should().BeNull();
            device.ExpiresInSeconds.Should().Be(0U);
            device.Interval.Should().BeNull();
            device.IntervalInMilliseconds.Should().Be(0U);
            device.IntervalInSeconds.Should().Be(0U);
            device.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            device.IsValid.Should().BeFalse();
            device.IsExpiredUnused.Should().BeTrue();
        }

        [Fact]
        public async Task TestTraktDeviceFromJson()
        {
            TraktDevice? device = await TestUtility.DeserializeJsonAsync<TraktDevice>("Authentication\\device.json");

            device.Should().NotBeNull();

            device!.DeviceCode.Should().Be("d9c126a7706328d808914cfd1e40274b6e009f684b1aca271b9b3f90b3630d64");
            device!.UserCode.Should().Be("5055CC52");
            device!.VerificationUrl.Should().Be("https://trakt.tv/activate");
            device!.ExpiresIn.Should().Be(600);
            device!.ExpiresInSeconds.Should().Be(600);
            device!.Interval.Should().Be(5);
            device!.IntervalInMilliseconds.Should().Be(5000);
            device!.IntervalInSeconds.Should().Be(5);
            device!.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            device!.IsValid.Should().BeTrue();
            device!.IsExpiredUnused.Should().BeFalse();
        }

        [Fact]
        public void TestTraktDeviceIsValid()
        {
            var device = new TraktDevice();

            device.IsValid.Should().BeFalse();

            device.DeviceCode = "deviceCode";
            device.IsValid.Should().BeFalse();

            device.UserCode = "userCode";
            device.IsValid.Should().BeFalse();

            device.VerificationUrl = "verificationUrl";
            device.IsValid.Should().BeFalse();

            device.Interval = 1;
            device.IsValid.Should().BeFalse();

            device.ExpiresIn = 600;
            device.IsExpiredUnused.Should().BeFalse();
            device.IsValid.Should().BeTrue();
        }

        [Fact]
        public void TestTraktDeviceIsExpiredUnused()
        {
            var device = new TraktDevice();

            device.IsExpiredUnused.Should().BeTrue();

            device.ExpiresIn = 600;
            device.IsExpiredUnused.Should().BeFalse();
        }

        [Fact]
        public void TestTraktDeviceToString()
        {
            var device = new TraktDevice();

            device.ToString().Should().Be("no valid device code (expired unused)");

            device.DeviceCode = "deviceCode";
            device.UserCode = "userCode";
            device.VerificationUrl = "https://trakt.tv/activate";
            device.Interval = 5;
            device.ToString().Should().Be("no valid device code (expired unused)");

            device.ExpiresIn = 600;
            device.IsExpiredUnused.Should().BeFalse();
            device.ToString().Should().Be($"{device.DeviceCode} (valid until {device.CreatedAt.AddSeconds(device.ExpiresInSeconds)})");
        }
    }
}
