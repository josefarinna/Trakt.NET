namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>Gets collection progress for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="hidden"> If <see langword="true"/>, include hidden episodes in the progress results.</param>
        /// <param name="specials"> If <see langword="true"/>, include special episodes in the progress results.</param>
        /// <param name="countSpecials"> If <see langword="true"/>, count specials when calculating collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para/>If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the collection progress information.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowCollectionProgress" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/shows/collection-progress/get-show-collection-progresss">
        /// Trakt API Documentation: Shows: Collection - Get show collection progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowCollectionProgress>> GetShowCollectionProgressAsync(string traktShowIDOrSlug, bool? hidden = null, bool? specials = null, bool? countSpecials = null,
            CancellationToken cancellationToken = default)
            => GetShowCollectionProgressImplAsync(traktShowIDOrSlug, hidden, specials, countSpecials, cancellationToken);

        /// <summary>Gets collection progress for a <see cref="TraktShow" /> with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="hidden"> If <see langword="true"/>, include hidden episodes in the progress results.</param>
        /// <param name="specials"> If <see langword="true"/>, include special episodes in the progress results.</param>
        /// <param name="countSpecials"> If <see langword="true"/>, count specials when calculating collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para/>If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the collection progress information.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowCollectionProgress" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">
        /// Trakt API Documentation: Shows: Collection - Get show collection progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowCollectionProgress>> GetShowCollectionProgressAsync(uint traktShowID, bool? hidden = null, bool? specials = null, bool? countSpecials = null,
            CancellationToken cancellationToken = default)
            => GetShowCollectionProgressImplAsync(traktShowID.ToInvariantCultureString(), hidden, specials, countSpecials, cancellationToken);

        /// <summary>Gets collection progress for a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="hidden"> If <see langword="true"/>, include hidden episodes in the progress results.</param>
        /// <param name="specials"> If <see langword="true"/>, include special episodes in the progress results.</param>
        /// <param name="countSpecials"> If <see langword="true"/>, count specials when calculating collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para/>If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the collection progress information.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktShowCollectionProgress" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">
        /// Trakt API Documentation: Shows: Collection - Get show collection progress
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktShowCollectionProgress>> GetShowCollectionProgressAsync(TraktShowIDs showIDs, bool? hidden = null, bool? specials = null, bool? countSpecials = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetShowCollectionProgressImplAsync(showIDs.BestID, hidden, specials, countSpecials, cancellationToken);
        }
    }
}
