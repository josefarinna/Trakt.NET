namespace TraktNET
{
    /// <summary>An episode custom list post.</summary>
    public record class TraktUserPersonalListPost
    {
        /// <summary>Gets or sets the required name of the custom list.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the optional description of the custom list.</summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the optional privacy setting of the custom list.
        /// See also <seealso cref="TraktListPrivacy" />.
        /// </summary>
        public TraktListPrivacy? Privacy { get; set; }

        /// <summary>Gets or sets, whether the custom list should display numbers.</summary>
        public bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the custom list allows comments.</summary>
        public bool? AllowComments { get; set; }

        /// <summary>
        /// Gets or sets the custom list sort-by setting.
        /// See also <seealso cref="TraktSortBy" />.
        /// </summary>
        public TraktSortBy? SortBy { get; set; }

        /// <summary>
        /// Gets or sets the custom list sort-how setting.
        /// See also <seealso cref="TraktSortHow" />.
        /// </summary>
        public TraktSortHow? SortHow { get; set; }

        public void Validate()
        {
            if (Name == null)
                throw new TraktPostValidationException(nameof(Name), "list name must not be null");

            if (Name.Length == 0)
                throw new TraktPostValidationException(nameof(Name), "list name must not be empty");

            if (Privacy != null && Privacy == TraktListPrivacy.Unspecified)
                throw new TraktPostValidationException(nameof(Privacy), "Privacy must not be unspecified");
        }

        /// <summary>Returns whether the post has any values set.</summary>
        public bool HasAnyValuesSet()
        {
            return !string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Description)
                || (Privacy != null && Privacy != TraktListPrivacy.Unspecified)
                || DisplayNumbers.HasValue || AllowComments.HasValue
                || (SortBy != null && SortBy != TraktSortBy.Unspecified)
                || (SortHow != null && SortHow != TraktSortHow.Unspecified);
        }
    }
}
