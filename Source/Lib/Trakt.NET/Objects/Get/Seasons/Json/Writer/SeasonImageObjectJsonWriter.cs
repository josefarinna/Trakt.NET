namespace TraktNet.Objects.Get.Seasons.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Seasons;

    internal class SeasonImageObjectJsonWriter : AObjectJsonWriter<ITraktSeasonImage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSeasonImage obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Poster != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_POSTER, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Poster, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Thumb != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_THUMB, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Thumb, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
