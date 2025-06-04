namespace TraktNet.Objects.Get.Seasons.Json.Factories
{
    using Objects.Json;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using TraktNet.Objects.Get.Seasons;

    internal class SeasonImageJsonIOFactory : IJsonIOFactory<ITraktSeasonImage>
    {
        public IObjectJsonReader<ITraktSeasonImage> CreateObjectReader() => new SeasonImageObjectJsonReader();

        public IObjectJsonWriter<ITraktSeasonImage> CreateObjectWriter() => new SeasonImageObjectJsonWriter();
    }
}
