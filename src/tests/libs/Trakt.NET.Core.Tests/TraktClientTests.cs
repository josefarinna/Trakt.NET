namespace TraktNET
{
    public class TraktClientTests
    {
        [Fact]
        public void TestTraktClientWithClientIDAndSecret()
        {
            var client = new TraktClient(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID.Should().Be(TestConstants.ClientID);
            client.ClientSecret.Should().Be(TestConstants.ClientSecret);
        }

        [Fact]
        public void TestTraktClientCreate()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID.Should().Be(TestConstants.ClientID);
            client.ClientSecret.Should().Be(TestConstants.ClientSecret);
        }

        [Fact]
        public void TestTraktClientCreateForSandbox()
        {
            var client = TraktClient.CreateForSandbox(TestConstants.ClientID, TestConstants.ClientSecret);

            client.ClientID.Should().Be(TestConstants.ClientID);
            client.ClientSecret.Should().Be(TestConstants.ClientSecret);
        }
    }
}
