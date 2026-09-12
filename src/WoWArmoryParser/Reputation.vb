Namespace WoWArmoryParser
    Public Class Reputation
        '<faction key="argentdawn" name="Argent Dawn" reputation="28642"/>
        Public Key As String
        Public Name As String

        Protected _Value As Integer
        Protected _Status As ReputationEnum

        Public Property Value() As Integer
            Get
                Return _Value
            End Get
            Friend Set(ByVal value As Integer)
                _Value = value
                _Status = GetRepEnum(value)
            End Set
        End Property

        Public ReadOnly Property Status() As ReputationEnum
            Get
                Return _Status
            End Get
        End Property

        Public Function ToStatusString() As String
            Return System.Enum.GetName(GetType(ReputationEnum), _Status)
        End Function

        Public ReadOnly Property RelativeValue() As Integer
            Get
                Dim res As Integer = 0
                Select Case _Status
                    Case ReputationEnum.Hated
                        res = _Value + 42000
                    Case ReputationEnum.Hostile
                        res = _Value + 6000
                    Case ReputationEnum.Unfriendly
                        res = _Value + 3000
                    Case ReputationEnum.Neutral
                        res = _Value
                    Case ReputationEnum.Friendly
                        res = _Value - 3000
                    Case ReputationEnum.Honored
                        res = _Value - 9000
                    Case ReputationEnum.Revered
                        res = _Value - 21000
                    Case ReputationEnum.Exalted
                        res = _Value - 42000
                End Select
                Return res
            End Get
        End Property

        Public ReadOnly Property RelativeMax() As Integer
            Get
                Dim res As Integer = 0
                Select Case _Status
                    Case ReputationEnum.Hated
                        res = 36000
                    Case ReputationEnum.Hostile
                        res = 3000
                    Case ReputationEnum.Unfriendly
                        res = 3000
                    Case ReputationEnum.Neutral
                        res = 3000
                    Case ReputationEnum.Friendly
                        res = 6000
                    Case ReputationEnum.Honored
                        res = 12000
                    Case ReputationEnum.Revered
                        res = 21000
                    Case ReputationEnum.Exalted
                        res = 1000
                End Select
                Return res
            End Get
        End Property

        Public ReadOnly Property RelativeRatio() As Double
            Get
                Return (Me.RelativeValue / Me.RelativeMax)
            End Get
        End Property

        Protected Function GetRepEnum(ByVal Value As Integer) As ReputationEnum
            Dim res As ReputationEnum
            Select Case Value
                Case Is < -6000
                    res = ReputationEnum.Hated
                Case -6000 To -3001
                    res = ReputationEnum.Hostile
                Case -3000 To -1
                    res = ReputationEnum.Unfriendly
                Case 0 To 3000
                    res = ReputationEnum.Neutral
                Case 3001 To 9000
                    res = ReputationEnum.Friendly
                Case 9001 To 21000
                    res = ReputationEnum.Honored
                Case 21001 To 42000
                    res = ReputationEnum.Revered
                Case Is > 42000
                    res = ReputationEnum.Exalted
                Case Else
                    res = ReputationEnum.Neutral
            End Select
            Return res
        End Function

    End Class

    Public Class ReputationList
        Protected Sub New()

        End Sub

        Public Const DarkspearTrolls As String = "darkspeartrolls"
        Public Const Orgrimmar As String = "orgrimmar"
        Public Const SilvermoonCity As String = "silvermooncity"
        Public Const ThunderBluff As String = "thunderbluff"
        Public Const Undercity As String = "undercity"
        Public Const FrostwolfClan As String = "frostwolfclan"
        Public Const TheDefilers As String = "thedefilers"
        Public Const WarsongOutriders As String = "warsongoutriders"
        Public Const CenarionExpedition As String = "cenarionexpedition"
        Public Const Netherwing As String = "netherwing"
        Public Const Ogrila As String = "ogri'la"
        Public Const Sporeggar As String = "sporeggar"
        Public Const TheConsortium As String = "theconsortium"
        Public Const TheMaghar As String = "themag'har"
        Public Const Thrallmar As String = "thrallmar"
        Public Const LowerCity As String = "lowercity"
        Public Const ShatariSkyguard As String = "sha'tariskyguard"
        Public Const TheAldor As String = "thealdor"
        Public Const TheScryers As String = "thescryers"
        Public Const TheShatar As String = "thesha'tar"
        Public Const BootyBay As String = "bootybay"
        Public Const Everlook As String = "everlook"
        Public Const Gadgetzan As String = "gadgetzan"
        Public Const Ratchet As String = "ratchet"
        Public Const ArgentDawn As String = "argentdawn"
        Public Const BloodsailBuccaneers As String = "bloodsailbuccaneers"
        Public Const BroodOfNozdormu As String = "broodofnozdormu"
        Public Const CenarionCircle As String = "cenarioncircle"
        Public Const DarkmoonFaire As String = "darkmoonfaire"
        Public Const GelkisClanCentaur As String = "gelkisclancentaur"
        Public Const HydraxianWaterlords As String = "hydraxianwaterlords"
        Public Const KeepersOfTime As String = "keepersoftime"
        Public Const MagramClanCentaur As String = "magramclancentaur"
        Public Const ShenDralar As String = "shen'dralar"
        Public Const TheScaleOfTheSands As String = "thescaleofthesands"
        Public Const TheVioletEye As String = "thevioleteye"
        Public Const ThoriumBrotherhood As String = "thoriumbrotherhood"
        Public Const TimbermawHold As String = "timbermawhold"
        Public Const Tranquillien As String = "tranquillien"
        Public Const ZandalarTribe As String = "zandalartribe"
        Public Const Darnassus As String = "darnassus"
        Public Const Exodar As String = "exodar"
        Public Const GnomereganExiles As String = "gnomereganexiles"
        Public Const Ironforge As String = "ironforge"
        Public Const Stormwind As String = "stormwind"
        Public Const SilverwingSentinels As String = "silverwingsentinels"
        Public Const StormpikeGuard As String = "stormpikeguard"
        Public Const TheLeagueofArathor As String = "theleagueofarathor"
        Public Const AshtongueDeathsworn As String = "ashtonguedeathsworn"
        Public Const HonorHold As String = "honorhold"
        Public Const Kurenai As String = "kurenai"
        Public Const Ravenholdt As String = "ravenholdt"
        Public Const WintersaberTrainers As String = "wintersabertrainers"

        Public Shared Function AlteracValley(ByVal Faction As FactionEnum) As String
            Dim res As String = ""
            Select Case Faction
                Case FactionEnum.Alliance
                    res = ReputationList.StormpikeGuard
                Case FactionEnum.Horde
                    res = ReputationList.FrostwolfClan
            End Select
            Return res
        End Function

        Public Shared Function ArathiBasin(ByVal Faction As FactionEnum) As String
            Dim res As String = ""
            Select Case Faction
                Case FactionEnum.Alliance
                    res = ReputationList.TheLeagueofArathor
                Case FactionEnum.Horde
                    res = ReputationList.TheDefilers
            End Select
            Return res
        End Function

        Public Shared Function WarsongGulch(ByVal Faction As FactionEnum) As String
            Dim res As String = ""
            Select Case Faction
                Case FactionEnum.Alliance
                    res = ReputationList.SilverwingSentinels
                Case FactionEnum.Horde
                    res = ReputationList.WarsongOutriders
            End Select
            Return res
        End Function
    End Class

End Namespace