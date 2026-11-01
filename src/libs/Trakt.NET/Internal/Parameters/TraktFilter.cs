using System.Globalization;

namespace TraktNET
{
    public sealed partial class TraktFilter
    {
        private const string QueryName = "query";
        private const string YearsName = "years";
        private const string GenresName = "genres";
        private const string SubgenresName = "subgenres";
        private const string LanguagesName = "languages";
        private const string CountriesName = "countries";
        private const string RuntimesName = "runtimes";
        private const string StudioIDsName = "studio_ids";
        private const string RatingsName = "ratings";
        private const string VotesName = "votes";
        private const string TMDBRatingsName = "tmdb_ratings";
        private const string TMDBVotesName = "tmdb_votes";
        private const string IMDBRatingsName = "imdb_ratings";
        private const string IMDBVotesName = "imdb_votes";
        private const string RottenTomatoesMetersName = "rt_meters";
        private const string RottenTomatoesUserMetersName = "rt_user_meters";
        private const string MetascoresName = "metascores";
        private const string CertificationsName = "certifications";
        private const string NetworkIDsName = "network_ids";
        private const string StatusName = "status";
        private const string EpisodeTypesName = "episode_types";
        private const string HideName = "hide";
        private const string IgnoreWatchedName = "ignore_watched";
        private const string IgnoreCollectedName = "ignore_collected";
        private const string IgnoreWatchlistedName = "ignore_watchlisted";
        private const string StartDateName = "start_date";
        private const string EndDateName = "end_date";
        private const string ParentalNudityName = "parental_nudity";
        private const string ParentalViolenceName = "parental_violence";
        private const string ParentalProfanityName = "parental_profanity";
        private const string ParentalAlcoholName = "parental_alcohol";
        private const string ParentalFrighteningName = "parental_frightening";
        private const string ParentalIncludeUnratedName = "parental_include_unrated";
        private const string StudiosName = "studios";
        private const string PeopleName = "people";
        private const string PeopleOperatorName = "people_operator";
        private const string PeopleRoleName = "people_role";
        private const string ReleasedWithinDaysName = "released_within_days";
        private const string ThemeName = "theme";

        public override string ToString()
        {
            var values = new List<string>();

            AddText(values, QueryName, Query);

            if (Year.HasValue && !Years.HasValue)
                values.Add($"{YearsName}={Year.Value}");
            else
                AddRange(values, Years, YearsName);

            AddJoined(values, GenresName, Genres);
            AddJoined(values, SubgenresName, Subgenres);
            AddJoined(values, LanguagesName, Languages);
            AddJoined(values, CountriesName, Countries);
            AddRange(values, Runtimes, RuntimesName);
            AddJoined(values, StudioIDsName, StudioIDs);
            AddRange(values, Ratings, RatingsName);
            AddRange(values, Votes, VotesName);
            AddRange(values, TMDBRatings, TMDBRatingsName);
            AddRange(values, TMDBVotes, TMDBVotesName);
            AddRange(values, IMDBRatings, IMDBRatingsName);
            AddRange(values, IMDBVotes, IMDBVotesName);
            AddRange(values, RottenTomatoesMeters, RottenTomatoesMetersName);
            AddRange(values, RottenTomatoesUserMeters, RottenTomatoesUserMetersName);
            AddRange(values, Metascores, MetascoresName);
            AddJoined(values, CertificationsName, Certifications);
            AddJoined(values, NetworkIDsName, NetworkIDs);
            AddEnumValues(values, StatusName, Status, TraktShowStatus.Unspecified, status => status.ToJson());
            AddEnumValues(values, EpisodeTypesName, EpisodeTypes, TraktEpisodeType.Unspecified, episodeType => episodeType.ToJson());
            AddEnumValue(values, HideName, Hide, TraktFilterHide.Unspecified, hide => hide.ToJson());
            AddBool(values, IgnoreWatchedName, IgnoreWatched);
            AddBool(values, IgnoreCollectedName, IgnoreCollected);
            AddBool(values, IgnoreWatchlistedName, IgnoreWatchlisted);

            if (StartDate.HasValue)
                values.Add($"{StartDateName}={StartDate.Value.ToTraktSortDateTimeString()}");

            if (EndDate.HasValue)
                values.Add($"{EndDateName}={EndDate.Value.ToTraktSortDateTimeString()}");

            AddParentalRange(values, ParentalNudity, ParentalNudityName);
            AddParentalRange(values, ParentalViolence, ParentalViolenceName);
            AddParentalRange(values, ParentalProfanity, ParentalProfanityName);
            AddParentalRange(values, ParentalAlcohol, ParentalAlcoholName);
            AddParentalRange(values, ParentalFrightening, ParentalFrighteningName);
            AddBool(values, ParentalIncludeUnratedName, ParentalIncludeUnrated);
            AddJoined(values, StudiosName, Studios);
            AddJoined(values, PeopleName, People);
            AddEnumValue(values, PeopleOperatorName, PeopleOperator, TraktFilterOperator.Unspecified, peopleOperator => peopleOperator.ToJson());
            AddEnumValue(values, PeopleRoleName, PeopleRole, TraktPeopleRole.Unspecified, peopleRole => peopleRole.ToJson());

            if (ReleasedWithinDays.HasValue)
                values.Add($"{ReleasedWithinDaysName}={ReleasedWithinDays.Value}");

            AddText(values, ThemeName, Theme);

            return string.Join("&", values);
        }

