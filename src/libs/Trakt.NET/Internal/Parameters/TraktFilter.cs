using System.Globalization;

namespace TraktNET
{
    public sealed partial class TraktFilter
    {
        private const string QueryName = "query";
        private const string YearsName = "years";
        private const string GenresName = "genres";
        private const string LanguagesName = "languages";
        private const string CountriesName = "countries";
        private const string RuntimesName = "runtimes";
        private const string StudioIdsName = "studio_ids";
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
        private const string NetworkIdsName = "network_ids";
        private const string StatusName = "status";
        private const string EpisodeTypesName = "episode_types";

        public override string ToString()
        {
            var values = new List<string>();

            if (!string.IsNullOrEmpty(Query))
            {
                values.Add($"{QueryName}={Query}");
            }

            if (Year.HasValue && !Years.HasValue)
            {
                values.Add($"{YearsName}={Year.Value}");
            }
            else
            {
                AddRange(values, Years, YearsName);
            }

            if (Genres != null && Genres.Length > 0)
            {
                values.Add($"{GenresName}={string.Join(",", Genres)}");
            }

            if (Languages != null && Languages.Length > 0)
            {
                values.Add($"{LanguagesName}={string.Join(",", Languages)}");
            }

            if (Countries != null && Countries.Length > 0)
            {
                values.Add($"{CountriesName}={string.Join(",", Countries)}");
            }

            AddRange(values, Runtimes, RuntimesName);

            if (StudioIds != null && StudioIds.Length > 0)
            {
                values.Add($"{StudioIdsName}={string.Join(",", StudioIds)}");
            }

            AddRange(values, Ratings, RatingsName);
            AddRange(values, Votes, VotesName);
            AddRange(values, TMDBRatings, TMDBRatingsName);
            AddRange(values, TMDBVotes, TMDBVotesName);
            AddRange(values, IMDBRatings, IMDBRatingsName);
            AddRange(values, IMDBVotes, IMDBVotesName);
            AddRange(values, RottenTomatoesMeters, RottenTomatoesMetersName);
            AddRange(values, RottenTomatoesUserMeters, RottenTomatoesUserMetersName);
            AddRange(values, Metascores, MetascoresName);

            if (Certifications != null && Certifications.Length > 0)
            {
                values.Add($"{CertificationsName}={string.Join(",", Certifications)}");
            }

            if (NetworkIds != null && NetworkIds.Length > 0)
            {
                values.Add($"{NetworkIdsName}={string.Join(",", NetworkIds)}");
            }

            if (Status != null && Status.Length > 0)
            {
                var statusValues = new List<string>();

                foreach (TraktShowStatus status in Status)
                {
                    if (status != TraktShowStatus.Unspecified)
                    {
                        statusValues.Add(status.ToJson()!);
                    }
                }

                values.Add($"{StatusName}={string.Join(",", statusValues)}");
            }

            if (EpisodeTypes != null && EpisodeTypes.Length > 0)
            {
                var episodeTypesValues = new List<string>();

                foreach (TraktEpisodeType episodeType in EpisodeTypes)
                {
                    if (episodeType != TraktEpisodeType.Unspecified)
                    {
                        episodeTypesValues.Add(episodeType.ToJson()!);
                    }
                }

                values.Add($"{EpisodeTypesName}={string.Join(",", episodeTypesValues)}");
            }

            return string.Join("&", values);
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
