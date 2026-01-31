namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;

    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Trait("Category", "Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SearchResultObjectJsonReader();
            Func<Task<ITraktSearchResult>> traktSearchResultItem = () => jsonReader.ReadObjectAsync(default(string));
            await traktSearchResultItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktSearchResultItem.Should().BeNull();
        }
    }
}