        private static void AddText(List<string> values, string name, string? value)
        {
            if (!string.IsNullOrEmpty(value))
                values.Add($"{name}={value}");
        }

        private static void AddJoined<T>(List<string> values, string name, T[]? items)
        {
            if (items != null && items.Length > 0)
                values.Add($"{name}={string.Join(",", items)}");
        }

        private static void AddBool(List<string> values, string name, bool? value)
        {
            if (value.HasValue)
                values.Add($"{name}={value.Value.ToString().ToLower(CultureInfo.CurrentCulture)}");
        }

        /// <summary>Adds the JSON values of all specified enum items, skipping the given unspecified value.</summary>
        private static void AddEnumValues<TEnum>(List<string> values, string name, TEnum[]? items, TEnum unspecified, Func<TEnum, string?> toJson)
            where TEnum : struct, Enum
        {
            if (items == null || items.Length == 0)
                return;

            IEnumerable<string?> jsonValues = items
                .Where(item => !EqualityComparer<TEnum>.Default.Equals(item, unspecified))
                .Select(toJson);

            values.Add($"{name}={string.Join(",", jsonValues)}");
        }

        /// <summary>Adds the JSON value of the specified enum value, if it is set, not unspecified and has a JSON representation.</summary>
        private static void AddEnumValue<TEnum>(List<string> values, string name, TEnum? value, TEnum unspecified, Func<TEnum, string?> toJson)
            where TEnum : struct, Enum
        {
            if (!value.HasValue || EqualityComparer<TEnum>.Default.Equals(value.Value, unspecified))
                return;

            string? json = toJson(value.Value);

            if (!string.IsNullOrEmpty(json))
                values.Add($"{name}={json}");
        }

        private static void AddParentalRange(List<string> values, Range<uint>? range, string name)
        {
            if (range.HasValue)
            {
                uint firstValue = range.Value.From;
                uint secondValue = range.Value.To;

                if (firstValue <= secondValue)
                {
                    values.Add($"{name}={firstValue}-{secondValue}");
                }
                else
                {
                    values.Add($"{name}={secondValue}-{firstValue}");
                }
            }
        }

        private static void AddRange(List<string> values, Range<uint>? range, string name)
        {
            if (range.HasValue && range.Value.From > 0 && range.Value.To > 0)
            {
                uint firstValue = range.Value.From;
                uint secondValue = range.Value.To;

                if (firstValue <= secondValue)
                {
                    values.Add($"{name}={firstValue}-{secondValue}");
                }
                else
                {
                    values.Add($"{name}={secondValue}-{firstValue}");
                }
            }
        }

        private static void AddRange(List<string> values, Range<float>? range, string name)
        {
            if (range.HasValue && range.Value.From > 0 && range.Value.To > 0)
            {
                float firstValue = range.Value.From;
                float secondValue = range.Value.To;

                if (firstValue <= secondValue)
                {
                    values.Add($"{name}={firstValue.ToString(CultureInfo.InvariantCulture)}-{secondValue.ToString(CultureInfo.InvariantCulture)}");
                }
                else
                {
                    values.Add($"{name}={secondValue.ToString(CultureInfo.InvariantCulture)}-{firstValue.ToString(CultureInfo.InvariantCulture)}");
                }
            }
        }
    }
}
