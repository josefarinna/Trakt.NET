namespace TraktNet.Objects.Get.Movies.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Movies;

    internal class MovieImageObjectJsonWriter : AObjectJsonWriter<ITraktMovieImage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMovieImage obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Fanart != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FANART, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Fanart, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Poster != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_POSTER, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Poster, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Logo != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LOGO, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Logo, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Clearart != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CLEARART, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Clearart, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Banner != null)
            {
                var imageArrayJsonWriter = new ArrayJsonWriter<string>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_BANNER, cancellationToken).ConfigureAwait(false);
                await imageArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Banner, cancellationToken).ConfigureAwait(false);
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
