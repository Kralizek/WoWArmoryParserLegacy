Namespace WoWArmoryParser
    Public Class Character

        Friend Sub New()
            _BaseStats = New BaseStats
            _Resistances = New Resistances
            _Skills = New Skills

            _Reputations = New ReputationCollection
            _GroupedReputations = New Reputations

            _Melee = New MeleeInfo
            _Ranged = New RangedInfo
            _Spell = New SpellInfo
            _Defense = New DefenseInfo

            _Equip = New EquipInfo
        End Sub

        Public Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
            Friend Set(ByVal value As Boolean)
                _IsValid = value
            End Set
        End Property
        Protected _IsValid As Boolean

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Friend Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Protected _Name As String

        Public Property CharClass() As ClassEnum
            Get
                Return _Class
            End Get
            Friend Set(ByVal value As ClassEnum)
                _Class = value
            End Set
        End Property
        Protected _Class As ClassEnum

        Public Property Race() As RaceEnum
            Get
                Return _Race
            End Get
            Friend Set(ByVal value As RaceEnum)
                _Race = value
            End Set
        End Property
        Protected _Race As RaceEnum

        Public Property Faction() As FactionEnum
            Get
                Return _Faction
            End Get
            Friend Set(ByVal value As FactionEnum)
                _Faction = value
            End Set
        End Property
        Protected _Faction As FactionEnum

        Public Property Realm() As String
            Get
                Return _Realm
            End Get
            Friend Set(ByVal value As String)
                _Realm = value
            End Set
        End Property
        Protected _Realm As String

        Public ReadOnly Property Guild() As Guild
            Get
                Return ArmoryParser.GetGuild(_Realm, _GuildName, _Region)
            End Get
        End Property
        Public Property GuildName() As String
            Friend Set(ByVal value As String)
                _GuildName = value
            End Set
            Get
                Return _GuildName
            End Get
        End Property
        Protected _GuildName As String

        Public Property Level() As Integer
            Get
                Return _Level
            End Get
            Friend Set(ByVal value As Integer)
                _Level = value
            End Set
        End Property
        Protected _Level As Integer

        Public Property Region() As RegionEnum
            Get
                Return _Region
            End Get
            Friend Set(ByVal value As RegionEnum)
                _Region = value
            End Set
        End Property
        Protected _Region As RegionEnum

        Public Property Gender() As GenderEnum
            Get
                Return _Gender
            End Get
            Friend Set(ByVal value As GenderEnum)
                _Gender = value
            End Set
        End Property
        Protected _Gender As GenderEnum

        Public Property LastUpdate() As DateTime
            Get
                Return _LastUpdate.Date
            End Get
            Friend Set(ByVal value As DateTime)
                _LastUpdate = value
            End Set
        End Property
        Protected _LastUpdate As DateTime

        Public Property LifeTimeHonorableKills() As Integer
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _LifeTimeHonorableKills
            End Get
            Friend Set(ByVal value As Integer)
                _LifeTimeHonorableKills = value
            End Set
        End Property
        Protected _LifeTimeHonorableKills As Integer

        Public Property TalentSpec() As TalentSpec
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _TalentSpec
            End Get
            Friend Set(ByVal value As TalentSpec)
                _TalentSpec = value
            End Set
        End Property
        Protected _TalentSpec As TalentSpec

        Public Property HealthBar() As CharacterBar
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _HealthBar
            End Get
            Friend Set(ByVal value As CharacterBar)
                _HealthBar = value
            End Set
        End Property
        Protected _HealthBar As CharacterBar

        Public Property SecondBar() As CharacterBar
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _SecondBar
            End Get
            Friend Set(ByVal value As CharacterBar)
                _SecondBar = value
            End Set
        End Property
        Protected _SecondBar As CharacterBar

        Public ReadOnly Property BaseStats() As BaseStats
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _BaseStats
            End Get
        End Property
        Protected _BaseStats As BaseStats

        Public ReadOnly Property Resistances() As Resistances
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _Resistances
            End Get
        End Property
        Protected _Resistances As Resistances

        Public ReadOnly Property Skills() As Skills
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _Skills
            End Get
        End Property
        Protected _Skills As Skills

        Public ReadOnly Property GroupedReputations() As Reputations
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException()
                Return _GroupedReputations
            End Get
        End Property
        Protected _GroupedReputations As Reputations

        Public ReadOnly Property Reputations() As ReputationCollection
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException
                Return _Reputations
            End Get
        End Property
        Protected _Reputations As ReputationCollection

        Public Function CanBuyShattrathFlasks() As Boolean
            Dim res As Boolean = False

            Dim cenarion As Reputation
            Dim shatar As Reputation
            Dim aldor As Reputation
            Dim scryers As Reputation

            If _Reputations.ContainsKey(ReputationList.CenarionExpedition) AndAlso _Reputations.ContainsKey(ReputationList.TheShatar) AndAlso _Reputations.ContainsKey(ReputationList.TheAldor) AndAlso _Reputations.ContainsKey(ReputationList.TheScryers) Then
                cenarion = _Reputations(ReputationList.CenarionExpedition)
                shatar = _Reputations(ReputationList.TheShatar)
                aldor = _Reputations(ReputationList.TheAldor)
                scryers = _Reputations(ReputationList.TheScryers)
                res = (cenarion.Status = ReputationEnum.Exalted AndAlso shatar.Status = ReputationEnum.Exalted AndAlso (aldor.Status = ReputationEnum.Exalted Xor scryers.Status = ReputationEnum.Exalted))
            Else
                res = False
            End If
            Return res
        End Function

        Public ReadOnly Property Melee() As MeleeInfo
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException
                Return _Melee
            End Get
        End Property
        Protected _Melee As MeleeInfo

        Public ReadOnly Property Ranged() As RangedInfo
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException
                Return _Ranged
            End Get
        End Property
        Protected _Ranged As RangedInfo

        Public ReadOnly Property Spell() As SpellInfo
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException
                Return _Spell
            End Get
        End Property
        Protected _Spell As SpellInfo

        Public ReadOnly Property Defense() As DefenseInfo
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException
                Return _Defense
            End Get
        End Property
        Protected _Defense As DefenseInfo

        Protected _Equip As EquipInfo
        Public ReadOnly Property Equip() As EquipInfo
            Get
                If Not _IsValid Then Throw New CharacterNotUpdatedException
                Return _Equip
            End Get
        End Property

        Protected _Team2v2Name As String
        Friend Property Team2v2Name() As String
            Get
                Return _Team2v2Name
            End Get
            Set(ByVal value As String)
                _Team2v2Name = value
            End Set
        End Property
        Public ReadOnly Property Team2v2() As ArenaTeam
            Get
                Return ArmoryParser.GetArenaTeam(_Realm, _Team2v2Name, ArenaTeamSizeEnum.Team2v2, _Region)
            End Get
        End Property

        Protected _Team3v3Name As String
        Friend Property Team3v3Name() As String
            Get
                Return _Team3v3Name
            End Get
            Set(ByVal value As String)
                _Team3v3Name = value
            End Set
        End Property
        Public ReadOnly Property Team3v3() As ArenaTeam
            Get
                Return ArmoryParser.GetArenaTeam(_Realm, _Team3v3Name, ArenaTeamSizeEnum.Team3v3, _Region)
            End Get
        End Property

        Protected _Team5v5Name As String
        Friend Property Team5v5Name() As String
            Get
                Return _Team5v5Name
            End Get
            Set(ByVal value As String)
                _Team5v5Name = value
            End Set
        End Property
        Public ReadOnly Property Team5v5() As ArenaTeam
            Get
                Return ArmoryParser.GetArenaTeam(_Realm, _Team5v5Name, ArenaTeamSizeEnum.Team5v5, _Region)
            End Get
        End Property

        Public ReadOnly Property ArmoryWebPath() As Uri
            Get
                Return New Uri(String.Format("{0}/character-sheet.xml?r={1}&n={2}", ArmoryParser.GetRegionPath(_Region), _Realm, _Name))
            End Get
        End Property
    End Class

    Public Class BaseStats
        Public Sub New(ByVal Str As Integer, ByVal Agi As Integer, ByVal Sta As Integer, ByVal Int As Integer, ByVal Spi As Integer, ByVal Arm As Integer)
            _Strength = Str
            _Agility = Agi
            _Stamina = Sta
            _Intellect = Int
            _Spirit = Spi
            _Armor = Arm
        End Sub

        Public Sub New()

        End Sub

        Protected _Strength As Integer
        Protected _Agility As Integer
        Protected _Stamina As Integer
        Protected _Intellect As Integer
        Protected _Spirit As Integer
        Protected _Armor As Integer

        Public Property Strength() As Integer
            Get
                Return _Strength
            End Get
            Set(ByVal value As Integer)
                _Strength = value
            End Set
        End Property

        Public Property Agility() As Integer
            Get
                Return _Agility
            End Get
            Set(ByVal value As Integer)
                _Agility = value
            End Set
        End Property

        Public Property Stamina() As Integer
            Get
                Return _Stamina
            End Get
            Set(ByVal value As Integer)
                _Stamina = value
            End Set
        End Property

        Public Property Intellect() As Integer
            Get
                Return _Intellect
            End Get
            Set(ByVal value As Integer)
                _Intellect = value
            End Set
        End Property

        Public Property Spirit() As Integer
            Get
                Return _Spirit
            End Get
            Set(ByVal value As Integer)
                _Spirit = value
            End Set
        End Property

        Public Property Armor() As Integer
            Get
                Return _Armor
            End Get
            Set(ByVal value As Integer)
                _Armor = value
            End Set
        End Property
    End Class

    Public Class Resistances
        Public Sub New(ByVal Arcane As Integer, ByVal Fire As Integer, ByVal Frost As Integer, ByVal Holy As Integer, ByVal Nature As Integer, ByVal Shadow As Integer)
            _ArcaneRes = Arcane
            _FireRes = Fire
            _FrostRes = Frost
            _HolyRes = Holy
            _NatureRes = Nature
            _ShadowRes = Shadow
        End Sub

        Public Sub New()

        End Sub

        Protected _ArcaneRes As Integer
        Protected _FireRes As Integer
        Protected _FrostRes As Integer
        Protected _HolyRes As Integer
        Protected _NatureRes As Integer
        Protected _ShadowRes As Integer

        Public Property ArcaneRes() As Integer
            Get
                Return _ArcaneRes
            End Get
            Set(ByVal value As Integer)
                _ArcaneRes = value
            End Set
        End Property

        Public Property FireRes() As Integer
            Get
                Return _FireRes
            End Get
            Set(ByVal value As Integer)
                _FireRes = value
            End Set
        End Property

        Public Property FrostRes() As Integer
            Get
                Return _FrostRes
            End Get
            Set(ByVal value As Integer)
                _FrostRes = value
            End Set
        End Property

        Public Property HolyRes() As Integer
            Get
                Return _HolyRes
            End Get
            Set(ByVal value As Integer)
                _HolyRes = value
            End Set
        End Property

        Public Property NatureRes() As Integer
            Get
                Return _NatureRes
            End Get
            Set(ByVal value As Integer)
                _NatureRes = value
            End Set
        End Property

        Public Property ShadowRes() As Integer
            Get
                Return _ShadowRes
            End Get
            Set(ByVal value As Integer)
                _ShadowRes = value
            End Set
        End Property
    End Class

    Public Class CharacterBar
        Public Total As Integer
        Public Type As BarType

        Public Function ToTypeString() As String
            Return System.Enum.GetName(GetType(BarType), Type)
        End Function
    End Class

    Public Class Skills
        Public Sub New()

        End Sub

        Public Property Professions() As SkillCollection
            Get
                Return _Professions
            End Get
            Friend Set(ByVal value As SkillCollection)
                _Professions = value
            End Set
        End Property
        Protected _Professions As SkillCollection

        Public Property SecondarySkills() As SkillCollection
            Get
                Return _SecondarySkills
            End Get
            Friend Set(ByVal value As SkillCollection)
                _SecondarySkills = value
            End Set
        End Property
        Protected _SecondarySkills As SkillCollection

        Public Property WeaponsSkills() As SkillCollection
            Get
                Return _WeaponsSkills
            End Get
            Friend Set(ByVal value As SkillCollection)
                _WeaponsSkills = value
            End Set
        End Property
        Protected _WeaponsSkills As SkillCollection

        Public Property ClassSkills() As SkillCollection
            Get
                Return _ClassSkills
            End Get
            Friend Set(ByVal value As SkillCollection)
                _ClassSkills = value
            End Set
        End Property
        Protected _ClassSkills As SkillCollection

        Public Property ArmorProficiencies() As SkillCollection
            Get
                Return _ArmorProficiencies
            End Get
            Friend Set(ByVal value As SkillCollection)
                _ArmorProficiencies = value
            End Set
        End Property
        Protected _ArmorProficiencies As SkillCollection

        Public Property Languages() As SkillCollection
            Get
                Return _Languages
            End Get
            Friend Set(ByVal value As SkillCollection)
                _Languages = value
            End Set
        End Property
        Protected _Languages As SkillCollection
    End Class

    Public Class Reputations
        Public Sub New()
            _RepsCollection = New Generic.List(Of GroupedReputationCollection)
        End Sub

        Public ReadOnly Property FactionsCollection() As List(Of GroupedReputationCollection)
            Get
                Return _RepsCollection
            End Get
        End Property
        Protected _RepsCollection As List(Of GroupedReputationCollection)

        Public Property Faction() As GroupedReputationCollection
            Get
                Return _Faction
            End Get
            Friend Set(ByVal value As GroupedReputationCollection)
                _Faction = value
                _RepsCollection.Add(_Faction)
            End Set
        End Property
        Protected _Faction As GroupedReputationCollection

        Public Property BattleGrounds() As GroupedReputationCollection
            Get
                Return _BattleGrounds
            End Get
            Friend Set(ByVal value As GroupedReputationCollection)
                _BattleGrounds = value
                _RepsCollection.Add(_BattleGrounds)
            End Set
        End Property
        Protected _BattleGrounds As GroupedReputationCollection

        Public Property Outland() As GroupedReputationCollection
            Get
                Return _Outland
            End Get
            Friend Set(ByVal value As GroupedReputationCollection)
                _Outland = value
                _RepsCollection.Add(_Outland)
            End Set
        End Property
        Protected _Outland As GroupedReputationCollection

        Public Property ShattrathCity() As GroupedReputationCollection
            Get
                Return _Shattrath
            End Get
            Friend Set(ByVal value As GroupedReputationCollection)
                _Shattrath = value
                _RepsCollection.Add(_Shattrath)
            End Set
        End Property
        Protected _Shattrath As GroupedReputationCollection

        Public Property SteamwheedleCartel() As GroupedReputationCollection
            Get
                Return _SteamwheedleCartel
            End Get
            Friend Set(ByVal value As GroupedReputationCollection)
                _SteamwheedleCartel = value
                _RepsCollection.Add(_SteamwheedleCartel)
            End Set
        End Property
        Protected _SteamwheedleCartel As GroupedReputationCollection

        Public Property Others() As GroupedReputationCollection
            Get
                Return _Other
            End Get
            Friend Set(ByVal value As GroupedReputationCollection)
                _Other = value
                _RepsCollection.Add(_Other)
            End Set
        End Property
        Protected _Other As GroupedReputationCollection
    End Class

    Public Class TalentSpec
        Friend Sub New(ByVal One As Integer, ByVal Two As Integer, ByVal Three As Integer)
            _One = One
            _Two = Two
            _Three = Three
        End Sub

        Friend Sub New()

        End Sub

        Public Property TreeOne() As Integer
            Get
                Return _One
            End Get
            Set(ByVal value As Integer)
                _One = value
            End Set
        End Property

        Public Property TreeTwo() As Integer
            Get
                Return _Two
            End Get
            Set(ByVal value As Integer)
                _Two = value
            End Set
        End Property

        Public Property TreeThree() As Integer
            Get
                Return _Three
            End Get
            Set(ByVal value As Integer)
                _Three = value
            End Set
        End Property

        Public Overloads Overrides Function ToString() As String
            Return String.Format("{0}/{1}/{2}", _One, _Two, _Three)
        End Function

        Public Overloads Function ToString(ByVal Format As String)
            Return String.Format(Format, _One, _Two, _Three)
        End Function

        Protected _One As Integer
        Protected _Two As Integer
        Protected _Three As Integer
    End Class

    Public Class EquipInfo
        Public Sub New()
            _Dict = New Dictionary(Of EquipSlotEnum, Integer)
        End Sub

        Protected _Dict As Generic.Dictionary(Of EquipSlotEnum, Integer)

        Public Property Item(ByVal Slot As EquipSlotEnum) As Item
            Get
                If Not _Dict.ContainsKey(Slot) Then Throw New ItemNotSetException
                Return ArmoryParser.GetItem(_Dict(Slot))
            End Get
            Set(ByVal value As Item)
                If _Dict.ContainsKey(Slot) Then
                    _Dict(Slot) = value.ID
                Else
                    _Dict.Add(Slot, value.ID)
                End If
            End Set
        End Property

        Public Property ItemID(ByVal Slot As EquipSlotEnum) As Integer
            Get
                If Not _Dict.ContainsKey(Slot) Then Throw New ItemNotSetException
                Return _Dict(Slot)
            End Get
            Set(ByVal value As Integer)
                If _Dict.ContainsKey(Slot) Then
                    _Dict(Slot) = value
                Else
                    _Dict.Add(Slot, value)
                End If
            End Set
        End Property

        Public Property Head() As Item
            Get
                Return Item(EquipSlotEnum.Head)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Head) = value
            End Set
        End Property

        Public Property Neck() As Item
            Get
                Return Item(EquipSlotEnum.Neck)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Neck) = value
            End Set
        End Property

        Public Property Shoulder() As Item
            Get
                Return Item(EquipSlotEnum.Shoulder)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Shoulder) = value
            End Set
        End Property

        Public Property Back() As Item
            Get
                Return Item(EquipSlotEnum.Back)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Back) = value
            End Set
        End Property

        Public Property Chest() As Item
            Get
                Return Item(EquipSlotEnum.Chest)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Chest) = value
            End Set
        End Property

        Public Property Shirt() As Item
            Get
                Return Item(EquipSlotEnum.Shirt)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Shirt) = value
            End Set
        End Property

        Public Property Tabard() As Item
            Get
                Return Item(EquipSlotEnum.Tabard)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Tabard) = value
            End Set
        End Property

        Public Property Wrist() As Item
            Get
                Return Item(EquipSlotEnum.Wrist)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Wrist) = value
            End Set
        End Property

        Public Property Hands() As Item
            Get
                Return Item(EquipSlotEnum.Hand)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Hand) = value
            End Set
        End Property

        Public Property Waist() As Item
            Get
                Return Item(EquipSlotEnum.Waist)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Waist) = value
            End Set
        End Property

        Public Property Legs() As Item
            Get
                Return Item(EquipSlotEnum.Legs)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Legs) = value
            End Set
        End Property

        Public Property Feet() As Item
            Get
                Return Item(EquipSlotEnum.Feet)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Feet) = value
            End Set
        End Property

        Public Property Ring1() As Item
            Get
                Return Item(EquipSlotEnum.Ring1)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Ring1) = value
            End Set
        End Property

        Public Property Ring2() As Item
            Get
                Return Item(EquipSlotEnum.Ring2)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Ring2) = value
            End Set
        End Property

        Public Property Trinket1() As Item
            Get
                Return Item(EquipSlotEnum.Trinket1)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Trinket1) = value
            End Set
        End Property

        Public Property Trinket2() As Item
            Get
                Return Item(EquipSlotEnum.Trinket2)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Trinket2) = value
            End Set
        End Property

        Public Property MainHand() As Item
            Get
                Return Item(EquipSlotEnum.MainHand)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.MainHand) = value
            End Set
        End Property

        Public Property OffHand() As Item
            Get
                Return Item(EquipSlotEnum.OffHand)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.OffHand) = value
            End Set
        End Property

        Public Property Ranged() As Item
            Get
                Return Item(EquipSlotEnum.Ranged)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Ranged) = value
            End Set
        End Property

        Public Property Ammo() As Item
            Get
                Return Item(EquipSlotEnum.Ammo)
            End Get
            Set(ByVal value As Item)
                Item(EquipSlotEnum.Ammo) = value
            End Set
        End Property
    End Class
End Namespace

