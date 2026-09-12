Namespace WoWArmoryParser
    Public MustInherit Class Member
        Friend Sub New(ByVal Name As String, ByVal Realm As String, ByVal Region As RegionEnum)
            _Name = Name
            _Realm = Realm
            _Region = Region
        End Sub

        Protected _Realm As String
        Protected _Region As RegionEnum

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Friend Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Protected _Name As String

        Public Property Gender() As GenderEnum
            Get
                Return _Gender
            End Get
            Set(ByVal value As GenderEnum)
                _Gender = value
            End Set
        End Property
        Protected _Gender As GenderEnum

        Public Property CharClass() As ClassEnum
            Get
                Return _Class
            End Get
            Set(ByVal value As ClassEnum)
                _Class = value
            End Set
        End Property
        Protected _Class As ClassEnum

        Public Property Race() As RaceEnum
            Get
                Return _Race
            End Get
            Set(ByVal value As RaceEnum)
                _Race = value
            End Set
        End Property
        Protected _Race As RaceEnum

        Public Function GetCharacter() As Character
            Return ArmoryParser.GetCharacter(_Realm, _Name, _Region)
        End Function

        Public ReadOnly Property ArmoryWebPath() As Uri
            Get
                Return New Uri(String.Format("{0}/character-sheet.xml?r={1}&n={2}", ArmoryParser.GetRegionPath(_Region), _Realm, _Name))
            End Get
        End Property
    End Class

    Public Class GuildMember
        Inherits Member

        Friend Sub New(ByVal Name As String, ByVal Realm As String, ByVal Region As RegionEnum)
            MyBase.New(Name, Realm, Region)
        End Sub

        Public Property Rank() As Integer
            Get
                Return _Rank
            End Get
            Set(ByVal value As Integer)
                _Rank = value
            End Set
        End Property
        Protected _Rank As Integer

        Public Property Level() As Integer
            Get
                Return _Level
            End Get
            Set(ByVal value As Integer)
                _Level = value
            End Set
        End Property
        Protected _Level As Integer
    End Class

    Public Class ArenaMember
        Inherits Member

        Friend Sub New(ByVal Name As String, ByVal Realm As String, ByVal Region As RegionEnum)
            MyBase.New(Name, Realm, Region)
            _WeekGames = New GamesInfo
            _SeasonGames = New GamesInfo
        End Sub

        Public Property Rank() As Integer
            Get
                Return _Rank
            End Get
            Set(ByVal value As Integer)
                _Rank = value
            End Set
        End Property
        Protected _Rank As Integer

        Protected _WeekGames As GamesInfo
        Protected _SeasonGames As GamesInfo
        Protected _GuildName As String

        Public ReadOnly Property GamesInWeek() As GamesInfo
            Get
                Return _WeekGames
            End Get
        End Property

        Public ReadOnly Property GamesInSeason() As GamesInfo
            Get
                Return _SeasonGames
            End Get
        End Property

        Public Property GuildName() As String
            Get
                Return _GuildName
            End Get
            Friend Set(ByVal value As String)
                _GuildName = value
            End Set
        End Property

        Public ReadOnly Property Guild() As Guild
            Get
                Return ArmoryParser.GetGuild(_Realm, _GuildName, _Region)
            End Get
        End Property
    End Class
End Namespace

