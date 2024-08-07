namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktDeleteRequestGeneratorTests
    {
        [Fact]
        public Task TestGenerateDeleteRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequest",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequest));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestExtendedInfo",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithExtendedInfo));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestPagination",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithPagination));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestOAuth",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithOAuthRequirement));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestAll",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithAll));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameter",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string?}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestNullableParameter",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithNullableParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterExtendedInfo",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterExtendedInfo));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterPagination",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterPagination));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterOAuth",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterOAuthRequirement));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterAll",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterAll));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterTypeDefault",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterDefaultTypeString));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithMultipleParametersDefaultTypeString()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows/{id}/seasons/{season_number}/episodes/{episode_number}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestMultipleParameterTypeDefault", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithMultipleParametersDefaultTypeString));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithMultipleParameters()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows/{id:string}/seasons/{season_number:uint}/episodes/{episode_number:uint}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.NotRequired)]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestMultipleParameters",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithMultipleParameters));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithSlashAtEnd()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows/")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestSlashAtEnd",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithSlashAtEnd));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomEnumParameter",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomEnumParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalEnumParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomOptionalEnumParameter", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomOptionalEnumParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomStringParameter",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomStringParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalStringParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomOptionalStringParameter", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomOptionalStringParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomDateTimeParameter",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomOptionalDateTimeParameter", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomOptionalDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomCachedDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomCachedDateTimeParameter", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomCachedDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomCachedOptionalDateTimeParameter()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomCachedOptionalDateTimeParameter", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomCachedOptionalDateTimeParameter));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomParametersMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomParametersMix",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomParametersMix));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomParameterAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomParameterExtendedPagination", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomParameterAndExtendedInfoPagination));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomEnumQuery",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomEnumQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalEnumQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalEnumQuery",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomOptionalEnumQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomEnumQueryName",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomEnumQueryName));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalEnumQueryName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("type")]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomOptionalEnumQueryName", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomOptionalEnumQueryName));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomStringQuery",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomStringQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalStringQuery()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("country")]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomOptionalStringQuery", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomOptionalStringQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomDateTimeQuery",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("start_date")]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomOptionalDateTimeQuery", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomOptionalDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomCachedDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomCachedDateTimeQuery", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomCachedDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomCachedOptionalDateTimeQuery()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery("start_date", UseCacheEfficientDateTime = true)]
                        internal DateTime? StartDate { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomCachedOptionalDateTimeQuery", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomCachedOptionalDateTimeQuery));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomQueriesMix",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithCustomQueriesMix));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomQueryAndExtendedInfoPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomQueryExtendedPagination", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomQueryAndExtendedInfoPagination));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithCustomParametersAndQueriesMix()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomParametersAndQueriesMix", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithCustomParametersAndQueriesMix));
        }

        [Fact]
        public Task TestGenerateDeleteRequestParametersQueriesExtendedInfoPagination()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows", SupportsExtendedInfo = true, SupportsPagination = true)]
                    public sealed partial class TestDeleteRequest
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestCustomParametersAndQueriesMixExtendedInfoPagination", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestParametersQueriesExtendedInfoPagination));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterAndQueryAttributeDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestParameter]
                        [TraktRequestQuery]
                        internal TraktListType? ListType { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterQueryAttributeDiagnostic", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestWithParameterAndQueryAttributeDiagnostic));
        }

        [Fact]
        public Task TestGenerateDeleteRequestQueryAttributeNameRequiredDiagnostic()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("shows")]
                    public sealed partial class TestDeleteRequest
                    {
                        [TraktRequestQuery]
                        internal string? Country { get; set; }
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestQueryAttributeNameRequiredDiagnostic", source, RequestTestType.DeleteRequest,
                nameof(TestGenerateDeleteRequestQueryAttributeNameRequiredDiagnostic));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterRequiredDefaultStringVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterRequiredDefaultStringVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterRequiredDefaultStringVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterRequiredStringVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterRequiredStringVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterRequiredStringVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterOptionalDefaultStringVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id?!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterOptionalDefaultStringVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterOptionalDefaultStringVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterOptionalStringVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:string?!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterOptionalStringVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterOptionalStringVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterRequiredIntVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:int!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterRequiredIntVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterRequiredIntVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterOptionalIntVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:int?!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterOptionalIntVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterOptionalIntVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterRequiredUIntVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:uint!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterRequiredUIntVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterRequiredUIntVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterOptionalUIntVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id:uint?!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterOptionalUIntVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterOptionalUIntVerification));
        }

        [Fact]
        public Task TestGenerateDeleteRequestWithParameterMixedVerification()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktDeleteRequest("notes/{id1:string!!}/{id2:string?!!}/{id3!!}/{id4?!!}/{nr1:int!!}/{nr2:uint!!}/{nr3:int?!!}/{nr4:uint?!!}")]
                    public sealed partial class TestDeleteRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests",
                "SourceGeneration.DeleteRequestParameterMixedVerification",
                source, RequestTestType.DeleteRequest, nameof(TestGenerateDeleteRequestWithParameterMixedVerification));
        }
    }
}
