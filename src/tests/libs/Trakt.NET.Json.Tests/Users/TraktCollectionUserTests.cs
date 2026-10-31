namespace TraktNET.Json.Users
{
    public sealed class TraktCollectionUserTests
    {
        [Fact]
        public void TestTraktCollectionUserConstructor()
        {
            var collectionUser = new TraktCollectionUser();

            collectionUser.User.ShouldBeNull();
            collectionUser.Username.ShouldBeNull();
            collectionUser.Private.ShouldBeNull();
            collectionUser.Deleted.ShouldBeNull();
            collectionUser.IDs.ShouldBeNull();
            collectionUser.Name.ShouldBeNull();
            collectionUser.VIP.ShouldBeNull();
            collectionUser.VIPEP.ShouldBeNull();
            collectionUser.JoinedAt.ShouldBeNull();
            collectionUser.Location.ShouldBeNull();
            collectionUser.About.ShouldBeNull();
            collectionUser.Gender.ShouldBeNull();
            collectionUser.Age.ShouldBeNull();
            collectionUser.Images.ShouldBeNull();
            collectionUser.VIPOG.ShouldBeNull();
            collectionUser.VIPYears.ShouldBeNull();
            collectionUser.VIPCoverImage.ShouldBeNull();
            collectionUser.VIPVeteranSince.ShouldBeNull();
            collectionUser.VIPVeteranYears.ShouldBeNull();
            collectionUser.VIPVeteranTier.ShouldBeNull();
            collectionUser.VIPVeteranTitle.ShouldBeNull();
            collectionUser.VIPGraceEndsAt.ShouldBeNull();
            collectionUser.Email.ShouldBeNull();
        }

        [Fact]
        public void TestTraktCollectionUserPropertiesWithNullUser()
        {
            var collectionUser = new TraktCollectionUser
            {
                Username = "ixxus",
                Private = false,
                Deleted = false,
                IDs = new TraktUserIDs { Slug = "ixxus" },
                Name = "Henrik",
                VIP = true,
                VIPEP = false,
                JoinedAt = TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"),
                Location = "Germany",
                About = "I love movies and shows.",
                Gender = TraktGender.Male,
                Age = 36U,
                Images = new TraktUserImages { Avatar = new TraktUserImagesAvatar { Full = "avatar.png" } },
                VIPOG = false,
                VIPYears = 6U,
                VIPCoverImage = "cover.jpg",
                VIPVeteranSince = TestUtility.ParseUTCDateTime("2020-03-01T00:00:00.000Z"),
                VIPVeteranYears = 5U,
                VIPVeteranTier = 5U,
                VIPVeteranTitle = TraktVipVeteranTitle.Veteran,
                VIPGraceEndsAt = TestUtility.ParseUTCDateTime("2025-04-01T00:00:00.000Z"),
                Email = "henrik@example.com"
            };

            collectionUser.User.ShouldBeNull();
            collectionUser.Username.ShouldBeNull();
            collectionUser.Private.ShouldBeNull();
            collectionUser.Deleted.ShouldBeNull();
            collectionUser.IDs.ShouldBeNull();
            collectionUser.Name.ShouldBeNull();
            collectionUser.VIP.ShouldBeNull();
            collectionUser.VIPEP.ShouldBeNull();
            collectionUser.JoinedAt.ShouldBeNull();
            collectionUser.Location.ShouldBeNull();
            collectionUser.About.ShouldBeNull();
            collectionUser.Gender.ShouldBeNull();
            collectionUser.Age.ShouldBeNull();
            collectionUser.Images.ShouldBeNull();
            collectionUser.VIPOG.ShouldBeNull();
            collectionUser.VIPYears.ShouldBeNull();
            collectionUser.VIPCoverImage.ShouldBeNull();
            collectionUser.VIPVeteranSince.ShouldBeNull();
            collectionUser.VIPVeteranYears.ShouldBeNull();
            collectionUser.VIPVeteranTier.ShouldBeNull();
            collectionUser.VIPVeteranTitle.ShouldBeNull();
            collectionUser.VIPGraceEndsAt.ShouldBeNull();
            collectionUser.Email.ShouldBeNull();
        }

        [Fact]
        public void TestTraktCollectionUserProperties()
        {
            var ids = new TraktUserIDs { Slug = "ixxus", UUID = "jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82" };
            var images = new TraktUserImages { Avatar = new TraktUserImagesAvatar { Full = "avatar.png" } };
            DateTime joinedAt = TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z");
            DateTime veteranSince = TestUtility.ParseUTCDateTime("2020-03-01T00:00:00.000Z");
            DateTime graceEndsAt = TestUtility.ParseUTCDateTime("2025-04-01T00:00:00.000Z");

            var collectionUser = new TraktCollectionUser
            {
                User = new TraktUser()
            };

            collectionUser.Username = "ixxus";
            collectionUser.Private = false;
            collectionUser.Deleted = false;
            collectionUser.IDs = ids;
            collectionUser.Name = "Henrik";
            collectionUser.VIP = true;
            collectionUser.VIPEP = false;
            collectionUser.JoinedAt = joinedAt;
            collectionUser.Location = "Germany";
            collectionUser.About = "I love movies and shows.";
            collectionUser.Gender = TraktGender.Male;
            collectionUser.Age = 36U;
            collectionUser.Images = images;
            collectionUser.VIPOG = false;
            collectionUser.VIPYears = 6U;
            collectionUser.VIPCoverImage = "cover.jpg";
            collectionUser.VIPVeteranSince = veteranSince;
            collectionUser.VIPVeteranYears = 5U;
            collectionUser.VIPVeteranTier = 5U;
            collectionUser.VIPVeteranTitle = TraktVipVeteranTitle.Veteran;
            collectionUser.VIPGraceEndsAt = graceEndsAt;
            collectionUser.Email = "henrik@example.com";

            collectionUser.User.ShouldNotBeNull();
            collectionUser.Username.ShouldBe("ixxus");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Deleted.ShouldBe(false);
            collectionUser.IDs.ShouldBe(ids);
            collectionUser.Name.ShouldBe("Henrik");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(false);
            collectionUser.JoinedAt.ShouldBe(joinedAt);
            collectionUser.Location.ShouldBe("Germany");
            collectionUser.About.ShouldBe("I love movies and shows.");
            collectionUser.Gender.ShouldBe(TraktGender.Male);
            collectionUser.Age.ShouldBe(36U);
            collectionUser.Images.ShouldBe(images);
            collectionUser.VIPOG.ShouldBe(false);
            collectionUser.VIPYears.ShouldBe(6U);
            collectionUser.VIPCoverImage.ShouldBe("cover.jpg");
            collectionUser.VIPVeteranSince.ShouldBe(veteranSince);
            collectionUser.VIPVeteranYears.ShouldBe(5U);
            collectionUser.VIPVeteranTier.ShouldBe(5U);
            collectionUser.VIPVeteranTitle.ShouldBe(TraktVipVeteranTitle.Veteran);
            collectionUser.VIPGraceEndsAt.ShouldBe(graceEndsAt);
            collectionUser.Email.ShouldBe("henrik@example.com");
        }

        [Fact]
        public async Task TestTraktCollectionUserFromJsonMinimal()
        {
            TraktCollectionUser? collectionUser = await TestUtility.DeserializeJsonAsync<TraktCollectionUser>("Users\\collectionuser_minimal.json");

            collectionUser.ShouldNotBeNull();
            collectionUser.User.ShouldNotBeNull();

            collectionUser.Username.ShouldBe("ixxus");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Name.ShouldBe("Henrik");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(false);

            collectionUser.IDs.ShouldNotBeNull();
            collectionUser.IDs.Slug.ShouldBe("ixxus");
            collectionUser.IDs.UUID.ShouldBe("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");
            collectionUser.IDs.HasAnyID.ShouldBe(true);
            collectionUser.IDs.BestID.ShouldBe("ixxus");
        }

        [Fact]
        public async Task TestTraktCollectionUserFromJson()
        {
            TraktCollectionUser? collectionUser = await TestUtility.DeserializeJsonAsync<TraktCollectionUser>("Users\\collectionuser.json");

            collectionUser.ShouldNotBeNull();
            collectionUser.User.ShouldNotBeNull();

            collectionUser.Username.ShouldBe("ixxus");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Deleted.ShouldBe(false);
            collectionUser.Name.ShouldBe("Henrik");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(false);

            collectionUser.IDs.ShouldNotBeNull();
            collectionUser.IDs.Slug.ShouldBe("ixxus");
            collectionUser.IDs.UUID.ShouldBe("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");
            collectionUser.IDs.HasAnyID.ShouldBe(true);
            collectionUser.IDs.BestID.ShouldBe("ixxus");

            collectionUser.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            collectionUser.Location.ShouldBe("Germany");
            collectionUser.About.ShouldBe("I love movies and shows.");
            collectionUser.Gender.ShouldBe(TraktGender.Male);
            collectionUser.Age.ShouldBe(36U);

            collectionUser.Images.ShouldNotBeNull();
            collectionUser.Images.Avatar.ShouldNotBeNull();
            collectionUser.Images.Avatar.Full.ShouldBe("https://walter.trakt.tv/images/users/000/894/246/avatars/large/754b7e3761.png");

            collectionUser.VIPOG.ShouldBe(false);
            collectionUser.VIPYears.ShouldBe(6U);
            collectionUser.VIPCoverImage.ShouldBe("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            collectionUser.VIPVeteranSince.ShouldBe(TestUtility.ParseUTCDateTime("2020-03-01T00:00:00.000Z"));
            collectionUser.VIPVeteranYears.ShouldBe(5U);
            collectionUser.VIPVeteranTier.ShouldBe(5U);
            collectionUser.VIPVeteranTitle.ShouldBe(TraktVipVeteranTitle.Veteran);
            collectionUser.VIPGraceEndsAt.ShouldBe(TestUtility.ParseUTCDateTime("2025-04-01T00:00:00.000Z"));
            collectionUser.Email.ShouldBe("henrik@example.com");
        }

        [Fact]
        public async Task TestTraktCollectionUsersFromJsonMinimal()
        {
            IReadOnlyList<TraktCollectionUser>? collectionUsers = await TestUtility.DeserializeJsonListAsync<TraktCollectionUser>("Users\\collectionusers_minimal.json");

            collectionUsers.ShouldNotBeNull();
            collectionUsers.Count.ShouldBe(2);

            TraktCollectionUser collectionUser = collectionUsers[0];
            collectionUser.ShouldNotBeNull();
            collectionUser.Username.ShouldBe("ixxus");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Name.ShouldBe("Henrik");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(false);
            collectionUser.IDs.ShouldNotBeNull();
            collectionUser.IDs.Slug.ShouldBe("ixxus");

            // --------------------------------------------------------------------------------------------

            collectionUser = collectionUsers[1];
            collectionUser.ShouldNotBeNull();
            collectionUser.Username.ShouldBe("sean");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Name.ShouldBe("Sean Rudford");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(true);
            collectionUser.IDs.ShouldNotBeNull();
            collectionUser.IDs.Slug.ShouldBe("sean");
        }

        [Fact]
        public async Task TestTraktCollectionUsersFromJson()
        {
            IReadOnlyList<TraktCollectionUser>? collectionUsers = await TestUtility.DeserializeJsonListAsync<TraktCollectionUser>("Users\\collectionusers.json");

            collectionUsers.ShouldNotBeNull();
            collectionUsers.Count.ShouldBe(2);

            TraktCollectionUser collectionUser = collectionUsers[0];
            collectionUser.ShouldNotBeNull();
            collectionUser.Username.ShouldBe("ixxus");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Deleted.ShouldBe(false);
            collectionUser.Name.ShouldBe("Henrik");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(false);
            collectionUser.Location.ShouldBe("Germany");
            collectionUser.About.ShouldBe("I love movies and shows.");
            collectionUser.Gender.ShouldBe(TraktGender.Male);
            collectionUser.Age.ShouldBe(36U);
            collectionUser.VIPOG.ShouldBe(false);
            collectionUser.VIPYears.ShouldBe(6U);
            collectionUser.VIPVeteranYears.ShouldBe(5U);
            collectionUser.VIPVeteranTier.ShouldBe(5U);
            collectionUser.VIPVeteranTitle.ShouldBe(TraktVipVeteranTitle.Veteran);
            collectionUser.Email.ShouldBe("henrik@example.com");

            // --------------------------------------------------------------------------------------------

            collectionUser = collectionUsers[1];
            collectionUser.ShouldNotBeNull();
            collectionUser.Username.ShouldBe("sean");
            collectionUser.Private.ShouldBe(false);
            collectionUser.Deleted.ShouldBe(false);
            collectionUser.Name.ShouldBe("Sean Rudford");
            collectionUser.VIP.ShouldBe(true);
            collectionUser.VIPEP.ShouldBe(true);
            collectionUser.Location.ShouldBe("SF");
            collectionUser.About.ShouldBe("I have all your cassette tapes.");
            collectionUser.Gender.ShouldBe(TraktGender.Male);
            collectionUser.Age.ShouldBe(35U);
            collectionUser.VIPOG.ShouldBe(true);
            collectionUser.VIPYears.ShouldBe(14U);
            collectionUser.VIPVeteranYears.ShouldBe(10U);
            collectionUser.VIPVeteranTier.ShouldBe(10U);
            collectionUser.VIPVeteranTitle.ShouldBe(TraktVipVeteranTitle.Legend);
            collectionUser.Email.ShouldBe("sean@example.com");
        }
    }
}
