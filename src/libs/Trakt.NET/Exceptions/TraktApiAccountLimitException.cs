namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a user has exceeded their account limits.</summary>
    public sealed partial class TraktApiAccountLimitException : TraktApiException
    {
        /// <summary>URL where the user can sign up for Trakt VIP.</summary>
        public string UpgradeURL { get; }

        /// <summary>User's VIP status.</summary>
        public bool IsVIPUser { get; }

        /// <summary>User's account limit.</summary>
        public uint AccountLimit { get; }
    }
}
