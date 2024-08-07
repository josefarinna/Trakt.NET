#if NET6_0_OR_GREATER
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

#if NET8_0_OR_GREATER
using System.Collections.Frozen;
#endif

namespace TraktNET
{
    internal static class JsonSerializerContextFactory
    {
        internal static JsonSerializerContext GetContext<TJsonObjectType>()
        {
            if (s_authenticationJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(AuthenticationContextCacheKey));
                return s_jsonSerializerContexts[AuthenticationContextCacheKey];
            }

            if (s_checkinJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(CheckinContextCacheKey));
                return s_jsonSerializerContexts[CheckinContextCacheKey];
            }

            if (s_episodeJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(EpisodesContextCacheKey));
                return s_jsonSerializerContexts[EpisodesContextCacheKey];
            }

            if (s_generalJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(GeneralContextCacheKey));
                return s_jsonSerializerContexts[GeneralContextCacheKey];
            }

            if (s_movieJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(MoviesContextCacheKey));
                return s_jsonSerializerContexts[MoviesContextCacheKey];
            }

            if (s_peopleJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(PeopleContextCacheKey));
                return s_jsonSerializerContexts[PeopleContextCacheKey];
            }

            if (s_seasonsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(SeasonsContextCacheKey));
                return s_jsonSerializerContexts[SeasonsContextCacheKey];
            }

            if (s_showsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(ShowsContextCacheKey));
                return s_jsonSerializerContexts[ShowsContextCacheKey];
            }

            if (s_usersJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(UsersContextCacheKey));
                return s_jsonSerializerContexts[UsersContextCacheKey];
            }

            throw new NotSupportedException($"Json type {nameof(TJsonObjectType)} has no registered json serializer context.");
        }

        private const string AuthenticationContextCacheKey = "authentication";
        private const string CheckinContextCacheKey = "checkin";
        private const string EpisodesContextCacheKey = "episodes";
        private const string GeneralContextCacheKey = "general";
        private const string MoviesContextCacheKey = "movies";
        private const string PeopleContextCacheKey = "people";
        private const string SeasonsContextCacheKey = "seasons";
        private const string ShowsContextCacheKey = "shows";
        private const string UsersContextCacheKey = "users";

        // NOTE: JsonSerializerOptions needs to be copied, because the constructor
        //       of JsonSerializerContext makes JsonSerializerOptions readonly,
        //       which results in InvalidOperationException on multiple calls.
        //       Therefore each JsonSerializerContext gets it's own copied JsonSerializerOptions instance.

#if NET8_0_OR_GREATER
        private static readonly FrozenDictionary<string, JsonSerializerContext> s_jsonSerializerContexts = FrozenDictionary.ToFrozenDictionary(new[]
        {
            new KeyValuePair<string, JsonSerializerContext>(AuthenticationContextCacheKey, new AuthenticationJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(CheckinContextCacheKey, new CheckinJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(EpisodesContextCacheKey, new EpisodesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(GeneralContextCacheKey, new GeneralJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(MoviesContextCacheKey, new MoviesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(PeopleContextCacheKey, new PeopleJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(SeasonsContextCacheKey, new SeasonsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(ShowsContextCacheKey, new ShowsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(UsersContextCacheKey, new UsersJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)))
        }, StringComparer.OrdinalIgnoreCase);

        private static readonly FrozenSet<Type> s_authenticationJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktAuthorization),
            typeof(TraktDevice)
        });

        private static readonly FrozenSet<Type> s_checkinJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktCheckinErrorResponse)
        });

        private static readonly FrozenSet<Type> s_episodeJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktEpisode),
            typeof(TraktEpisodeIds),
            typeof(TraktEpisodeMinimal),
            typeof(TraktEpisodeTranslation)
        });

        private static readonly FrozenSet<Type> s_generalJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktRateLimitInfo)
        });

        private static readonly FrozenSet<Type> s_movieJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktMovie),
            typeof(TraktMovieIds),
            typeof(TraktMovieMinimal),
            typeof(TraktTrendingMovie)
        });

        private static readonly FrozenSet<Type> s_peopleJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktPerson),
            typeof(TraktPersonIds),
            typeof(TraktPersonMinimal),
            typeof(TraktPersonSocialIds)
        });

        private static readonly FrozenSet<Type> s_seasonsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktSeason),
            typeof(TraktSeasonIds),
            typeof(TraktSeasonMinimal)
        });

        private static readonly FrozenSet<Type> s_showsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktShow),
            typeof(TraktShowAirs),
            typeof(TraktShowIds),
            typeof(TraktShowMinimal)
        });

        private static readonly FrozenSet<Type> s_usersJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktUser),
            typeof(TraktUserIds),
            typeof(TraktUserImages),
            typeof(TraktUserImagesAvatar),
            typeof(TraktUserMinimal)
        });
#else
        private static readonly Dictionary<string, JsonSerializerContext> s_jsonSerializerContexts = new()
        {
            { AuthenticationContextCacheKey, new AuthenticationJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { CheckinContextCacheKey, new CheckinJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { EpisodesContextCacheKey, new EpisodesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { GeneralContextCacheKey, new GeneralJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { MoviesContextCacheKey, new MoviesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { PeopleContextCacheKey, new PeopleJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { SeasonsContextCacheKey, new SeasonsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { ShowsContextCacheKey, new ShowsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { UsersContextCacheKey, new UsersJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) }
        };

        private static readonly HashSet<Type> s_authenticationJsonTypes = [
            typeof(TraktAuthorization),
            typeof(TraktDevice)
        ];

        private static readonly HashSet<Type> s_checkinJsonTypes = [
            typeof(TraktCheckinErrorResponse)
        ];

        private static readonly HashSet<Type> s_episodeJsonTypes = [
            typeof(TraktEpisode),
            typeof(TraktEpisodeIds),
            typeof(TraktEpisodeMinimal),
            typeof(TraktEpisodeTranslation)
        ];

        private static readonly HashSet<Type> s_generalJsonTypes = [
            typeof(TraktRateLimitInfo)
        ];

        private static readonly HashSet<Type> s_movieJsonTypes = [
            typeof(TraktMovie),
            typeof(TraktMovieIds),
            typeof(TraktMovieMinimal),
            typeof(TraktTrendingMovie)
        ];

        private static readonly HashSet<Type> s_peopleJsonTypes = [
            typeof(TraktPerson),
            typeof(TraktPersonIds),
            typeof(TraktPersonMinimal),
            typeof(TraktPersonSocialIds)
        ];

        private static readonly HashSet<Type> s_seasonsJsonTypes = [
            typeof(TraktSeason),
            typeof(TraktSeasonIds),
            typeof(TraktSeasonMinimal)
        ];

        private static readonly HashSet<Type> s_showsJsonTypes = [
            typeof(TraktShow),
            typeof(TraktShowAirs),
            typeof(TraktShowIds),
            typeof(TraktShowMinimal)
        ];

        private static readonly HashSet<Type> s_usersJsonTypes = [
            typeof(TraktUser),
            typeof(TraktUserIds),
            typeof(TraktUserImages),
            typeof(TraktUserImagesAvatar),
            typeof(TraktUserMinimal)
        ];
#endif
    }
}
#endif
