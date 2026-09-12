Namespace WoWArmoryParser
    Public Class ArenaTeam
        Friend Sub New()
            _WeekGames = New GamesInfo
            _SeasonGames = New GamesInfo
            _Members = New ArenaTeamMemberCollection
            _Emblem = New ArenaEmblem
        End Sub

        Protected _Region As RegionEnum
        Protected _BattleGroup As String
        Protected _Faction As FactionEnum
        Protected _Realm As String
        Protected _Name As String
        Protected _Size As ArenaTeamSizeEnum
        Protected _Ranking As Integer
        Protected _Rating As Integer
        Protected _WeekGames As GamesInfo
        Protected _SeasonGames As GamesInfo
        Protected _Members As ArenaTeamMemberCollection
        Protected _Leader As ArenaMember
        Protected _Emblem As ArenaEmblem

        Public Property Region() As RegionEnum
            Get
                Return _Region
            End Get
            Friend Set(ByVal value As RegionEnum)
                _Region = value
            End Set
        End Property

        Public Property BattleGroup() As String
            Get
                Return _BattleGroup
            End Get
            Friend Set(ByVal value As String)
                _BattleGroup = value
            End Set
        End Property

        Public Property Faction() As FactionEnum
            Get
                Return _Faction
            End Get
            Friend Set(ByVal value As FactionEnum)
                _Faction = value
            End Set
        End Property

        Public Property Realm() As String
            Get
                Return _Realm
            End Get
            Friend Set(ByVal value As String)
                _Realm = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Friend Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Property Size() As ArenaTeamSizeEnum
            Get
                Return _Size
            End Get
            Friend Set(ByVal value As ArenaTeamSizeEnum)
                _Size = value
            End Set
        End Property

        Public Property Ranking() As Integer
            Get
                Return _Ranking
            End Get
            Friend Set(ByVal value As Integer)
                _Ranking = value
            End Set
        End Property

        Public Property Rating() As Integer
            Get
                Return _Rating
            End Get
            Friend Set(ByVal value As Integer)
                _Rating = value
            End Set
        End Property

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

        Public ReadOnly Property Members() As ArenaTeamMemberCollection
            Get
                Return _Members
            End Get
        End Property

        Public Property Leader() As ArenaMember
            Get
                If _Leader IsNot Nothing Then
                    Return _Leader
                Else
                    Throw New ArenaTeamLeaderNotFoundException
                End If
            End Get
            Friend Set(ByVal value As ArenaMember)
                _Leader = value
            End Set
        End Property

        Public ReadOnly Property Emblem() As ArenaEmblem
            Get
                Return _Emblem
            End Get
        End Property

        Public ReadOnly Property ArmoryWebPath() As System.Uri
            Get
                Return New Uri(String.Format("{0}/team-info.xml?r={1}&t={2}&ts={3}", ArmoryParser.GetRegionPath(_Region), _Realm, _Name, CType(_Size, Integer)))
            End Get
        End Property

    End Class

    Public Class ArenaEmblem
        Friend Sub New()

        End Sub

        Protected _BackgroundColor As String
        Protected _BorderColor As String
        Protected _BorderStyle As Integer
        Protected _IconColor As String
        Protected _IconStyle As Integer

        Public Property BackgroundColor() As String
            Get
                Return _BackgroundColor
            End Get
            Friend Set(ByVal value As String)
                _BackgroundColor = value
            End Set
        End Property

        Public Property BorderColor() As String
            Get
                Return _BorderColor
            End Get
            Friend Set(ByVal value As String)
                _BorderColor = value
            End Set
        End Property

        Public Property IconColor() As String
            Get
                Return _IconColor
            End Get
            Friend Set(ByVal value As String)
                _IconColor = value
            End Set
        End Property

        Public Property BorderStyle() As Integer
            Get
                Return _BorderStyle
            End Get
            Friend Set(ByVal value As Integer)
                _BorderStyle = value
            End Set
        End Property

        Public Property IconStyle() As Integer
            Get
                Return _IconStyle
            End Get
            Friend Set(ByVal value As Integer)
                _IconStyle = value
            End Set
        End Property
    End Class
End Namespace