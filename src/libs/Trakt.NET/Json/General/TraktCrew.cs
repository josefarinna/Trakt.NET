using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of crew members in different categories.</summary>
    public record class TraktCrew
    {
        /// <summary>A list of crew members in the sound category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Sound { get; set; }

        /// <summary>A list of crew members in the production category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Production { get; set; }

        /// <summary>A list of crew members in the editing category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Editing { get; set; }

        /// <summary>A list of crew members in the art category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Art { get; set; }

        /// <summary>A list of crew members in the costume &amp; make-up category. See also <seealso cref="TraktCrewMember" />.</summary>
        [JsonPropertyName("costume & make-up")]
        public List<TraktCrewMember>? CostumeAndMakeUp { get; set; }

        /// <summary>A list of miscellaneous crew members. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Crew { get; set; }

        /// <summary>A list of crew members in the writing category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Writing { get; set; }

        /// <summary>A list of crew members in the camera category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Camera { get; set; }

        /// <summary>A list of crew members in the visual effects category. See also <seealso cref="TraktCrewMember" />.</summary>
        [JsonPropertyName("visual effects")]
        public List<TraktCrewMember>? VisualEffects { get; set; }

        /// <summary>A list of crew members in the directing category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Directing { get; set; }

        /// <summary>A list of crew members in the lighting category. See also <seealso cref="TraktCrewMember" />.</summary>
        public List<TraktCrewMember>? Lighting { get; set; }
    }
}
