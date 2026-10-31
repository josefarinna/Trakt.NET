namespace TraktNET
{
    internal static class ArgumentValidator
    {
        internal static void ThrowIfNullOrWhiteSpace(string? value, string message, bool checkSpaces = false)
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (checkSpaces && value.ContainsSpace())
                throw new ArgumentException(message, nameof(value));
#else
            if (string.IsNullOrWhiteSpace(value) || (checkSpaces && value!.ContainsSpace()))
                throw new ArgumentException(message, nameof(value));
#endif
        }

        /// <summary>
        /// Validates an optional value: null is allowed, but if provided it must not be empty, whitespace or contain spaces.
        /// </summary>
        internal static void ThrowIfProvidedAndInvalid(string? value, string message)
        {
            if (value != null && (string.IsNullOrWhiteSpace(value) || value.ContainsSpace()))
                throw new ArgumentException(message, nameof(value));
        }

        internal static void ThrowIfNull<T>(T? argument)
#if NETSTANDARD2_0 || NETSTANDARD2_1 || NET5_0
        {
            if (argument is null)
                throw new ArgumentNullException(nameof(argument));
        }
#else
            => ArgumentNullException.ThrowIfNull(argument);
#endif
    }
}
