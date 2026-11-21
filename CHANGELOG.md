# Changelog

All notable changes to Trakt.NET are documented in this file. Changes for 1.x and older versions are in [Changelogs/CHANGELOG-v1.md](Changelogs/CHANGELOG-v1.md).

## [2.3.0] - Unreleased

### New Features & API Endpoints

- **Awards API (`client.Awards`, `client.Movies`, `client.Shows`, `client.People`)**
  - Added support for award catalog, award ceremonies, and movie, show, and person awards.

- **Anticipated Recommendations (`client.Movies`, `client.Shows`, `client.Media`, `client.Recommendations`)**
  - Added support for personalized anticipated recommendations for movies, shows, and media.

- **Smart List Award Filters (`client.SmartLists`)**
  - Added award filters (`awards`, `award_years`, `award_won`) to `TraktSmartListFilters`.

### Added & Updated Data Models

- **Awards Models**
  - Added `TraktAward`, `TraktAwardCeremony`, `TraktUpcomingCeremony`, `TraktTitleAward`, `TraktPersonAward`, `TraktAwardCatalogCeremony`, and `TraktAwardCatalogAward`.
  - Added `TraktAwardKind` and `TraktAwardMediaType` enumerations.
- **Recommendation Models**
  - Added `TraktAnticipatedMovieRecommendation`, `TraktAnticipatedShowRecommendation`, and `TraktAnticipatedMediaRecommendation`.
- **Smart List Models**
  - Added `Awards`, `AwardYears`, and `AwardWon` to `TraktSmartListFilters`.
- **Notes, Comments & Hidden Items Models**
  - Added `WatchedAt`, `CollectedAt`, `RatedAt`, and `Rating` to `TraktNoteAttachedTo`.
  - Added `Person`, `Comment`, and `User` to `TraktCommentItem` (and `Person`, `Comment`, `User` values to `TraktCommentObjectType`).
  - Added optional `HiddenAt` to `TraktUserHiddenItemsPostMovie`, `TraktUserHiddenItemsPostShow`, `TraktUserHiddenItemsPostSeason`, and `TraktUserHiddenItemsPostShowSeason`.
- **Not Found Response Models**
  - Added optional `Title`, `Year`, and `Seasons` (`TraktPostResponseNotFoundShowSeason`, `TraktPostResponseNotFoundShowEpisode`) to `TraktPostResponseNotFoundShow`, `TraktPostResponseNotFoundSeason`, and `TraktPostResponseNotFoundEpisode`, and `Title`/`Year` to `TraktSyncRatingsPostResponseNotFoundShow`, to preserve show-shaped `not_found` entries returned by the Trakt API.

### Breaking Changes

- Renamed `Id`/`Ids` to `ID`/`IDs` in the method and property names that still used them (e.g. `GetIDLookupResultsAsync`, `ClientID`). JSON property names are unchanged.
- Renamed `RtMeters`, `RtUserMeters`, and `MalRatings` in `TraktSmartListFilters` to `RottenTomatoesMeters`, `RottenTomatoesUserMeters`, and `MALRatings`.
- `TraktUserComment` no longer inherits from `TraktCommentItem` and declares its own properties directly.
- Removed `TraktCommentSortOrder.Watched`, which is rejected with `400 invalid_sort` by the Trakt API on all comment endpoints.
- Removed deprecated hot and streaming chart endpoints (`GetHotMoviesAsync`, `GetStreamingMoviesAsync`, `GetHotShowsAsync`, `GetStreamingShowsAsync`) and their models (`TraktHotMovie`, `TraktStreamingMovie`, `TraktHotShow`, `TraktStreamingShow`) as they are no longer served by the Trakt API.
- Removed deprecated Plex endpoints (`ConnectPlexAsync`, `GetPlexServersAsync`, `GetPlexServerAccountsAsync`, `SyncPlexAsync`) and their models (`TraktPlexConnectPost`, `TraktPlexConnectResponse`, `TraktPlexServer`, `TraktPlexServersResponse`, `TraktPlexServerAccountsAndLibraries`, `TraktPlexAccount`, `TraktPlexLibraryInfo`, `TraktPlexSyncPost`) as they are no longer served by the Trakt API.
- Changed `MinutesLeft` in `TraktShowStats` and `TraktSeasonStats` from `uint?` to `int?`, because the Trakt API can return negative values (e.g. in `GET /sync/progress/watched`), which made deserialization throw a `JsonException`.
- `BestID` of `TraktShowIDs`, `TraktMovieIDs`, `TraktPersonIDs`, `TraktSeasonIDs`, `TraktEpisodeIDs`, `TraktNetworkIDs`, and `TraktStudioIDs` no longer falls back to the TMDB or TVDB ID, because the Trakt API does not accept them in request URLs and interpreted them as Trakt IDs, returning a different item. Methods that take an IDs object now throw an `ArgumentException` if only TMDB or TVDB IDs are set; use `client.Search.GetIDLookupResultsAsync` to resolve them first.

