using System.Security.Cryptography;
using System.Text;

namespace TraktNET
{
    /// <summary>
    /// Represents a generated PKCE challenge pair containing the code verifier, code challenge, and code challenge method.
    /// </summary>
    /// <param name="CodeVerifier">The cryptographically random code verifier.</param>
    /// <param name="CodeChallenge">The SHA-256 derived code challenge encoded as URL-safe base64 without padding.</param>
    /// <param name="CodeChallengeMethod">The code challenge method (defaults to "S256").</param>
    public sealed record class TraktPKCEChallenge(string CodeVerifier, string CodeChallenge, string CodeChallengeMethod = TraktPKCE.S256);

    /// <summary>
    /// Helper for Proof Key for Code Exchange (PKCE) according to RFC 7636.
    /// </summary>
    public static class TraktPKCE
    {
        /// <summary>The SHA-256 code challenge method name.</summary>
        public const string S256 = "S256";

        /// <summary>
        /// Creates a new cryptographically random <see cref="TraktPKCEChallenge" /> pair using SHA-256 ("S256").
        /// </summary>
        /// <param name="byteLength">
        /// The number of random bytes to generate for the verifier. Must be between 32 and 96.
        /// Defaults to 32 (producing a 43-character verifier).
        /// </param>
        /// <returns>A new <see cref="TraktPKCEChallenge" /> containing the verifier, challenge, and method.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="byteLength" /> is less than 32 or greater than 96.</exception>
        public static TraktPKCEChallenge Create(int byteLength = 32)
        {
            string verifier = GenerateCodeVerifier(byteLength);
            string challenge = CalculateCodeChallenge(verifier);
            return new TraktPKCEChallenge(verifier, challenge, S256);
        }

        /// <summary>
        /// Generates a cryptographically secure random code verifier according to RFC 7636.
        /// </summary>
        /// <param name="byteLength">
        /// The number of random bytes to generate. Must be between 32 and 96.
        /// Defaults to 32, which results in a 43-character string.
        /// </param>
        /// <returns>A URL-safe base64-encoded string without padding.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="byteLength" /> is less than 32 or greater than 96.</exception>
        public static string GenerateCodeVerifier(int byteLength = 32)
        {
            if (byteLength < 32 || byteLength > 96)
                throw new ArgumentOutOfRangeException(nameof(byteLength), "byte length must be between 32 and 96");

            byte[] bytes = new byte[byteLength];
#if NETSTANDARD2_0
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
#else
            RandomNumberGenerator.Fill(bytes);
#endif
            return Base64UrlEncode(bytes);
        }

        /// <summary>
        /// Calculates the SHA-256 code challenge for the given <paramref name="codeVerifier" /> according to RFC 7636.
        /// </summary>
        /// <param name="codeVerifier">The code verifier string.</param>
        /// <returns>The URL-safe base64-encoded SHA-256 hash without padding.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="codeVerifier" /> is null, empty, outside 43-128 characters,
        /// or contains characters other than <c>[A-Za-z0-9-._~]</c>.
        /// </exception>
        public static string CalculateCodeChallenge(string codeVerifier)
        {
            ThrowIfInvalidCodeVerifier(codeVerifier, nameof(codeVerifier));

            byte[] asciiBytes = Encoding.ASCII.GetBytes(codeVerifier);
#if NET5_0_OR_GREATER
            byte[] hash = SHA256.HashData(asciiBytes);
#else
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(asciiBytes);
#endif
            return Base64UrlEncode(hash);
        }

        /// <summary>
        /// Checks whether <paramref name="codeVerifier" /> is a valid code verifier according to RFC 7636, section 4.1:
        /// 43-128 characters from the unreserved set <c>[A-Za-z0-9-._~]</c>.
        /// </summary>
        internal static bool IsValidCodeVerifier(string? codeVerifier)
        {
            if (codeVerifier is null || codeVerifier.Length < 43 || codeVerifier.Length > 128)
                return false;

            foreach (char c in codeVerifier)
            {
                bool isUnreserved = c is (>= 'A' and <= 'Z') or (>= 'a' and <= 'z') or (>= '0' and <= '9') or '-' or '.' or '_' or '~';

                if (!isUnreserved)
                    return false;
            }

            return true;
        }

        internal static void ThrowIfInvalidCodeVerifier(string? codeVerifier, string paramName)
        {
            if (!IsValidCodeVerifier(codeVerifier))
                throw new ArgumentException("code verifier not valid - must be 43-128 characters of [A-Za-z0-9-._~]", paramName);
        }

        private static string Base64UrlEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes)
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
        }
    }
}
