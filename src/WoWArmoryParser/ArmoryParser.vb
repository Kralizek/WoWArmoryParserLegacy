Imports System.Xml

Namespace WoWArmoryParser
    Public Class ArmoryParser
        Public Shared Function GetCharacter(ByVal Realm As String, ByVal Name As String, ByVal Region As RegionEnum) As Character
            Dim ch As New Character

            Dim path As String
            Dim doc As XmlTextReader

            Try
                path = GetRegionPath(Region) & "/character-sheet.xml"
                doc = GetStream(path, Realm, Name)

                ch.Region = Region
                ch.IsValid = False
                Do While doc.Read
                    If doc.NodeType = XmlNodeType.Element Then
                        If doc.LocalName = "character" Then
                            If doc.MoveToAttribute("name") AndAlso doc.ReadContentAsString().ToLower = Name.ToLower Then
                                ch.Name = doc.GetAttribute("name")
                                If doc.MoveToAttribute("realm") Then ch.Realm = doc.ReadContentAsString
                                If doc.MoveToAttribute("class") Then ch.CharClass = GetClassEnumFromString(doc.ReadContentAsString)
                                If doc.MoveToAttribute("gender") Then ch.Gender = GetGenderEnumFromString(doc.ReadContentAsString)
                                If doc.MoveToAttribute("guildName") Then ch.GuildName = doc.ReadContentAsString
                                If doc.MoveToAttribute("level") Then ch.Level = doc.ReadContentAsInt
                                If doc.MoveToAttribute("race") Then ch.Race = GetRaceEnumFromString(doc.ReadContentAsString)
                                If doc.MoveToAttribute("lastModified") Then ch.LastUpdate = DateTime.Parse(doc.ReadContentAsString)
                                If doc.MoveToAttribute("factionId") Then ch.Faction = doc.ReadContentAsInt
                            End If
                        End If

                        If doc.LocalName = "characterTab" Then ch.IsValid = True
                        '<pvp />
                        If doc.LocalName = "lifetimehonorablekills" Then
                            If doc.MoveToAttribute("value") Then ch.LifeTimeHonorableKills = doc.ReadContentAsInt
                        End If

                        '<arenaTeam battleGroup="Ruin" faction="Horde" factionId="1" gamesPlayed="3" gamesWon="3" lastSeasonRanking="0" name="Chester Bennington" ranking="34" rating="2154" realm="Hakkar" realmUrl="b=Ruin&amp;r=Hakkar&amp;ts=2&amp;t=Chester+Bennington&amp;ff=realm&amp;fv=Hakkar&amp;select=Chester+Bennington" seasonGamesPlayed="191" seasonGamesWon="124" size="2" url="r=Hakkar&amp;ts=2&amp;t=Chester+Bennington&amp;select=Chester+Bennington">
                        If doc.LocalName = "arenaTeam" Then
                            Select Case doc.GetAttribute("size")
                                Case "2"
                                    ch.Team2v2Name = doc.GetAttribute("name")
                                Case "3"
                                    ch.Team3v3Name = doc.GetAttribute("name")
                                Case "5"
                                    ch.Team5v5Name = doc.GetAttribute("name")
                            End Select
                        End If

                        '<talentSpec />
                        If doc.LocalName = "talentSpec" Then
                            Dim t1 As Integer, t2 As Integer, t3 As Integer
                            If doc.MoveToAttribute("treeOne") Then t1 = doc.ReadContentAsInt
                            If doc.MoveToAttribute("treeTwo") Then t2 = doc.ReadContentAsInt
                            If doc.MoveToAttribute("treeThree") Then t3 = doc.ReadContentAsInt
                            ch.TalentSpec = New TalentSpec(t1, t2, t3)
                        End If

                        '<characterBars />
                        If doc.LocalName = "health" Then
                            Dim cb As New CharacterBar
                            cb.Type = BarType.Health
                            If doc.MoveToAttribute("effective") Then cb.Total = doc.ReadContentAsInt
                            ch.HealthBar = cb
                        End If
                        If doc.LocalName = "secondBar" Then
                            Dim cb As New CharacterBar
                            If doc.MoveToAttribute("effective") Then cb.Total = doc.ReadContentAsInt
                            Dim type As String = ""
                            If doc.MoveToAttribute("type") Then type = doc.ReadContentAsString
                            Select Case type
                                Case "m"
                                    cb.Type = BarType.Mana
                                Case "e"
                                    cb.Type = BarType.Energy
                                Case "r"
                                    cb.Type = BarType.Rage
                                Case Else
                                    Throw New SecondBarTypeNotValidException
                            End Select
                            ch.SecondBar = cb
                        End If
                        '<baseStats />
                        If doc.LocalName = "baseStats" Then
                            Using stat As XmlReader = doc.ReadSubtree
                                Do While stat.Read
                                    If stat.LocalName = "strength" AndAlso stat.MoveToAttribute("effective") Then ch.BaseStats.Strength = stat.ReadContentAsInt
                                    If stat.LocalName = "agility" AndAlso stat.MoveToAttribute("effective") Then ch.BaseStats.Agility = stat.ReadContentAsInt
                                    If stat.LocalName = "stamina" AndAlso stat.MoveToAttribute("effective") Then ch.BaseStats.Stamina = stat.ReadContentAsInt
                                    If stat.LocalName = "intellect" AndAlso stat.MoveToAttribute("effective") Then ch.BaseStats.Intellect = stat.ReadContentAsInt
                                    If stat.LocalName = "spirit" AndAlso stat.MoveToAttribute("effective") Then ch.BaseStats.Spirit = stat.ReadContentAsInt
                                    If stat.LocalName = "armor" AndAlso stat.MoveToAttribute("effective") Then ch.BaseStats.Armor = stat.ReadContentAsInt
                                Loop
                                stat.Close()
                            End Using
                        End If

                        '<resistances />
                        If doc.LocalName = "resistances" Then
                            Using res As XmlReader = doc.ReadSubtree
                                Do While res.Read
                                    If res.LocalName = "arcane" AndAlso res.MoveToAttribute("value") Then ch.Resistances.ArcaneRes = res.ReadContentAsInt
                                    If res.LocalName = "fire" AndAlso res.MoveToAttribute("value") Then ch.Resistances.FireRes = res.ReadContentAsInt
                                    If res.LocalName = "frost" AndAlso res.MoveToAttribute("value") Then ch.Resistances.FrostRes = res.ReadContentAsInt
                                    If res.LocalName = "holy" AndAlso res.MoveToAttribute("value") Then ch.Resistances.HolyRes = res.ReadContentAsInt
                                    If res.LocalName = "nature" AndAlso res.MoveToAttribute("value") Then ch.Resistances.NatureRes = res.ReadContentAsInt
                                    If res.LocalName = "shadow" AndAlso res.MoveToAttribute("value") Then ch.Resistances.ShadowRes = res.ReadContentAsInt
                                Loop
                                res.Close()
                            End Using
                        End If

                        If doc.LocalName = "spell" Then
                            Using spell As XmlReader = doc.ReadSubtree
                                Do While spell.Read
                                    If spell.LocalName = "bonusDamage" Then
                                        Using dmg As XmlReader = spell.ReadSubtree
                                            Do While dmg.Read
                                                If dmg.LocalName = "arcane" AndAlso dmg.MoveToAttribute("value") Then ch.Spell.Arcane.DamageBonus = dmg.ReadContentAsInt
                                                If dmg.LocalName = "fire" AndAlso dmg.MoveToAttribute("value") Then ch.Spell.Fire.DamageBonus = dmg.ReadContentAsInt
                                                If dmg.LocalName = "frost" AndAlso dmg.MoveToAttribute("value") Then ch.Spell.Frost.DamageBonus = dmg.ReadContentAsInt
                                                If dmg.LocalName = "holy" AndAlso dmg.MoveToAttribute("value") Then ch.Spell.Holy.DamageBonus = dmg.ReadContentAsInt
                                                If dmg.LocalName = "nature" AndAlso dmg.MoveToAttribute("value") Then ch.Spell.Nature.DamageBonus = dmg.ReadContentAsInt
                                                If dmg.LocalName = "shadow" AndAlso dmg.MoveToAttribute("value") Then ch.Spell.Shadow.DamageBonus = dmg.ReadContentAsInt
                                            Loop
                                            dmg.Close()
                                        End Using
                                    ElseIf spell.LocalName = "critChance" Then

                                        Using crit As XmlReader = spell.ReadSubtree
                                            Do While crit.Read
                                                If crit.LocalName = "arcane" AndAlso crit.MoveToAttribute("percent") Then
                                                    ch.Spell.Arcane.CritChance = crit.ReadContentAsDouble
                                                ElseIf crit.LocalName = "fire" AndAlso crit.MoveToAttribute("percent") Then
                                                    ch.Spell.Fire.CritChance = crit.ReadContentAsDouble
                                                ElseIf crit.LocalName = "frost" AndAlso crit.MoveToAttribute("percent") Then
                                                    ch.Spell.Frost.CritChance = crit.ReadContentAsDouble
                                                ElseIf crit.LocalName = "holy" AndAlso crit.MoveToAttribute("percent") Then
                                                    ch.Spell.Holy.CritChance = crit.ReadContentAsDouble
                                                ElseIf crit.LocalName = "nature" AndAlso crit.MoveToAttribute("percent") Then
                                                    ch.Spell.Nature.CritChance = crit.ReadContentAsDouble
                                                ElseIf crit.LocalName = "shadow" AndAlso crit.MoveToAttribute("percent") Then
                                                    ch.Spell.Shadow.CritChance = crit.ReadContentAsDouble
                                                End If
                                            Loop
                                            crit.Close()
                                        End Using
                                        If spell.MoveToAttribute("rating") Then ch.Spell.CritRating = spell.ReadContentAsInt
                                    ElseIf spell.LocalName = "hitRating" Then
                                        If spell.MoveToAttribute("increasedHitPercent") Then ch.Spell.HitRating.IncreasedHitChance = spell.ReadContentAsDouble
                                        If spell.MoveToAttribute("value") Then ch.Spell.HitRating.Value = spell.ReadContentAsInt
                                    ElseIf spell.LocalName = "bonusHealing" AndAlso spell.MoveToAttribute("value") Then
                                        ch.Spell.HealingBonus = spell.ReadContentAsInt
                                    ElseIf spell.LocalName = "penetration" AndAlso spell.MoveToAttribute("value") Then
                                        ch.Spell.SpellPenetration = spell.ReadContentAsInt
                                    ElseIf spell.LocalName = "manaRegen" Then
                                        If spell.MoveToAttribute("casting") Then ch.Spell.ManaRegen.WhileCasting = spell.ReadContentAsDouble
                                        If spell.MoveToAttribute("notCasting") Then ch.Spell.ManaRegen.WhileNotCasting = spell.ReadContentAsDouble
                                    End If
                                Loop
                                spell.Close()
                            End Using
                        End If

                        If doc.LocalName = "melee" Then
                            Using melee As XmlReader = doc.ReadSubtree
                                Do While melee.Read
                                    If melee.LocalName = "mainHandWeaponSkill" Then
                                        If melee.MoveToAttribute("rating") Then ch.Melee.MainHand.Skill.Rating = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("value") Then ch.Melee.MainHand.Skill.Value = melee.ReadContentAsInt
                                    End If
                                    If melee.LocalName = "mainHandDamage" Then
                                        If melee.MoveToAttribute("dps") Then ch.Melee.MainHand.Damage.DPS = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("max") Then ch.Melee.MainHand.Damage.Max = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("min") Then ch.Melee.MainHand.Damage.Min = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("percent") Then ch.Melee.MainHand.Damage.Percent = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("speed") Then ch.Melee.MainHand.Damage.Speed = melee.ReadContentAsDouble
                                    End If
                                    If melee.LocalName = "mainHandSpeed" Then
                                        If melee.MoveToAttribute("hastePercent") Then ch.Melee.MainHand.Speed.HastePercent = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("hasteRating") Then ch.Melee.MainHand.Speed.HasteRating = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("value") Then ch.Melee.MainHand.Speed.Value = melee.ReadContentAsDouble
                                    End If
                                    If melee.LocalName = "offHandWeaponSkill" Then
                                        If melee.MoveToAttribute("rating") Then ch.Melee.OffHand.Skill.Rating = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("value") Then ch.Melee.OffHand.Skill.Value = melee.ReadContentAsInt
                                    End If
                                    If melee.LocalName = "offHandDamage" Then
                                        If melee.MoveToAttribute("dps") Then ch.Melee.OffHand.Damage.DPS = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("max") Then ch.Melee.OffHand.Damage.Max = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("min") Then ch.Melee.OffHand.Damage.Min = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("percent") Then ch.Melee.OffHand.Damage.Percent = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("speed") Then ch.Melee.OffHand.Damage.Speed = melee.ReadContentAsDouble
                                    End If
                                    If melee.LocalName = "offHandSpeed" Then
                                        If melee.MoveToAttribute("hastePercent") Then ch.Melee.OffHand.Speed.HastePercent = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("hasteRating") Then ch.Melee.OffHand.Speed.HasteRating = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("value") Then ch.Melee.OffHand.Speed.Value = melee.ReadContentAsDouble
                                    End If
                                    If melee.LocalName = "hitRating" Then
                                        If melee.MoveToAttribute("increasedHitPercent") Then ch.Melee.HitRating.IncreasedHitChance = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("value") Then ch.Melee.HitRating.Value = melee.ReadContentAsInt
                                    End If
                                    If melee.LocalName = "power" Then
                                        If melee.MoveToAttribute("base") Then ch.Melee.AttackPower.Base = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("effective") Then ch.Melee.AttackPower.Effective = melee.ReadContentAsInt
                                        If melee.MoveToAttribute("increasedDps") Then ch.Melee.AttackPower.IncreasedDPS = melee.ReadContentAsDouble
                                    End If
                                    If melee.LocalName = "critChance" Then
                                        If melee.MoveToAttribute("percent") Then ch.Melee.CritChance.Percent = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("plusPercent") Then ch.Melee.CritChance.IncreasedByRating = melee.ReadContentAsDouble
                                        If melee.MoveToAttribute("rating") Then ch.Melee.CritChance.Rating = melee.ReadContentAsInt
                                    End If
                                Loop
                                melee.Close()
                            End Using
                        End If

                        If doc.LocalName = "ranged" Then
                            Using ranged As XmlReader = doc.ReadSubtree
                                While ranged.Read
                                    If ranged.LocalName = "weaponSkill" Then
                                        If ranged.MoveToAttribute("rating") Then ch.Ranged.Weapon.Skill.Rating = ranged.ReadContentAsInt
                                        If ranged.MoveToAttribute("value") Then ch.Ranged.Weapon.Skill.Value = ranged.ReadContentAsInt
                                    End If
                                    If ranged.LocalName = "damage" Then
                                        If ranged.MoveToAttribute("dps") Then ch.Ranged.Weapon.Damage.DPS = ranged.ReadContentAsDouble
                                        If ranged.MoveToAttribute("max") Then ch.Ranged.Weapon.Damage.Max = ranged.ReadContentAsInt
                                        If ranged.MoveToAttribute("min") Then ch.Ranged.Weapon.Damage.Min = ranged.ReadContentAsInt
                                        If ranged.MoveToAttribute("percent") Then ch.Ranged.Weapon.Damage.Percent = ranged.ReadContentAsDouble
                                        If ranged.MoveToAttribute("speed") Then ch.Ranged.Weapon.Damage.Speed = ranged.ReadContentAsDouble
                                    End If
                                    If ranged.LocalName = "speed" Then
                                        If ranged.MoveToAttribute("hastePercent") Then ch.Ranged.Weapon.Speed.HastePercent = ranged.ReadContentAsDouble
                                        If ranged.MoveToAttribute("hasteRating") Then ch.Ranged.Weapon.Speed.HasteRating = ranged.ReadContentAsInt
                                        If ranged.MoveToAttribute("value") Then ch.Ranged.Weapon.Speed.Value = ranged.ReadContentAsDouble
                                    End If
                                    If ranged.LocalName = "hitRating" Then
                                        If ranged.MoveToAttribute("increasedHitPercent") Then ch.Ranged.HitRating.IncreasedHitChance = ranged.ReadContentAsDouble
                                        If ranged.MoveToAttribute("value") Then ch.Ranged.HitRating.Value = ranged.ReadContentAsInt
                                    End If
                                    If ranged.LocalName = "power" Then
                                        If ranged.MoveToAttribute("base") Then ch.Ranged.AttackPower.Base = ranged.ReadContentAsInt
                                        If ranged.MoveToAttribute("effective") Then ch.Ranged.AttackPower.Effective = ranged.ReadContentAsInt
                                        If ranged.MoveToAttribute("increasedDps") Then ch.Ranged.AttackPower.IncreasedDPS = ranged.ReadContentAsDouble
                                    End If
                                    If ranged.LocalName = "critChance" Then
                                        If ranged.MoveToAttribute("percent") Then ch.Ranged.CritChance.Percent = ranged.ReadContentAsDouble
                                        If ranged.MoveToAttribute("plusPercent") Then ch.Ranged.CritChance.IncreasedByRating = ranged.ReadContentAsDouble
                                        If ranged.MoveToAttribute("rating") Then ch.Ranged.CritChance.Rating = ranged.ReadContentAsInt
                                    End If
                                End While
                                ranged.Close()
                            End Using
                        End If

                        If doc.LocalName = "defenses" Then
                            Using def As XmlReader = doc.ReadSubtree
                                Dim defense As DefenseInfo = ch.Defense
                                While def.Read
                                    If def.LocalName = "armor" Then
                                        If def.MoveToAttribute("base") Then defense.Armor.Base = def.ReadContentAsInt
                                        If def.MoveToAttribute("effective") Then defense.Armor.Effective = def.ReadContentAsInt
                                        If def.MoveToAttribute("percent") Then defense.Armor.DamageReductionPercent = def.ReadContentAsDouble
                                    End If
                                    If def.LocalName = "defense" Then
                                        If def.MoveToAttribute("rating") Then defense.Defense.Rating = def.ReadContentAsDouble
                                        If def.MoveToAttribute("value") Then defense.Defense.Value = def.ReadContentAsDouble
                                    End If
                                    If def.LocalName = "dodge" Then
                                        If def.MoveToAttribute("increasePercent") Then defense.Dodge.IncreasedByRating = def.ReadContentAsDouble
                                        If def.MoveToAttribute("percent") Then defense.Dodge.Percent = def.ReadContentAsDouble
                                        If def.MoveToAttribute("rating") Then defense.Dodge.Rating = def.ReadContentAsDouble
                                    End If
                                    If def.LocalName = "parry" Then
                                        If def.MoveToAttribute("increasePercent") Then defense.Parry.IncreasedByRating = def.ReadContentAsDouble
                                        If def.MoveToAttribute("percent") Then defense.Parry.Percent = def.ReadContentAsDouble
                                        If def.MoveToAttribute("rating") Then defense.Parry.Rating = def.ReadContentAsDouble
                                    End If
                                    If def.LocalName = "block" Then
                                        If def.MoveToAttribute("increasePercent") Then defense.Block.IncreasedByRating = def.ReadContentAsDouble
                                        If def.MoveToAttribute("percent") Then defense.Block.Percent = def.ReadContentAsDouble
                                        If def.MoveToAttribute("rating") Then defense.Block.Rating = def.ReadContentAsDouble
                                    End If
                                    If def.LocalName = "resilience" Then
                                        If def.MoveToAttribute("damagePercent") Then defense.Resilience.DamageReduction = def.ReadContentAsDouble
                                        If def.MoveToAttribute("hitPercent") Then defense.Resilience.HitReduction = def.ReadContentAsDouble
                                        If def.MoveToAttribute("value") Then defense.Resilience.Rating = def.ReadContentAsDouble
                                    End If
                                End While
                                def.Close()
                            End Using
                        End If

                        If doc.LocalName = "items" Then
                            Using itm As XmlReader = doc.ReadSubtree
                                While itm.Read
                                    If itm.LocalName = "item" Then
                                        Dim slot As EquipSlotEnum
                                        Dim id As Integer

                                        If itm.MoveToAttribute("slot") Then slot = itm.ReadContentAsInt
                                        If itm.MoveToAttribute("id") Then id = itm.ReadContentAsInt

                                        ch.Equip.ItemID(slot) = id
                                    End If
                                End While
                                itm.Close()
                            End Using
                        End If
                    End If
                Loop
                doc.Close()

                'Skill

                path = GetRegionPath(Region) & "/character-skills.xml"
                doc = GetStream(path, Realm, Name)

                Do While doc.Read
                    If doc.NodeType = XmlNodeType.Element Then
                        '<skillTab />
                        If doc.LocalName = "skillCategory" AndAlso doc.GetAttribute("key") = "professions" Then ch.Skills.Professions = GetSkillList(doc)
                        If doc.LocalName = "skillCategory" AndAlso doc.GetAttribute("key") = "secondaryskills" Then ch.Skills.SecondarySkills = GetSkillList(doc)
                        If doc.LocalName = "skillCategory" AndAlso doc.GetAttribute("key") = "weaponskills" Then ch.Skills.WeaponsSkills = GetSkillList(doc)
                        If doc.LocalName = "skillCategory" AndAlso doc.GetAttribute("key") = "classskills" Then ch.Skills.ClassSkills = GetSkillList(doc)
                        If doc.LocalName = "skillCategory" AndAlso doc.GetAttribute("key") = "armorproficiencies" Then ch.Skills.ArmorProficiencies = GetSkillList(doc)
                        If doc.LocalName = "skillCategory" AndAlso doc.GetAttribute("key") = "languages" Then ch.Skills.Languages = GetSkillList(doc)
                    End If
                Loop
                doc.Close()

                'Reps
                path = GetRegionPath(Region) & "/character-reputation.xml"
                doc = GetStream(path, Realm, Name)

                Do While doc.Read
                    If doc.NodeType = XmlNodeType.Element Then
                        '<reputationTab />
                        If doc.LocalName = "factionCategory" AndAlso (doc.GetAttribute("key") = "horde" OrElse doc.GetAttribute("key") = "alliance") Then ch.GroupedReputations.Faction = GetRepsList(ch, doc.GetAttribute("name"), doc)
                        If doc.LocalName = "factionCategory" AndAlso (doc.GetAttribute("key") = "hordeforces" OrElse doc.GetAttribute("key") = "allianceforces") Then ch.GroupedReputations.BattleGrounds = GetRepsList(ch, doc.GetAttribute("name"), doc)
                        If doc.LocalName = "factionCategory" AndAlso doc.GetAttribute("key") = "outland" Then ch.GroupedReputations.Outland = GetRepsList(ch, doc.GetAttribute("name"), doc)
                        If doc.LocalName = "factionCategory" AndAlso doc.GetAttribute("key") = "shattrathcity" Then ch.GroupedReputations.ShattrathCity = GetRepsList(ch, doc.GetAttribute("name"), doc)
                        If doc.LocalName = "factionCategory" AndAlso doc.GetAttribute("key") = "steamwheedlecartel" Then ch.GroupedReputations.SteamwheedleCartel = GetRepsList(ch, doc.GetAttribute("name"), doc)
                        If doc.LocalName = "factionCategory" AndAlso doc.GetAttribute("key") = "zother" Then ch.GroupedReputations.Others = GetRepsList(ch, doc.GetAttribute("name"), doc)
                    End If
                Loop
                doc.Close()
            Catch ex As Exception
                ch.IsValid = False
            End Try
            Return ch
        End Function

        Public Shared Function GetGuild(ByVal Realm As String, ByVal Name As String, ByVal Region As RegionEnum) As Guild
            Dim g As New Guild
            Dim path As String = GetRegionPath(Region) & "/guild-info.xml"
            Using doc As XmlReader = GetStream(path, Realm, Name)

                g.Region = Region
                Do While doc.Read
                    If doc.NodeType = XmlNodeType.Element Then
                        If doc.LocalName = "guild" Then
                            g.BattleGroup = doc.GetAttribute("battleGroup")
                            g.Realm = doc.GetAttribute("realm")
                            g.Name = doc.GetAttribute("name")
                        End If
                        If doc.LocalName = "character" Then
                            Dim member As New GuildMember(doc.GetAttribute("name"), g.Realm, Region)
                            With member
                                .CharClass = GetClassEnumFromString(doc.GetAttribute("class"))
                                .Gender = GetGenderEnumFromString(doc.GetAttribute("gender"))
                                .Race = GetRaceEnumFromString(doc.GetAttribute("race"))
                                .Level = doc.GetAttribute("level")
                                .Rank = doc.GetAttribute("rank")
                            End With
                            If doc.GetAttribute("rank") = 0 Then g.GuildMaster = member
                            g.Members.Add(member)
                        End If

                    End If
                Loop
            End Using
            Return g
        End Function

        Public Shared Function GetArenaTeam(ByVal Realm As String, ByVal Name As String, ByVal Size As ArenaTeamSizeEnum, ByVal Region As RegionEnum) As ArenaTeam
            Dim at As New ArenaTeam
            Dim path As String = GetRegionPath(Region) & "/team-info.xml"
            Using doc As XmlReader = GetStream(path, Realm, Name, Size)
                'at.Realm = Realm
                at.Region = Region
                Do While doc.Read
                    If doc.NodeType = XmlNodeType.Element Then
                        If doc.LocalName = "arenaTeam" Then
                            at.BattleGroup = doc.GetAttribute("battleGroup")
                            at.Faction = CType(doc.GetAttribute("factionID"), Integer)
                            at.Name = doc.GetAttribute("name")
                            at.Ranking = doc.GetAttribute("ranking")
                            at.Rating = doc.GetAttribute("rating")
                            at.Size = CType(doc.GetAttribute("size"), Integer)
                            at.Realm = doc.GetAttribute("realm")
                            With at.GamesInWeek
                                .Played = doc.GetAttribute("gamesPlayed")
                                .Wins = doc.GetAttribute("gamesWon")
                            End With
                            With at.GamesInSeason
                                .Played = doc.GetAttribute("seasonGamesPlayed")
                                .Wins = doc.GetAttribute("seasonGamesWon")
                            End With
                        ElseIf doc.LocalName = "emblem" Then
                            With at.Emblem
                                .BackgroundColor = doc.GetAttribute("background")
                                .BorderColor = doc.GetAttribute("borderColor")
                                .IconColor = doc.GetAttribute("iconColor")
                                .BorderStyle = doc.GetAttribute("borderStyle")
                                .IconStyle = doc.GetAttribute("iconStyle")
                            End With
                        ElseIf doc.LocalName = "character" Then
                            Dim member As New ArenaMember(doc.GetAttribute("name"), Realm, Region)
                            With member
                                .CharClass = GetClassEnumFromString(doc.GetAttribute("class"))
                                .Gender = GetGenderEnumFromString(doc.GetAttribute("gender"))
                                .Race = GetRaceEnumFromString(doc.GetAttribute("race"))
                                .Rank = doc.GetAttribute("teamRank")
                                .GuildName = doc.GetAttribute("guild")
                                With .GamesInWeek
                                    .Played = doc.GetAttribute("gamesPlayed")
                                    .Wins = doc.GetAttribute("gamesWon")
                                End With
                                With .GamesInSeason
                                    .Played = doc.GetAttribute("seasonGamesPlayed")
                                    .Wins = doc.GetAttribute("seasonGamesWon")
                                End With
                            End With
                            If doc.GetAttribute("teamRank") = 0 Then at.Leader = member
                            at.Members.Add(member)
                        End If
                    End If
                Loop
            End Using
            Return at
        End Function

        Public Shared Function GetItem(ByVal ID As Integer) As Item
            Dim i As New Item
            Dim path As String = GetRegionPath(RegionEnum.USA) & "/item-info.xml"

            Using doc As XmlReader = GetStream(path, ID)
                Do While doc.Read
                    If doc.NodeType = XmlNodeType.Element Then
                        If doc.LocalName = "item" Then
                            If doc.MoveToAttribute("id") AndAlso doc.ReadContentAsInt = ID Then
                                i.ID = ID
                                If doc.MoveToAttribute("icon") Then i.Icon = doc.ReadContentAsString
                                If doc.MoveToAttribute("level") Then i.Level = doc.ReadContentAsInt
                                If doc.MoveToAttribute("name") Then i.Name = doc.ReadContentAsString
                                If doc.MoveToAttribute("quality") Then i.Quality = doc.ReadContentAsInt
                                i.IsValid = True
                            End If
                        End If
                    End If
                Loop
                doc.Close()
            End Using
            Return i
        End Function

        Protected Friend Shared Function GetRegionPath(ByVal Region As RegionEnum) As String
            Dim path As String = ""
            Select Case Region
                Case RegionEnum.Europe
                    path = "http://eu.wowarmory.com"
                Case RegionEnum.USA
                    path = "http://www.wowarmory.com"
            End Select
            Return path
        End Function

        Protected Shared Function GetStream(ByVal Path As String, ByVal Realm As String, ByVal Name As String) As Xml.XmlTextReader
            Dim wc As New Net.WebClient
            Dim xtr As Xml.XmlTextReader
            wc.QueryString.Add("r", Realm)
            wc.QueryString.Add("n", Name)
            wc.Headers.Add("user-agent", "MSIE 7.0")
            xtr = New Xml.XmlTextReader(wc.OpenRead(Path))
            Return xtr
        End Function

        Protected Shared Function GetStream(ByVal Path As String, ByVal ItemID As Integer) As XmlTextReader
            Dim wc As New Net.WebClient
            Dim xtr As Xml.XmlTextReader
            wc.QueryString.Add("i", ItemID)
            wc.Headers.Add("user-agent", "MSIE 7.0")
            xtr = New Xml.XmlTextReader(wc.OpenRead(Path))
            Return xtr
        End Function

        Protected Shared Function GetStream(ByVal Path As String, ByVal Realm As String, ByVal Name As String, ByVal Size As ArenaTeamSizeEnum) As Xml.XmlTextReader
            Dim wc As New Net.WebClient
            Dim xtr As Xml.XmlTextReader
            wc.QueryString.Add("r", Realm)
            wc.QueryString.Add("t", Name)
            wc.QueryString.Add("ts", CType(Size, Integer))
            wc.Headers.Add("user-agent", "MSIE 7.0")
            xtr = New Xml.XmlTextReader(wc.OpenRead(Path))
            Return xtr
        End Function

        Protected Shared Function GetRepsList(ByRef ch As Character, ByVal FactionCategory As String, ByVal xml As XmlTextReader) As GroupedReputationCollection
            Dim list As New GroupedReputationCollection(FactionCategory)
            If xml.NodeType = XmlNodeType.Element Then
                Using reps As XmlReader = xml.ReadSubtree
                    Do While reps.Read
                        If reps.NodeType = XmlNodeType.Element AndAlso reps.LocalName = "faction" Then 'Not reps.LocalName = "factionCategory" Then
                            Dim re As New Reputation
                            With re
                                .Key = reps.GetAttribute("key")
                                .Name = reps.GetAttribute("name")
                                .Value = reps.GetAttribute("reputation")
                            End With
                            list.Add(re.Key, re)
                            ch.Reputations.Add(re.Key, re)
                        End If
                    Loop
                End Using
            End If
            Return list
        End Function

        Protected Shared Function GetSkillList(ByRef xml As XmlTextReader) As SkillCollection
            Dim list As New SkillCollection
            Using skillz As XmlReader = xml.ReadSubtree
                Do While skillz.Read
                    If skillz.NodeType = XmlNodeType.Element AndAlso Not skillz.LocalName = "skillCategory" Then
                        Dim sk As New Skill
                        With sk
                            .Key = skillz.GetAttribute("key")
                            .Max = skillz.GetAttribute("max")
                            .Name = skillz.GetAttribute("name")
                            .Value = skillz.GetAttribute("value")
                        End With
                        list.Add(sk)
                    End If
                Loop
                skillz.Close()
            End Using
            Return list
        End Function

        Protected Shared Function GetClassEnumFromString(ByVal Cls As String) As ClassEnum
            Dim res As ClassEnum
            Select Case Cls.ToLower
                Case "druid"
                    res = ClassEnum.Druid
                Case "hunter"
                    res = ClassEnum.Hunter
                Case "mage"
                    res = ClassEnum.Mage
                Case "paladin"
                    res = ClassEnum.Paladin
                Case "priest"
                    res = ClassEnum.Priest
                Case "rogue"
                    res = ClassEnum.Rogue
                Case "shaman"
                    res = ClassEnum.Shaman
                Case "warlock"
                    res = ClassEnum.Warlock
                Case "warrior"
                    res = ClassEnum.Warrior
                Case Else
                    Throw New ClassNotValidException
            End Select
            Return res
        End Function

        Protected Shared Function GetGenderEnumFromString(ByVal Gender As String) As GenderEnum
            Dim res As GenderEnum
            Select Case Gender.ToLower
                Case "male"
                    res = GenderEnum.Male
                Case "female"
                    res = GenderEnum.Female
                Case Else
                    Throw New GenderNotValidException
            End Select
            Return res
        End Function

        Protected Shared Function GetRaceEnumFromString(ByVal Race As String) As RaceEnum
            Dim res As RaceEnum
            Select Case Race.ToLower
                Case "blood elf"
                    res = RaceEnum.BloodElf
                Case "draenei"
                    res = RaceEnum.Draenei
                Case "dwarf"
                    res = RaceEnum.Dwarf
                Case "gnome"
                    res = RaceEnum.Gnome
                Case "human"
                    res = RaceEnum.Human
                Case "night elf"
                    res = RaceEnum.NightElf
                Case "orc"
                    res = RaceEnum.Orc
                Case "tauren"
                    res = RaceEnum.Tauren
                Case "troll"
                    res = RaceEnum.Troll
                Case "undead"
                    res = RaceEnum.Undead
                Case Else
                    Throw New RaceNotValidException
            End Select
            Return res
        End Function

        Protected _Region As RegionEnum
    End Class
End Namespace