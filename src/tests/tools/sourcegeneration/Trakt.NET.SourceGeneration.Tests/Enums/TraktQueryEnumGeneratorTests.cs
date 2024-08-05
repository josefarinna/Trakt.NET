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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumTests", source, customFilename: nameof(TestGeneratesQueryEnumExtensions));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumFlagsTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithFlagsAttribute));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMember));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberURIAndFlagsTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberURIAndFlagsAttribute));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberURITests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberURI));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberFlagsTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberAndFlagsAttribute));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumNullQueryDiagnosticTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsEmptyQueryDiagnostics));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumNullQueryDiagnosticTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsEmptyQueryWithSupportFlagDiagnostics));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumNullQueryDiagnosticTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsNullQueryDiagnostics));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberEmptyJsonValueTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberEmptyJsonValue));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberEmptyDisplayNameTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberEmptyDisplayName));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberNullJsonValueTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberNullJsonValue));
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/QueryEnum",
                "SourceGeneration.QueryEnumMemberNullDisplayNameTests", source,
                customFilename: nameof(TestGeneratesQueryEnumExtensionsWithCustomEnumMemberNullDisplayName));
        }
    }
}
