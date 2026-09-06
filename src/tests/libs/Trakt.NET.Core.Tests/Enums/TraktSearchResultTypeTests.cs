using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSearchResultTypeTests
    {
        [Fact]
        public void TestTraktSearchResultTypeToJson()
        {
            TraktSearchResultType.Unspecified.ToJson().ShouldBeNull();
            TraktSearchResultType.Movie.ToJson().ShouldBe("movie");
            TraktSearchResultType.Show.ToJson().ShouldBe("show");
            TraktSearchResultType.Episode.ToJson().ShouldBe("episode");
            TraktSearchResultType.Person.ToJson().ShouldBe("person");
            TraktSearchResultType.List.ToJson().ShouldBe("list");
            ((TraktSearchResultType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSearchResultTypeFromJson()
        {
            "unspecified".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Unspecified);
            "movie".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Movie);
            "show".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Show);
            "episode".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Episode);
            "person".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Person);
            "list".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.List);

            string? nullValue = null;
            nullValue.ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Unspecified);
            "invalid".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Unspecified);
            "".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchResultTypeToURI()
        {
            TraktSearchResultType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktSearchResultType.Movie.ToURI().ShouldBe("movie");
            TraktSearchResultType.Show.ToURI().ShouldBe("show");
            TraktSearchResultType.Episode.ToURI().ShouldBe("episode");
            TraktSearchResultType.Person.ToURI().ShouldBe("person");
            TraktSearchResultType.List.ToURI().ShouldBe("list");
        }

        [Fact]
        public void TestTraktSearchResultTypeDisplayName()
        {
            TraktSearchResultType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchResultType.Movie.DisplayName().ShouldBe("Movie");
            TraktSearchResultType.Show.DisplayName().ShouldBe("Show");
            TraktSearchResultType.Episode.DisplayName().ShouldBe("Episode");
            TraktSearchResultType.Person.DisplayName().ShouldBe("Person");
            TraktSearchResultType.List.DisplayName().ShouldBe("List");
        }

        [Fact]
        public void TestTraktSearchResultTypeAsQuery()
        {
            TraktSearchResultType.Unspecified.AsQuery().ShouldBe(string.Empty);
            TraktSearchResultType.Movie.AsQuery().ShouldBe("type=movie");
            TraktSearchResultType.Show.AsQuery().ShouldBe("type=show");
            TraktSearchResultType.Episode.AsQuery().ShouldBe("type=episode");
            TraktSearchResultType.Person.AsQuery().ShouldBe("type=person");
            TraktSearchResultType.List.AsQuery().ShouldBe("type=list");

            TraktSearchResultType movieAndShow = TraktSearchResultType.Movie | TraktSearchResultType.Show;
            movieAndShow.AsQuery().ShouldBe("type=movie,show");

            TraktSearchResultType multiple = TraktSearchResultType.Episode | TraktSearchResultType.Person | TraktSearchResultType.List;
            multiple.AsQuery().ShouldBe("type=episode,person,list");
        }

        [Fact]
        public void TestTraktSearchResultTypeAsPathParameter()
        {
            TraktSearchResultType.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktSearchResultType.Movie.AsPathParameter().ShouldBe("movie");
            TraktSearchResultType.Show.AsPathParameter().ShouldBe("show");
            TraktSearchResultType.Episode.AsPathParameter().ShouldBe("episode");
            TraktSearchResultType.Person.AsPathParameter().ShouldBe("person");
            TraktSearchResultType.List.AsPathParameter().ShouldBe("list");

            TraktSearchResultType movieAndShow = TraktSearchResultType.Movie | TraktSearchResultType.Show;
            movieAndShow.AsPathParameter().ShouldBe("movie,show");

            TraktSearchResultType multiple = TraktSearchResultType.Episode | TraktSearchResultType.Person | TraktSearchResultType.List;
            multiple.AsPathParameter().ShouldBe("episode,person,list");
        }

        [Fact]
        public void TestTraktSearchResultTypeJsonConverter()
        {
            var converter = new TraktSearchResultTypeJsonConverter();
            converter.CanConvert(typeof(TraktSearchResultType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSearchResultType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktSearchResultType>("\"movie\"", options).ShouldBe(TraktSearchResultType.Movie);
            JsonSerializer.Deserialize<TraktSearchResultType>("\"\"", options).ShouldBe(TraktSearchResultType.Unspecified);
        }
    }
}
