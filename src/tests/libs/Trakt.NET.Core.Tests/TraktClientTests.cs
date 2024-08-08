namespace TraktNET
{
    public class TraktClientTests
    {
        [Fact]
        public void TestTraktClientWithClientIDAndSecret()
        {
            var client = new TraktClient(TestConstants.ClientId, TestConstants.ClientSecret);

            client.ClientID.Should().Be(TestConstants.ClientId);
            client.ClientSecret.Should().Be(TestConstants.ClientSecret);
        }

        [Fact]
        public void TestTraktClientCreate()
        {
            var client = TraktClient.Create(TestConstants.ClientId, TestConstants.ClientSecret);

            client.ClientID.Should().Be(TestConstants.ClientId);
            client.ClientSecret.Should().Be(TestConstants.ClientSecret);
        }

        [Fact]
        public void TestTraktClientCreateForSandbox()
        {
            var client = TraktClient.CreateForSandbox(TestConstants.ClientId, TestConstants.ClientSecret);

            client.ClientID.Should().Be(TestConstants.ClientId);
            client.ClientSecret.Should().Be(TestConstants.ClientSecret);
        }
    }
}
