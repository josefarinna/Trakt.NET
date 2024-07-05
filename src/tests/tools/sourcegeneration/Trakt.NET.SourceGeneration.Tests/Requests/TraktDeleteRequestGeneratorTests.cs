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
    }
}
