namespace TraktNet.Objects.Get.Episodes.Json.Factories
{
    using Objects.Json;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using TraktNet.Objects.Get.Episodes.Json.Writer;

    internal class EpisodeImageJsonIOFactory : IJsonIOFactory<ITraktEpisodeImage>
    {
        public IObjectJsonReader<ITraktEpisodeImage> CreateObjectReader() => new EpisodeImageObjectJsonReader();

        public IObjectJsonWriter<ITraktEpisodeImage> CreateObjectWriter() => new EpisodeImageObjectJsonWriter();
    }
}
