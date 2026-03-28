namespace TraktNET.Json.General
{
    public sealed class TraktMetadataTests
    {
        [Fact]
        public void TestTraktMetadataDefaultConstructor()
        {
            var traktMetadata = new TraktMetadata();

            traktMetadata.MediaType.ShouldBeNull();
            traktMetadata.Resolution.ShouldBeNull();
            traktMetadata.Audio.ShouldBeNull();
            traktMetadata.AudioChannels.ShouldBeNull();
            traktMetadata.HDR.ShouldBeNull();
            traktMetadata.ThreeDimensional.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMetadataFromJson()
        {
            TraktMetadata? traktMetadata = await TestUtility.DeserializeJsonAsync<TraktMetadata>("General\\metadata.json");

            traktMetadata.ShouldNotBeNull();
            traktMetadata.MediaType.ShouldBe(TraktMediaType.Digital);
            traktMetadata.Resolution.ShouldBe(TraktMediaResolution.HD720p);
            traktMetadata.Audio.ShouldBe(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.ShouldBe(TraktMediaAudioChannel.Channels51);
            traktMetadata.HDR.ShouldBe(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.ShouldBe(true);
        }
    }
}
