namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktPutRequestGeneratorTests
    {
        [Fact]
        public Task TestGeneratePutRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequest", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestExtendedInfo", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestOAuth", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestAll", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string?}")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestNullableParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterExtendedInfo", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterOAuth", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterAll", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterTypeDefault", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithMultipleParametersDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows/{id}/seasons/{season_number}/episodes/{episode_number}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestMultipleParameterTypeDefault", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithMultipleParameters()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows/{id:string}/seasons/{season_number:uint}/episodes/{episode_number:uint}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestMultipleParameters", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithSlashAtEnd()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows/")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestSlashAtEnd", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomEnumParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalEnumParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomStringParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalStringParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomDateTimeParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalDateTimeParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomCachedDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomCachedDateTimeParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomCachedOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomCachedOptionalDateTimeParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomParametersMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                
                        [TraktRequestParameter]
                        internal string Country { get; set; }

                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomParametersMix", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomParameterAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomParameterExtendedPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomEnumQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalEnumQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomEnumQueryName", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalEnumQueryName", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomStringQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalStringQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomDateTimeQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomOptionalDateTimeQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomCachedDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomCachedDateTimeQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomCachedOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomCachedOptionalDateTimeQuery", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                
                        [TraktRequestQuery("country")]
                        internal string Country { get; set; }

                        [TraktRequestQuery("start_date")]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomQueriesMix", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomQueryAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomQueryExtendedPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithCustomParametersAndQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                
                        [TraktRequestParameter]
                        internal string Country { get; set; }

                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }

                        [TraktRequestQuery]
                        internal TraktListSortOrder? SortOrder { get; set; }

                        [TraktRequestQuery("language")]
                        internal string? Language { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomParametersAndQueriesMix", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestParametersQueriesExtendedInfoPagination()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                
                        [TraktRequestParameter]
                        internal string Country { get; set; }

                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }

                        [TraktRequestQuery]
                        internal TraktListSortOrder? SortOrder { get; set; }

                        [TraktRequestQuery("language")]
                        internal string? Language { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestCustomParametersAndQueriesMixExtendedInfoPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterAndQueryAttributeDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestParameter]
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterQueryAttributeDiagnostic", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestQueryAttributeNameRequiredDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("shows")]
                    public sealed partial class TestPutRequest
                    {
                        [TraktRequestQuery]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestQueryAttributeNameRequiredDiagnostic", source, RequestTestType.PutRequest);
        }
    }
}