### Improvements & Fixes

- **Postman Collection**
  - Updated collection to v2.3.0 with anticipated recommendations and awards requests.

- **Episodes & Seasons**
  - `ToString()` of `TraktEpisode`, `TraktEpisodeMinimal`, and `TraktSeason` no longer ends with `": "` when there is no title (e.g. `S01E01`).

- **Sync (`client.Sync`)**
  - Added optional `extendedInfo` parameter support (`extended=images`) and made `description` optional/nullable in `UpdateWatchlistAsync` (`PUT /sync/watchlist`).

## [2.2.0] - 2026-11-09

### New Features & API Endpoints

- **Year and Month in Review (`client.Users`)**
  - Added support for Year in Review across year ranges (`GET /users/{id}/yir/{year}/{year_end}`) via `GetYearInReviewRangeAsync`.
  - Added support for All-Time Year in Review (`GET /users/{id}/yir/all`) via `GetYearInReviewAllAsync`.
  - Added `slurm` query parameter support across all review endpoints (`mir`, `yir`, `yir` range, and `yir` all-time).

- **Person Social IDs & Language Filter (`client.People`)**
  - Added `TraktPersonSocialIDs` to `TraktPerson` for social network identifiers (Twitter, Facebook, Instagram, YouTube, TikTok).
  - Added `language` parameter support to person summary requests.

- **User Avatar Removal (`client.Users`)**
  - Added support for deleting custom user avatars (`DELETE /users/avatar`) via `DeleteAvatarAsync`.

- **Personalized Related Media (`client.Movies`, `client.Shows`)**
  - Added `personalized` boolean query parameter to related movies (`GetRelatedMoviesAsync`) and related shows (`GetRelatedShowsAsync`).

- **OAuth & PKCE Authentication (`client.Auth`)**
  - Migrated OAuth endpoints to `auth.trakt.tv`.
  - Added support for Proof Key for Code Exchange (PKCE) with code challenges and code verifiers.

- **List Items & Notes (`client.Users`)**
  - Added support for optional `notes` when adding items to personal lists.

- **Show Progress Reset (`client.Sync`)**
  - Added support for optional `reset_at` timestamp when resetting show progress.

- **Social Activity Rating (`client.Users`)**
  - Added support for `extended=rating` on user social activities (`UserRating` on `TraktUserActivity`).

### Added & Updated Data Models

- **Review Models (`TraktUserAllTimeYearInReview`, etc.)**
  - Added comprehensive models for all-time and range reviews: `TraktUserAllTimeYearInReview`, `TraktUserReviewAllTimeGlobalTop`, `TraktUserReviewAllTimeListProgress`, `TraktUserReviewAllTimeReleaseYears`, `TraktUserReviewCompany`, `TraktUserReviewDecadeCount`, `TraktUserReviewDistributions`, `TraktUserReviewGenreCount`, `TraktUserReviewGenreItem`, `TraktUserReviewGenres`, `TraktUserReviewGlobalTopMovie`, `TraktUserReviewGlobalTopShow`, `TraktUserReviewListProgress`, `TraktUserReviewMostWatched`, `TraktUserReviewMostWatchedMovie`, `TraktUserReviewMostWatchedShow`, `TraktUserReviewRatingCount`, `TraktUserReviewReleaseYears`, `TraktUserReviewTopRated`, `TraktUserReviewTopRatedMovie`, `TraktUserReviewTopRatedShow`, `TraktUserReviewYearCount`, and `TraktUserReviewYearlyPlayCount`.
- **People Models**
  - Added `TraktPersonSocialIDs` model for social media profile links.
- **Naming Unification**
  - Standardized identifier properties to `ID` with `[JsonPropertyName("id")]` across data models (`TraktListItem`, `TraktWatchlistItem`, `TraktUserActivity`, `TraktUserSync`, `TraktSearchRecentPost`, `TraktTrendingSearchResult`, `TraktSmartListTemplate`, `TraktSyncPlaybackProgressItem`, `TraktPlexServer`, `TraktUserFollowRequest`, `TraktWatchnowWebos`, `TraktYounifyConnection`).

