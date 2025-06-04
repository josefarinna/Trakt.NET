namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using TraktNet.Objects.Get.Shows.Json.Writer;

    internal class ShowImageJsonIOFactory : IJsonIOFactory<ITraktShowImage>
    {
        public IObjectJsonReader<ITraktShowImage> CreateObjectReader() => new ShowImageObjectJsonReader();

        public IObjectJsonWriter<ITraktShowImage> CreateObjectWriter() => new ShowImageObjectJsonWriter();
    }
}
