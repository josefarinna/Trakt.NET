using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktCollectionUser
    {
        /// <summary>Gets or sets the following / followed Trakt user. See also <seealso cref="TraktUser" />.</summary>
        public TraktUser? User { get; set; }

        /// <summary>Gets or sets the user's username.</summary>
        [JsonIgnore]
        public string? Username
        {
            get => User?.Username;
            set => User?.Username = value;
        }

        /// <summary>Gets or sets the user's privacy status.</summary>
        [JsonIgnore]
        public bool? Private
        {
            get => User?.Private;
            set => User?.Private = value;
        }

        /// <summary>Gets or sets the user's deleted status.</summary>
        [JsonIgnore]
        public bool? Deleted
        {
            get => User?.Deleted;
            set => User?.Deleted = value;
        }

        /// <summary>Gets or sets the collection of ids for the user. See also <seealso cref="TraktUserIDs" />.</summary>
        [JsonIgnore]
        public TraktUserIDs? IDs
        {
            get => User?.IDs;
            set => User?.IDs = value;
        }

        /// <summary>Gets or sets the user's name.</summary>
        [JsonIgnore]
        public string? Name
        {
            get => User?.Name;
            set => User?.Name = value;
        }

        /// <summary>Gets or sets the user's VIP status.</summary>
        [JsonIgnore]
        public bool? VIP
        {
            get => User?.VIP;
            set => User?.VIP = value;
        }

        /// <summary>Gets or sets the user's VIP EP status.</summary>
        [JsonIgnore]
        public bool? VIPEP
        {
            get => User?.VIPEP;
            set => User?.VIPEP = value;
        }

        /// <summary>Gets or sets the UTC datetime when the user joined Trakt.</summary>
        [JsonIgnore]
        public DateTime? JoinedAt
        {
            get => User?.JoinedAt;
            set => User?.JoinedAt = value;
        }

        /// <summary>Gets or sets the user's location.</summary>
        [JsonIgnore]
        public string? Location
        {
            get => User?.Location;
            set => User?.Location = value;
        }

        /// <summary>Gets or sets the user's about information.</summary>
        [JsonIgnore]
        public string? About
        {
            get => User?.About;
            set => User?.About = value;
        }

        /// <summary>Gets or sets the user's gender.</summary>
        [JsonIgnore]
        public TraktGender? Gender
        {
            get => User?.Gender;
            set => User?.Gender = value;
        }

        /// <summary>Gets or sets the user's age.</summary>
        [JsonIgnore]
        public uint? Age
        {
            get => User?.Age;
            set => User?.Age = value;
        }

        /// <summary>Gets or sets the collection of images for the user. See also <seealso cref="TraktUserImages" />.</summary>
        [JsonIgnore]
        public TraktUserImages? Images
        {
            get => User?.Images;
            set => User?.Images = value;
        }

        /// <summary>Gets or sets the user's VIP OG status.</summary>
        [JsonIgnore]
        public bool? VIPOG
        {
            get => User?.VIPOG;
            set => User?.VIPOG = value;
        }

        /// <summary>Gets or sets the user's VIP years.</summary>
        [JsonIgnore]
        public uint? VIPYears
        {
            get => User?.VIPYears;
            set => User?.VIPYears = value;
        }

        /// <summary>Gets or sets the user's VIP cover image.</summary>
        [JsonIgnore]
        public string? VIPCoverImage
        {
            get => User?.VIPCoverImage;
            set => User?.VIPCoverImage = value;
        }

        /// <summary>Gets or sets the UTC datetime when the user's unbroken paid VIP status started.</summary>
        [JsonIgnore]
        public DateTime? VIPVeteranSince
        {
            get => User?.VIPVeteranSince;
            set => User?.VIPVeteranSince = value;
        }

        /// <summary>Gets or sets the whole years since the user's unbroken paid VIP status started.</summary>
        [JsonIgnore]
        public uint? VIPVeteranYears
        {
            get => User?.VIPVeteranYears;
            set => User?.VIPVeteranYears = value;
        }

        /// <summary>Gets or sets the highest reached rung of the 1 / 3 / 5 / 7 / 10 year ladder for the user's VIP status.</summary>
        [JsonIgnore]
        public uint? VIPVeteranTier
        {
            get => User?.VIPVeteranTier;
            set => User?.VIPVeteranTier = value;
        }

        /// <summary>Gets or sets the VIP veteran title for the user. See also <seealso cref="TraktVIPVeteranTitle" />.</summary>
        [JsonIgnore]
        public TraktVIPVeteranTitle? VIPVeteranTitle
        {
            get => User?.VIPVeteranTitle;
            set => User?.VIPVeteranTitle = value;
        }

        /// <summary>Gets or sets the UTC datetime when the user's VIP grace period ends.</summary>
        [JsonIgnore]
        public DateTime? VIPGraceEndsAt
        {
            get => User?.VIPGraceEndsAt;
            set => User?.VIPGraceEndsAt = value;
        }

        /// <summary>Gets or sets the user's email address.</summary>
        [JsonIgnore]
        public string? Email
        {
            get => User?.Email;
            set => User?.Email = value;
        }
    }
}
