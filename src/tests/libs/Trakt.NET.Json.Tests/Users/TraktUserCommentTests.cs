namespace TraktNET.Json.Users
{
    public sealed class TraktUserCommentTests
    {
        [Fact]
        public void TestTraktUserCommentDefaultConstructor()
        {
            var userComment = new TraktUserComment();

            userComment.Type.ShouldBeNull();
            userComment.Comment.ShouldBeNull();
            userComment.Movie.ShouldBeNull();
            userComment.Show.ShouldBeNull();
            userComment.Season.ShouldBeNull();
            userComment.Episode.ShouldBeNull();
            userComment.List.ShouldBeNull();
        }

        [Theory]
        [InlineData("Users\\usercommentmovie.json", TraktCommentObjectType.Movie)]
        [InlineData("Users\\usercommentshow.json", TraktCommentObjectType.Show)]
        [InlineData("Users\\usercommentseason.json", TraktCommentObjectType.Season)]
        [InlineData("Users\\usercommentepisode.json", TraktCommentObjectType.Episode)]
        [InlineData("Users\\usercommentlist.json", TraktCommentObjectType.List)]
        public async Task TestTraktUserCommentFromJson(string jsonFile, TraktCommentObjectType expectedType)
        {
            TraktUserComment? userComment = await TestUtility.DeserializeJsonAsync<TraktUserComment>(jsonFile);

            userComment.ShouldNotBeNull();
            userComment.Type.ShouldBe(expectedType);

            userComment.Comment.ShouldNotBeNull();
            userComment.Comment.ID.ShouldBe(76957U);
            userComment.Comment.Comment.ShouldBe("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            userComment.Comment.User.ShouldNotBeNull();
            userComment.Comment.User.Username.ShouldBe("sean");

            switch (expectedType)
            {
                case TraktCommentObjectType.Movie:
                    userComment.Movie.ShouldNotBeNull();
                    userComment.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
                    break;
                case TraktCommentObjectType.Show:
                    userComment.Show.ShouldNotBeNull();
                    userComment.Show.Title.ShouldBe("Game of Thrones");
                    break;
                case TraktCommentObjectType.Season:
                    userComment.Season.ShouldNotBeNull();
                    userComment.Season.Number.ShouldBe(1U);
                    break;
                case TraktCommentObjectType.Episode:
                    userComment.Episode.ShouldNotBeNull();
                    userComment.Episode.Title.ShouldBe("Winter Is Coming");
                    break;
                case TraktCommentObjectType.List:
                    userComment.List.ShouldNotBeNull();
                    userComment.List.Name.ShouldBe("Star Wars in machete order");
                    break;
            }
        }
    }
}
