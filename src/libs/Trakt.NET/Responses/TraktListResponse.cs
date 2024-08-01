using System.Collections;

namespace TraktNET
{
    public partial class TraktListResponse<T> : TraktResponse<IReadOnlyList<T>>, IReadOnlyList<T>
    {
        public T this[int index]
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

        public IEnumerator<T> GetEnumerator()
        {
            if (Content == null)
            {
                throw new InvalidOperationException("Invalid access to non existing list.");
            }

            return Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator bool(TraktListResponse<T> response) => response.IsSuccess && response.HasValue;
    }
}
