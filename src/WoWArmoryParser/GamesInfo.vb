Namespace WoWArmoryParser
    Public Class GamesInfo

        Protected _Played As Integer
        Protected _Wins As Integer

        Public Property Played() As Integer
            Get
                Return _Played
            End Get
            Friend Set(ByVal value As Integer)
                _Played = value
            End Set
        End Property

        Public Property Wins() As Integer
            Get
                Return _Wins
            End Get
            Friend Set(ByVal value As Integer)
                _Wins = value
            End Set
        End Property

        Public ReadOnly Property Losses() As Integer
            Get
                Return (_Played - _Wins)
            End Get
        End Property

        Public ReadOnly Property WinPercentage() As Double
            Get
                If _Played = 0 OrElse _Wins = 0 Then
                    Return 0
                Else
                    Return (_Wins / _Played)
                End If
            End Get
        End Property
    End Class
End Namespace