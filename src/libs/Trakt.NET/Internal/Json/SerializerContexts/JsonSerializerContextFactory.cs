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

            if (s_calendarssJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(CalendarsContextCacheKey));
                return s_jsonSerializerContexts[CalendarsContextCacheKey];
            }

            if (s_certificationsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(CertificationsContextCacheKey));
                return s_jsonSerializerContexts[CertificationsContextCacheKey];
            }

            if (s_checkinJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(CheckinContextCacheKey));
                return s_jsonSerializerContexts[CheckinContextCacheKey];
            }

            if (s_commentsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(CommentsContextCacheKey));
                return s_jsonSerializerContexts[CommentsContextCacheKey];
            }

            if (s_countriesJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(CountriesContextCacheKey));
                return s_jsonSerializerContexts[CountriesContextCacheKey];
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

            if (s_genresJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(GenresContextCacheKey));
                return s_jsonSerializerContexts[GenresContextCacheKey];
            }

            if (s_historyJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(HistoryContextCacheKey));
                return s_jsonSerializerContexts[HistoryContextCacheKey];
            }

            if (s_languagesJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(LanguagesContextCacheKey));
                return s_jsonSerializerContexts[LanguagesContextCacheKey];
            }

            if (s_listsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(ListsContextCacheKey));
                return s_jsonSerializerContexts[ListsContextCacheKey];
            }

            if (s_mediaJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(MediaContextCacheKey));
                return s_jsonSerializerContexts[MediaContextCacheKey];
            }

            if (s_movieJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(MoviesContextCacheKey));
                return s_jsonSerializerContexts[MoviesContextCacheKey];
            }

            if (s_networksJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(NetworksContextCacheKey));
                return s_jsonSerializerContexts[NetworksContextCacheKey];
            }

            if (s_notesJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(NotesContextCacheKey));
                return s_jsonSerializerContexts[NotesContextCacheKey];
            }

            if (s_peopleJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(PeopleContextCacheKey));
                return s_jsonSerializerContexts[PeopleContextCacheKey];
            }

            if (s_ratingsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(RatingsContextCacheKey));
                return s_jsonSerializerContexts[RatingsContextCacheKey];
            }

            if (s_recommendationsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(RecommendationsContextCacheKey));
                return s_jsonSerializerContexts[RecommendationsContextCacheKey];
            }

            if (s_responsesJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(ResponsesContextCacheKey));
                return s_jsonSerializerContexts[ResponsesContextCacheKey];
            }

            if (s_scrobblesJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(ScrobllesContextCacheKey));
                return s_jsonSerializerContexts[ScrobllesContextCacheKey];
            }

            if (s_searchsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(SearchsContextCacheKey));
                return s_jsonSerializerContexts[SearchsContextCacheKey];
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

            if (s_smartListsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(SmartListsContextCacheKey));
                return s_jsonSerializerContexts[SmartListsContextCacheKey];
            }

            if (s_socialrecommendationsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(SocialRecommendationsContextCacheKey));
                return s_jsonSerializerContexts[SocialRecommendationsContextCacheKey];
            }

            if (s_syncsJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(SyncsContextCacheKey));
                return s_jsonSerializerContexts[SyncsContextCacheKey];
            }

            if (s_teamJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(TeamContextCacheKey));
                return s_jsonSerializerContexts[TeamContextCacheKey];
            }

            if (s_usersJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(UsersContextCacheKey));
                return s_jsonSerializerContexts[UsersContextCacheKey];
            }

            if (s_watchedJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(WatchedContextCacheKey));
                return s_jsonSerializerContexts[WatchedContextCacheKey];
            }

            if (s_watchlistJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(WatchlistContextCacheKey));
                return s_jsonSerializerContexts[WatchlistContextCacheKey];
            }

            if (s_watchnowJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(WatchnowContextCacheKey));
                return s_jsonSerializerContexts[WatchnowContextCacheKey];
            }

            if (s_younifyJsonTypes.Contains(typeof(TJsonObjectType)))
            {
                Debug.Assert(s_jsonSerializerContexts.ContainsKey(YounifyContextCacheKey));
                return s_jsonSerializerContexts[YounifyContextCacheKey];
            }

            throw new NotSupportedException($"Json type {nameof(TJsonObjectType)} has no registered json serializer context.");
        }

        private const string AuthenticationContextCacheKey = "authentication";
        private const string CalendarsContextCacheKey = "calendars";
        private const string CertificationsContextCacheKey = "certifications";
        private const string CheckinContextCacheKey = "checkin";
        private const string CommentsContextCacheKey = "comments";
        private const string CountriesContextCacheKey = "countries";
        private const string EpisodesContextCacheKey = "episodes";
        private const string GeneralContextCacheKey = "general";
        private const string GenresContextCacheKey = "genres";
        private const string HistoryContextCacheKey = "history";
        private const string LanguagesContextCacheKey = "languages";
        private const string ListsContextCacheKey = "lists";
        private const string MediaContextCacheKey = "media";
        private const string MoviesContextCacheKey = "movies";
        private const string NetworksContextCacheKey = "networks";
        private const string NotesContextCacheKey = "notes";
        private const string PeopleContextCacheKey = "people";
        private const string RatingsContextCacheKey = "ratings";
        private const string RecommendationsContextCacheKey = "recommendations";
        private const string ResponsesContextCacheKey = "responses";
        private const string ScrobllesContextCacheKey = "scrobbles";
        private const string SearchsContextCacheKey = "searchs";
        private const string SeasonsContextCacheKey = "seasons";
        private const string ShowsContextCacheKey = "shows";
        private const string SmartListsContextCacheKey = "smartlists";
        private const string SocialRecommendationsContextCacheKey = "socialrecommendations";
        private const string SyncsContextCacheKey = "syncs";
        private const string TeamContextCacheKey = "team";
        private const string UsersContextCacheKey = "users";
        private const string WatchedContextCacheKey = "watched";
        private const string WatchlistContextCacheKey = "watchlist";
        private const string WatchnowContextCacheKey = "watchnow";
        private const string YounifyContextCacheKey = "younify";

        // NOTE: JsonSerializerOptions needs to be copied, because the constructor
        //       of JsonSerializerContext makes JsonSerializerOptions readonly,
        //       which results in InvalidOperationException on multiple calls.
        //       Therefore each JsonSerializerContext gets it's own copied JsonSerializerOptions instance.

