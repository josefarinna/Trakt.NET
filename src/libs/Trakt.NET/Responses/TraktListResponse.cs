using System.Collections;

namespace TraktNET
{
    /// <summary>A Trakt list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public partial class TraktListResponse<TResponseContentType> : TraktResponse<IReadOnlyList<TResponseContentType>>, IReadOnlyList<TResponseContentType>
    {
        /// <summary>Gets the item at the specified <paramref name="index" />.</summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns>The item at the specified index in the response.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="TraktResponse{TResponseContentType}.Content" /> is null.</exception>
        public TResponseContentType this[int index]
        {
            get
            {
                if (Content == null)
                {
                    throw new InvalidOperationException("Invalid access to non existing list.");
                }

                return Content[index];
            }
        }

        /// <summary>The number of items in the response.</summary>
        public int Count => Content?.Count ?? 0;

        /// <inheritdoc />
        public IEnumerator<TResponseContentType> GetEnumerator()
        {
            if (Content == null)
            {
                throw new InvalidOperationException("Invalid access to non existing list.");
            }

            return Content.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>Implicit conversion to bool for this response.</summary>
        /// <param name="response">The <see cref="TraktListResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktListResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
