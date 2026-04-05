#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktPerson))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPerson>))]
    [JsonSerializable(typeof(TraktPersonIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonIDs>))]
    [JsonSerializable(typeof(TraktPersonImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonImages>))]
    [JsonSerializable(typeof(TraktPersonMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonMinimal>))]
    [JsonSerializable(typeof(TraktPersonMovieCredits))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonMovieCredits>))]
    [JsonSerializable(typeof(TraktPersonMovieCreditsCastItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonMovieCreditsCastItem>))]
    [JsonSerializable(typeof(TraktPersonMovieCreditsCrew))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonMovieCreditsCrew>))]
    [JsonSerializable(typeof(TraktPersonMovieCreditsCrewItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonMovieCreditsCrewItem>))]
    [JsonSerializable(typeof(TraktPersonShowCredits))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonShowCredits>))]
    [JsonSerializable(typeof(TraktPersonShowCreditsCastItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonShowCreditsCastItem>))]
    [JsonSerializable(typeof(TraktPersonShowCreditsCrew))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonShowCreditsCrew>))]
    [JsonSerializable(typeof(TraktPersonShowCreditsCrewItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonShowCreditsCrewItem>))]
    [JsonSerializable(typeof(TraktPersonSocialIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonSocialIDs>))]
    [JsonSerializable(typeof(TraktRecentlyUpdatedPerson))]
    [JsonSerializable(typeof(IReadOnlyList<TraktRecentlyUpdatedPerson>))]
    public sealed partial class PeopleJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
