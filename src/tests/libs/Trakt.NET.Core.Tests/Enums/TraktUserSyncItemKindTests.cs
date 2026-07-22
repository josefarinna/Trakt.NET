namespace TraktNET.Enums
{
    public sealed class TraktUserSyncItemKindTests
    {
        [Fact]
        public void TestTraktUserSyncItemKindToJson()
        {
            TraktUserSyncItemKind.Unspecified.ToJson().ShouldBeNull();
            TraktUserSyncItemKind.History.ToJson().ShouldBe("history");
            TraktUserSyncItemKind.Rating.ToJson().ShouldBe("rating");
        }

        [Fact]
        public void TestTraktUserSyncItemKindFromJson()
        {
            "unspecified".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Unspecified);
            "history".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.History);
            "rating".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Rating);

            string? nullValue = null;
            nullValue.ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Unspecified);
        }

        [Fact]
        public void TestTraktUserSyncItemKindDisplayName()
        {
            TraktUserSyncItemKind.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserSyncItemKind.History.DisplayName().ShouldBe("History");
            TraktUserSyncItemKind.Rating.DisplayName().ShouldBe("Rating");
        }
    }
}
