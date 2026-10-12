namespace TraktNET.Json.SmartLists
{
    public sealed class TraktSmartListDraftsSummaryTests
    {
        [Fact]
        public void TestTraktSmartListDraftsSummaryConstructor()
        {
            var summary = new TraktSmartListDraftsSummary();

            summary.ConvertibleCount.ShouldBeNull();
            summary.BestConfidence.ShouldBeNull();
            summary.Lists.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListDraftSummaryListConstructor()
        {
            var draftSummaryList = new TraktSmartListDraftSummaryList();

            draftSummaryList.IDs.ShouldBeNull();
            draftSummaryList.Name.ShouldBeNull();
            draftSummaryList.ItemCount.ShouldBeNull();
            draftSummaryList.Confidence.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSmartListDraftsSummaryFromJson()
        {
            TraktSmartListDraftsSummary? summary = await TestUtility.DeserializeJsonAsync<TraktSmartListDraftsSummary>("SmartLists\\smartlist_drafts_summary.json");

            summary.ShouldNotBeNull();

            summary.ConvertibleCount.ShouldBe(2U);
            summary.BestConfidence.ShouldBe(0.95f);

            summary.Lists.ShouldNotBeNull();
            summary.Lists.Count.ShouldBe(2);

            summary.Lists[0].ShouldNotBeNull();
            summary.Lists[0].IDs.ShouldNotBeNull();
            summary.Lists[0].IDs!.Trakt.ShouldBe(1248149U);
            summary.Lists[0].IDs!.Slug.ShouldBe("marvel-cinematic-universe");
            summary.Lists[0].Name.ShouldBe("Marvel Cinematic Universe");
            summary.Lists[0].ItemCount.ShouldBe(33U);
            summary.Lists[0].Confidence.ShouldBe(0.95f);

            summary.Lists[1].ShouldNotBeNull();
            summary.Lists[1].IDs.ShouldNotBeNull();
            summary.Lists[1].IDs!.Trakt.ShouldBe(987654U);
            summary.Lists[1].IDs!.Slug.ShouldBe("dc-extended-universe");
            summary.Lists[1].Name.ShouldBe("DC Extended Universe");
            summary.Lists[1].ItemCount.ShouldBe(15U);
            summary.Lists[1].Confidence.ShouldBe(0.8f);
        }
    }
}
