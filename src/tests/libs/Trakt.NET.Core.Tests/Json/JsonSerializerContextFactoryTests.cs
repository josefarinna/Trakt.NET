#if NET6_0_OR_GREATER
namespace TraktNET.Json
{
    public sealed class JsonSerializerContextFactoryTests
    {
        [Fact]
        public void TestGetContextForRegisteredType()
            => JsonSerializerContextFactory.GetContext<TraktMovie>().ShouldNotBeNull();

        [Fact]
        public void TestGetContextThrowsForUnregisteredType()
            => Should.Throw<NotSupportedException>(() => JsonSerializerContextFactory.GetContext<JsonSerializerContextFactoryTests>())
                .Message.ShouldContain(typeof(JsonSerializerContextFactoryTests).FullName!);
    }
}
#endif
