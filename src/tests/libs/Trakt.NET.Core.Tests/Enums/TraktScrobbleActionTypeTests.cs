using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktScrobbleActionTypeTests
    {
        [Fact]
        public void TestTraktScrobbleActionTypeToJson()
        {
            TraktScrobbleActionType.Unspecified.ToJson().ShouldBeNull();
            TraktScrobbleActionType.Start.ToJson().ShouldBe("start");
            TraktScrobbleActionType.Pause.ToJson().ShouldBe("pause");
            TraktScrobbleActionType.Stop.ToJson().ShouldBe("stop");
            ((TraktScrobbleActionType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktScrobbleActionTypeFromJson()
        {
            "unspecified".ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Unspecified);
            "start".ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Start);
            "pause".ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Pause);
            "stop".ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Stop);

            string? nullValue = null;
            nullValue.ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Unspecified);
            "invalid".ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Unspecified);
            "".ToTraktScrobbleActionType().ShouldBe(TraktScrobbleActionType.Unspecified);
        }

        [Fact]
        public void TestTraktScrobbleActionTypeDisplayName()
        {
            TraktScrobbleActionType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktScrobbleActionType.Start.DisplayName().ShouldBe("Start");
            TraktScrobbleActionType.Pause.DisplayName().ShouldBe("Pause");
            TraktScrobbleActionType.Stop.DisplayName().ShouldBe("Stop");
            ((TraktScrobbleActionType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktScrobbleActionTypeJsonConverter()
        {
            var converter = new TraktScrobbleActionTypeJsonConverter();
            converter.CanConvert(typeof(TraktScrobbleActionType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktScrobbleActionType.Start, options).ShouldBe("\"start\"");
            JsonSerializer.Deserialize<TraktScrobbleActionType>("\"start\"", options).ShouldBe(TraktScrobbleActionType.Start);
            JsonSerializer.Deserialize<TraktScrobbleActionType>("\"\"", options).ShouldBe(TraktScrobbleActionType.Unspecified);
        }
    }
}
