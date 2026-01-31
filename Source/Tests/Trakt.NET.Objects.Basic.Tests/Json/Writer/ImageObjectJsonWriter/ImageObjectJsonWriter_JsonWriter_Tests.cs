namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Trait("Category", "Objects.Basic.JsonWriter")]
    public partial class ImageArtObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ImageArtObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ImageObjectJsonWriter();
            ITraktImage traktImage = new TraktImage();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktImage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArtObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktImage traktImage = new TraktImage
            {
                Full = "fullPath"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ImageObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"{""full"":""fullPath""}");
            }
        }
    }
}
