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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterEnumTests", source, customFilename: nameof(TestGeneratesPathParameterEnumExtensions));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterFlagsEnumTests", source,
                customFilename: nameof(TestGeneratesPathParameterEnumExtensionsWithFlagsAttribute));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterEnumMemberTests", source,
                customFilename: nameof(TestGeneratesPathParameterEnumExtensionsWithCustomEnumMember));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterEnumMemberURITests", source,
                customFilename: nameof(TestGeneratesPathParameterEnumExtensionsWithCustomEnumMemberURI));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterEnumMemberURIAndFlagsTests", source,
                customFilename: nameof(TestGeneratesPathParameterEnumExtensionsWithCustomEnumMemberURIAndFlagsAttribute));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterQueryEnumTests", source,
                customFilename: nameof(TestGeneratesPathParameterEnumExtensionsWithQuerySupport));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/ParameterEnum",
                "SourceGeneration.PathParameterQueryFlagsEnumTests", source,
                customFilename: nameof(TestGeneratesPathParameterEnumExtensionsWithQuerySupportAndFlagsAttribute));
        }
    }
}
