namespace TraktNET.Json.SmartLists
{
    public sealed class TraktSmartListDraftTests
    {
        [Fact]
        public void TestTraktSmartListDraftConstructor()
        {
            var draft = new TraktSmartListDraft();

            draft.List.ShouldBeNull();
            draft.OriginUrl.ShouldBeNull();
            draft.Source.ShouldBeNull();
            draft.MediaType.ShouldBeNull();
            draft.Filters.ShouldBeNull();
            draft.Unsupported.ShouldBeNull();
            draft.Confidence.ShouldBeNull();
            draft.Converted.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListDraftListConstructor()
        {
            var draftList = new TraktSmartListDraftList();

            draftList.IDs.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListDraftConvertedConstructor()
        {
            var converted = new TraktSmartListDraftConverted();

            converted.SmartListId.ShouldBeNull();
            converted.ConvertedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSmartListDraftFromJson()
        {
            TraktSmartListDraft? draft = await TestUtility.DeserializeJsonAsync<TraktSmartListDraft>("SmartLists\\smartlist_draft.json");

            draft.ShouldNotBeNull();

            draft!.List.ShouldNotBeNull();
            draft!.List!.IDs.ShouldNotBeNull();
            draft!.List!.IDs!.Trakt.ShouldBe(1248149U);
            draft!.List!.IDs!.Slug.ShouldBe("marvel-cinematic-universe");

            draft!.OriginUrl.ShouldBe("https://mdblist.com/lists/trakt/mcu");
            draft!.Source.ShouldBe(TraktSmartListSource.Popular);
            draft!.MediaType.ShouldBe(TraktSmartListMediaType.Movies);

            draft!.Filters.ShouldNotBeNull();
            draft!.Filters!.Genres.ShouldNotBeNull();
            draft!.Filters!.Genres.Length.ShouldBe(2);
            draft!.Filters!.Genres[0].ShouldBe("action");
            draft!.Filters!.Genres[1].ShouldBe("adventure");
            draft!.Filters!.Years.ShouldNotBeNull();
            draft!.Filters!.Years.Length.ShouldBe(2);
            draft!.Filters!.Years![0].ShouldBe(2008U);
            draft!.Filters!.Years![1].ShouldBe(2024U);

            draft!.Unsupported.ShouldNotBeNull();
            draft!.Unsupported.Count.ShouldBe(1);
            draft!.Unsupported[0].ShouldBe("custom_rank");

            draft!.Confidence.ShouldBe(0.95f);

            draft!.Converted.ShouldNotBeNull();
            draft!.Converted!.SmartListId.ShouldBe(99999);
            draft!.Converted!.ConvertedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-10-12T12:00:00.000Z"));
        }
    }
}
