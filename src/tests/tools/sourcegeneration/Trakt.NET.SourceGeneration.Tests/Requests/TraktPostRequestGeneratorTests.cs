namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktPostRequestGeneratorTests
    {
        [Fact]
        public Task TestGeneratePostRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequest",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequest));
        }

        [Fact]
        public Task TestGeneratePostRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestExtendedInfo",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithExtendedInfo));
        }

        [Fact]
        public Task TestGeneratePostRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestPagination",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithPagination));
        }

        [Fact]
        public Task TestGeneratePostRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestOAuth",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithOAuthRequirement));
        }

        [Fact]
        public Task TestGeneratePostRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestAll",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithAll));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameter",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string?}")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestNullableParameter",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithNullableParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterExtendedInfo",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithParameterExtendedInfo));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterPagination",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithParameterPagination));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterOAuth",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithParameterOAuthRequirement));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterAll",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithParameterAll));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterTypeDefault",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithParameterDefaultTypeString));
        }

        [Fact]
        public Task TestGeneratePostRequestWithMultipleParametersDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows/{id}/seasons/{season_number}/episodes/{episode_number}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestMultipleParameterTypeDefault", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithMultipleParametersDefaultTypeString));
        }

        [Fact]
        public Task TestGeneratePostRequestWithMultipleParameters()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows/{id:string}/seasons/{season_number:uint}/episodes/{episode_number:uint}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestMultipleParameters",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithMultipleParameters));
        }

        [Fact]
        public Task TestGeneratePostRequestWithSlashAtEnd()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows/")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestSlashAtEnd",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithSlashAtEnd));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomEnumParameter",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomEnumParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomOptionalEnumParameter",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomOptionalEnumParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomStringParameter",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomStringParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomOptionalStringParameter", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomOptionalStringParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomDateTimeParameter",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomDateTimeParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomOptionalDateTimeParameter", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomOptionalDateTimeParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomCachedDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomCachedDateTimeParameter", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomCachedDateTimeParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomCachedOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomCachedOptionalDateTimeParameter", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomCachedOptionalDateTimeParameter));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomParametersMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomParametersMix",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomParametersMix));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomParameterAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomParameterExtendedPagination", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomParameterAndExtendedInfoPagination));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomEnumQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomEnumQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomOptionalEnumQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomOptionalEnumQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomEnumQueryName",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomEnumQueryName));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomOptionalEnumQueryName",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomOptionalEnumQueryName));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomStringQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomStringQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomOptionalStringQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomOptionalStringQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomDateTimeQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomDateTimeQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomOptionalDateTimeQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomOptionalDateTimeQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomCachedDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomCachedDateTimeQuery",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomCachedDateTimeQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomCachedOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomCachedOptionalDateTimeQuery", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomCachedOptionalDateTimeQuery));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestCustomQueriesMix",
                source, RequestTestType.PostRequest, nameof(TestGeneratePostRequestWithCustomQueriesMix));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomQueryAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomQueryExtendedPagination", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomQueryAndExtendedInfoPagination));
        }

        [Fact]
        public Task TestGeneratePostRequestWithCustomParametersAndQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomParametersAndQueriesMix", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithCustomParametersAndQueriesMix));
        }

        [Fact]
        public Task TestGeneratePostRequestParametersQueriesExtendedInfoPagination()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestPostRequest
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestCustomParametersAndQueriesMixExtendedInfoPagination", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestParametersQueriesExtendedInfoPagination));
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterAndQueryAttributeDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestParameter]
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestParameterQueryAttributeDiagnostic", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestWithParameterAndQueryAttributeDiagnostic));
        }

        [Fact]
        public Task TestGeneratePostRequestQueryAttributeNameRequiredDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("shows")]
                    public sealed partial class TestPostRequest
                    {
                        [TraktRequestQuery]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests",
                "SourceGeneration.PostRequestQueryAttributeNameRequiredDiagnostic", source, RequestTestType.PostRequest,
                nameof(TestGeneratePostRequestQueryAttributeNameRequiredDiagnostic));
        }
    }
}
