namespace TraktNet.Objects.Get.People.Json.Factories
{
    using Objects.Json;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using TraktNet.Objects.Get.People.Json.Writer;

    internal class PersonImageJsonIOFactory : IJsonIOFactory<ITraktPersonImage>
    {
        public IObjectJsonReader<ITraktPersonImage> CreateObjectReader() => new PersonImageObjectJsonReader();

        public IObjectJsonWriter<ITraktPersonImage> CreateObjectWriter() => new PersonImageObjectJsonWriter();
    }
}
