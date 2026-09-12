Namespace WoWArmoryParser
    Public Class Item

        Protected _ID As Integer
        Protected _Level As Integer
        Protected _Quality As QualityEnum
        Protected _Name As String
        Protected _Icon As String
        Protected _IsValid As Boolean = False

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Public Property Level() As Integer
            Get
                Return _Level
            End Get
            Set(ByVal value As Integer)
                _Level = value
            End Set
        End Property

        Public Property Quality() As QualityEnum
            Get
                Return _Quality
            End Get
            Set(ByVal value As QualityEnum)
                _Quality = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Property Icon() As String
            Get
                Return _Icon
            End Get
            Set(ByVal value As String)
                _Icon = value
            End Set
        End Property

        Public Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
            Set(ByVal value As Boolean)
                _IsValid = value
            End Set
        End Property

        Public Function ExtraLargeIconWebPath() As Uri
            Return New Uri(String.Format("{1}/images/icons/64x64/{0}.jpg", _Icon, ArmoryParser.GetRegionPath(RegionEnum.USA)))
        End Function

        Public Function LargeIconWebPath() As Uri
            Return New Uri(String.Format("{1}/images/icons/43x43/{0}.png", _Icon, ArmoryParser.GetRegionPath(RegionEnum.USA)))
        End Function

        Public Function SmallIconWebPath() As Uri
            Return New Uri(String.Format("{1}/images/icons/21x21/{0}.png", _Icon, ArmoryParser.GetRegionPath(RegionEnum.USA)))
        End Function

        Public Function ItemWebLink() As Uri
            Return New Uri(String.Format("{1}/item-info.xml?i={0}", _ID, ArmoryParser.GetRegionPath(RegionEnum.USA)))
        End Function
    End Class
End Namespace