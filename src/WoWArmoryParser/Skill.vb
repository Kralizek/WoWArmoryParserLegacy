Namespace WoWArmoryParser
    Public Class Skill
        Public Key As String
        Public Name As String
        Public Value As Integer
        Public Max As Integer

        Public ReadOnly Property Ratio() As Double
            Get
                Return IIf(Max > 0, (Value / Max), 1)
            End Get
        End Property
    End Class
End Namespace