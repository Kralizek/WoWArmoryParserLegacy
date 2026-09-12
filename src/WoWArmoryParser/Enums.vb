Namespace WoWArmoryParser
    Public Enum RegionEnum
        Europe
        USA
    End Enum

    Public Enum GenderEnum
        Male
        Female
    End Enum

    Public Enum RaceEnum
        BloodElf = 10
        Draenei = 11
        Dwarf = 3
        Gnome = 7
        Human = 1
        NightElf = 4
        Orc = 2
        Tauren = 6
        Troll = 8
        Undead = 5
    End Enum

    Public Enum ClassEnum
        Druid = 11
        Hunter = 3
        Mage = 8
        Paladin = 2
        Priest = 5
        Rogue = 4
        Shaman = 7
        Warlock = 9
        Warrior = 1
    End Enum

    Public Enum FactionEnum
        Alliance = 0
        Horde = 1
    End Enum

    Public Enum BarType
        Energy
        Health
        Mana
        Rage
    End Enum

    Public Enum ReputationEnum
        Hated = -3
        Hostile = -2
        Unfriendly = -1
        Neutral = 0
        Friendly = 1
        Honored = 2
        Revered = 3
        Exalted = 4
    End Enum

    Public Enum QualityEnum As Integer
        Poor = 0
        Common = 1
        Uncommon = 2
        Rare = 3
        Epic = 4
        Legendary = 5
    End Enum

    Public Enum EquipSlotEnum As Integer
        Head = 0
        Neck = 1
        Shoulder = 2
        Shirt = 3
        Chest = 4
        Waist = 5
        Legs = 6
        Feet = 7
        Wrist = 8
        Hand = 9
        Ring1 = 10
        Ring2 = 11
        Trinket1 = 12
        Trinket2 = 13
        Back = 14
        MainHand = 15
        OffHand = 16
        Ranged = 17
        Tabard = 18
        Ammo = -1
    End Enum

    Public Enum ArenaTeamSizeEnum
        Team2v2 = 2
        Team3v3 = 3
        Team5v5 = 5
    End Enum

    Public Enum SecurityLevelEnum
        Normal
        Secure
    End Enum

    Public Enum BankTranasctionEnum
        Deposit = 1
        Withdrawl = 2
        Move = 3
        DepositMoney = 4
        WithdrawlMoney = 5
        Repair = 6
    End Enum
End Namespace
