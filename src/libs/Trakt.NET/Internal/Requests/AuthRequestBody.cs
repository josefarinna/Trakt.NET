namespace TraktNET
{
    internal sealed class AuthorizationPollRequestBody
    {
        internal required TraktDevice Device { get; set; }

        internal required string ClientId { get; set; }

        internal required string ClientSecret { get; set; }

        public string ToJson() => HttpContentAsString;

        private string HttpContentAsString => $$"""
        {
            "code": "{{Device.DeviceCode}}",
            "client_id": "{{ClientId}}",
            "client_secret": "{{ClientSecret}}"
        }
        """;

        public void Validate()
        {
            if (Device == null)
                throw new TraktRequestValidationException(nameof(Device), "device must not be null");

            if (Device.IsExpiredUnused)
                throw new TraktRequestValidationException(nameof(Device), "device code expired unused");

            if (!Device.IsValid)
                throw new TraktRequestValidationException(nameof(Device), "device not valid");

            ArgumentValidator.ThrowIfNullOrWhiteSpace(Device.DeviceCode, "device code not valid", true);
            
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);
        }
    }

    internal sealed class AuthorizationRefreshRequestBody
    {
        internal required string RefreshToken { get; set; }

        internal required string ClientId { get; set; }

        internal required string ClientSecret { get; set; }

        internal required string RedirectUri { get; set; }

        public string ToJson() => HttpContentAsString;

        private string HttpContentAsString => $$"""
        {
            "refresh_token": "{{RefreshToken}}",
            "client_id": "{{ClientId}}",
            "client_secret": "{{ClientSecret}}",
            "redirect_uri": "{{RedirectUri}}",
            "grant_type": "refresh_token"
        }
        """;

        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(RefreshToken, "refresh token not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(RedirectUri, "redirect uri not valid", true);
        }
    }

    internal sealed class AuthorizationRequestBody
    {
        internal required string Code { get; set; }

        internal required string ClientId { get; set; }

        internal required string ClientSecret { get; set; }

        internal required string RedirectUri { get; set; }

        public string ToJson() => HttpContentAsString;

        private string HttpContentAsString => $$"""
        {
            "code": "{{Code}}",
            "client_id": "{{ClientId}}",
            "client_secret": "{{ClientSecret}}",
            "redirect_uri": "{{RedirectUri}}",
            "grant_type": "authorization_code"
        }
        """;

        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(Code, "code not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(RedirectUri, "redirect uri not valid", true);
        }
    }

    internal sealed class AuthorizationRevokeRequestBody
    {
        internal required string AccessToken { get; set; }

        internal required string ClientId { get; set; }

        internal required string ClientSecret { get; set; }

        public string ToJson() => HttpContentAsString;

        private string HttpContentAsString => $$"""
        {
            "token": "{{AccessToken}}",
            "client_id": "{{ClientId}}",
            "client_secret": "{{ClientSecret}}"
        }
        """;

        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(AccessToken, "access token not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);

            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);
        }
    }

    internal sealed class DeviceRequestBody
    {
        internal required string ClientId { get; set; }

        public string ToJson() => HttpContentAsString;

        private string HttpContentAsString => $$"""
        {
            "client_id": "{{ClientId}}"
        }
        """;

        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);
        }
    }
}
