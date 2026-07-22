namespace TraktNET.Enums
{
    public sealed class TraktUserSyncTypeTests
    {
        [Fact]
        public void TestTraktUserSyncTypeToJson()
        {
            TraktUserSyncType.Unspecified.ToJson().ShouldBeNull();
            TraktUserSyncType.Younify.ToJson().ShouldBe("younify");
            TraktUserSyncType.Plex.ToJson().ShouldBe("plex");
            TraktUserSyncType.Import.ToJson().ShouldBe("import");
        }

        [Fact]
        public void TestTraktUserSyncTypeFromJson()
        {
            "unspecified".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Unspecified);
            "younify".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Younify);
            "plex".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Plex);
            "import".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Import);

            string? nullValue = null;
            nullValue.ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Unspecified);
        }

        [Fact]
        public void TestTraktUserSyncTypeDisplayName()
        {
            TraktUserSyncType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserSyncType.Younify.DisplayName().ShouldBe("Younify");
            TraktUserSyncType.Plex.DisplayName().ShouldBe("Plex");
            TraktUserSyncType.Import.DisplayName().ShouldBe("Import");
        }
    }
}
