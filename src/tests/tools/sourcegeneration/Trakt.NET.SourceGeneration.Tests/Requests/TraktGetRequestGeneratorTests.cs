namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktGetRequestGeneratorTests
    {
        [Fact]
        public Task TestGenerateGetRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequest",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequest));
        }

        [Fact]
        public Task TestGenerateGetRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestExtendedInfo",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithExtendedInfo));
        }

        [Fact]
        public Task TestGenerateGetRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestPagination",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithPagination));
        }

        [Fact]
        public Task TestGenerateGetRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestOAuth",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithOAuthRequirement));
        }

        [Fact]
        public Task TestGenerateGetRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestAll",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithAll));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string?}")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestNullableParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithNullableParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterExtendedInfo",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithParameterExtendedInfo));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterPagination",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithParameterPagination));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterOAuth",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithParameterOAuthRequirement));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterAll",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithParameterAll));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterTypeDefault",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithParameterDefaultTypeString));
        }

        [Fact]
        public Task TestGenerateGetRequestWithMultipleParametersDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows/{id}/seasons/{season_number}/episodes/{episode_number}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestMultipleParameterTypeDefault",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithMultipleParametersDefaultTypeString));
        }

        [Fact]
        public Task TestGenerateGetRequestWithMultipleParameters()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows/{id:string}/seasons/{season_number:uint}/episodes/{episode_number:uint}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestMultipleParameters",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithMultipleParameters));
        }

        [Fact]
        public Task TestGenerateGetRequestWithSlashAtEnd()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows/")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestSlashAtEnd",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithSlashAtEnd));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomEnumParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomEnumParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomOptionalEnumParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomOptionalEnumParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomStringParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomStringParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomOptionalStringParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomOptionalStringParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomDateTimeParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestCustomOptionalDateTimeParameter", source, RequestTestType.GetRequest, 
                nameof(TestGenerateGetRequestWithCustomOptionalDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomCachedDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomCachedDateTimeParameter",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomCachedDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomCachedOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestCustomCachedOptionalDateTimeParameter", source, RequestTestType.GetRequest,
                nameof(TestGenerateGetRequestWithCustomCachedOptionalDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomParametersMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
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

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomParametersMix",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomParametersMix));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomParameterAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestCustomParameterExtendedPagination", source, RequestTestType.GetRequest,
                nameof(TestGenerateGetRequestWithCustomParameterAndExtendedInfoPagination));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomEnumQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomEnumQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomOptionalEnumQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomOptionalEnumQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomEnumQueryName",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomEnumQueryName));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomOptionalEnumQueryName",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomOptionalEnumQueryName));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomStringQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomStringQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomOptionalStringQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomOptionalStringQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomDateTimeQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomOptionalDateTimeQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomOptionalDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomCachedDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomCachedDateTimeQuery",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomCachedDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomCachedOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestCustomCachedOptionalDateTimeQuery", source, RequestTestType.GetRequest,
                nameof(TestGenerateGetRequestWithCustomCachedOptionalDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
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

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomQueriesMix",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomQueriesMix));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomQueryAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomQueryExtendedPagination",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomQueryAndExtendedInfoPagination));
        }

        [Fact]
        public Task TestGenerateGetRequestWithCustomParametersAndQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
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

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestCustomParametersAndQueriesMix",
                source, RequestTestType.GetRequest, nameof(TestGenerateGetRequestWithCustomParametersAndQueriesMix));
        }

        [Fact]
        public Task TestGenerateGetRequestParametersQueriesExtendedInfoPagination()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestGetRequest
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

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestCustomParametersAndQueriesMixExtendedInfoPagination", source, RequestTestType.GetRequest,
                nameof(TestGenerateGetRequestParametersQueriesExtendedInfoPagination));
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterAndQueryAttributeDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestParameter]
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestParameterQueryAttributeDiagnostic", source, RequestTestType.GetRequest,
                nameof(TestGenerateGetRequestWithParameterAndQueryAttributeDiagnostic));
        }

        [Fact]
        public Task TestGenerateGetRequestQueryAttributeNameRequiredDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("shows")]
                    public sealed partial class TestGetRequest
                    {
                        [TraktRequestQuery]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests",
                "SourceGeneration.GetRequestQueryAttributeNameRequiredDiagnostic", source, RequestTestType.GetRequest,
                nameof(TestGenerateGetRequestQueryAttributeNameRequiredDiagnostic));
        }
    }
}