### Improvements & Fixes

- **Authentication & Security**
  - Automatically save acquired credentials to client context in `PollForAuthorizationAsync`.
  - Avoid sending empty `Bearer` authorization headers when tokens are invalid or revoked.
  - Added `ConfigureAwait(false)` in `RefreshAuthorizationAsync` and eliminated synchronous `.Result` calls in URL building.
  - Fixed XML documentation for `TraktAuthorization.IsExpired`.
- **Sync & Collection Alignment**
  - Aligned collection add and remove payload contracts with upstream API specifications.
  - Formatted user history start and end timestamps using full ISO-8601 UTC format.
  - Fixed handling of OpenAPI string date formats and nullable user statistics.
- **Request & Parameter Handling**
  - Properly URL-encode string query parameters and filter text values.
  - Allow zero-bounded filter ranges in `TraktFilter`.
  - Skip empty enum filter parameters when all values are `Unspecified`.
  - Correctly dispose `HttpResponseMessage` instances when request execution throws.
- **HttpClientFactory Integration**
  - Isolated `TraktContext` per dependency injection client instance and ensured default `Accept: application/json` headers.
- **Diagnostics & Error Handling**
  - Included HTTP reason phrase in `TraktApiNotFoundException` messages.
  - Use last pending response for device polling timeout exception.
- **Postman Collection**
  - Renamed and updated collection to v2.2.0 with all new endpoints and parameters.

## [2.1.0] - 2026-10-24

### New Features & API Endpoints

- **Smart Lists Enhancements (`client.SmartLists`)**
  - Added support for Smart List templates (`GET /lists/smart/templates`) and drafts summary (`GET /lists/smart/drafts/summary`).
  - Added support for converting static lists into Smart Lists (`POST /lists/{id}/convert`).
  - Expanded Smart List filters and sources (`TraktSmartListFilters`, `TraktSmartListSource`) with sort, type, streaming region, parental filters, and additional filter dimensions.

- **Sync & Users Collection / Watched (`client.Sync`, `client.Users`)**
  - Added support for the unified media collection endpoint (`GET /sync/collection/media`).
  - Added support for the minimal watched shows endpoint (`GET /users/{id}/watched/shows`).
  - Added pagination (`page` and `limit`) support to movie and episode collection endpoints.
  - Added media item support for favorite items.

- **Calendar Grouping (`client.Calendar`)**
  - Added `TraktCalendarGroup` (`group=day`) parameter and grouped episode response support (`TraktEpisodeType.FullSeason`, `TraktEpisodeType.MultipleEpisodes`, and collapsed `Episodes` collection).

- **Comments & Reactions (`client.Comments`)**
  - Added `TraktCommentGif` support (`gif` with `slug`, `width`, and `height`) on comment creation, replies, and responses.
  - Added language filter parameter support for comments endpoints.
  - Updated comment reaction add endpoint to accept `204 No Content`.

- **Ratings & Recommendations (`client.Sync`, `client.Recommendations`)**
  - Added support for nested season and episode ratings under shows, `rated_at` on sync ratings add, and `show` echo in `not_found` for nested misses.
  - Added support for `extended=all` ratings response variants (nested `trakt` rating object and external rating providers).
  - Added seasonal `theme` parameter support on recommendation feeds.

- **Media & Translations (`client.Media`, `client.Movies`, `client.Shows`)**
  - Unified media refresh endpoints (`POST /movies/{id}/refresh`, `POST /shows/{id}/refresh`) with optional `images` query parameter.
  - Updated translations `language` filter to be an optional query parameter.

- **Users & Lists Filtering (`client.Users`)**
  - Added pagination and sort parameters (`sort_by`, `sort_how`) support for user personal lists.
  - Added filter support to watched history, playback progress, and list items, plus `hide` filter support on watchlist endpoints.
  - Fixed support for adding and deleting user saved filters.

### Added & Updated Data Models

- **Shows & Seasons (`TraktShow`, `TraktCollectionShow`, `TraktSeason`)**
  - Added `Ending` (`TraktShowEnding`), `LastAired`, and `TotalRuntime` to `TraktShow` and `TraktCollectionShow`.
  - Added `TotalRuntime` to `TraktSeason`.
