namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the authorized user does not have VIP support.</summary>
    public sealed partial class TraktApiVIPValidationException : TraktApiException
    {
        /// <summary>URL where the user can sign up for Trakt VIP.</summary>
        public string UpgradeURL { get; }
    }
}
