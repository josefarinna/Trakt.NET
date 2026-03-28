namespace TraktNET.Json.Syncs
{
    public sealed class TraktUpdateListPostTests
    {
        [Fact]
        public void TestTraktUpdateListPostDefaultConstructor()
        {
            var updateListPost = new TraktUpdateListPost();

            updateListPost.Description.ShouldBeNull();
            updateListPost.SortBy.ShouldBeNull();
            updateListPost.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUpdateListPostFromJson()
        {
            TraktUpdateListPost? updateListPost = await TestUtility.DeserializeJsonAsync<TraktUpdateListPost>("Syncs\\Lists\\updatelistpost.json");

            updateListPost.ShouldNotBeNull();
            updateListPost.Description.ShouldBe("Updated description");
            updateListPost.SortBy.ShouldBe(TraktSortBy.Rank);
            updateListPost.SortHow.ShouldBe(TraktSortHow.Descending);
        }

        [Fact]
        public void TestTraktUpdateListPostValidate()
        {
            var updateListPost = new TraktUpdateListPost();

            // description = null, sortBy = null, sortHow = null
            Action act = () => updateListPost.Validate();
            _ = act.ShouldThrow<TraktPostValidationException>();

            // description = empty, sortBy = null, sortHow = null
            updateListPost.Description = string.Empty;
            _ = act.ShouldThrow<TraktPostValidationException>();

            // description = not empty, sortBy = null, sortHow = null
            updateListPost.Description = "description";
            act.ShouldNotThrow();

            // description = null, sortBy = unspecified, sortHow = null
            updateListPost.Description = null;
            updateListPost.SortBy = TraktSortBy.Unspecified;
            _ = act.ShouldThrow<TraktPostValidationException>();

            // description = null, sortBy = has value, sortHow = null
            updateListPost.SortBy = TraktSortBy.Rank;
            act.ShouldNotThrow();

            // description = null, sortBy = null, sortHow = unspecified
            updateListPost.SortBy = null;
            updateListPost.SortHow = TraktSortHow.Unspecified;
            _ = act.ShouldThrow<TraktPostValidationException>();

            // description = null, sortBy = null, sortHow = has value
            updateListPost.SortHow = TraktSortHow.Descending;
            act.ShouldNotThrow();
        }
    }
}
