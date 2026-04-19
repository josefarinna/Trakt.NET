using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdatePersonalListTests
    {
        private readonly string UpdatePersonalListUri = $"users/{Username}/lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const string NewListName = "new list name";
        private const string NewDescription = "new list description";
        private const TraktListPrivacy NewPrivacy = TraktListPrivacy.Private;
        private const bool NewDisplayNumbers = false;
        private const bool NewAllowComments = false;

        [Fact]
        public async Task TestUpdatePersonalListWithName()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{TraktListID}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, TraktListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithListIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{TraktListID}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, listIds, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, listIds, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithListIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, listIds, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, list, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescription()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescriptionAndPrivacy()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                Privacy = NewPrivacy
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescriptionAndPrivacyAndDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                Privacy = NewPrivacy,
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescriptionAndPrivacyAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                Privacy = NewPrivacy,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescriptionAndDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescriptionAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithNameAndDescriptionAndDisplayNumbersAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                DisplayNumbers = NewDisplayNumbers,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescription()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescriptionAndPrivacy()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription,
                Privacy = NewPrivacy
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescriptionAndPrivacyAndDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription,
                Privacy = NewPrivacy,
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescriptionAndPrivacyAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription,
                Privacy = NewPrivacy,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescriptionAndDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription,
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescriptionAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDescriptionAndDisplayNumbersAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Description = NewDescription,
                DisplayNumbers = NewDisplayNumbers,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithPrivacy()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Privacy = NewPrivacy
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithPrivacyAndDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Privacy = NewPrivacy,
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithPrivacyAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Privacy = NewPrivacy,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithPrivacyAndDisplayNumbersAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Privacy = NewPrivacy,
                DisplayNumbers = NewDisplayNumbers,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDisplayNumbers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                DisplayNumbers = NewDisplayNumbers
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListWithDisplayNumbersAndAllowComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                DisplayNumbers = NewDisplayNumbers,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var content = new TraktUserPersonalListPost
            {
                Name = NewListName,
                Description = NewDescription,
                Privacy = NewPrivacy,
                DisplayNumbers = NewDisplayNumbers,
                AllowComments = NewAllowComments
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestUpdatePersonalListThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.UpdatePersonalListAsync(Username, ListID, content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListThrowsArgumentExceptions()
        {
            var content = new TraktUserPersonalListPost
            {
                Name = NewListName
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.UpdatePersonalListAsync(Username, default(TraktListIDs)!, content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListAsync(Username, default(TraktList)!, content);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListAsync(Username, new TraktListIDs(), content);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdatePersonalListAsync(Username, 0, content);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