#if NET8_0_OR_GREATER
        private static readonly FrozenDictionary<string, JsonSerializerContext> s_jsonSerializerContexts = FrozenDictionary.ToFrozenDictionary(new[]
        {
            new KeyValuePair<string, JsonSerializerContext>(AuthenticationContextCacheKey, new AuthenticationJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(CalendarsContextCacheKey, new CalendarsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(CertificationsContextCacheKey, new CertificationsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(CheckinContextCacheKey, new CheckinJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(CommentsContextCacheKey, new CommentsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(CountriesContextCacheKey, new CountriesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(EpisodesContextCacheKey, new EpisodesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(GeneralContextCacheKey, new GeneralJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(GenresContextCacheKey, new GenresJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(HistoryContextCacheKey, new HistoryJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(LanguagesContextCacheKey, new LanguagesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(ListsContextCacheKey, new ListsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(MediaContextCacheKey, new MediaJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(MoviesContextCacheKey, new MoviesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(NetworksContextCacheKey, new NetworksJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(NotesContextCacheKey, new NotesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(PeopleContextCacheKey, new PeopleJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(RatingsContextCacheKey, new RatingsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(RecommendationsContextCacheKey, new RecommendationsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(ResponsesContextCacheKey, new ResponsesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(ScrobllesContextCacheKey, new ScrobblesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(SearchsContextCacheKey, new SearchsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(SeasonsContextCacheKey, new SeasonsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(ShowsContextCacheKey, new ShowsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(SmartListsContextCacheKey, new SmartListsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(SocialRecommendationsContextCacheKey, new SocialRecommendationsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(SyncsContextCacheKey, new SyncsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(TeamContextCacheKey, new TeamJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(UsersContextCacheKey, new UsersJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(WatchedContextCacheKey, new WatchedJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(WatchlistContextCacheKey, new WatchlistJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(WatchnowContextCacheKey, new WatchnowJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions))),
            new KeyValuePair<string, JsonSerializerContext>(YounifyContextCacheKey, new YounifyJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)))
        }, StringComparer.OrdinalIgnoreCase);

        private static readonly FrozenSet<Type> s_authenticationJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktAuthorization),
            typeof(TraktAuthorizationPollPost),
            typeof(TraktAuthorizationPost),
            typeof(TraktAuthorizationRefreshPost),
            typeof(TraktAuthorizationRevokePost),
            typeof(TraktDevice),
            typeof(TraktDevicePost)
        });

        private static readonly FrozenSet<Type> s_calendarssJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktCalendarShow),
            typeof(TraktCalendarMovie),
            typeof(TraktCalendarMedia)
        });

        private static readonly FrozenSet<Type> s_certificationsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktCertification),
            typeof(TraktCertifications)
        });

        private static readonly FrozenSet<Type> s_checkinJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktCheckinErrorResponse),
            typeof(TraktEpisodeCheckin),
            typeof(TraktEpisodeCheckinResponse),
            typeof(TraktMovieCheckin),
            typeof(TraktMovieCheckinResponse)
        });

        private static readonly FrozenSet<Type> s_commentsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktComment),
            typeof(TraktCommentItem),
            typeof(TraktCommentLike),
            typeof(TraktCommentPost),
            typeof(TraktCommentPostResponse),
            typeof(TraktCommentReplyPost),
            typeof(TraktCommentUpdatePost),
            typeof(TraktCommentUserStats),
            typeof(TraktEpisodeCommentPost),
            typeof(TraktListCommentPost),
            typeof(TraktMovieCommentPost),
            typeof(TraktSeasonCommentPost),
            typeof(TraktShowCommentPost),
            typeof(TraktCommentReaction),
            typeof(TraktCommentUserReaction),
            typeof(TraktCommentReactionSummary)
        });

        private static readonly FrozenSet<Type> s_countriesJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktCountry)
        });

        private static readonly FrozenSet<Type> s_episodeJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktEpisode),
            typeof(TraktEpisodeCollectionProgress),
            typeof(TraktEpisodeIDs),
            typeof(TraktEpisodeImages),
            typeof(TraktEpisodeMinimal),
            typeof(TraktEpisodeProgress),
            typeof(TraktEpisodeStatistics),
            typeof(TraktEpisodeStats),
            typeof(TraktEpisodeTranslation),
            typeof(TraktEpisodeWatchedProgress)
        });

        private static readonly FrozenSet<Type> s_generalJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(uint),
            typeof(TraktCastAndCrew),
            typeof(TraktCastMember),
            typeof(TraktColors),
            typeof(TraktCrew),
            typeof(TraktCrewMember),
            typeof(TraktMetadata),
            typeof(TraktRateLimitInfo),
            typeof(TraktRating),
            typeof(TraktRatingItem),
            typeof(TraktMetascoreRatingItem),
            typeof(TraktRottenTomatoesRatingItem),
            typeof(TraktSentimentItem),
            typeof(TraktSentiments),
            typeof(TraktStudio),
            typeof(TraktStudioIDs),
            typeof(TraktVideo),
            typeof(TraktReportPost)
        });

        private static readonly FrozenSet<Type> s_genresJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktGenre),
            typeof(TraktSubgenre)
        });

        private static readonly FrozenSet<Type> s_historyJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktHistoryItem)
        });

        private static readonly FrozenSet<Type> s_languagesJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktLanguage)
        });

        private static readonly FrozenSet<Type> s_listsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktList),
            typeof(TraktListIDs),
            typeof(TraktListImages),
            typeof(TraktListItem),
            typeof(TraktListItemsReorderPost),
            typeof(TraktListItemsReorderPostResponse),
            typeof(TraktListItemUpdatePost),
            typeof(TraktListLike),
            typeof(TraktPopularList),
            typeof(TraktTrendingList),
            typeof(TraktTrendingOrPopularList)
        });

        private static readonly FrozenSet<Type> s_mediaJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktTrendingMedia),
            typeof(TraktAnticipatedMedia),
            typeof(TraktPopularMedia)
        });

        private static readonly FrozenSet<Type> s_movieJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktBoxOfficeMovie),
            typeof(TraktCollectionMovie),
            typeof(TraktHotMovie),
            typeof(TraktMostAnticipatedMovie),
            typeof(TraktMostCollectedMovie),
            typeof(TraktMostFavoritedMovie),
            typeof(TraktMostPlayedMovie),
            typeof(TraktMostPWCMovie),
            typeof(TraktMostWatchedMovie),
            typeof(TraktMovie),
            typeof(TraktMovieAlias),
            typeof(TraktMovieIDs),
            typeof(TraktMovieImages),
            typeof(TraktMovieMinimal),
            typeof(TraktMovieRelease),
            typeof(TraktMovieSocialIDs),
            typeof(TraktMovieStatistics),
            typeof(TraktMovieTranslation),
            typeof(TraktStreamingMovie),
            typeof(TraktTrendingMovie),
            typeof(TraktUpdatedMovie)
        });

        private static readonly FrozenSet<Type> s_networksJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktNetwork),
            typeof(TraktNetworkIDs)
        });

        private static readonly FrozenSet<Type> s_notesJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktNote),
            typeof(TraktNoteAttachedTo),
            typeof(TraktNoteItem),
            typeof(TraktNotePost)
        });

        private static readonly FrozenSet<Type> s_peopleJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktPerson),
            typeof(TraktPersonIDs),
            typeof(TraktPersonImages),
            typeof(TraktPersonMinimal),
            typeof(TraktPersonMovieCredits),
            typeof(TraktPersonMovieCreditsCastItem),
            typeof(TraktPersonMovieCreditsCrew),
            typeof(TraktPersonMovieCreditsCrewItem),
            typeof(TraktPersonShowCredits),
            typeof(TraktPersonShowCreditsCastItem),
            typeof(TraktPersonShowCreditsCrew),
            typeof(TraktPersonShowCreditsCrewItem),
            typeof(TraktPersonSocialIDs),
            typeof(TraktRecentlyUpdatedPerson)
        });

        private static readonly FrozenSet<Type> s_ratingsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktRatingsItem)
        });

        private static readonly FrozenSet<Type> s_recommendationsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktFavoritedBy),
            typeof(TraktRecommendedMovie),
            typeof(TraktRecommendedShow)
        });

        private static readonly FrozenSet<Type> s_responsesJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktPostResponseListData),
            typeof(TraktPostResponseNotFoundEpisode),
            typeof(TraktPostResponseNotFoundMovie),
            typeof(TraktPostResponseNotFoundPerson),
            typeof(TraktPostResponseNotFoundSeason),
            typeof(TraktPostResponseNotFoundShow),
            typeof(TraktPostResponseNotFoundUser)
        });

        private static readonly FrozenSet<Type> s_scrobblesJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktEpisodeScrobblePost),
            typeof(TraktEpisodeScrobblePostResponse),
            typeof(TraktMovieScrobblePost),
            typeof(TraktMovieScrobblePostResponse),
            typeof(TraktScrobblePost),
            typeof(TraktScrobblePostResponse)
        });

        private static readonly FrozenSet<Type> s_searchsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktSearchResult),
            typeof(TraktSearchRecentPost),
            typeof(TraktTrendingSearchResult)
        });

        private static readonly FrozenSet<Type> s_seasonsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktSeason),
            typeof(TraktSeasonCollectionProgress),
            typeof(TraktSeasonIDs),
            typeof(TraktSeasonImages),
            typeof(TraktSeasonMinimal),
            typeof(TraktSeasonProgress),
            typeof(TraktSeasonStatistics),
            typeof(TraktSeasonStats),
            typeof(TraktSeasonTranslation),
            typeof(TraktSeasonWatchedProgress)
        });

        private static readonly FrozenSet<Type> s_showsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktCollectionShow),
            typeof(TraktHotShow),
            typeof(TraktMostAnticipatedShow),
            typeof(TraktMostCollectedShow),
            typeof(TraktMostFavoritedShow),
            typeof(TraktMostPlayedShow),
            typeof(TraktMostPWCShow),
            typeof(TraktMostWatchedShow),
            typeof(TraktShow),
            typeof(TraktShowAirs),
            typeof(TraktShowAlias),
            typeof(TraktShowCertification),
            typeof(TraktShowCollectionProgress),
            typeof(TraktShowIDs),
            typeof(TraktShowImages),
            typeof(TraktShowMinimal),
            typeof(TraktShowProgress),
            typeof(TraktShowResetWatchedProgress),
            typeof(TraktShowSocialIDs),
            typeof(TraktShowStatistics),
            typeof(TraktShowStats),
            typeof(TraktShowTranslation),
            typeof(TraktShowWatchedProgress),
            typeof(TraktStreamingShow),
            typeof(TraktTrendingShow),
            typeof(TraktUpdatedShow)
        });

        private static readonly FrozenSet<Type> s_smartListsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktSmartList),
            typeof(TraktSmartListImages),
            typeof(TraktSmartListFilters),
            typeof(TraktSmartListPost),
            typeof(TraktSmartListPostResponse)
        });

        private static readonly FrozenSet<Type> s_socialrecommendationsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktSocialMovieRecommendation),
            typeof(TraktSocialShowRecommendation)
        });

        private static readonly FrozenSet<Type> s_syncsJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktSyncAccountLastActivities),
            typeof(TraktSyncCollaborationsLastActivities),
            typeof(TraktSyncCommentsLastActivities),
            typeof(TraktSyncEpisodesLastActivities),
            typeof(TraktSyncFavoritesLastActivities),
            typeof(TraktSyncLastActivities),
            typeof(TraktSyncListsLastActivities),
            typeof(TraktSyncMoviesLastActivities),
            typeof(TraktSyncNotesLastActivities),
            typeof(TraktSyncRecommendationsLastActivities),
            typeof(TraktSyncSavedFiltersLastActivities),
            typeof(TraktSyncSeasonsLastActivities),
            typeof(TraktSyncShowsLastActivities),
            typeof(TraktSyncWatchlistLastActivities),
            typeof(TraktSyncCollectionMovie),
            typeof(Dictionary<string, string>),
            typeof(Dictionary<string, Dictionary<string, Dictionary<string, string>>>),
            typeof(TraktSyncCollectionPost),
            typeof(TraktSyncCollectionPostEpisode),
            typeof(TraktSyncCollectionPostMovie),
            typeof(TraktSyncCollectionPostResponse),
            typeof(TraktSyncCollectionPostSeason),
            typeof(TraktSyncCollectionPostShow),
            typeof(TraktSyncCollectionPostShowEpisode),
            typeof(TraktSyncCollectionPostShowSeason),
            typeof(TraktSyncCollectionRemovePost),
            typeof(TraktSyncCollectionRemovePostResponse),
            typeof(TraktSyncCollectionShow),
            typeof(TraktSyncCollectionShowEpisode),
            typeof(TraktSyncCollectionShowSeason),
            typeof(TraktSyncFavoritesPost),
            typeof(TraktSyncFavoritesPostMovie),
            typeof(TraktSyncFavoritesPostResponse),
            typeof(TraktSyncFavoritesPostResponseGroup),
            typeof(TraktSyncFavoritesPostResponseNotFoundGroup),
            typeof(TraktSyncFavoritesPostShow),
            typeof(TraktSyncFavoritesRemovePost),
            typeof(TraktSyncFavoritesRemovePostResponse),
            typeof(TraktSyncHistoryPost),
            typeof(TraktSyncHistoryPostEpisode),
            typeof(TraktSyncHistoryPostMovie),
            typeof(TraktSyncHistoryPostResponse),
            typeof(TraktSyncHistoryPostSeason),
            typeof(TraktSyncHistoryPostShow),
            typeof(TraktSyncHistoryPostShowEpisode),
            typeof(TraktSyncHistoryPostShowSeason),
            typeof(TraktSyncHistoryRemovePost),
            typeof(TraktSyncHistoryRemovePostResponse),
            typeof(TraktSyncHistoryRemovePostResponseGroup),
            typeof(TraktSyncHistoryRemovePostResponseNotFoundGroup),
            typeof(TraktUpdateListPost),
            typeof(TraktSyncPlaybackProgressItem),
            typeof(TraktSyncProgressWatchedItem),
            typeof(TraktSyncRatingsPost),
            typeof(TraktSyncRatingsPostEpisode),
            typeof(TraktSyncRatingsPostMovie),
            typeof(TraktSyncRatingsPostResponse),
            typeof(TraktSyncRatingsPostResponseNotFoundEpisode),
            typeof(TraktSyncRatingsPostResponseNotFoundGroup),
            typeof(TraktSyncRatingsPostResponseNotFoundMovie),
            typeof(TraktSyncRatingsPostResponseNotFoundSeason),
            typeof(TraktSyncRatingsPostResponseNotFoundShow),
            typeof(TraktSyncRatingsPostSeason),
            typeof(TraktSyncRatingsPostShow),
            typeof(TraktSyncRatingsPostShowEpisode),
            typeof(TraktSyncRatingsPostShowSeason),
            typeof(TraktSyncRatingsRemovePost),
            typeof(TraktSyncRatingsRemovePostResponse),
            typeof(TraktSyncPostResponseGroup),
            typeof(TraktSyncPostResponseNotFoundGroup),
            typeof(TraktSyncWatchlistPost),
            typeof(TraktSyncWatchlistPostEpisode),
            typeof(TraktSyncWatchlistPostMovie),
            typeof(TraktSyncWatchlistPostResponse),
            typeof(TraktSyncWatchlistPostSeason),
            typeof(TraktSyncWatchlistPostShow),
            typeof(TraktSyncWatchlistPostShowEpisode),
            typeof(TraktSyncWatchlistPostShowSeason),
            typeof(TraktSyncWatchlistRemovePost),
            typeof(TraktSyncWatchlistRemovePostResponse),
            typeof(TraktSyncRemovePostEpisode),
            typeof(TraktSyncRemovePostMovie),
            typeof(TraktSyncRemovePostSeason),
            typeof(TraktSyncRemovePostShow),
            typeof(TraktSyncRemovePostShowEpisode),
            typeof(TraktSyncRemovePostShowSeason)
        });

        private static readonly FrozenSet<Type> s_teamJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktTeamMember)
        });

        private static readonly FrozenSet<Type> s_usersJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktUserHiddenItemsPost),
            typeof(TraktUserHiddenItemsPostMovie),
            typeof(TraktUserHiddenItemsPostResponse),
            typeof(TraktUserHiddenItemsPostResponseGroup),
            typeof(TraktUserHiddenItemsPostResponseNotFoundGroup),
            typeof(TraktUserHiddenItemsPostSeason),
            typeof(TraktUserHiddenItemsPostShow),
            typeof(TraktUserHiddenItemsPostShowSeason),
            typeof(TraktUserHiddenItemsRemovePost),
            typeof(TraktUserHiddenItemsRemovePostResponse),
            typeof(TraktUserPersonalListItemsPost),
            typeof(TraktUserPersonalListItemsPostEpisode),
            typeof(TraktUserPersonalListItemsPostMovie),
            typeof(TraktUserPersonalListItemsPostPerson),
            typeof(TraktUserPersonalListItemsPostResponse),
            typeof(TraktUserPersonalListItemsPostResponseGroup),
            typeof(TraktUserPersonalListItemsPostResponseNotFoundGroup),
            typeof(TraktUserPersonalListItemsPostSeason),
            typeof(TraktUserPersonalListItemsPostShow),
            typeof(TraktUserPersonalListItemsPostShowEpisode),
            typeof(TraktUserPersonalListItemsPostShowSeason),
            typeof(TraktUserPersonalListItemsRemovePost),
            typeof(TraktUserPersonalListItemsRemovePostResponse),
            typeof(TraktUserEpisodesStatistics),
            typeof(TraktUserMoviesStatistics),
            typeof(TraktUserNetworkStatistics),
            typeof(TraktUserProgressStatistics),
            typeof(TraktUserRatingsStatistics),
            typeof(TraktUserSeasonsStatistics),
            typeof(TraktUserShowsStatistics),
            typeof(TraktUserStatistics),
            typeof(TraktAccountSettings),
            typeof(TraktCollectionUser),
            typeof(TraktFavorite),
            typeof(TraktPermissions),
            typeof(TraktSharingText),
            typeof(TraktUser),
            typeof(TraktUserComment),
            typeof(TraktUserFavoritesLimits),
            typeof(TraktUserFollower),
            typeof(TraktUserFollowRequest),
            typeof(TraktUserFollowUserPostResponse),
            typeof(TraktUserFriend),
            typeof(TraktUserHiddenItem),
            typeof(TraktUserIDs),
            typeof(TraktUserImages),
            typeof(TraktUserImagesAvatar),
            typeof(TraktUserLikeItem),
            typeof(TraktUserLimits),
            typeof(TraktUserListLimits),
            typeof(TraktUserMinimal),
            typeof(TraktUserPersonalListPost),
            typeof(TraktUserRecommendationsLimits),
            typeof(TraktUserRemovePostEpisode),
            typeof(TraktUserRemovePostMovie),
            typeof(TraktUserRemovePostSeason),
            typeof(TraktUserRemovePostShow),
            typeof(TraktUserRemovePostShowEpisode),
            typeof(TraktUserRemovePostShowSeason),
            typeof(TraktUserSavedFilter),
            typeof(TraktUserSavedFilterPost),
            typeof(TraktUserSettings),
            typeof(TraktUserWatchingItem),
            typeof(TraktUserWatchlistLimits),
            typeof(TraktUserBlockedUser),
            typeof(TraktUserBrowsingSettings),
            typeof(TraktUserWatchnowSettings),
            typeof(TraktUserSettingsPost),
            typeof(TraktUserSettingsUserPost),
            typeof(TraktUserSettingsBrowsingPost),
            typeof(TraktUserBrowsingSpoilersSettings),
            typeof(TraktUserBrowsingCalendarSettings),
            typeof(TraktUserBrowsingProgressSettings),
            typeof(TraktUserBrowsingProgressOnDeckSettings),
            typeof(TraktUserBrowsingProgressWatchedSettings),
            typeof(TraktUserBrowsingProgressCollectedSettings),
            typeof(TraktUserBrowsingWelcomeSettings),
            typeof(TraktUserBrowsingGenresSettings),
            typeof(TraktUserBrowsingCommentsSettings),
            typeof(TraktUserBrowsingRecommendationsSettings),
            typeof(TraktUserBrowsingRewatchingSettings),
            typeof(TraktUserBrowsingProfileSettings),
            typeof(TraktUserBrowsingProfileFavoritesSettings),
            typeof(TraktUserBrowsingProfileShowsSettings),
            typeof(TraktUserBrowsingProfileMoviesSettings),
            typeof(TraktUserBrowsingSearchSettings),
            typeof(TraktUserBrowsingRecentQuery),
            typeof(TraktPlexSettings),
            typeof(TraktPlexConnection),
            typeof(TraktPlexWebhook),
            typeof(TraktPlexSync),
            typeof(TraktPlexSelection),
            typeof(TraktPlexLibrary),
            typeof(TraktPlexSyncToggles),
            typeof(TraktPlexMovieSyncToggles),
            typeof(TraktPlexShowSyncToggles),
            typeof(TraktPlexSeasonSyncToggles),
            typeof(TraktPlexEpisodeSyncToggles),
            typeof(TraktPlexScrobbler),
            typeof(TraktPlexScrobblerToggles),
            typeof(TraktPlexMovieScrobblerToggles),
            typeof(TraktPlexShowScrobblerToggles),
            typeof(TraktPlexSeasonScrobblerToggles),
            typeof(TraktPlexEpisodeScrobblerToggles),
            typeof(TraktPlexSettingsUpdate),
            typeof(TraktPlexSyncUpdate),
            typeof(TraktPlexSyncTogglesUpdate),
            typeof(TraktPlexMovieSyncTogglesUpdate),
            typeof(TraktPlexShowSyncTogglesUpdate),
            typeof(TraktPlexSeasonSyncTogglesUpdate),
            typeof(TraktPlexEpisodeSyncTogglesUpdate),
            typeof(TraktPlexScrobblerUpdate),
            typeof(TraktPlexScrobblerTogglesUpdate),
            typeof(TraktPlexMovieScrobblerTogglesUpdate),
            typeof(TraktPlexShowScrobblerTogglesUpdate),
            typeof(TraktPlexSeasonScrobblerTogglesUpdate),
            typeof(TraktPlexEpisodeScrobblerTogglesUpdate),
            typeof(TraktPlexWebhookUpdate),
            typeof(TraktPlexTriggerSync),
            typeof(TraktPlexConnectPost),
            typeof(TraktPlexConnectResponse),
            typeof(TraktPlexServer),
            typeof(TraktPlexServersResponse),
            typeof(TraktPlexServerAccountsAndLibraries),
            typeof(TraktPlexAccount),
            typeof(TraktPlexLibraryInfo),
            typeof(TraktPlexSyncPost),
            typeof(TraktUserAvatarPost),
            typeof(TraktUserAvatarPostUser),
            typeof(TraktUserCoverPost),
            typeof(TraktCoverType),
            typeof(TraktUserActivity),
            typeof(TraktUserSyncType),
            typeof(TraktUserSyncItemKind),
            typeof(TraktUserSyncCountGroup),
            typeof(TraktUserSyncItemsCount),
            typeof(TraktUserSync),
            typeof(TraktUserSyncItem),
            typeof(TraktUserYearInReview),
            typeof(TraktUserMonthInReview)
        });

        private static readonly FrozenSet<Type> s_watchedJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktWatchedMovie),
            typeof(TraktWatchedShow),
            typeof(TraktWatchedEpisode),
            typeof(TraktWatchedShowEpisode),
            typeof(TraktWatchedShowSeason)
        });

        private static readonly FrozenSet<Type> s_watchlistJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktWatchlistItem)
        });

        private static readonly FrozenSet<Type> s_watchnowJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktWatchnowSource),
            typeof(TraktWatchnowSourceImages),
            typeof(TraktWatchnowSources),
            typeof(Dictionary<string, TraktWatchnowSources>),
            typeof(Dictionary<string, IReadOnlyList<TraktWatchnowSource>>),
            typeof(IReadOnlyList<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>),
            typeof(Dictionary<string, string>),
            typeof(TraktStreamingRank),
            typeof(TraktWatchnowOffer),
            typeof(TraktWatchnowPrices),
            typeof(TraktWatchnowWebos),
            typeof(TraktWatchnowWebosParams)
        });

        private static readonly FrozenSet<Type> s_younifyJsonTypes = FrozenSet.ToFrozenSet(new[]
        {
            typeof(TraktYounifyConnection),
            typeof(IReadOnlyList<TraktYounifyConnection>),
            typeof(TraktYounifyConnectionImages),
            typeof(TraktYounifyConnectPost),
            typeof(TraktYounifyConnectResponse)
        });
