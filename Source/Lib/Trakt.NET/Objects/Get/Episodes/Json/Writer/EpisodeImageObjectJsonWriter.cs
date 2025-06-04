namespace TraktNet.Objects.Get.Episodes.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Episodes;

    internal class EpisodeImageObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeImage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeImage obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Screenshot != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SCREENSHOT, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Screenshot, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
