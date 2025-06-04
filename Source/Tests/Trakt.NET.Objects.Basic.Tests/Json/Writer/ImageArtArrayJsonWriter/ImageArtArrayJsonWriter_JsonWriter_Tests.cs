namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class ImageArtArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
            IEnumerable<ITraktImageArt> traktImage = new List<TraktImageArt>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktImage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktImageArt> traktImage = new List<TraktImageArt>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktImageArt> traktImage = new List<ITraktImageArt>
            {
                new TraktImageArt
                {
                    Full = "fullPath 1"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"[{""full"":""fullPath 1""}]");
            }
        }

        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktImageArt> traktImage = new List<ITraktImageArt>
            {
                new TraktImageArt
                {
                    Full = "fullPath 1"
                },
                new TraktImageArt
                {
                    Full = "fullPath 2"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"[{""full"":""fullPath 1""},{""full"":""fullPath 2""}]");
            }
        }
    }
}
