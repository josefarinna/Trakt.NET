namespace TraktNET.Json.Notes
{
    public sealed class TraktNotePostTests
    {
        [Fact]
        public void TestTraktNotePostValidate()
        {
            var notePost = new TraktNotePost();

            // Notes is null
            Action act = () => notePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Notes is empty
            notePost.Notes = string.Empty;
            act.ShouldThrow<TraktPostValidationException>();

            // Notes is set, but no media object attached
            notePost.Notes = "Test note";
            act.ShouldThrow<TraktPostValidationException>();

            // Movie attached
            notePost.Movie = new TraktMovie();
            act.ShouldNotThrow();

            // Show attached
            notePost.Movie = null;
            notePost.Show = new TraktShow();
            act.ShouldNotThrow();

            // Season attached
            notePost.Show = null;
            notePost.Season = new TraktSeason();
            act.ShouldNotThrow();

            // Episode attached
            notePost.Season = null;
            notePost.Episode = new TraktEpisode();
            act.ShouldNotThrow();

            // Person attached
            notePost.Episode = null;
            notePost.Person = new TraktPerson();
            act.ShouldNotThrow();

            // List attached
            notePost.Person = null;
            notePost.List = new TraktList();
            act.ShouldNotThrow();

            // AttachedTo attached
            notePost.List = null;
            notePost.AttachedTo = new TraktNoteAttachedTo();
            act.ShouldNotThrow();

            // IgnoreCompleteValidation flag set
            notePost.AttachedTo = null;
            notePost.IgnoreCompleteValidation = true;
            act.ShouldNotThrow();
        }
    }
}
