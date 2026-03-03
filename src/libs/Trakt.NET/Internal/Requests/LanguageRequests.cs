namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("languages")]
    internal sealed partial class ListLanguagesGetRequest
    {
        [TraktRequestParameter]
        public TraktLanguageItemType LanguageType { get; set; }
    }
}
