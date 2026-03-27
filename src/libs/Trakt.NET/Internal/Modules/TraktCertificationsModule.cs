namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to certifications.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/certifications">"Trakt API Documentation - Certifications"</a> section.
    /// </summary>
    public sealed partial class TraktCertificationsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktCertifications>> GetMovieCertificationsImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new CertificationsMoviesGetRequest();
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCertifications>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCertifications>> GetShowCertificationsImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new CertificationsShowsGetRequest();
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCertifications>(_context, request, cancellationToken);
        }
    }
}
