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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequest", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestExtendedInfo", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestPagination", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestOAuth", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestAll", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameter", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestNullableParameter", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterExtendedInfo", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterPagination", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterOAuth", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterAll", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterTypeDefault", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestMultipleParameterTypeDefault", source, RequestTestType.PostRequest);
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

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestMultipleParameters", source, RequestTestType.PostRequest);
        }
    }
}
