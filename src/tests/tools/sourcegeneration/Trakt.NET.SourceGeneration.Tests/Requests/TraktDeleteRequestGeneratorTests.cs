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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequest", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestExtendedInfo", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestPagination", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestOAuth", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestAll", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestNullableParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterExtendedInfo", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterPagination", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterOAuth", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterAll", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterTypeDefault", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestMultipleParameterTypeDefault", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestMultipleParameters", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestSlashAtEnd", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomEnumParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalEnumParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomStringParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalStringParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomDateTimeParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalDateTimeParameter", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomParametersMix", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomParameterExtendedPagination", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomEnumQuery", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalEnumQuery", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomEnumQueryName", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalEnumQueryName", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomStringQuery", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalStringQuery", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomDateTimeQuery", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomOptionalDateTimeQuery", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomQueriesMix", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomQueryExtendedPagination", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomParametersAndQueriesMix", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestCustomParametersAndQueriesMixExtendedInfoPagination", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestParameterQueryAttributeDiagnostic", source, RequestTestType.DeleteRequest);
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

            return TestHelper.Verify<TraktDeleteRequestSourceGenerator>("Requests", "SourceGeneration.DeleteRequestQueryAttributeNameRequiredDiagnostic", source, RequestTestType.DeleteRequest);
        }
    }
}
