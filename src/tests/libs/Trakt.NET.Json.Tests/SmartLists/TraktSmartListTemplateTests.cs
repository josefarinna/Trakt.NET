namespace TraktNET.Json.SmartLists
{
    public sealed class TraktSmartListTemplateTests
    {
        [Fact]
        public void TestTraktSmartListTemplateConstructor()
        {
            var template = new TraktSmartListTemplate();

            template.Id.ShouldBeNull();
            template.Source.ShouldBeNull();
            template.MediaType.ShouldBeNull();
            template.Filters.ShouldBeNull();
            template.Personal.ShouldBeNull();
            template.Total.ShouldBeNull();
            template.Items.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSmartListTemplateFromJson()
        {
            TraktSmartListTemplate? template = await TestUtility.DeserializeJsonAsync<TraktSmartListTemplate>("SmartLists\\smartlist_template.json");

            template.ShouldNotBeNull();
            template.Id.ShouldBe("hidden-gems");
            template.Source.ShouldBe(TraktSmartListSource.Discover);
            template.MediaType.ShouldBe(TraktSmartListMediaType.Movies);
            template.Personal.ShouldBe(false);
            template.Total.ShouldBe(315U);

            template.Filters.ShouldNotBeNull();
            template.Filters.Ratings.ShouldNotBeNull();
            template.Filters.Ratings.Length.ShouldBe(1);
            template.Filters.Ratings[0].ShouldBe(78U);

            template.Filters.Votes.ShouldNotBeNull();
            template.Filters.Votes.Length.ShouldBe(2);
            template.Filters.Votes[0].ShouldBe(300U);
            template.Filters.Votes[1].ShouldBe(3000U);

            template.Filters.Runtimes.ShouldNotBeNull();
            template.Filters.Runtimes.Length.ShouldBe(1);
            template.Filters.Runtimes[0].ShouldBe(80U);

            template.Filters.Metascores.ShouldNotBeNull();
            template.Filters.Metascores.Length.ShouldBe(1);
            template.Filters.Metascores[0].ShouldBe(65U);

            template.Items.ShouldNotBeNull();
            template.Items.Count.ShouldBe(1);

            TraktListItem item = template.Items[0];
            item.ShouldNotBeNull();
            item.Rank.ShouldBe(1U);
            item.Type.ShouldBe(TraktListItemType.Movie);
            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Ne Zha 2");
            item.Movie.Year.ShouldBe(2025);
            item.Movie.IDs.ShouldNotBeNull();
            item.Movie.IDs.Trakt.ShouldBe(787956U);
            item.Movie.IDs.Slug.ShouldBe("ne-zha-2-2025");
        }

        [Fact]
        public async Task TestTraktSmartListTemplatesFromJson()
        {
            IReadOnlyList<TraktSmartListTemplate>? templates = await TestUtility.DeserializeJsonListAsync<TraktSmartListTemplate>("SmartLists\\smartlist_templates.json");

            templates.ShouldNotBeNull();
            templates.Count.ShouldBe(2);

            TraktSmartListTemplate template1 = templates[0];
            template1.ShouldNotBeNull();
            template1.Id.ShouldBe("hidden-gems");
            template1.Source.ShouldBe(TraktSmartListSource.Discover);
            template1.MediaType.ShouldBe(TraktSmartListMediaType.Movies);
            template1.Personal.ShouldBe(false);
            template1.Total.ShouldBe(315U);
            template1.Items.ShouldNotBeNull();
            template1.Items.Count.ShouldBe(1);

            TraktSmartListTemplate template2 = templates[1];
            template2.ShouldNotBeNull();
            template2.Id.ShouldBe("just-landed-services");
            template2.Source.ShouldBe(TraktSmartListSource.Discover);
            template2.MediaType.ShouldBe(TraktSmartListMediaType.Movies);
            template2.Personal.ShouldBe(true);
            template2.Total.ShouldBeNull();
            template2.Items.ShouldNotBeNull();
            template2.Items.Count.ShouldBe(0);

            template2.Filters.ShouldNotBeNull();
            template2.Filters.ReleasedWithinDays.ShouldBe(120U);
            template2.Filters.Watchnow.ShouldNotBeNull();
            template2.Filters.Watchnow.Length.ShouldBe(1);
            template2.Filters.Watchnow[0].ShouldBe("subscriptions");
            template2.Filters.Votes.ShouldNotBeNull();
            template2.Filters.Votes.Length.ShouldBe(1);
            template2.Filters.Votes[0].ShouldBe(200U);
        }

        [Fact]
        public void TestTraktSmartListTemplateToJson()
        {
            var template = new TraktSmartListTemplate
            {
                Id = "hidden-gems",
                Source = TraktSmartListSource.Discover,
                MediaType = TraktSmartListMediaType.Movies,
                Personal = false,
                Total = 315U,
                Filters = new TraktSmartListFilters
                {
                    Ratings = [78U],
                    Votes = [300U, 3000U],
                    Runtimes = [80U],
                    Metascores = [65U]
                },
                Items =
                [
                    new TraktListItem
                    {
                        Rank = 1U,
                        Type = TraktListItemType.Movie,
                        Movie = new TraktMovie
                        {
                            Title = "Ne Zha 2",
                            Year = 2025,
                            IDs = new TraktMovieIDs
                            {
                                Trakt = 787956U,
                                Slug = "ne-zha-2-2025"
                            }
                        }
                    }
                ]
            };

            string json = TestUtility.SerializeObject(template);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"id\":\"hidden-gems\"");
            json.ShouldContain("\"source\":\"discover\"");
            json.ShouldContain("\"media_type\":\"movies\"");
            json.ShouldContain("\"personal\":false");
            json.ShouldContain("\"total\":315");
            json.ShouldContain("\"ratings\":[78]");
            json.ShouldContain("\"title\":\"Ne Zha 2\"");
        }
    }
}
