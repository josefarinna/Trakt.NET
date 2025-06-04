namespace TraktNet.Objects.Get.People.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.People;

    internal class PersonImageObjectJsonWriter : AObjectJsonWriter<ITraktPersonImage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonImage obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Headshot != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_HEADSHOT, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Headshot, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Fanart != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FANART, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Fanart, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
