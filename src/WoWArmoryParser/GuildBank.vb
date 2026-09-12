Namespace WoWArmoryParser
    Public Class GuildBankLog
        Friend Sub New()
            _Transacitons = New GuildBankTransactionCollection
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

        Public Property Region() As RegionEnum
            Get
                Return _Region
            End Get
            Set(ByVal value As RegionEnum)
                _Region = value
            End Set
        End Property
        Protected _Region As RegionEnum

        Public ReadOnly Property Transactions() As GuildBankTransactionCollection
            Get
                Return _Transacitons
            End Get
        End Property
        Protected _Transacitons As GuildBankTransactionCollection

        Public ReadOnly Property ArmoryWebPath() As Uri
            Get
                Return New Uri(String.Format("{0}/guild-bank-log.xml?r={1}&n={2}", ArmoryParser.GetRegionPath(_Region), _Realm, _Name))
            End Get
        End Property
    End Class

    Public Class GuidBankTransaction

    End Class
End Namespace