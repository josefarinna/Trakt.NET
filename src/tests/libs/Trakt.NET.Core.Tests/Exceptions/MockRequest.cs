#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET
{
    internal sealed class MockRequest(HttpMethod method, Uri? requestUri, string objectId, uint seasonNumber, uint episodeNumber)
        : RequestBase(method, requestUri)
    {
        internal override TraktOAuthRequirement OAuthRequirement => throw new NotImplementedException();

        internal override string ObjectId => objectId;

        internal override uint SeasonNr => seasonNumber;

        internal override uint EpisodeNr => episodeNumber;

        internal override void BuildUri() => throw new NotImplementedException();
    }
}
