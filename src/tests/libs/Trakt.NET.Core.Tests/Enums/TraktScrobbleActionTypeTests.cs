namespace TraktNET.Enums
{
    public sealed class TraktScrobbleActionTypeTests
    {
        [Fact]
        public void TestTraktScrobbleActionTypeToJson()
        {
            TraktScrobbleActionType.Unspecified.ToJson().Should().BeNull();
            TraktScrobbleActionType.Start.ToJson().Should().Be("start");
            TraktScrobbleActionType.Pause.ToJson().Should().Be("pause");
            TraktScrobbleActionType.Scrobble.ToJson().Should().Be("scrobble");
        }

        [Fact]
        public void TestTraktScrobbleActionTypeFromJson()
        {
            "unspecified".ToTraktScrobbleActionType().Should().Be(TraktScrobbleActionType.Unspecified);
            "start".ToTraktScrobbleActionType().Should().Be(TraktScrobbleActionType.Start);
            "pause".ToTraktScrobbleActionType().Should().Be(TraktScrobbleActionType.Pause);
            "scrobble".ToTraktScrobbleActionType().Should().Be(TraktScrobbleActionType.Scrobble);

            string? nullValue = null;
            nullValue.ToTraktScrobbleActionType().Should().Be(TraktScrobbleActionType.Unspecified);
        }

        [Fact]
        public void TestTraktScrobbleActionTypeDisplayName()
        {
            TraktScrobbleActionType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktScrobbleActionType.Start.DisplayName().Should().Be("Start");
            TraktScrobbleActionType.Pause.DisplayName().Should().Be("Pause");
            TraktScrobbleActionType.Scrobble.DisplayName().Should().Be("Scrobble");
        }
    }
}
