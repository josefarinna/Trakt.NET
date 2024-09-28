namespace TraktNET
{
    /// <summary>Determines the type of an video item.</summary>
    [TraktEnum(JsonSeparator = " ")]
    public enum TraktVideoType
    {
        /// <summary>An invalid video type.</summary>
        Unspecified,

        /// <summary>The video features footage of the cast and the crew on set during the production.</summary>
        BehindTheScenes,

        /// <summary>The video is a montage of mistakes and other amusing moments featuring the cast and crew during filming.</summary>
        Bloopers,

        /// <summary>The video is any scene from a movie or show.</summary>
        Clip,

        /// <summary>The video represents any material that is not a trailer, a teaser, a behind the scenes or a clip.</summary>
        Featurette,

        /// <summary>The video features the on-screen title as well as the main cast and crew credits.</summary>
        OpeningCredits,

        /// <summary>The video is a recap.</summary>
        Recap,

        /// <summary>The video is a teaser, which is usually shorter than a trailer.</summary>
        Teaser,

        /// <summary>The video is a trailer.</summary>
        Trailer
    }
}
