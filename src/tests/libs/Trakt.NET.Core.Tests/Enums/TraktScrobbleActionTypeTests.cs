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
        }

        [Fact]
        public void TestTraktScrobbleActionTypeDisplayName()
        {
            TraktScrobbleActionType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktScrobbleActionType.Start.DisplayName().ShouldBe("Start");
            TraktScrobbleActionType.Pause.DisplayName().ShouldBe("Pause");
            TraktScrobbleActionType.Stop.DisplayName().ShouldBe("Stop");
        }
    }
}
