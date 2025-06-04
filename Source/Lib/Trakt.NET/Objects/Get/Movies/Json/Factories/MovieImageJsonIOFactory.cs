namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using TraktNet.Objects.Get.Movies.Json.Writer;

    internal class MovieImageJsonIOFactory : IJsonIOFactory<ITraktMovieImage>
    {
        public IObjectJsonReader<ITraktMovieImage> CreateObjectReader() => new MovieImageObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieImage> CreateObjectWriter() => new MovieImageObjectJsonWriter();
    }
}
