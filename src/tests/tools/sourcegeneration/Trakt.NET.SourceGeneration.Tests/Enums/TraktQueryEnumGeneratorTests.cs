namespace TraktNET.SourceGeneration.Enums
{
    public sealed class TraktQueryEnumGeneratorTests
    {
        [Fact]
        public Task TestGeneratesQueryEnumExtensions()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
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
                "SourceGeneration.QueryEnumFlagsTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMember()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
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
                "SourceGeneration.QueryEnumMemberTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberURIAndFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
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
                "SourceGeneration.QueryEnumMemberURIAndFlagsTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberURI()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
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
                "SourceGeneration.QueryEnumMemberURITests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberAndFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
                    [Flags]
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
                "SourceGeneration.QueryEnumMemberFlagsTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsEmptyQueryDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "", HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumNullQueryDiagnosticTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsEmptyQueryWithSupportFlagDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "")]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumNullQueryDiagnosticTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsNullQueryDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = null, HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumNullQueryDiagnosticTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberEmptyJsonValue()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = "")]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumMemberEmptyJsonValueTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberEmptyDisplayName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = "first_value")]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumMemberEmptyDisplayNameTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberNullJsonValue()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = null)]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumMemberNullJsonValueTests", source);
        }

        [Fact]
        public Task TestGeneratesQueryEnumExtensionsWithCustomEnumMemberNullDisplayName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(QueryName = "testenum", HasQuerySupport = true)]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(JsonValue = "first_value")]
                        ValueOne,
                
                        [TraktEnumMember(JsonValue = "second_value", DisplayName = null)]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.QueryEnumMemberNullDisplayNameTests", source);
        }
    }
}
