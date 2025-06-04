namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class ImageArtObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ImageArtObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ImageArtObjectJsonWriter();
            ITraktImageArt traktImage = new TraktImageArt();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktImage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArtObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktImageArt traktImage = new TraktImageArt
            {
                Full = "fullPath"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ImageArtObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"{""full"":""fullPath""}");
            }
        }
    }
}
