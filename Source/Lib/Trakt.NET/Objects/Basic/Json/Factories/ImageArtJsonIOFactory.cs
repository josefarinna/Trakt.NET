namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class ImageArtJsonIOFactory : IJsonIOFactory<ITraktImageArt>
    {
        public IObjectJsonReader<ITraktImageArt> CreateObjectReader() => new ImageArtObjectJsonReader();

        public IObjectJsonWriter<ITraktImageArt> CreateObjectWriter() => new ImageArtObjectJsonWriter();
    }
}
