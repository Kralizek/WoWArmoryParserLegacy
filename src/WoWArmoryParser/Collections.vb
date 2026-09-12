Namespace WoWArmoryParser
    Public Class SkillCollection
        Inherits Generic.List(Of Skill)
    End Class

    Public Class ReputationCollection
        Inherits Generic.SortedDictionary(Of String, Reputation)
    End Class

    Public Class GroupedReputationCollection
        Inherits ReputationCollection

        Public Sub New(ByVal FactionCategoryName As String)
            _Name = FactionCategoryName
        End Sub

        Protected _Name As String
        Public ReadOnly Property Name() As String
            Get
                Return _Name
            End Get
        End Property
    End Class

    Public Class GuildMemberCollection
        Inherits Generic.List(Of GuildMember)
    End Class

    Public Class ArenaTeamCollection
        Inherits Generic.List(Of ArenaTeam)
    End Class

    Public Class ArenaTeamMemberCollection
        Inherits Generic.List(Of ArenaMember)
    End Class

    Public Class GuildBankTransactionCollection
        Inherits Generic.List(Of GuidBankTransaction)
    End Class
End Namespace