#else
        private static readonly Dictionary<string, JsonSerializerContext> s_jsonSerializerContexts = new()
        {
            { AuthenticationContextCacheKey, new AuthenticationJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { CalendarsContextCacheKey, new CalendarsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { CertificationsContextCacheKey, new CertificationsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { CheckinContextCacheKey, new CheckinJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { CommentsContextCacheKey, new CommentsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { CountriesContextCacheKey, new CountriesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { EpisodesContextCacheKey, new EpisodesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { GeneralContextCacheKey, new GeneralJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { GenresContextCacheKey, new GenresJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { HistoryContextCacheKey, new HistoryJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { LanguagesContextCacheKey, new LanguagesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { ListsContextCacheKey, new ListsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { MediaContextCacheKey, new MediaJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { MoviesContextCacheKey, new MoviesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { NetworksContextCacheKey, new NetworksJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { NotesContextCacheKey, new NotesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { PeopleContextCacheKey, new PeopleJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { RatingsContextCacheKey, new RatingsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { RecommendationsContextCacheKey, new RecommendationsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { ResponsesContextCacheKey, new ResponsesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { ScrobllesContextCacheKey, new ScrobblesJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { SearchsContextCacheKey, new SearchsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { SeasonsContextCacheKey, new SeasonsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { ShowsContextCacheKey, new ShowsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { SmartListsContextCacheKey, new SmartListsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { SocialRecommendationsContextCacheKey, new SocialRecommendationsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { SyncsContextCacheKey, new SyncsJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { TeamContextCacheKey, new TeamJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { UsersContextCacheKey, new UsersJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { WatchedContextCacheKey, new WatchedJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { WatchlistContextCacheKey, new WatchlistJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { WatchnowContextCacheKey, new WatchnowJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) },
            { YounifyContextCacheKey, new YounifyJsonSerializerContext(new JsonSerializerOptions(Constants.Json.JsonOptions)) }
        };

        private static readonly HashSet<Type> s_authenticationJsonTypes = [
            typeof(TraktAuthorization),
            typeof(TraktAuthorizationPollPost),
            typeof(TraktAuthorizationPost),
            typeof(TraktAuthorizationRefreshPost),
            typeof(TraktAuthorizationRevokePost),
            typeof(TraktDevice),
            typeof(TraktDevicePost)
        ];

        private static readonly HashSet<Type> s_calendarssJsonTypes = [
            typeof(TraktCalendarShow),
            typeof(TraktCalendarMovie),
            typeof(TraktCalendarMedia)
        ];

        private static readonly HashSet<Type> s_certificationsJsonTypes = [
            typeof(TraktCertification),
            typeof(TraktCertifications)
        ];

        private static readonly HashSet<Type> s_checkinJsonTypes = [
            typeof(TraktCheckinErrorResponse),
            typeof(TraktEpisodeCheckin),
            typeof(TraktEpisodeCheckinResponse),
            typeof(TraktMovieCheckin),
            typeof(TraktMovieCheckinResponse)
        ];

        private static readonly HashSet<Type> s_commentsJsonTypes = [
            typeof(TraktComment),
            typeof(TraktCommentItem),
            typeof(TraktCommentLike),
            typeof(TraktCommentPost),
            typeof(TraktCommentPostResponse),
            typeof(TraktCommentReplyPost),
            typeof(TraktCommentUpdatePost),
            typeof(TraktCommentUserStats),
            typeof(TraktEpisodeCommentPost),
            typeof(TraktListCommentPost),
            typeof(TraktMovieCommentPost),
            typeof(TraktSeasonCommentPost),
            typeof(TraktShowCommentPost),
            typeof(TraktCommentReaction),
            typeof(TraktCommentUserReaction),
            typeof(TraktCommentReactionSummary)
        ];

        private static readonly HashSet<Type> s_countriesJsonTypes = [
            typeof(TraktCountry)
        ];

        private static readonly HashSet<Type> s_episodeJsonTypes = [
            typeof(TraktEpisode),
            typeof(TraktEpisodeCollectionProgress),
            typeof(TraktEpisodeIDs),
            typeof(TraktEpisodeImages),
            typeof(TraktEpisodeMinimal),
            typeof(TraktEpisodeProgress),
            typeof(TraktEpisodeStatistics),
            typeof(TraktEpisodeStats),
            typeof(TraktEpisodeTranslation),
            typeof(TraktEpisodeWatchedProgress)
        ];

        private static readonly HashSet<Type> s_generalJsonTypes = [
            typeof(uint),
            typeof(TraktCastAndCrew),
            typeof(TraktCastMember),
            typeof(TraktColors),
            typeof(TraktCrew),
            typeof(TraktCrewMember),
            typeof(TraktMetadata),
            typeof(TraktRateLimitInfo),
            typeof(TraktRating),
            typeof(TraktRatingItem),
            typeof(TraktMetascoreRatingItem),
            typeof(TraktRottenTomatoesRatingItem),
            typeof(TraktSentimentItem),
            typeof(TraktSentiments),
            typeof(TraktStudio),
            typeof(TraktStudioIDs),
            typeof(TraktVideo),
            typeof(TraktReportPost)
        ];

        private static readonly HashSet<Type> s_genresJsonTypes = [
            typeof(TraktGenre),
            typeof(TraktSubgenre)
        ];

        private static readonly HashSet<Type> s_historyJsonTypes = [
            typeof(TraktHistoryItem)
        ];

        private static readonly HashSet<Type> s_languagesJsonTypes = [
            typeof(TraktLanguage)
        ];

        private static readonly HashSet<Type> s_listsJsonTypes = [
            typeof(TraktList),
            typeof(TraktListIDs),
            typeof(TraktListImages),
            typeof(TraktListItem),
            typeof(TraktListItemsReorderPost),
            typeof(TraktListItemsReorderPostResponse),
            typeof(TraktListItemUpdatePost),
            typeof(TraktListLike),
            typeof(TraktPopularList),
            typeof(TraktTrendingList),
            typeof(TraktTrendingOrPopularList)
        ];

        private static readonly HashSet<Type> s_mediaJsonTypes = [
            typeof(TraktTrendingMedia),
            typeof(TraktAnticipatedMedia),
            typeof(TraktPopularMedia)
        ];

        private static readonly HashSet<Type> s_movieJsonTypes = [
            typeof(TraktBoxOfficeMovie),
            typeof(TraktCollectionMovie),
            typeof(TraktHotMovie),
            typeof(TraktMostAnticipatedMovie),
            typeof(TraktMostCollectedMovie),
            typeof(TraktMostFavoritedMovie),
            typeof(TraktMostPlayedMovie),
            typeof(TraktMostPWCMovie),
            typeof(TraktMostWatchedMovie),
            typeof(TraktMovie),
            typeof(TraktMovieAlias),
            typeof(TraktMovieIDs),
            typeof(TraktMovieImages),
            typeof(TraktMovieMinimal),
            typeof(TraktMovieRelease),
            typeof(TraktMovieSocialIDs),
            typeof(TraktMovieStatistics),
            typeof(TraktMovieTranslation),
            typeof(TraktStreamingMovie),
            typeof(TraktTrendingMovie),
            typeof(TraktUpdatedMovie)
        ];

        private static readonly HashSet<Type> s_networksJsonTypes = [
            typeof(TraktNetwork),
            typeof(TraktNetworkIDs)
        ];

        private static readonly HashSet<Type> s_notesJsonTypes = [
            typeof(TraktNote),
            typeof(TraktNoteAttachedTo),
            typeof(TraktNoteItem),
            typeof(TraktNotePost)
        ];

        private static readonly HashSet<Type> s_peopleJsonTypes = [
            typeof(TraktPerson),
            typeof(TraktPersonIDs),
            typeof(TraktPersonImages),
            typeof(TraktPersonMinimal),
            typeof(TraktPersonMovieCredits),
            typeof(TraktPersonMovieCreditsCastItem),
            typeof(TraktPersonMovieCreditsCrew),
            typeof(TraktPersonMovieCreditsCrewItem),
            typeof(TraktPersonShowCredits),
            typeof(TraktPersonShowCreditsCastItem),
            typeof(TraktPersonShowCreditsCrew),
            typeof(TraktPersonShowCreditsCrewItem),
            typeof(TraktPersonSocialIDs),
            typeof(TraktRecentlyUpdatedPerson)
        ];

        private static readonly HashSet<Type> s_ratingsJsonTypes = [
            typeof(TraktRatingsItem)
        ];

        private static readonly HashSet<Type> s_recommendationsJsonTypes = [
            typeof(TraktFavoritedBy),
            typeof(TraktRecommendedMovie),
            typeof(TraktRecommendedShow)
        ];

        private static readonly HashSet<Type> s_responsesJsonTypes = [
            typeof(TraktPostResponseListData),
            typeof(TraktPostResponseNotFoundEpisode),
            typeof(TraktPostResponseNotFoundMovie),
            typeof(TraktPostResponseNotFoundPerson),
            typeof(TraktPostResponseNotFoundSeason),
            typeof(TraktPostResponseNotFoundShow),
            typeof(TraktPostResponseNotFoundUser)
        ];

        private static readonly HashSet<Type> s_scrobblesJsonTypes = [
            typeof(TraktEpisodeScrobblePost),
            typeof(TraktEpisodeScrobblePostResponse),
            typeof(TraktMovieScrobblePost),
            typeof(TraktMovieScrobblePostResponse),
            typeof(TraktScrobblePost),
            typeof(TraktScrobblePostResponse)
        ];

        private static readonly HashSet<Type> s_searchsJsonTypes = [
            typeof(TraktSearchResult),
            typeof(TraktSearchRecentPost),
            typeof(TraktTrendingSearchResult)
        ];

        private static readonly HashSet<Type> s_seasonsJsonTypes = [
            typeof(TraktSeason),
            typeof(TraktSeasonCollectionProgress),
            typeof(TraktSeasonIDs),
            typeof(TraktSeasonImages),
            typeof(TraktSeasonMinimal),
            typeof(TraktSeasonProgress),
            typeof(TraktSeasonStatistics),
            typeof(TraktSeasonStats),
            typeof(TraktSeasonTranslation),
            typeof(TraktSeasonWatchedProgress)
        ];

        private static readonly HashSet<Type> s_showsJsonTypes = [
            typeof(TraktCollectionShow),
            typeof(TraktHotShow),
            typeof(TraktMostAnticipatedShow),
            typeof(TraktMostCollectedShow),
            typeof(TraktMostFavoritedShow),
            typeof(TraktMostPlayedShow),
            typeof(TraktMostPWCShow),
            typeof(TraktMostWatchedShow),
            typeof(TraktShow),
            typeof(TraktShowAirs),
            typeof(TraktShowAlias),
            typeof(TraktShowCertification),
            typeof(TraktShowCollectionProgress),
            typeof(TraktShowIDs),
            typeof(TraktShowImages),
            typeof(TraktShowMinimal),
            typeof(TraktShowProgress),
            typeof(TraktShowResetWatchedProgress),
            typeof(TraktShowSocialIDs),
            typeof(TraktShowStatistics),
            typeof(TraktShowStats),
            typeof(TraktShowTranslation),
            typeof(TraktShowWatchedProgress),
            typeof(TraktStreamingShow),
            typeof(TraktTrendingShow),
            typeof(TraktUpdatedShow)
        ];

        private static readonly HashSet<Type> s_smartListsJsonTypes = [
            typeof(TraktSmartList),
            typeof(TraktSmartListImages),
            typeof(TraktSmartListFilters),
            typeof(TraktSmartListPost),
            typeof(TraktSmartListPostResponse)
        ];

        private static readonly HashSet<Type> s_socialrecommendationsJsonTypes = [
            typeof(TraktSocialMovieRecommendation),
            typeof(TraktSocialShowRecommendation)
        ];

        private static readonly HashSet<Type> s_syncsJsonTypes = [
            typeof(TraktSyncAccountLastActivities),
            typeof(TraktSyncCollaborationsLastActivities),
            typeof(TraktSyncCommentsLastActivities),
            typeof(TraktSyncEpisodesLastActivities),
            typeof(TraktSyncFavoritesLastActivities),
            typeof(TraktSyncLastActivities),
            typeof(TraktSyncListsLastActivities),
            typeof(TraktSyncMoviesLastActivities),
            typeof(TraktSyncNotesLastActivities),
            typeof(TraktSyncRecommendationsLastActivities),
            typeof(TraktSyncSavedFiltersLastActivities),
            typeof(TraktSyncSeasonsLastActivities),
            typeof(TraktSyncShowsLastActivities),
            typeof(TraktSyncWatchlistLastActivities),
            typeof(TraktSyncCollectionMovie),
            typeof(Dictionary<string, string>),
            typeof(Dictionary<string, Dictionary<string, Dictionary<string, string>>>),
            typeof(TraktSyncCollectionPost),
            typeof(TraktSyncCollectionPostEpisode),
            typeof(TraktSyncCollectionPostMovie),
            typeof(TraktSyncCollectionPostResponse),
            typeof(TraktSyncCollectionPostSeason),
            typeof(TraktSyncCollectionPostShow),
            typeof(TraktSyncCollectionPostShowEpisode),
            typeof(TraktSyncCollectionPostShowSeason),
            typeof(TraktSyncCollectionRemovePost),
            typeof(TraktSyncCollectionRemovePostResponse),
            typeof(TraktSyncCollectionShow),
            typeof(TraktSyncCollectionShowEpisode),
            typeof(TraktSyncCollectionShowSeason),
            typeof(TraktSyncFavoritesPost),
            typeof(TraktSyncFavoritesPostMovie),
            typeof(TraktSyncFavoritesPostResponse),
            typeof(TraktSyncFavoritesPostResponseGroup),
            typeof(TraktSyncFavoritesPostResponseNotFoundGroup),
            typeof(TraktSyncFavoritesPostShow),
            typeof(TraktSyncFavoritesRemovePost),
            typeof(TraktSyncFavoritesRemovePostResponse),
            typeof(TraktSyncHistoryPost),
            typeof(TraktSyncHistoryPostEpisode),
            typeof(TraktSyncHistoryPostMovie),
            typeof(TraktSyncHistoryPostResponse),
            typeof(TraktSyncHistoryPostSeason),
            typeof(TraktSyncHistoryPostShow),
            typeof(TraktSyncHistoryPostShowEpisode),
            typeof(TraktSyncHistoryPostShowSeason),
            typeof(TraktSyncHistoryRemovePost),
            typeof(TraktSyncHistoryRemovePostResponse),
            typeof(TraktSyncHistoryRemovePostResponseGroup),
            typeof(TraktSyncHistoryRemovePostResponseNotFoundGroup),
            typeof(TraktUpdateListPost),
            typeof(TraktSyncPlaybackProgressItem),
            typeof(TraktSyncProgressWatchedItem),
            typeof(TraktSyncRatingsPost),
            typeof(TraktSyncRatingsPostEpisode),
            typeof(TraktSyncRatingsPostMovie),
            typeof(TraktSyncRatingsPostResponse),
            typeof(TraktSyncRatingsPostResponseNotFoundEpisode),
            typeof(TraktSyncRatingsPostResponseNotFoundGroup),
            typeof(TraktSyncRatingsPostResponseNotFoundMovie),
            typeof(TraktSyncRatingsPostResponseNotFoundSeason),
            typeof(TraktSyncRatingsPostResponseNotFoundShow),
            typeof(TraktSyncRatingsPostSeason),
            typeof(TraktSyncRatingsPostShow),
            typeof(TraktSyncRatingsPostShowEpisode),
            typeof(TraktSyncRatingsPostShowSeason),
            typeof(TraktSyncRatingsRemovePost),
            typeof(TraktSyncRatingsRemovePostResponse),
            typeof(TraktSyncPostResponseGroup),
            typeof(TraktSyncPostResponseNotFoundGroup),
            typeof(TraktSyncWatchlistPost),
            typeof(TraktSyncWatchlistPostEpisode),
            typeof(TraktSyncWatchlistPostMovie),
            typeof(TraktSyncWatchlistPostResponse),
            typeof(TraktSyncWatchlistPostSeason),
            typeof(TraktSyncWatchlistPostShow),
            typeof(TraktSyncWatchlistPostShowEpisode),
            typeof(TraktSyncWatchlistPostShowSeason),
            typeof(TraktSyncWatchlistRemovePost),
            typeof(TraktSyncWatchlistRemovePostResponse),
            typeof(TraktSyncRemovePostEpisode),
            typeof(TraktSyncRemovePostMovie),
            typeof(TraktSyncRemovePostSeason),
            typeof(TraktSyncRemovePostShow),
            typeof(TraktSyncRemovePostShowEpisode),
            typeof(TraktSyncRemovePostShowSeason)
        ];

        private static readonly HashSet<Type> s_teamJsonTypes = [
            typeof(TraktTeamMember)
        ];

        private static readonly HashSet<Type> s_usersJsonTypes = [
            typeof(TraktUserHiddenItemsPost),
            typeof(TraktUserHiddenItemsPostMovie),
            typeof(TraktUserHiddenItemsPostResponse),
            typeof(TraktUserHiddenItemsPostResponseGroup),
            typeof(TraktUserHiddenItemsPostResponseNotFoundGroup),
            typeof(TraktUserHiddenItemsPostSeason),
            typeof(TraktUserHiddenItemsPostShow),
            typeof(TraktUserHiddenItemsPostShowSeason),
            typeof(TraktUserHiddenItemsRemovePost),
            typeof(TraktUserHiddenItemsRemovePostResponse),
            typeof(TraktUserPersonalListItemsPost),
            typeof(TraktUserPersonalListItemsPostEpisode),
            typeof(TraktUserPersonalListItemsPostMovie),
            typeof(TraktUserPersonalListItemsPostPerson),
            typeof(TraktUserPersonalListItemsPostResponse),
            typeof(TraktUserPersonalListItemsPostResponseGroup),
            typeof(TraktUserPersonalListItemsPostResponseNotFoundGroup),
            typeof(TraktUserPersonalListItemsPostSeason),
            typeof(TraktUserPersonalListItemsPostShow),
            typeof(TraktUserPersonalListItemsPostShowEpisode),
            typeof(TraktUserPersonalListItemsPostShowSeason),
            typeof(TraktUserPersonalListItemsRemovePost),
            typeof(TraktUserPersonalListItemsRemovePostResponse),
            typeof(TraktUserEpisodesStatistics),
            typeof(TraktUserMoviesStatistics),
            typeof(TraktUserNetworkStatistics),
            typeof(TraktUserRatingsStatistics),
            typeof(TraktUserSeasonsStatistics),
            typeof(TraktUserShowsStatistics),
            typeof(TraktUserStatistics),
            typeof(TraktAccountSettings),
            typeof(TraktCollectionUser),
            typeof(TraktFavorite),
            typeof(TraktPermissions),
            typeof(TraktSharingText),
            typeof(TraktUser),
            typeof(TraktUserComment),
            typeof(TraktUserFavoritesLimits),
            typeof(TraktUserFollower),
            typeof(TraktUserFollowRequest),
            typeof(TraktUserFollowUserPostResponse),
            typeof(TraktUserFriend),
            typeof(TraktUserHiddenItem),
            typeof(TraktUserIDs),
            typeof(TraktUserImages),
            typeof(TraktUserImagesAvatar),
            typeof(TraktUserLikeItem),
            typeof(TraktUserLimits),
            typeof(TraktUserListLimits),
            typeof(TraktUserMinimal),
            typeof(TraktUserPersonalListPost),
            typeof(TraktUserRecommendationsLimits),
            typeof(TraktUserRemovePostEpisode),
            typeof(TraktUserRemovePostMovie),
            typeof(TraktUserRemovePostSeason),
            typeof(TraktUserRemovePostShow),
            typeof(TraktUserRemovePostShowEpisode),
            typeof(TraktUserRemovePostShowSeason),
            typeof(TraktUserSavedFilter),
            typeof(TraktUserSavedFilterPost),
            typeof(TraktUserSettings),
            typeof(TraktUserWatchingItem),
            typeof(TraktUserWatchlistLimits),
            typeof(TraktUserBlockedUser),
            typeof(TraktUserBrowsingSettings),
            typeof(TraktUserWatchnowSettings),
            typeof(TraktUserSettingsPost),
            typeof(TraktUserSettingsUserPost),
            typeof(TraktUserSettingsBrowsingPost),
            typeof(TraktUserBrowsingSpoilersSettings),
            typeof(TraktUserBrowsingCalendarSettings),
            typeof(TraktUserBrowsingProgressSettings),
            typeof(TraktUserBrowsingProgressOnDeckSettings),
            typeof(TraktUserBrowsingProgressWatchedSettings),
            typeof(TraktUserBrowsingProgressCollectedSettings),
            typeof(TraktUserBrowsingWelcomeSettings),
            typeof(TraktUserBrowsingGenresSettings),
            typeof(TraktUserBrowsingCommentsSettings),
            typeof(TraktUserBrowsingRecommendationsSettings),
            typeof(TraktUserBrowsingRewatchingSettings),
            typeof(TraktUserBrowsingProfileSettings),
            typeof(TraktUserBrowsingProfileFavoritesSettings),
            typeof(TraktUserBrowsingProfileShowsSettings),
            typeof(TraktUserBrowsingProfileMoviesSettings),
            typeof(TraktUserBrowsingSearchSettings),
            typeof(TraktUserBrowsingRecentQuery),
            typeof(TraktPlexSettings),
            typeof(TraktPlexConnection),
            typeof(TraktPlexWebhook),
            typeof(TraktPlexSync),
            typeof(TraktPlexSelection),
            typeof(TraktPlexLibrary),
            typeof(TraktPlexSyncToggles),
            typeof(TraktPlexMovieSyncToggles),
            typeof(TraktPlexShowSyncToggles),
            typeof(TraktPlexSeasonSyncToggles),
            typeof(TraktPlexEpisodeSyncToggles),
            typeof(TraktPlexScrobbler),
            typeof(TraktPlexScrobblerToggles),
            typeof(TraktPlexMovieScrobblerToggles),
            typeof(TraktPlexShowScrobblerToggles),
            typeof(TraktPlexSeasonScrobblerToggles),
            typeof(TraktPlexEpisodeScrobblerToggles),
            typeof(TraktPlexSettingsUpdate),
            typeof(TraktPlexSyncUpdate),
            typeof(TraktPlexSyncTogglesUpdate),
            typeof(TraktPlexMovieSyncTogglesUpdate),
            typeof(TraktPlexShowSyncTogglesUpdate),
            typeof(TraktPlexSeasonSyncTogglesUpdate),
            typeof(TraktPlexEpisodeSyncTogglesUpdate),
            typeof(TraktPlexScrobblerUpdate),
            typeof(TraktPlexScrobblerTogglesUpdate),
            typeof(TraktPlexMovieScrobblerTogglesUpdate),
            typeof(TraktPlexShowScrobblerTogglesUpdate),
            typeof(TraktPlexSeasonScrobblerTogglesUpdate),
            typeof(TraktPlexEpisodeScrobblerTogglesUpdate),
            typeof(TraktPlexWebhookUpdate),
            typeof(TraktPlexTriggerSync),
            typeof(TraktPlexConnectPost),
            typeof(TraktPlexConnectResponse),
            typeof(TraktPlexServer),
            typeof(TraktPlexServersResponse),
            typeof(TraktPlexServerAccountsAndLibraries),
            typeof(TraktPlexAccount),
            typeof(TraktPlexLibraryInfo),
            typeof(TraktPlexSyncPost),
            typeof(TraktUserAvatarPost),
            typeof(TraktUserAvatarPostUser),
            typeof(TraktUserCoverPost),
            typeof(TraktCoverType),
            typeof(TraktUserActivity),
            typeof(TraktUserSyncType),
            typeof(TraktUserSyncItemKind),
            typeof(TraktUserSyncCountGroup),
            typeof(TraktUserSyncItemsCount),
            typeof(TraktUserSync),
            typeof(TraktUserSyncItem),
            typeof(TraktUserYearInReview),
            typeof(TraktUserMonthInReview)
        ];

        private static readonly HashSet<Type> s_watchedJsonTypes = [
            typeof(TraktWatchedMovie),
            typeof(TraktWatchedShow),
            typeof(TraktWatchedEpisode),
            typeof(TraktWatchedShowEpisode),
            typeof(TraktWatchedShowSeason)
        ];

        private static readonly HashSet<Type> s_watchlistJsonTypes = [
            typeof(TraktWatchlistItem)
        ];

        private static readonly HashSet<Type> s_watchnowJsonTypes = [
            typeof(TraktWatchnowSource),
            typeof(TraktWatchnowSourceImages),
            typeof(TraktWatchnowSources),
            typeof(Dictionary<string, TraktWatchnowSources>),
            typeof(Dictionary<string, IReadOnlyList<TraktWatchnowSource>>),
            typeof(IReadOnlyList<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>),
            typeof(Dictionary<string, string>),
            typeof(TraktStreamingRank),
            typeof(TraktWatchnowOffer),
            typeof(TraktWatchnowPrices),
            typeof(TraktWatchnowWebos),
            typeof(TraktWatchnowWebosParams)
        ];

        private static readonly HashSet<Type> s_younifyJsonTypes = [
            typeof(TraktYounifyConnection),
            typeof(IReadOnlyList<TraktYounifyConnection>),
            typeof(TraktYounifyConnectionImages),
            typeof(TraktYounifyConnectPost),
            typeof(TraktYounifyConnectResponse)
        ];
#endif
    }
}
#endif
