namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
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
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
            IEnumerable<ITraktImageArt> traktImage = new List<TraktImageArt>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktImage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktImageArt> traktImage = new List<TraktImageArt>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktImage);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktImageArt> traktImage = new List<ITraktImageArt>
            {
                new TraktImageArt
                {
                    Full = "fullPath 1"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktImage);
                json.Should().Be(@"[{""full"":""fullPath 1""}]");
            }
        }

        [Fact]
        public async Task Test_ImageArtArrayJsonWriter_WriteArray_StringWriter_Complete()
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
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImageArt>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktImage);
                json.Should().Be(@"[{""full"":""fullPath 1""},{""full"":""fullPath 2""}]");
            }
        }
    }
}
