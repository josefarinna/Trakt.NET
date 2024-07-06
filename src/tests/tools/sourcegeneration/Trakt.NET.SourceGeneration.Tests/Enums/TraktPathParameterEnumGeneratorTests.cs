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
