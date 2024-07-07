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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EmptyEnumMemberTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberEmptyJsonValueTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberEmptyDisplayNameTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberNullJsonValueDiagnosticsTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberNullDisplayNameDiagnosticsTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberPathQueryEnumMemberTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberPathQueryEnumMemberURITests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberPathQueryEnumMemberFlagsTests", source);
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberPathQueryEnumMemberURIFlagsTests", source);
        }
    }
}
