Namespace WoWArmoryParser
    Public MustInherit Class NotUpdatedException
        Inherits ApplicationException
    End Class

    Public MustInherit Class NotFoundException
        Inherits ApplicationException
    End Class

    Public MustInherit Class ParserException
        Inherits ApplicationException
    End Class

    Public Class CharacterNotUpdatedException
        Inherits NotUpdatedException
    End Class

    Public Class ArenaTeamNotFoundException
        Inherits NotFoundException
    End Class

    Public Class ArenaTeamLeaderNotFoundException
        Inherits NotFoundException
    End Class

    Public Class GuildNotFoundException
        Inherits NotFoundException
    End Class

    Public Class GuildLeaderNotFoundException
        Inherits NotFoundException
    End Class

    Public Class ClassNotValidException
        Inherits ParserException
    End Class

    Public Class RaceNotValidException
        Inherits ParserException
    End Class

    Public Class GenderNotValidException
        Inherits ParserException
    End Class

    Public Class SecondBarTypeNotValidException
        Inherits ParserException
    End Class

    Public Class ItemNotSetException
        Inherits ApplicationException
    End Class

    Public Class ArmoryAuthNotAuthenticatedException
        Inherits ApplicationException
    End Class

    Public Class GuildBankTransactionDateNotSetException
        Inherits ApplicationException
    End Class

    Public Class TransactionTypeNotValidException
        Inherits ParserException
    End Class

    Public Class ItemQualityNotValidExecption
        Inherits ParserException
    End Class
End Namespace
