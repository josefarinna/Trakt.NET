namespace TraktNet.Objects.Get.Tests.Notes.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;

    using TraktNet.Enums;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Get.Notes.Json.Reader;
    using Xunit;

    [Trait("Category", "Objects.Get.Notes.Implementations")]
    public class TraktNoteAttachedTo_Tests
    {
        [Fact]
        public void Test_TraktUserNoteAttachedTo_Default_Constructor()
        {
            var userNoteAttachedTo = new TraktNoteAttachedTo();

            userNoteAttachedTo.Type.Should().BeNull();
            userNoteAttachedTo.Id.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNoteAttachedTo_From_Json()
        {
            var jsonReader = new NoteAttachedToObjectJsonReader();
            var userNoteAttachedTo = await jsonReader.ReadObjectAsync(JSON) as TraktNoteAttachedTo;

            userNoteAttachedTo.Should().NotBeNull();
            userNoteAttachedTo.Type.Should().Be(TraktNotesObjectType.Movie);
            userNoteAttachedTo.Id.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNoteAttachedTo_From_Json_History()
        {
            var jsonReader = new NoteAttachedToObjectJsonReader();
            var userNoteAttachedTo = await jsonReader.ReadObjectAsync(JSON_HISTORY) as TraktNoteAttachedTo;

            userNoteAttachedTo.Should().NotBeNull();
            userNoteAttachedTo.Type.Should().Be(TraktNotesObjectType.History);
            userNoteAttachedTo.Id.Should().Be(5224U);
        }

        private const string JSON =
            @"{
                ""type"": ""movie""
              }";

        private const string JSON_HISTORY =
            @"{
                ""type"": ""history"",
                ""id"": 5224
              }";
    }
}
