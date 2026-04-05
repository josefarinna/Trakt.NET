namespace TraktNET.Json.Recommendations
{
    public sealed class TraktRecommendedShowTests
    {
        [Fact]
        public void TestTraktRecommendedShowDefaultConstructor()
        {
            var recommendedShow = new TraktRecommendedShow();

            recommendedShow.Title.ShouldBeNullOrEmpty();
            recommendedShow.Year.ShouldBeNull();
            recommendedShow.Airs.ShouldBeNull();
            recommendedShow.AvailableTranslations.ShouldBeNull();
            recommendedShow.IDs.ShouldBeNull();
            recommendedShow.Genres.ShouldBeNull();
            recommendedShow.Overview.ShouldBeNullOrEmpty();
            recommendedShow.FirstAired.ShouldBeNull();
            recommendedShow.Runtime.ShouldBeNull();
            recommendedShow.Certification.ShouldBeNullOrEmpty();
            recommendedShow.Network.ShouldBeNullOrEmpty();
            recommendedShow.Country.ShouldBeNullOrEmpty();
            recommendedShow.UpdatedAt.ShouldBeNull();
            recommendedShow.Trailer.ShouldBeNullOrEmpty();
            recommendedShow.Homepage.ShouldBeNullOrEmpty();
            recommendedShow.Status.ShouldBeNull();
            recommendedShow.Rating.ShouldBeNull();
            recommendedShow.Votes.ShouldBeNull();
            recommendedShow.Language.ShouldBeNullOrEmpty();
            recommendedShow.AiredEpisodes.ShouldBeNull();
            recommendedShow.FavoritedBy.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRecommendedShowFromJson()
        {
            TraktRecommendedShow? recommendedShow = await TestUtility.DeserializeJsonAsync<TraktRecommendedShow>("Recommendations\\recommendedshow.json");

            recommendedShow.ShouldNotBeNull();
            recommendedShow.Title.ShouldBe("Game of Thrones");
            recommendedShow.Year.ShouldBe(2011U);
            recommendedShow.Airs.ShouldNotBeNull();
            recommendedShow.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            recommendedShow.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            recommendedShow.Airs.Time.ShouldBe("21:00");
#endif
            recommendedShow.Airs.Timezone.ShouldBe("America/New_York");
            recommendedShow.AvailableTranslations.ShouldNotBeNull();
            recommendedShow.AvailableTranslations.Count.ShouldBe(4);
            recommendedShow.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            recommendedShow.IDs.ShouldNotBeNull();
            recommendedShow.IDs!.Trakt.ShouldBe(1390U);
            recommendedShow.IDs!.Slug.ShouldBe("game-of-thrones");
            recommendedShow.IDs!.TVDB.ShouldBe(121361U);
            recommendedShow.IDs!.IMDB.ShouldBe("tt0944947");
            recommendedShow.IDs!.TMDB.ShouldBe(1399U);
            recommendedShow.Genres.ShouldNotBeNull();
            recommendedShow.Genres.Count.ShouldBe(5);
            recommendedShow.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            recommendedShow.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");
            recommendedShow.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            recommendedShow.Runtime.ShouldBe(60U);
            recommendedShow.Certification.ShouldBe("TV-MA");
            recommendedShow.Network.ShouldBe("HBO");
            recommendedShow.Country.ShouldBe("us");
            recommendedShow.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            recommendedShow.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            recommendedShow.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            recommendedShow.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            recommendedShow.Rating.ShouldBe(9.38327f);
            recommendedShow.Votes.ShouldBe(44773U);
            recommendedShow.Language.ShouldBe("en");
            recommendedShow.AiredEpisodes.ShouldBe(50U);

            recommendedShow.FavoritedBy.ShouldNotBeNull();
            recommendedShow.FavoritedBy.Count.ShouldBe(1);

            TraktFavoritedBy favoritedBy = recommendedShow.FavoritedBy.First();

            favoritedBy.ShouldNotBeNull();
            favoritedBy.User.ShouldNotBeNull();
            favoritedBy.User.Username.ShouldBe("sean");
            favoritedBy.User.Private.ShouldBe(false);
            favoritedBy.User.Name.ShouldBe("Sean Rudford");
            favoritedBy.User.VIP.ShouldBe(true);
            favoritedBy.User.VIPEP.ShouldBe(true);
            favoritedBy.User.IDs.ShouldNotBeNull();
            favoritedBy.User.IDs.Slug.ShouldBe("sean");
            favoritedBy.User.IDs.UUID.ShouldBe("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            favoritedBy.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            favoritedBy.User.Location.ShouldBe("SF");
            favoritedBy.User.About.ShouldBe("I have all your cassette tapes.");
            favoritedBy.User.Gender.ShouldBe(TraktGender.Male);
            favoritedBy.User.Age.ShouldBe(35U);
            favoritedBy.User.Images.ShouldNotBeNull();
            favoritedBy.User.Images.Avatar.ShouldNotBeNull();
            favoritedBy.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            favoritedBy.User.VIPOG.ShouldBe(true);
            favoritedBy.User.VIPYears.ShouldBe(5U);
            favoritedBy.User.VIPCoverImage.ShouldBe("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            favoritedBy.Notes.ShouldBe("Favorited because ...");
        }
    }
}
