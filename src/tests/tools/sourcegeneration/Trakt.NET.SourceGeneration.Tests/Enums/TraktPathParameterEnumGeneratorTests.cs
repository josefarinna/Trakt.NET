namespace TraktNET.SourceGeneration.Enums
{
    public sealed class TraktPathParameterEnumGeneratorTests
    {
        [Fact]
        public Task TestGeneratesPathParameterEnumExtensions()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterEnumTests", source);
        }

        [Fact]
        public Task TestGeneratesPathParameterEnumExtensionsWithFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true)]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterFlagsEnumTests", source);
        }

        [Fact]
        public Task TestGeneratesPathParameterEnumExtensionsWithCustomEnumMember()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = "first_value")]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterEnumMemberTests", source);
        }

        [Fact]
        public Task TestGeneratesPathParameterEnumExtensionsWithCustomEnumMemberURI()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = "first_value", UriValue = "first_value_uri")]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2", UriValue = "second_value_uri")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterEnumMemberURITests", source);
        }

        [Fact]
        public Task TestGeneratesPathParameterEnumExtensionsWithCustomEnumMemberURIAndFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true)]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = "first_value", UriValue = "first_value_uri")]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2", UriValue = "second_value_uri")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterEnumMemberURIAndFlagsTests", source);
        }

        [Fact]
        public Task TestGeneratesPathParameterEnumExtensionsWithQuerySupport()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true, HasPathSupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterQueryEnumTests", source);
        }

        [Fact]
        public Task TestGeneratesPathParameterEnumExtensionsWithQuerySupportAndFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true, HasPathSupport = true)]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.PathParameterQueryFlagsEnumTests", source);
        }
    }
}
