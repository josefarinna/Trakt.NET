using System.Collections;

namespace TraktNET
{
    public partial class TraktListResponse<TResponseContentType> : TraktResponse<IReadOnlyList<TResponseContentType>>, IReadOnlyList<TResponseContentType>
    {
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

        public int Count => Content?.Count ?? 0;

        public IEnumerator<TResponseContentType> GetEnumerator()
        {
            if (Content == null)
            {
                throw new InvalidOperationException("Invalid access to non existing list.");
            }

            return Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator bool(TraktListResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
