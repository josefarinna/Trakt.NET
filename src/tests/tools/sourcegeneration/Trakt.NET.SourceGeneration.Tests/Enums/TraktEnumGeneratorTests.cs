namespace TraktNET.SourceGeneration.Enums
{
    public sealed class TraktEnumGeneratorTests
    {
        [Fact]
        public Task TestGeneratesEnumExtensions()
        {
            string source = """
                using TraktNET;

                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumTests", source, customFilename: nameof(TestGeneratesEnumExtensions));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomJsonSeparator()
        {
            string source = """
                using TraktNET;

                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(JsonSeparator = " ")]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumCustomJsonSeparatorTests", source, customFilename: nameof(TestGeneratesEnumExtensionsWithCustomJsonSeparator));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithEmptyCustomJsonSeparator()
        {
            string source = """
                using TraktNET;

                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(JsonSeparator = "")]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumEmptyCustomJsonSeparatorTests", source, customFilename: nameof(TestGeneratesEnumExtensionsWithEmptyCustomJsonSeparator));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMember()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberTests", source, customFilename: nameof(TestGeneratesEnumExtensionsWithCustomEnumMember));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithEmptyCustomEnumMember()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
                    public enum TestEnum
                    {
                        Unspecified,

                        [TraktEnumMember()]
                        ValueOne,

                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EmptyEnumMemberTests", source, customFilename: nameof(TestGeneratesEnumExtensionsWithEmptyCustomEnumMember));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberEmptyJsonValue()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberEmptyJsonValueTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithCustomEnumMemberEmptyJsonValue));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberEmptyDisplayName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberEmptyDisplayNameTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithCustomEnumMemberEmptyDisplayName));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberNullJsonValueDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberNullJsonValueDiagnosticsTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithCustomEnumMemberNullJsonValueDiagnostics));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberNullDisplayNameDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberNullDisplayNameDiagnosticsTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithCustomEnumMemberNullDisplayNameDiagnostics));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMember()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true, HasQuerySupport = true, QueryName = "testenum")]
                    public enum TestEnum
                    {
                        Unspecified,

                        ValueOne,

                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberPathQueryEnumMemberTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMember));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMemberURI()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true, HasQuerySupport = true, QueryName = "testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(UriValue = "first_value_uri")]
                        ValueOne,

                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberPathQueryEnumMemberURITests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMemberURI));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMemberAndFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true, HasQuerySupport = true, QueryName = "testenum")]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,

                        ValueOne,

                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberPathQueryEnumMemberFlagsTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMemberAndFlagsAttribute));
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMemberURIAndFlagsAttribute()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum(HasPathSupport = true, HasQuerySupport = true, QueryName = "testenum")]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(UriValue = "first_value_uri")]
                        ValueOne,

                        [TraktEnumMember(JsonValue = "second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums/Enum",
                "SourceGeneration.EnumMemberPathQueryEnumMemberURIFlagsTests", source,
                customFilename: nameof(TestGeneratesEnumExtensionsWithPathAndQueryAndCustomEnumMemberURIAndFlagsAttribute));
        }
    }
}
