namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if validation of a post object fails.</summary>
    public partial class TraktPostValidationException : TraktException
    {
        /// <summary>The name of the proeprty that caused the current exception.</summary>
        public string? PropertyName { get; }
    }
}
