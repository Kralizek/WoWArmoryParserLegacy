
Namespace WoWArmoryParser
    Public Class MeleeInfo
        Public Sub New()
            _MainHand = New WeaponInfo
            _OffHand = New WeaponInfo
            _HitRating = New HitRatingInfo
            _Crit = New CritInfo
            _AttackPower = New AttackPowerInfo
        End Sub

        Protected _MainHand As WeaponInfo
        Protected _OffHand As WeaponInfo
        Protected _HitRating As HitRatingInfo
        Protected _Crit As CritInfo
        Protected _AttackPower As AttackPowerInfo

        Public ReadOnly Property MainHand() As WeaponInfo
            Get
                Return _MainHand
            End Get
        End Property

        Public ReadOnly Property OffHand() As WeaponInfo
            Get
                Return _OffHand
            End Get
        End Property

        Public ReadOnly Property HitRating() As HitRatingInfo
            Get
                Return _HitRating
            End Get
        End Property

        Public ReadOnly Property CritChance() As CritInfo
            Get
                Return _Crit
            End Get
        End Property

        Public ReadOnly Property AttackPower() As AttackPowerInfo
            Get
                Return _AttackPower
            End Get
        End Property
    End Class

    Public Class RangedInfo
        Public Sub New()
            _Weapon = New WeaponInfo
            _HitRating = New HitRatingInfo
            _Crit = New CritInfo
            _AttackPower = New AttackPowerInfo
        End Sub

        Protected _Weapon As WeaponInfo
        Protected _HitRating As HitRatingInfo
        Protected _Crit As CritInfo
        Protected _AttackPower As AttackPowerInfo

        Public ReadOnly Property Weapon() As WeaponInfo
            Get
                Return _Weapon
            End Get
        End Property

        Public ReadOnly Property HitRating() As HitRatingInfo
            Get
                Return _HitRating
            End Get
        End Property

        Public ReadOnly Property CritChance() As CritInfo
            Get
                Return _Crit
            End Get
        End Property

        Public ReadOnly Property AttackPower() As AttackPowerInfo
            Get
                Return _AttackPower
            End Get
        End Property
    End Class

    Public Class SpellInfo

        Public Sub New()
            _Arcane = New SpellSchool
            _Fire = New SpellSchool
            _Frost = New SpellSchool
            _Holy = New SpellSchool
            _Nature = New SpellSchool
            _Shadow = New SpellSchool

            _HitRating = New HitRatingInfo
            _ManaRegen = New ManaRegenInfo
        End Sub

        Protected _Arcane As SpellSchool
        Protected _Fire As SpellSchool
        Protected _Frost As SpellSchool
        Protected _Holy As SpellSchool
        Protected _Nature As SpellSchool
        Protected _Shadow As SpellSchool

        Public ReadOnly Property Arcane() As SpellSchool
            Get
                Return _Arcane
            End Get
        End Property

        Public ReadOnly Property Fire() As SpellSchool
            Get
                Return _Fire
            End Get
        End Property

        Public ReadOnly Property Frost() As SpellSchool
            Get
                Return _Frost
            End Get
        End Property

        Public ReadOnly Property Holy() As SpellSchool
            Get
                Return _Holy
            End Get
        End Property

        Public ReadOnly Property Nature() As SpellSchool
            Get
                Return _Nature
            End Get
        End Property

        Public ReadOnly Property Shadow() As SpellSchool
            Get
                Return _Shadow
            End Get
        End Property

        Protected _CritRating As Integer
        Public Property CritRating() As Integer
            Get
                Return _CritRating
            End Get
            Set(ByVal value As Integer)
                _CritRating = value
            End Set
        End Property

        Protected _HitRating As HitRatingInfo
        Public ReadOnly Property HitRating() As HitRatingInfo
            Get
                Return _HitRating
            End Get
        End Property

        Protected _ManaRegen As ManaRegenInfo
        Public ReadOnly Property ManaRegen() As ManaRegenInfo
            Get
                Return _ManaRegen
            End Get
        End Property

        Protected _SpellPenetration As Integer
        Public Property SpellPenetration() As Integer
            Get
                Return _SpellPenetration
            End Get
            Set(ByVal value As Integer)
                _SpellPenetration = value
            End Set
        End Property

        Protected _HealingBonus As Integer
        Public Property HealingBonus() As Integer
            Get
                Return _HealingBonus
            End Get
            Set(ByVal value As Integer)
                _HealingBonus = value
            End Set
        End Property
    End Class

    Public Class DefenseInfo
        Public Sub New()
            _Armor = New ArmorInfo
            _Defense = New DefenseStatInfo
            _Parry = New ParryInfo
            _Block = New BlockInfo
            _Dodge = New DodgeInfo
            _Resilience = New ResilienceInfo
        End Sub

        Protected _Armor As ArmorInfo
        Protected _Defense As DefenseStatInfo
        Protected _Dodge As DodgeInfo
        Protected _Parry As ParryInfo
        Protected _Block As BlockInfo
        Protected _Resilience As ResilienceInfo

        Public ReadOnly Property Armor() As ArmorInfo
            Get
                Return _Armor
            End Get
        End Property

        Public ReadOnly Property Defense() As DefenseStatInfo
            Get
                Return _Defense
            End Get
        End Property

        Public ReadOnly Property Dodge() As DodgeInfo
            Get
                Return _Dodge
            End Get
        End Property

        Public ReadOnly Property Parry() As ParryInfo
            Get
                Return _Parry
            End Get
        End Property

        Public ReadOnly Property Block() As BlockInfo
            Get
                Return _Block
            End Get
        End Property

        Public ReadOnly Property Resilience() As ResilienceInfo
            Get
                Return _Resilience
            End Get
        End Property
    End Class

    Public Class ManaRegenInfo
        Protected _WhileCasting As Double
        Protected _WhileNotCasting As Double

        Public Property WhileCasting() As Double
            Get
                Return _WhileCasting
            End Get
            Set(ByVal value As Double)
                _WhileCasting = value
            End Set
        End Property

        Public Property WhileNotCasting() As Double
            Get
                Return _WhileNotCasting
            End Get
            Set(ByVal value As Double)
                _WhileNotCasting = value
            End Set
        End Property
    End Class

    Public Class HitRatingInfo
        Protected _IncreasedHitChance As Double
        Protected _Value As Integer

        Public Property IncreasedHitChance() As Double
            Get
                Return _IncreasedHitChance
            End Get
            Set(ByVal value As Double)
                _IncreasedHitChance = value
            End Set
        End Property

        Public Property Value() As Integer
            Get
                Return _Value
            End Get
            Set(ByVal value As Integer)
                _Value = value
            End Set
        End Property
    End Class

    Public Class SpellSchool
        Public Sub New()

        End Sub

        Protected _BonusDmg As Integer
        Protected _CritChance As Double

        Public Property DamageBonus() As Integer
            Get
                Return _BonusDmg
            End Get
            Set(ByVal value As Integer)
                _BonusDmg = value
            End Set
        End Property

        Public Property CritChance() As Double
            Get
                Return _CritChance
            End Get
            Set(ByVal value As Double)
                _CritChance = value
            End Set
        End Property
    End Class

    Public Class WeaponInfo
        Public Sub New()
            _Skill = New SkillInfo
            _Damage = New DamageInfo
            _Speed = New SpeedInfo
        End Sub

        Public ReadOnly Property Skill() As SkillInfo
            Get
                Return _Skill
            End Get
        End Property

        Public ReadOnly Property Damage() As DamageInfo
            Get
                Return _Damage
            End Get
        End Property

        Public ReadOnly Property Speed() As SpeedInfo
            Get
                Return _Speed
            End Get
        End Property

        Protected _Skill As SkillInfo
        Protected _Damage As DamageInfo
        Protected _Speed As SpeedInfo

    End Class

    Public Class SkillInfo
        Protected _Rating As Integer
        Protected _Value As Integer

        Public Property Rating() As Integer
            Get
                Return _Rating
            End Get
            Set(ByVal value As Integer)
                _Rating = value
            End Set
        End Property

        Public Property Value() As Integer
            Get
                Return _Value
            End Get
            Set(ByVal value As Integer)
                _Value = value
            End Set
        End Property
    End Class

    Public Class DamageInfo
        Protected _DPS As Double
        Protected _Max As Integer
        Protected _Min As Integer
        Protected _Percent As Double
        Protected _Speed As Double

        Public Property DPS() As Double
            Get
                Return _DPS
            End Get
            Set(ByVal value As Double)
                _DPS = value
            End Set
        End Property

        Public Property Max() As Integer
            Get
                Return _Max
            End Get
            Set(ByVal value As Integer)
                _Max = value
            End Set
        End Property

        Public Property Min() As Integer
            Get
                Return _Min
            End Get
            Set(ByVal value As Integer)
                _Min = value
            End Set
        End Property

        Public Property Percent() As Double
            Get
                Return _Percent
            End Get
            Set(ByVal value As Double)
                _Percent = value
            End Set
        End Property

        Public Property Speed() As Double
            Get
                Return _Speed
            End Get
            Set(ByVal value As Double)
                _Speed = value
            End Set
        End Property
    End Class

    Public Class SpeedInfo
        Protected _HastePercent As Double
        Protected _HasteRating As Integer
        Protected _Value As Double

        Public Property HastePercent() As Double
            Get
                Return _HastePercent
            End Get
            Set(ByVal value As Double)
                _HastePercent = value
            End Set
        End Property

        Public Property HasteRating() As Integer
            Get
                Return _HasteRating
            End Get
            Set(ByVal value As Integer)
                _HasteRating = value
            End Set
        End Property

        Public Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal value As Double)
                _Value = value
            End Set
        End Property
    End Class

    Public Class RatingStat
        Protected _Percent As Double
        Protected _IncreasedByRating As Double
        Protected _Rating As Double

        Public Property Percent() As Double
            Get
                Return _Percent
            End Get
            Set(ByVal value As Double)
                _Percent = value
            End Set
        End Property

        Public Property IncreasedByRating() As Double
            Get
                Return _IncreasedByRating
            End Get
            Set(ByVal value As Double)
                _IncreasedByRating = value
            End Set
        End Property

        Public Property Rating() As Double
            Get
                Return _Rating
            End Get
            Set(ByVal value As Double)
                _Rating = value
            End Set
        End Property
    End Class

    Public Class CritInfo
        Inherits RatingStat
    End Class

    Public Class AttackPowerInfo

        Protected _Base As Integer
        Protected _Effective As Integer
        Protected _IncreasedDPS As Double

        Public Property Base() As Integer
            Get
                Return _Base
            End Get
            Set(ByVal value As Integer)
                _Base = value
            End Set
        End Property

        Public Property Effective() As Integer
            Get
                Return _Effective
            End Get
            Set(ByVal value As Integer)
                _Effective = value
            End Set
        End Property

        Public Property IncreasedDPS() As Double
            Get
                Return _IncreasedDPS
            End Get
            Set(ByVal value As Double)
                _IncreasedDPS = value
            End Set
        End Property
    End Class

    Public Class ArmorInfo
        Protected _Base As Integer
        Protected _Effective As Integer
        Protected _DamageReductionPercent As Double

        Public Property Base() As Integer
            Get
                Return _Base
            End Get
            Set(ByVal value As Integer)
                _Base = value
            End Set
        End Property

        Public Property Effective() As Integer
            Get
                Return _Effective
            End Get
            Set(ByVal value As Integer)
                _Effective = value
            End Set
        End Property

        Public Property DamageReductionPercent() As Double
            Get
                Return _DamageReductionPercent
            End Get
            Set(ByVal value As Double)
                _DamageReductionPercent = value
            End Set
        End Property
    End Class

    Public Class DefenseStatInfo

        Protected _Rating As Double
        Public Property Rating() As Double
            Get
                Return _Rating
            End Get
            Set(ByVal value As Double)
                _Rating = value
            End Set
        End Property

        Protected _Value As Double
        Public Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal value As Double)
                _Value = value
            End Set
        End Property
    End Class

    Public Class DodgeInfo
        Inherits RatingStat
    End Class

    Public Class ParryInfo
        Inherits RatingStat
    End Class

    Public Class BlockInfo
        Inherits RatingStat
    End Class

    Public Class ResilienceInfo
        Protected _Damage As Double
        Protected _Hit As Double
        Protected _Rating As Double

        Public Property DamageReduction() As Double
            Get
                Return _Damage
            End Get
            Set(ByVal value As Double)
                _Damage = value
            End Set
        End Property

        Public Property HitReduction() As Double
            Get
                Return _Hit
            End Get
            Set(ByVal value As Double)
                _Hit = value
            End Set
        End Property

        Public Property Rating() As Double
            Get
                Return _Rating
            End Get
            Set(ByVal value As Double)
                _Rating = value
            End Set
        End Property
    End Class
End Namespace
