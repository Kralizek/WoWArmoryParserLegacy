Namespace WoWArmoryParser
    Public Class Guild
        Friend Sub New()
            _GuildMembers = New GuildMemberCollection
        End Sub

        Protected _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Protected _Realm As String
        Public Property Realm() As String
            Get
                Return _Realm
            End Get
            Set(ByVal value As String)
                _Realm = value
            End Set
        End Property

        Protected _BattleGroup As String
        Public Property BattleGroup() As String
            Get
                Return _BattleGroup
            End Get
            Set(ByVal value As String)
                _BattleGroup = value
            End Set
        End Property

        Public Property Region() As RegionEnum
            Get
                Return _Region
            End Get
            Set(ByVal value As RegionEnum)
                _Region = value
            End Set
        End Property
        Protected _Region As RegionEnum

        Public ReadOnly Property Members() As GuildMemberCollection
            Get
                Return _GuildMembers
            End Get
        End Property
        Protected _GuildMembers As GuildMemberCollection

        Public Property GuildMaster() As GuildMember
            Get
                If _GuildMaster IsNot Nothing Then
                    Return _GuildMaster
                Else
                    Throw New GuildLeaderNotFoundException
                End If
            End Get
            Friend Set(ByVal value As GuildMember)
                _GuildMaster = value
            End Set
        End Property
        Protected _GuildMaster As GuildMember

        Public ReadOnly Property ArmoryWebPath() As Uri
            Get
                Return New Uri(String.Format("{0}/guild-info.xml?r={1}&n={2}", ArmoryParser.GetRegionPath(_Region), _Realm, _Name))
            End Get
        End Property
    End Class
End Namespace