- **Users & Settings (`TraktUser`, `TraktCollectionUser`, `TraktUserSettings`)**
  - Added VIP veteran status properties (`VIPVeteranSince`, `VIPVeteranYears`, `VIPVeteranTier`, `VIPVeteranTitle`, `VIPGraceEndsAt`) and `Email` to `TraktUser` and `TraktCollectionUser`.
  - Added `ShareCode` and `WatchOnlyOnce` to `TraktAccountSettings`.
  - Added `Locale` and `ShowRatingPrompt` to `TraktUserBrowsingSettings`.
  - Added `ServerLimit` to `TraktPlexSync`.
  - Updated `TraktUserStatistics` and Year/Month in Review (`TraktUserYearInReview`, `TraktUserMonthInReview`) models with new API fields.
- **General & Enums**
  - Added `TraktStreamingRank` support for streaming chart rankings.
  - Added `TraktAvailableOn.Digital` (`digital`) enum value.
  - Added `TraktExtendedInfo.Markdown` support for person summaries.

### Removed / Deprecated

- Removed deprecated people lists endpoint (`GET /people/{id}/lists`) and unused endpoints.

### Improvements & Fixes

- Improved `HttpClient` lifecycle management in `TraktClient` and `HttpClientProvider`.
- Fixed `TraktShowCollectionProgress` response deserialization.
- Added missing `[JsonIgnore]` attributes on `TraktCollectionMovie` and `TraktCollectionShow` delegated properties and expanded unit test coverage across enums, modules, requests, and collection models.

## [2.0.0] - 2026-09-01

### Major Features & Architectural Changes

- **100% Trakt.tv API v2 Coverage & New API Modules**
  - **`SmartLists`** (`client.SmartLists`): Added complete support for Trakt Smart Lists management, creation, update, and item filtering.
  - **`SocialRecommendations`** (`client.SocialRecommendations`): Added support for friend & social graph recommendations for movies and shows.
  - **`Notes`** (`client.Notes`): Added support for Trakt Notes API (creating, updating, and attaching personal notes to movies, shows, seasons, episodes, people, and lists).
  - **`Team`** (`client.Team`): Added support for Trakt Team staff and contributor information.
  - **`Watchnow`** (`client.Watchnow`): Added support for WatchNow streaming source providers, offers, and regional sources. *(Note: Documented for API visibility; availability may depend on Trakt backend access level).*
  - **`Younify`** (`client.Younify`): Added support for Younify streaming service connections, syncing, and account management.
  - **`Users` / `Sync` Extensions**: Added Plex integration (`client.Users.GetPlexSettingsAsync()`, `ConnectPlexAsync()`, `SyncPlexAsync()`), Data Syncs history & undo, Saved Filters (VIP), Year/Month in Review, Favorites (`client.Sync.GetFavoritesAsync()`), Blocked Users, Follow Requests, and User Hidden Items.

- **Migration to Concrete Record Data Models (Zero-Allocation Architecture)**
  - Replaced all legacy `ITrakt...` data model interfaces with strongly-typed C# `record class` types (`TraktShow`, `TraktMovie`, `TraktEpisode`, `TraktSeason`, `TraktPerson`, `TraktUser`, `TraktList`, etc.).
  - Unified root namespace to `TraktNET`.
  - Zero allocation overhead, enhanced type safety, and native record immutability.

- **Comprehensive Media Image Support**
  - Full support for retrieving media image URLs across all Trakt objects (Shows, Movies, Seasons, Episodes, People, Users, Lists).
  - Introduced `TraktExtendedInfo.Images` to query image metadata in API requests.
  - Concrete image data models (`TraktShowImages`, `TraktMovieImages`, `TraktEpisodeImages`, `TraktSeasonImages`, `TraktPersonImages`, `TraktUserImages`, `TraktListImages`).

- **High-Performance System.Text.Json Source Generation (`Trakt.NET.SourceGeneration`)**
  - Custom Roslyn Source Generator generating compile-time `System.Text.Json` serializer contexts with zero reflection.
  - Significantly reduced startup latency and memory footprint for JSON serialization and deserialization.

- **Full Native AOT & Assembly Trimming Compatibility**
  - Built with `IsTrimmable` (.NET 6+) and `IsAotCompatible` (.NET 8+) enabled.
  - Fully compatible with ahead-of-time (Native AOT) compilation in modern .NET applications.

- **Modern .NET Target Frameworks Support**
  - Native target support for .NET 6.0, .NET 7.0, .NET 8.0, .NET 9.0, and .NET 10.0, as well as .NET Standard 2.0 / 2.1 and .NET Framework 4.7.2 / 4.8.1.

- **Modernized Testing Suite**
  - Comprehensive unit test suite with 75,000+ tests covering all modules, JSON readers/writers, request builders, and source generation.
