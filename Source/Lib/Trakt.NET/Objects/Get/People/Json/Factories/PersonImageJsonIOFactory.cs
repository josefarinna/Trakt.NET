namespace TraktNet.Objects.Get.People.Json.Factories
{
    using Objects.Json;
    using TraktNet.Objects.Get.People.Json.Reader;
    using TraktNet.Objects.Get.People.Json.Writer;
    using TraktNet.Objects.Get.People;

    internal class PersonImageJsonIOFactory : IJsonIOFactory<ITraktPersonImage>
    {
        public IObjectJsonReader<ITraktPersonImage> CreateObjectReader() => new PersonImageObjectJsonReader();

        public IObjectJsonWriter<ITraktPersonImage> CreateObjectWriter() => new PersonImageObjectJsonWriter();
    }
}
