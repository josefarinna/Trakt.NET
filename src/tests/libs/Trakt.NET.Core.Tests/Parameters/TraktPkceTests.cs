namespace TraktNET.Parameters
{
    public sealed class TraktPkceTests
    {
        [Fact]
        public void TestTraktPkceChallengeRFC7636TestVector()
        {
            // RFC 7636 Appendix B test vector:
            const string codeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";
            const string expectedCodeChallenge = "E9Melhoa2OwvFrEMTJguCHaoeK1t8URWbuGJSstw-cM";

            string calculatedChallenge = TraktPkce.CalculateCodeChallenge(codeVerifier);
            calculatedChallenge.ShouldBe(expectedCodeChallenge);
        }

        [Fact]
        public void TestTraktPkceCreate()
        {
            TraktPkceChallenge challenge = TraktPkce.Create();

            challenge.ShouldNotBeNull();
            challenge.CodeVerifier.ShouldNotBeNullOrEmpty();
            challenge.CodeChallenge.ShouldNotBeNullOrEmpty();
            challenge.CodeChallengeMethod.ShouldBe(TraktPkce.S256);

            // 32 bytes produce exactly 43 Base64URL characters without padding
            challenge.CodeVerifier.Length.ShouldBe(43);
            challenge.CodeChallenge.Length.ShouldBe(43);

            string expectedChallenge = TraktPkce.CalculateCodeChallenge(challenge.CodeVerifier);
            challenge.CodeChallenge.ShouldBe(expectedChallenge);
        }

        [Fact]
        public void TestTraktPkceGenerateCodeVerifierLengths()
        {
            string verifier32 = TraktPkce.GenerateCodeVerifier(32);
            verifier32.Length.ShouldBe(43);

            string verifier64 = TraktPkce.GenerateCodeVerifier(64);
            verifier64.Length.ShouldBe(86);

            string verifier96 = TraktPkce.GenerateCodeVerifier(96);
            verifier96.Length.ShouldBe(128);

            // Verifiers must only contain unreserved characters [A-Z], [a-z], [0-9], '-', '_'
            verifier32.ShouldNotContain(' ');
            verifier32.ShouldNotContain('+');
            verifier32.ShouldNotContain('/');
            verifier32.ShouldNotContain('=');
        }

        [Fact]
        public void TestTraktPkceGenerateCodeVerifierThrowsOnInvalidByteLength()
        {
            Action act = () => TraktPkce.GenerateCodeVerifier(31);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => TraktPkce.GenerateCodeVerifier(97);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => TraktPkce.Create(16);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestTraktPkceCalculateCodeChallengeThrowsOnInvalidVerifier()
        {
            Action act = () => TraktPkce.CalculateCodeChallenge(null!);
            act.ShouldThrow<ArgumentException>();

            act = () => TraktPkce.CalculateCodeChallenge(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => TraktPkce.CalculateCodeChallenge("   ");
            act.ShouldThrow<ArgumentException>();

            // Less than 43 characters
            act = () => TraktPkce.CalculateCodeChallenge(new string('a', 42));
            act.ShouldThrow<ArgumentException>();

            // Greater than 128 characters
            act = () => TraktPkce.CalculateCodeChallenge(new string('a', 129));
            act.ShouldThrow<ArgumentException>();

            // Contains spaces
            act = () => TraktPkce.CalculateCodeChallenge(new string('a', 42) + " ");
            act.ShouldThrow<ArgumentException>();
        }

        // Every alternative of the unreserved check, including the inclusive range boundaries.
        [Theory]
        [InlineData('A')]
        [InlineData('M')]
        [InlineData('Z')]
        [InlineData('a')]
        [InlineData('m')]
        [InlineData('z')]
        [InlineData('0')]
        [InlineData('5')]
        [InlineData('9')]
        [InlineData('-')]
        [InlineData('.')]
        [InlineData('_')]
        [InlineData('~')]
        public void TestTraktPkceCalculateCodeChallengeAcceptsUnreservedCharacter(char validChar)
        {
            Action act = () => TraktPkce.CalculateCodeChallenge(new string(validChar, 43));
            act.ShouldNotThrow();
        }

        // Characters just outside each range ('@' < 'A', '[' > 'Z', '`' < 'a', '{' > 'z', '/' < '0', ':' > '9')
        // and other reserved / non-ASCII characters.
        [Theory]
        [InlineData('@')]
        [InlineData('[')]
        [InlineData('`')]
        [InlineData('{')]
        [InlineData('/')]
        [InlineData(':')]
        [InlineData('+')]
        [InlineData('=')]
        [InlineData('!')]
        [InlineData('%')]
        [InlineData(',')]
        [InlineData('ñ')]
        [InlineData('\t')]
        public void TestTraktPkceCalculateCodeChallengeThrowsOnInvalidCharacter(char invalidChar)
        {
            Action act = () => TraktPkce.CalculateCodeChallenge(new string('a', 42) + invalidChar);
            act.ShouldThrow<ArgumentException>();

            // Invalid character at the start, so the check does not depend on the position
            act = () => TraktPkce.CalculateCodeChallenge(invalidChar + new string('a', 42));
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestTraktPkceCalculateCodeChallengeAcceptsBoundaryLengthsAndUnreservedCharacters()
        {
            Action act = () => TraktPkce.CalculateCodeChallenge(new string('a', 43));
            act.ShouldNotThrow();

            act = () => TraktPkce.CalculateCodeChallenge(new string('a', 128));
            act.ShouldNotThrow();

            // All unreserved characters: ALPHA / DIGIT / "-" / "." / "_" / "~"
            act = () => TraktPkce.CalculateCodeChallenge("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~");
            act.ShouldNotThrow();
        }
    }
}
