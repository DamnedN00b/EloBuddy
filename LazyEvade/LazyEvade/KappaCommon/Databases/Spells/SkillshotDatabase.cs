using System.Collections.Generic;
using EloBuddy;
using LazyEvade.KappaCommon.Databases.SpellData;

namespace LazyEvade.KappaCommon.Databases.Spells
{
    public static class SkillshotDatabase
    {
        public static readonly List<SkillshotData> List = new List<SkillshotData>
            {
				#region All
				
               new SkillshotData
                  {
                     type = Type.LineMissile,
                     hero = Champion.Unknown,
                     slot = SpellSlot.Unknown,
                     GameType = (GameType)911,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1600,
                     Width = 70,
                     SpellName = "testskill",
                     MissileName = "",
                     IsFixedRange = true,
                     Collisions = new[] { Collision.YasuoWall }
                  },
               new SkillshotData
                  {
                     type = Type.LineMissile,
                     hero = Champion.Unknown,
                     slot = SpellSlot.Unknown,
                     GameType = (GameType)7,
                     DangerLevel = 2,
                     CastDelay = 750,
                     Range = 2825,
                     Speed = int.MaxValue,
                     Width = 70,
                     SpellName = "SiegeLaserAffixShot",
                     MissileName = "",
                     IsFixedRange = true,
                     StaticStart = true
                  },
               new SkillshotData
                  {
                     type = Type.LineMissile,
                     hero = Champion.Unknown,
                     slot = SpellSlot.Unknown,
                     GameType = GameType.ARAM,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1600,
                     Speed = 1200,
                     Width = 80,
                     SpellName = "SummonerSnowball",
                     MissileName = "",
                     IsFixedRange = true,
                     Collisions = new[] { Collision.Heros, Collision.Minions, Collision.YasuoWall }
                  },
				  
				#endregion All
				
				#region Aatrox
				
               new SkillshotData
                  {
                     type = Type.CircleMissile,
                     hero = Champion.Aatrox,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 600,
                     Range = 650,
                     Speed = 2000,
                     Width = 250,
                     SpellName = "AatroxQ",
                     MissileName = "",
                     ParticalName = "Aatrox_Base_Q_Tar_",
                  },
               new SkillshotData
                  {
                     type = Type.LineMissile,
                     hero = Champion.Aatrox,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1075,
                     Speed = 1200,
                     Width = 100,
                     SpellName = "AatroxE",
                     MissileName = "AatroxEConeMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                  },
				  
				#endregion Aatrox
				
				#region Ahri
				
               new SkillshotData
                  {
                     type = Type.LineMissile,
                     hero = Champion.Ahri,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 2500,
                     Width = 100,
                     MissileAccel = -3200,
                     MissileMaxSpeed = 2500,
                     MissileMinSpeed = 400,
                     SpellName = "AhriOrbofDeception",
                     MissileName = "AhriOrbMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                  {
                     type = Type.LineMissile,
                     hero = Champion.Ahri,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 25000,
                     Speed = 60,
                     Width = 100,
                     MissileAccel = 1900,
                     MissileMinSpeed = 60,
                     MissileMaxSpeed = 2600,
                     SpellName = "AhriOrbReturn",
                     MissileName = "AhriOrbReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     EndSticksToCaster = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ahri,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1550,
                     Width = 60,
                     SpellName = "AhriSeduce",
                     MissileName = "AhriSeduceMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Ahri
				
				#region Akali
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Akali,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 325,
                     SpellName = "AkaliShadowSwipe",
                     MissileName = "",
                   },
				
				#endregion Akali
				
				#region Alistar
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Alistar,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 365,
                     SpellName = "Pulverize",
                     MissileName = "",
                   },
				   
				#endregion Alistar
				   
				#region Amumu
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Amumu,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 2000,
                     Width = 80,
                     SpellName = "BandageToss",
                     MissileName = "SadMummyBandageToss",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Amumu,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 350,
                     SpellName = "Tantrum",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Amumu,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 550,
                     SpellName = "CurseoftheSadMummy",
                     MissileName = "",
                     IsFixedRange = true
                   },
				   
				#endregion Amumu
				
				#region Anivia
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Anivia,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1100,
                     ExtraRange = 250,
                     Speed = 850,
                     Width = 150,
                     SpellName = "FlashFrostSpell",
                     MissileName = "FlashFrostSpell",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true
                   },
				   
				#endregion Anivia
				
				#region Annie
				
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Annie,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     Angle = 50,
                     CastDelay = 250,
                     Range = 560,
                     Speed = int.MaxValue,
                     Width = 50,
                     SpellName = "Incinerate",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Annie,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 600,
                     Speed = int.MaxValue,
                     Width = 250,
                     SpellName = "InfernalGuardian",
                     MissileName = "",
                   },
				   
				#endregion Annie
				
				#region Ashe
			
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ashe,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 1500,
                     Width = 35,
                     SpellName = "Volley",
                     MissileName = "VolleyAttack",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     ForceRemove = true,
                     IsFixedRange = true,
                     SticksToMissile = true,
                     DetectByMissile = true,
                     AllowDuplicates = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ashe,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 4000,
                     Speed = 1600,
                     Width = 130,
                     SpellName = "EnchantedCrystalArrow",
                     MissileName = "EnchantedCrystalArrow",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Ashe
				
				#region AurelionSol
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.AurelionSol,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 550,
                     Speed = 850,
                     Width = 210,
                     SpellName = "AurelionSolQ",
                     MissileName = "AurelionSolQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.AurelionSol,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 300,
                     Range = 1420,
                     Speed = 4500,
                     Width = 120,
                     SpellName = "AurelionSolR",
                     MissileName = "AurelionSolRBeamMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion AurelionSol
				
				#region Azir
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Azir,
                     slot = SpellSlot.Q,
                     CasterName = "AzirSoldier",
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1750,
                     Speed = 1600,
                     Width = 80,
                     ExtraRange = 175,
                     SpellName = "AzirQ",
                     MissileName = "AzirSoldierMissile",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Azir,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 550,
                     Speed = 1400,
                     Width = 150,
                     SpellName = "AzirR",
                     MissileName = "AzirSoldierRMissile",
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Azir
				
				#region Bard
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Bard,
                     slot = SpellSlot.Q,
                     CollideCount = 1,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1500,
                     Width = 60,
                     SpellName = "BardQ",
                     MissileName = "BardQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Bard,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 500,
                     Range = 3400,
                     Speed = 2100,
                     Width = 350,
                     SpellName = "BardR",
                     MissileName = "BardRMissileFixedTravelTime",
                     ExtraMissileName = new[] { "BardRMissileRange1", "BardRMissileRange2", "BardRMissileRange3", "BardRMissileRange4", "BardRMissileRange5" },
                   },
				   
				#endregion Bard
				
				#region Blitzcrank
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Blitzcrank,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1800,
                     Width = 90,
                     SpellName = "RocketGrab",
                     MissileName = "RocketGrabMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Blitzcrank,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 600,
                     SpellName = "StaticField",
                     MissileName = "",
                     IsFixedRange = true
                   },
				   
				#endregion Blitzcrank
				
				#region Brand
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Brand,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 60,
                     SpellName = "BrandQ",
                     MissileName = "BrandQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Brand,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 900,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 240,
                     SpellName = "BrandW",
                     MissileName = "",
                     ParticalName = "Brand_Base_W_POF_tar_",
                   },
				   
				#endregion Brand
				
				#region Braum
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Braum,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1700,
                     Width = 60,
                     SpellName = "BraumQ",
                     MissileName = "BraumQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Braum,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 550,
                     Range = 1200,
                     Speed = 1400,
                     Width = 115,
                     SpellName = "BraumRWrapper",
                     MissileName = "BraumRMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Braum
				
				#region Caitlyn
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Caitlyn,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 625,
                     Range = 1300,
                     Speed = 2200,
                     Width = 90,
                     SpellName = "CaitlynPiltoverPeacemaker",
                     ExtraSpellName = new[] { "CaitlynQBehind" },
                     MissileName = "CaitlynPiltoverPeacemaker",
                     ExtraMissileName = new[] { "CaitlynPiltoverPeacemaker2" },
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Caitlyn,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 160,
                     Range = 800,
                     Speed = 1600,
                     Width = 70,
                     SpellName = "CaitlynEntrapment",
                     MissileName = "CaitlynEntrapmentMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Caitlyn
				
				#region Camille
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Camille,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 800,
                     Speed = 900,
                     Width = 90,
                     SpellName = "CamilleEDash2",
                     MissileName = "",
                     Collisions = new []{ Collision.Heros },
                     SticksToCaster = true,
                     IsFixedRange = true
                   },
				   
				#endregion Camille
				
				#region Cassiopeia
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Cassiopeia,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 750,
                     Range = 850,
                     Speed = int.MaxValue,
                     Width = 160,
                     SpellName = "CassiopeiaQ",
                     MissileName = "",
                     ParticalName = "Cassiopeia_Base_Q_Hit_"
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Cassiopeia,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 3000,
                     Width = 180,
                     SpellName = "CassiopeiaW",
                     MissileName = "CassiopeiaWMissile",
                     DetectByMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Cassiopeia,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 5000,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 180,
                     SpellName = "Cassiopeia W Placement",
                     MissileName = "",
                     ParticalName = "Cassiopeia_Base_W_WCircle_tar_",
                     AllowDuplicates = true
                   },
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Cassiopeia,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 450,
                     Range = 790,
                     Speed = 2000,
                     Width = 80,
                     Angle = 70,
                     SpellName = "CassiopeiaR",
                     MissileName = "CassiopeiaR",
                     ForceRemove = true,
                     IsFixedRange = true,
                     SticksToMissile = true,
                     StaticStart = true
                   },
				   
				#endregion Cassiopeia
				
				#region Chogath
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Chogath,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 1200,
                     Range = 950,
                     Speed = int.MaxValue,
                     Width = 250,
                     SpellName = "Rupture",
                     MissileName = "Rupture",
                     ParticalName = "rupture_cas_01_"
                   },
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Chogath,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 500,
                     Range = 650,
                     Speed = int.MaxValue,
                     Width = 55,
                     Angle = 55,
                     SpellName = "FeralScream",
                     MissileName = "FeralScream",
                     StaticStart = true
                   },
				   
				#endregion Chogath
				
				#region Corki
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Corki,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 300,
                     Range = 825,
                     Speed = 1000,
                     Width = 250,
                     SpellName = "PhosphorusBomb",
                     MissileName = "PhosphorusBombMissile",
                     ExtraMissileName = new[] { "PhosphorusBombMissileMin" },
                     ParticalName = "Corki_Base_Q_Indicator_",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Corki,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 180,
                     Range = 1300,
                     Speed = 2000,
                     Width = 40,
                     SpellName = "MissileBarrage",
                     MissileName = "MissileBarrageMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Corki,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 180,
                     Range = 1500,
                     Speed = 2000,
                     Width = 40,
                     SpellName = "MissileBarrage2",
                     MissileName = "MissileBarrageMissile2",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Corki
				
				#region Darius
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Darius,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 750,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 375,
                     SpellName = "DariusCleave",
                     MissileName = "DariusCleave",
                     EndSticksToCaster = true,
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Darius,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 550,
                     Speed = 1500,
                     Width = 80,
                     Angle = 50,
                     SpellName = "DariusAxeGrabCone",
                     MissileName = "DariusAxeGrabCone",
                     IsFixedRange = true,
                     StaticStart = true
                   },
				   
				#endregion Darius
				   
				#region Diana
				
               new SkillshotData
                   {
                     type = Type.Arc,
                     hero = Champion.Diana,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1400,
                     Width = 198,
                     SpellName = "DianaArc",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     TakeClosestPath = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 250
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Diana,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 200,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 350,
                     SpellName = "DianaVortex",
                     MissileName = "",
                     IsFixedRange = true
                   },
				   
				#endregion Diana
				
				#region DrMundo
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.DrMundo,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "InfectedCleaverMissileCast",
                     MissileName = "InfectedCleaverMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion DrMundo
				
				#region Draven
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Draven,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1400,
                     Width = 130,
                     SpellName = "DravenDoubleShot",
                     MissileName = "DravenDoubleShotMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Draven,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 4500,
                     Speed = 2000,
                     Width = 160,
                     SpellName = "DravenRCast",
                     ExtraSpellName = new[] { "DravenRDoublecast" },
                     MissileName = "DravenR",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Draven
				
				#region Ekko
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ekko,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1650,
                     Width = 60,
                     SpellName = "EkkoQ",
                     MissileName = "EkkoQMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ekko,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 20000,
                     Speed = 2300,
                     Width = 100,
                     SpellName = "EkkoQReturn",
                     MissileName = "EkkoQReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     EndSticksToCaster = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ekko,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 3300,
                     Range = 1700,
                     Speed = int.MaxValue,
                     Width = 375,
                     SpellName = "EkkoW",
                     MissileName = "EkkoWMis",
					 //ParticalName = "Ekko_Base_W_Indicator"
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ekko,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 500,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 375,
                     SpellName = "Ekko-R",
                     MissileName = "EkkoR",
                     ParticalName = "Ekko_Base_R_AOERing",
                     DodgeFrom = new [] { "TestCubeRender" }
                   },
				   
				#endregion Ekko
				
				#region Elise
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Elise,
                     slot = SpellSlot.E,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 80,
                     SpellName = "EliseHumanE",
                     MissileName = "EliseHumanE",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Elise
				
				#region Evelynn
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Evelynn,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 650,
                     Speed = 2200,
                     Width = 60,
                     SpellName = "Evelynn Q",
                     MissileName = "HateSpikeLineMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Evelynn,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 650,
                     Speed = int.MaxValue,
                     Width = 350,
                     SpellName = "EvelynnR",
                     MissileName = "EvelynnR"
                   },
				   
				#endregion Evelynn
				
				#region Ezreal
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ezreal,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "EzrealMysticShot",
                     MissileName = "EzrealMysticShotMissile",
                     ExtraMissileName = new [] { "EzrealMysticShotPulseMissile" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ezreal,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1600,
                     Width = 80,
                     SpellName = "EzrealEssenceFlux",
                     MissileName = "EzrealEssenceFluxMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ezreal,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 1000,
                     Range = 4500,
                     Speed = 2000,
                     Width = 160,
                     SpellName = "EzrealTrueshotBarrage",
                     MissileName = "EzrealTrueshotBarrage",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Ezreal
				
				#region Fiora
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Fiora,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 400,
                     Speed = 666,
                     Width = 175,
                     SpellName = "FioraQ",
                     MissileName = "",
                     SticksToCaster = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Fiora,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 500,
                     Range = 800,
                     Speed = 3200,
                     Width = 70,
                     SpellName = "FioraW",
                     MissileName = "FioraWMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Fiora
				
				#region Fizz
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Fizz,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 550,
                     Speed = 1400,
                     Width = 60,
                     SpellName = "FizzQ",
                     MissileName = "",
                     SticksToCaster = true,
                     IsFixedRange = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Fizz,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 400,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "FizzETwo",
                     ExtraSpellName = new[] { "FizzEBuffer" },
                     MissileName = "",
                     ParticalName = "Fizz_Base_E2_Indicator_Ring"
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Fizz,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1275,
                     Speed = 1300,
                     Width = 120,
                     SpellName = "FizzR",
                     MissileName = "FizzRMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     SticksToMissile = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 300,
                     ExtraDuration = 2000
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Fizz,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 2000,
                     Range = 1275,
                     Speed = int.MaxValue,
                     Width = 275,
                     SpellName = "Fizz R Shark",
                     MissileName = "",
                     ParticalName = "Fizz_Base_R_OrbitFish"
                   },
				   
				#endregion Fizz
				
				#region Galio
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Galio,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 930,
                     Speed = 1300,
                     Width = 200,
                     SpellName = "GalioResoluteSmite",
                     MissileName = "GalioResoluteSmite",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Galio,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1300,
                     Width = 160,
                     SpellName = "GalioRighteousGust",
                     MissileName = "GalioRighteousGust",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Galio,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 550,
                     SpellName = "GalioIdolOfDurand",
                     MissileName = "",
                     FastEvade = true,
                     ExtraDuration = 2000,
                     DontCross = true
                   },
				   
				#endregion Galio
				
				#region Gangplank
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gangplank,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 300,
                     SpellName = "Barrel Explosion",
                     ParticalName = "Gangplank_Base_E_Explosion",
                     ParticalObjectName = "Barrel",
                     AllowDuplicates = true
                   },
				   
				#endregion Gangplank
				
				#region Gnar
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1125,
                     Speed = 2500,
                     Width = 60,
                     MissileAccel = -3000,
                     MissileMaxSpeed = 2500,
                     MissileMinSpeed = 1400,
                     SpellName = "GnarQ",
                     MissileName = "GnarQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Minions, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 5000,
                     Speed = 60,
                     Width = 90,
                     MissileAccel = 800,
                     MissileMaxSpeed = 2600,
                     MissileMinSpeed = 60,
                     SpellName = "GnarQReturn",
                     MissileName = "GnarQMissileReturn",
                     Collisions = new []{ Collision.YasuoWall, Collision.Caster },
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 500,
                     Range = 1150,
                     Speed = 2100,
                     Width = 90,
                     SpellName = "GnarBigQ",
                     MissileName = "GnarBigQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Minions, Collision.Heros },
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 600,
                     Range = 600,
                     Speed = int.MaxValue,
                     Width = 110,
                     SpellName = "GnarBigW",
                     MissileName = "",
                     IsFixedRange = true,
                     FastEvade = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 475,
                     Speed = 900,
                     Width = 150,
                     SpellName = "GnarE",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 475,
                     Speed = 800,
                     Width = 350,
                     SpellName = "GnarBigE",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gnar,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 275,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 500,
                     SpellName = "GnarR",
                     MissileName = "",
                     FastEvade = true
                   },
				   
				#endregion Gnar
				
				#region Gragas
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gragas,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1000,
                     Width = 200,
                     SpellName = "GragasQ",
                     MissileName = "GragasQMissile",
                     ParticalName = "Gragas_Base_Q_",
                     Collisions = new []{ Collision.YasuoWall },
                     DontCross = true,
                     ExtraDuration = 3750
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gragas,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 3750,
                     Range = 850,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "Gragas Q Placement",
                     MissileName = "",
                     ParticalName = "Gragas_Base_Q_",
                     DontCross = true,
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Gragas,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 0,
                     Range = 600,
                     ExtraRange = 100,
                     Speed = 1000,
                     Width = 200,
                     SpellName = "GragasE",
                     MissileName = "",
                     Collisions = new []{ Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToCaster = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Gragas,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1800,
                     Width = 350,
                     SpellName = "GragasR",
                     MissileName = "GragasRBoom",
                     Collisions = new []{ Collision.YasuoWall },
                   },
				   
				#endregion Gragas
				
				#region Graves
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Graves,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 825,
                     Speed = 3000,
                     Width = 60,
                     SpellName = "GravesQLineSpell",
                     MissileName = "GravesQLineMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Walls },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     ExtraDuration = 250
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Graves,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 825,
                     Speed = 1600,
                     Width = 60,
                     SpellName = "GravesQReturn",
                     MissileName = "GravesQReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Graves,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1500,
                     Width = 225,
                     SpellName = "GravesSmokeGrenade",
                     MissileName = "GravesSmokeGrenadeBoom",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Graves,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 4300,
                     Range = 950,
                     Speed = int.MaxValue,
                     Width = 225,
                     SpellName = "Graves W Placement",
                     MissileName = "",
                     ParticalName = "Graves_Base_W_tar_"
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Graves,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 2100,
                     Width = 100,
                     SpellName = "GravesChargeShot",
                     MissileName = "GravesChargeShotShot",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Graves,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 10,
                     Range = 800,
                     Speed = 2100,
                     Width = 45,
                     SpellName = "Graves R Explode",
                     MissileName = "GravesChargeShotFxMissile",
                     ExtraMissileName = new []{ "GravesChargeShotFxMissile2" },
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     AllowDuplicates = true
                   },
				   
				#endregion Graves
				
				#region Hecarim
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Hecarim,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 50,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 300,
                     SpellName = "HecarimRapidSlash",
                     MissileName = "",
                     ParticalName = "Hecarim_Base_Q_Cas"
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Hecarim,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 0,
                     Range = 1500,
                     Speed = 1100,
                     Width = 240,
                     SpellName = "HecarimUlt",
                     MissileName = "HecarimUltMissile",
                     SticksToMissile = true
                   },
				   
				#endregion Hecarim
				   
				#region Heimerdinger

               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Heimerdinger,
                     CasterName = "HeimerTYellow",
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 1000,
                     Speed = 1650,
                     Width = 65,
                     MissileAccel = -1000,
                     MissileMinSpeed = 1200,
                     MissileMaxSpeed = 1650,
                     SpellName = "HeimerdingerQTurretBlast",
                     ExtraSpellName = new[] { "HeimerdingerQTurretBigBlast" },
                     MissileName = "HeimerdingerTurretEnergyBlast",
                     ExtraMissileName = new[] { "HeimerdingerTurretBigEnergyBlast" },
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Heimerdinger,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1350,
                     Speed = 750,
                     Width = 40,
                     MissileAccel = 4000,
                     MissileMinSpeed = 750,
                     MissileMaxSpeed = 3000,
                     SpellName = "Heimerdingerwm",
                     MissileName = "HeimerdingerWAttack2",
                     ExtraMissileName = new[] { "HeimerdingerWAttack2Ult" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     DetectByMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Heimerdinger,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1200,
                     Width = 135,
                     SpellName = "HeimerdingerE",
                     ExtraSpellName = new[] { "HeimerdingerEUlt", "HeimerdingerEUltBounce" },
                     MissileName = "HeimerdingerESpell",
                     ExtraMissileName = new[] { "HeimerdingerESpell_ult", "HeimerdingerESpell_ult2" },
                     Collisions = new []{ Collision.YasuoWall },
                   },
				   
				#endregion Heimerdinger
				
				#region Illaoi
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Illaoi,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 750,
                     Range = 850,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "IllaoiQ",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Illaoi,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 265,
                     Range = 950,
                     Speed = 1900,
                     Width = 50,
                     SpellName = "IllaoiE",
                     MissileName = "Illaoiemis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Illaoi,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 850,
                     Range = 850,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "Illaoi Tentacles",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     StaticStart = true,
                     AllowDuplicates = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Illaoi,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 450,
                     SpellName = "IllaoiR",
                     MissileName = ""
                   },
				   
				#endregion Illaoi
				
				#region Irelia
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Irelia,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1200,
                     Speed = 1600,
                     Width = 120,
                     SpellName = "IreliaTranscendentBlades",
                     MissileName = "IreliaTranscendentBlades",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Irelia
				
				#region Ivern
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ivern,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1300,
                     Width = 65,
                     SpellName = "IvernQ",
                     MissileName = "IvernQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     SticksToMissile = true,
                     DetectByMissile = true
                   },
				   
				#endregion Ivern
				
				#region Janna
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Janna,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 1700,
                     Speed = 900,
                     Width = 120,
                     SpellName = "HowlingGale",
                     MissileName = "HowlingGaleSpell",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true,
                     DetectByMissile = true
                   },
				   
				#endregion Janna
				
				#region JarvanIV
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.JarvanIV,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 425,
                     Range = 770,
                     Speed = int.MaxValue,
                     Width = 70,
                     SpellName = "JarvanIVDragonStrike",
                     MissileName = "",
                     IsFixedRange = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.JarvanIV,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 450,
                     Range = 910,
                     Speed = 2600,
                     Width = 120,
                     SpellName = "JarvanIVEQ",
                     MissileName = "",
                     IsFixedRange = true,
                     SticksToCaster = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.JarvanIV,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 450,
                     Range = 850,
                     Speed = int.MaxValue,
                     Width = 175,
                     SpellName = "JarvanIVDemacianStandard",
                     MissileName = "JarvanIVDemacianStandard"
                   },
				   
				#endregion JarvanIV
				
				#region Jax
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Jax,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 125,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 300,
                     SpellName = "JaxCounterStrike",
                     MissileName = "",
                     RequireBuff = "JaxEvasion",
                     RequireBuffCount = 1
                   },
				
				#endregion Jax
				
				#region Jayce
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Jayce,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 230,
                     Range = 1050,
                     Speed = 1450,
                     Width = 70,
                     SpellName = "jayceshockblast",
                     MissileName = "JayceShockBlastMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 200
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Jayce,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 2000,
                     Speed = 2350,
                     Width = 70,
                     SpellName = "Jayce E Q",
                     MissileName = "JayceShockBlastWallMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     SticksToMissile = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 250
                   },
				   
				#endregion Jayce
				
				#region Jhin
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Jhin,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 750,
                     Range = 2550,
                     Speed = 5000,
                     Width = 45,
                     SpellName = "JhinW",
                     MissileName = "JhinWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Jhin,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 3500,
                     Speed = 5000,
                     Width = 80,
                     SpellName = "JhinRShotMis",
                     MissileName = "JhinRShotMis",
                     ExtraMissileName = new []{ "JhinRShotMis4" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Jhin
				
				#region Jinx
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Jinx,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 600,
                     Range = 1500,
                     Speed = 3300,
                     Width = 65,
                     SpellName = "JinxW",
                     ExtraSpellName = new[] { "JinxWMissile" },
                     MissileName = "JinxWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Jinx,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 4500,
                     Range = 1500,
                     Speed = int.MaxValue,
                     Width = 75,
                     SpellName = "Jinx E Placement",
                     MissileName = "",
                     ParticalName = "Jinx_Base_E_Mine_Ready_",
                     AllowDuplicates = true,
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Jinx,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 600,
                     Range = 4000,
                     Speed = 1700,
                     Width = 140,
                     SpellName = "JinxR",
                     MissileName = "JinxR",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Jinx
				
				#region Kalista
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Kalista,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 350,
                     Range = 1200,
                     Speed = 2400,
                     Width = 70,
                     SpellName = "KalistaMysticShot",
                     MissileName = "kalistamysticshotmistrue",
                     ExtraMissileName = new []{ "kalistamysticshotmis" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Kalista
				
				#region Karma
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Karma,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1700,
                     Width = 90,
                     SpellName = "KarmaQ",
                     MissileName = "KarmaQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Karma,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 1700,
                     Width = 100,
                     SpellName = "KarmaQMantra",
                     MissileName = "KarmaQMissileMantra",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 200,
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Karma,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 1500,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "Karma Q Explode",
                     MissileName = "",
                     ParticalName = "Karma_Base_Q_impact_R_01",
                   },
				   
				#endregion Karma
				
				#region Karthus
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Karthus,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 850,
                     Range = 875,
                     Speed = int.MaxValue,
                     Width = 160,
                     SpellName = "KarthusLayWasteA1",
                     MissileName = "KarthusLayWasteA1",
                     ParticalName = "Karthus_Base_Q_Ring",
                     ExtraSpellName = new [] { "KarthusLayWasteA1", "KarthusLayWasteA2", "KarthusLayWasteA3", "KarthusLayWasteDeadA1", "KarthusLayWasteDeadA2", "KarthusLayWasteDeadA3" },
                   },
				   
				#endregion Karthus
				
				#region Kassadin
				
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Kassadin,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 600,
                     Speed = 1000,
                     Width = 20,
                     Angle = 70,
                     SpellName = "ForcePulse",
                     MissileName = "ForcePulse",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Kassadin,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 500,
                     Speed = int.MaxValue,
                     Width = 270,
                     SpellName = "RiftWalk",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     StaticStart = true
                   },
				   
				#endregion Kassadin
				
				#region Kennen
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Kennen,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 175,
                     Range = 1050,
                     Speed = 1700,
                     Width = 50,
                     SpellName = "KennenShurikenHurlMissile1",
                     MissileName = "KennenShurikenHurlMissile1",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Kennen
				
				#region Khazix
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Khazix,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1025,
                     Speed = 1700,
                     Width = 70,
                     SpellName = "KhazixW",
                     ExtraSpellName = new [] { "khazixwlong" },
                     MissileName = "KhazixWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Khazix,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 700,
                     Speed = 1250,
                     Width = 300,
                     SpellName = "KhazixE",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Khazix,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 900,
                     Speed = 1250,
                     Width = 300,
                     SpellName = "KhazixELong",
                     MissileName = "",
                   },
				   
				#endregion Khazix
				
				#region Kled
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Kled,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1600,
                     Width = 45,
                     SpellName = "KledQ",
                     MissileName = "KledQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Kled,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 700,
                     Speed = 3000,
                     Width = 40,
                     SpellName = "KledRiderQ",
                     MissileName = "KledRiderQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Kled,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 550,
                     Speed = 970,
                     Width = 100,
                     SpellName = "KledEDash",
                     MissileName = "",
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Kled
				   
				#region KogMaw
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.KogMaw,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1650,
                     Width = 70,
                     SpellName = "KogMawQ",
                     MissileName = "KogMawQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.KogMaw,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1300,
                     Speed = 1400,
                     Width = 120,
                     SpellName = "KogMawVoidOoze",
                     MissileName = "KogMawVoidOozeMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.KogMaw,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 1150,
                     Range = 5000,
                     Speed = int.MaxValue,
                     Width = 240,
                     SpellName = "KogMawLivingArtillery",
                     MissileName = "",
                     ParticalName = "KogMaw_Base_R_cas_"
                   },
				   
				#endregion KogMaw
				
				#region Leblanc
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Leblanc,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 550,
                     Speed = 1600,
                     Width = 220,
                     SpellName = "LeblancW",
                     MissileName = "",
                     ParticalName = "LeBlanc_Base_W_cas"
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Leblanc,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1750,
                     Width = 55,
                     SpellName = "LeblancE",
                     MissileName = "LeblancEMissile",
                     ExtraMissileName = new[] { "LeblancRE" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Leblanc
				
				#region LeeSin
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.LeeSin,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1800,
                     Width = 60,
                     SpellName = "BlindMonkQOne",
                     MissileName = "BlindMonkQOne",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.LeeSin,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 430,
                     SpellName = "BlindMonkEOne",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.LeeSin,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 700,
                     Speed = 1500,
                     Width = 100,
                     SpellName = "BlindMonkRKick",
                     MissileName = "",
                     IsFixedRange = true,
                     StartsFromTarget = true
                   },
				   
				#endregion LeeSin
				
				#region Leona
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Leona,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 200,
                     Range = 900,
                     Speed = 2000,
                     Width = 70,
                     SpellName = "LeonaZenithBlade",
                     MissileName = "LeonaZenithBladeMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     TakeClosestPath = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Leona,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 1000,
                     Range = 1200,
                     Speed = int.MaxValue,
                     Width = 300,
                     SpellName = "LeonaSolarFlare",
                     MissileName = "LeonaSolarFlare",
                     ParticalName = "Leona_Base_R_hit_aoe_"
                   },
				   
				#endregion Leona
				
				#region Lissandra
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lissandra,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 700,
                     Speed = 2200,
                     Width = 75,
                     SpellName = "LissandraQ",
                     MissileName = "LissandraQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Minions, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lissandra,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 450,
                     Speed = 2200,
                     Width = 90,
                     SpellName = "LissandraQShards",
                     MissileName = "LissandraQShards",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true,
                     AllowDuplicates = true,
                     ExtraRange = 100
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Lissandra,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 10,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 450,
                     SpellName = "LissandraW",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lissandra,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1025,
                     Speed = 850,
                     Width = 125,
                     SpellName = "LissandraE",
                     MissileName = "LissandraEMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Lissandra,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 475,
                     Speed = int.MaxValue,
                     Width = 375,
                     SpellName = "LissandraR",
                     MissileName = "",
                     StartsFromTarget = true
                   },
				   
				#endregion Lissandra
				
				#region Lucian
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lucian,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 350,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 65,
                     SpellName = "LucianQ",
                     MissileName = "",
                     IsFixedRange = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lucian,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 325,
                     Range = 900,
                     Speed = 1600,
                     Width = 55,
                     SpellName = "LucianW",
                     MissileName = "lucianwmissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lucian,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1200,
                     Speed = 2800,
                     Width = 110,
                     SpellName = "LucianR",
                     ExtraSpellName = new[] { "LucianRMis" },
                     MissileName = "lucianrmissileoffhand",
                     ExtraMissileName = new[] { "lucianrmissile" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Lucian
				
				#region Lulu
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lulu,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1450,
                     Width = 80,
                     SpellName = "LuluQ",
                     ExtraSpellName = new[] { "LuluQPix" },
                     MissileName = "LuluQMissile",
                     ExtraMissileName = new[] { "LuluQMissileTwo" },
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Lulu
				
				#region Lux
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lux,
                     slot = SpellSlot.Q,
                     CollideCount = 1,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1300,
                     Speed = 1200,
                     Width = 70,
                     SpellName = "LuxLightBinding",
                     MissileName = "LuxLightBindingMis",
                     ExtraMissileName = new[] { "LuxLightBindingDummy" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Lux,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1300,
                     Width = 275,
                     SpellName = "LuxLightStrikeKugel",
                     MissileName = "LuxLightStrikeKugel",
                     Collisions = new []{ Collision.YasuoWall },
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Lux,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 5000,
                     Range = 1100,
                     Speed = int.MaxValue,
                     Width = 275,
                     SpellName = "Lux E Placement",
                     ParticalName = "Lux_Base_E_tar_aoe_",
                     MissileName = "",
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Lux,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 1000,
                     Range = 3500,
                     Speed = int.MaxValue,
                     Width = 150,
                     SpellName = "LuxMaliceCannon",
                     StartParticalName = "Lux_Base_R_cas",
                     MidParticalName = "Lux_Base_R_mis_beam_middle",
                     EndParticalName = "Lux_Base_R_mis_beam",
                     MissileName = "",
                     IsFixedRange = true,
                     StaticStart = true
                   },
				   
				#endregion Lux
				
				#region Warwick
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Warwick,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 0,
                     Range = 0,
                     Speed = 1600,
                     Width = 150,
                     MoveSpeedScaleMod = 2.5f,
                     SpellName = "WarwickR",
                     MissileName = "",
                     FastEvade = true,
                     SticksToCaster = true,
                     RangeScaleWithMoveSpeed = true,
                     IsFixedRange = true,
                     Collisions = new []{ Collision.Heros },
                   },
				   
				#endregion Warwick
				
				#region Malphite
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Malphite,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 400,
                     SpellName = "Landslide",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Malphite,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 0,
                     Range = 1000,
                     Speed = 1600,
                     Width = 270,
                     SpellName = "UFSlash",
                     MissileName = "UFSlash",
                   },
				   
				#endregion Malphite
				
				#region MonkeyKing
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.MonkeyKing,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 50,
                     ExtraDuration = 3950,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 320,
                     SpellName = "MonkeyKingSpinToWin",
                     MissileName = "",
                     EndSticksToCaster = true,
                     FastEvade = true
                   },
				   
				#endregion MonkeyKing
				
				#region Malzahar
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Malzahar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 750,
                     Speed = 1600,
                     Width = 90,
                     SpellName = "MalzaharQ",
                     MissileName = "MalzaharQMissile",
                     StaticStart = true,
                     StaticEnd = true
                   },
				   
				#endregion Malzahar
				   
				#region Maokai
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Maokai,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 400,
                     Range = 650,
                     Speed = 1800,
                     Width = 110,
                     SpellName = "MaokaiTrunkLine",
                     MissileName = "MaokaiTrunkLineMissile",
                     IsFixedRange = true,
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Maokai,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 650,
                     Range = 1100,
                     Speed = 1750,
                     Width = 100,
                     SpellName = "MaokaiSapling2",
                     MissileName = "MaokaiSapling2Boom",
                   },
				   
				#endregion Maokai
				
				#region MissFortune
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.MissFortune,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 1450,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "MissFortuneBulletTime",
                     MissileName = "MissFortuneBullets",
                     ExtraMissileName = new[] { "MissFortuneBulletEMPTY" },
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion MissFortune
				
				#region Mordekaiser
				
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Mordekaiser,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 640,
                     Speed = int.MaxValue,
                     Width = 50,
                     Angle = 50,
                     SpellName = "MordekaiserSyphonOfDestruction",
                     MissileName = "",
                     IsFixedRange = true,
                     StaticStart = true
                   },
				   
				#endregion Mordekaiser
				
				#region Morgana
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Morgana,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1150,
                     Width = 80,
                     SpellName = "DarkBindingMissile",
                     MissileName = "DarkBindingMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Morgana,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 0,
                     ExtraDuration = 5000,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 250,
                     SpellName = "TormentedSoil",
                     MissileName = "",
                   },
				   
				#endregion Morgana
				
				#region Nami
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Nami,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 700,
                     Range = 850,
                     Speed = 2500,
                     Width = 200,
                     SpellName = "NamiQ",
                     MissileName = "NamiQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Nami,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 2750,
                     Speed = 850,
                     Width = 260,
                     SpellName = "NamiR",
                     MissileName = "NamiRMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Nami
				
				#region Nautilus
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Nautilus,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 2000,
                     Width = 90,
                     SpellName = "NautilusAnchorDrag",
                     MissileName = "NautilusAnchorDragMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions, Collision.Walls },
                     IsFixedRange = true,
                     SticksToMissile = true,
                   },
				   
				#endregion Nautilus
				
				#region Nasus
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Nasus,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 650,
                     Speed = int.MaxValue,
                     Width = 400,
                     SpellName = "NasusE",
                     MissileName = "",
                   },
				   
				#endregion Nasus
				
				#region Nidalee
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Nidalee,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1500,
                     Speed = 1300,
                     Width = 60,
                     SpellName = "JavelinToss",
                     MissileName = "JavelinToss",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Nidalee,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 300,
                     Speed = int.MaxValue,
                     Width = 60,
                     Angle = 180,
                     SpellName = "Swipe",
                     MissileName = "",
                     IsFixedRange = true,
                     StaticStart = true
                   },
				   
				#endregion Nidalee
				
				#region Nocturne
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Nocturne,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1400,
                     Width = 60,
                     SpellName = "NocturneDuskbringer",
                     MissileName = "NocturneDuskbringer",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Nocturne
				
				#region Nunu
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Nunu,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 10,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 550,
                     SpellName = "AbsoluteZero",
                     MissileName = "",
                     ParticalName = "Nunu_Base_R_indicator_",
                     ExtraDuration = 3000
                   },
				   
				#endregion Nunu
				
				#region Olaf
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Olaf,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     ExtraRange = 150,
                     Speed = 1600,
                     Width = 90,
                     SpellName = "OlafAxeThrowCast",
                     MissileName = "OlafAxeThrow",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true
                   },
				   
				#endregion Olaf
				
				#region Orianna
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Orianna,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 2000,
                     Speed = 1200,
                     Width = 80,
                     SpellName = "OrianaIzunaCommand",
                     MissileName = "OrianaIzuna",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 175
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Orianna,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 10,
                     Range = 2000,
                     Speed = int.MaxValue,
                     Width = 255,
                     SpellName = "Orianna W",
                     MissileName = "",
                     ParticalName = "Orianna_Base_W_Dissonance_ball_"
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Orianna,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 1500,
                     Speed = 1850,
                     Width = 85,
                     SpellName = "OriannasE",
                     MissileName = "orianaredact",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Orianna,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 25000,
                     Speed = int.MaxValue,
                     Width = 400,
                     SpellName = "OriannaR",
                     MissileName = "Orianna_Base_R_VacuumIndicatorSelfRing",
                     ExtraMissileName = new[] {"Orianna_Base_R_VacuumIndicator"},
                   },
				   
				#endregion Orianna
				
				#region Pantheon
				
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Pantheon,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 400,
                     Range = 640,
                     Speed = int.MaxValue,
                     Width = 70,
                     Angle = 70,
                     ExtraDuration = 750,
                     SpellName = "PantheonE",
                     MissileName = "",
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Pantheon,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 4700,
                     Range = 5500,
                     Speed = int.MaxValue,
                     Width = 600,
                     SpellName = "PantheonRJump",
                     MissileName = "",
                     ParticalName = "Pantheon_Base_R_indicator_",
                     StaticEnd = true
                   },
				   
				#endregion Pantheon
				   
				#region Poppy
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Poppy,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 500,
                     ExtraDuration = 900,
                     Range = 430,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "PoppyQ",
                     ExtraSpellName = new[] { "PoppyQSpell" },
                     MissileName = "PoppyQ",
                     IsFixedRange = true,
                     StaticStart = true,
                     DontAddExtraDuration = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Poppy,
                     slot = (SpellSlot)50,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 450,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "PoppyRSpellInstant",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Poppy,
                     slot = (SpellSlot)50,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1600,
                     Width = 100,
                     SpellName = "PoppyRSpell",
                     MissileName = "PoppyRMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     SticksToMissile = true
                   },
				   
				#endregion Poppy
				
				#region Quinn
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Quinn,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 300,
                     Range = 1050,
                     Speed = 1550,
                     Width = 60,
                     SpellName = "QuinnQ",
                     MissileName = "QuinnQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Quinn
				
				#region RekSai
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.RekSai,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 125,
                     Range = 1500,
                     Speed = 1950,
                     Width = 65,
                     SpellName = "reksaiqburrowed",
                     MissileName = "RekSaiQBurrowedMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.RekSai,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 10,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "RekSaiW2",
                     MissileName = "",
                   },
				   
				#endregion RekSai
				
				#region Renekton
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Renekton,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 450,
                     Speed = 1100,
                     Width = 100,
                     SpellName = "RenektonSliceAndDice",
                     ExtraSpellName = new[] { "RenektonDice" },
                     MissileName = "",
                     IsFixedRange = true
                   },
				   
				#endregion Renekton
				
				#region Rengar
				
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Rengar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 300,
                     Range = 400,
                     Speed = int.MaxValue,
                     Width = 70,
                     Angle = 180,
                     SpellName = "RengarQ",
                     MissileName = "RengarQ",
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Rengar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 600,
                     Speed = int.MaxValue,
                     Width = 80,
                     SpellName = "RengarQ2",
                     MissileName = "RengarQ2",
                     IsFixedRange = true,
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Rengar,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1500,
                     Width = 70,
                     SpellName = "RengarE",
                     ExtraSpellName = new[] { "RengarEEmp" },
                     MissileName = "RengarEMis",
                     ExtraMissileName = new[] { "RengarEEmpMis" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Rengar
				
				#region Riven
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Riven,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 350,
                     Range = 250,
                     Speed = int.MaxValue,
                     Width = 200,
                     RequireBuff = "RivenTriCleaveBuff",
                     RequireBuffCount = 2,
                     SpellName = "RivenTriCleave",
                     MissileName = "",
                     ParticalName = "Riven_Base_Q_03_Wpn_Trail",
                     IsFixedRange = true,
                     EndIsCasterDirection = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Riven,
                     slot = SpellSlot.W,
                     DangerLevel = 4,
                     CastDelay = 10,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 250,
                     SpellName = "RivenMartyr",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Riven,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1075,
                     Speed = 1600,
                     Width = 130,
                     SpellName = "RivenIzunaBlade",
                     MissileName = "RivenLightsaberMissile",
                     ExtraMissileName = new[] { "RivenWindslashMissileCenter", "RivenWindslashMissileLeft", "RivenWindslashMissileRight"},
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Riven
				
				#region Rumble
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Rumble,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "RumbleGrenade",
                     MissileName = "RumbleGrenadeMissile",
                     ExtraMissileName = new[] { "RumbleGrenadeMissileDangerZone" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Rumble,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 400,
                     Range = 1200,
                     Speed = 1600,
                     Width = 200,
                     SpellName = "RumbleCarpetBombM",
                     MissileName = "RumbleCarpetBombMissile",
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Rumble,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 4600,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 170,
                     SpellName = "Rumble R Placement",
                     MissileName = "",
                     ParticalName = "rumble_base_r_burn",
                     StaticStart = true,
                     AllowDuplicates = true,
                     DontCross = true
                   },
				   
				#endregion Rumble
				
				#region Ryze
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Ryze,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1700,
                     Width = 55,
                     SpellName = "RyzeQ",
                     MissileName = "RyzeQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Ryze
				
				#region Sejuani
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sejuani,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 0,
                     Range = 620,
                     ExtraRange = 200,
                     Speed = 1000,
                     Width = 90,
                     SpellName = "SejuaniArcticAssault",
                     MissileName = "",
                     Collisions = new []{ Collision.Heros },
                     FastEvade = true,
                     SticksToCaster = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sejuani,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 110,
                     SpellName = "SejuaniGlacialPrisonCast",
                     MissileName = "sejuaniglacialprison",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Sejuani
				
				#region Shen
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Shen,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1,
                     Speed = 2500,
                     Width = 80,
                     SpellName = "",
                     MissileName = "ShenQMissile",
                     EndSticksToCaster = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Shen,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 0,
                     Range = 600,
                     Speed = 1300,
                     Width = 50,
                     SpellName = "ShenE",
                     MissileName = "ShenE",
                     SticksToCaster = true
                   },
				   
				#endregion Shen
				
				#region Shyvana
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Shyvana,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1575,
                     Width = 60,
                     SpellName = "ShyvanaFireball",
                     MissileName = "ShyvanaFireballMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Shyvana,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 350,
                     Range = 975,
                     Speed = 1575,
                     Width = 60,
                     SpellName = "ShyvanaFireballDragon2",
                     MissileName = "ShyvanaFireballDragonMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true,
                     HasExplodingEnd = true,
                     ExplodeWidth = 250
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Shyvana,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 300,
                     Range = 950,
                     ExtraRange = 200,
                     Speed = 1100,
                     Width = 200,
                     SpellName = "ShyvanaTransformCast",
                     MissileName = "",
                     SticksToCaster = true
                   },
				   
				#endregion Shyvana
				
				#region Sion
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sion,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 1000,
                     ExtraDuration = 1000,
                     Range = 750,
                     Speed = int.MaxValue,
                     Width = 250,
                     SpellName = "SionQ",
                     MissileName = "SionQHitParticleMissile2",
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Sion,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 50,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 325,
                     SpellName = "SionWDetonate",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sion,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1800,
                     Width = 80,
                     SpellName = "SionE",
                     MissileName = "SionEMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sion,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 0,
                     Range = 1500,
                     Speed = 1000,
                     Width = 200,
                     SpellName = "SionR",
                     MissileName = "",
                     Collisions = new []{ Collision.Heros, Collision.Walls },
                     SticksToCaster = true,
                     FastEvade = true
                   },
				   
				#endregion Sion
				
				#region Sivir
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sivir,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1250,
                     Speed = 1350,
                     Width = 90,
                     SpellName = "SivirQ",
                     MissileName = "SivirQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sivir,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 20000,
                     Speed = 1350,
                     Width = 90,
                     SpellName = "SivirQReturn",
                     MissileName = "SivirQMissileReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = false,
                     EndSticksToCaster = true,
                     SticksToMissile = true
                   },
				   
				#endregion Sivir
				
				#region Skarner
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Skarner,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1500,
                     Width = 70,
                     SpellName = "SkarnerFracture",
                     MissileName = "SkarnerFractureMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Skarner
				
				#region Sona
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Sona,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 2400,
                     Width = 140,
                     SpellName = "SonaR",
                     MissileName = "SonaR",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Sona
				
				#region Soraka
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Soraka,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1100,
                     Width = 225,
                     SpellName = "SorakaQ",
                     MissileName = "SorakaQMissile",
                     ParticalName = "soraka_base_q_indicator_",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Soraka,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 1770,
                     Range = 920,
                     Speed = int.MaxValue,
                     Width = 250,
                     SpellName = "SorakaE",
                     MissileName = "",
                     ParticalName = "Soraka_Base_E_rune",
                   },
				   
				#endregion Soraka
				
				#region Swain
				
              new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Swain,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 1100,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 180,
                     SpellName = "SwainShadowGrasp",
                     MissileName = "SwainShadowGrasp",
                   },
				   
				#endregion Swain
				
				#region Syndra
				
              new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Syndra,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 650,
                     Range = 825,
                     Speed = int.MaxValue,
                     Width = 180,
                     SpellName = "SyndraQ",
                     MissileName = "SyndraQSpell",
                   },
              new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Syndra,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 950,
                     Speed = 1500,
                     Width = 210,
                     SpellName = "SyndraWCast",
                     MissileName = "",
                   },
              new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Syndra,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 800,
                     Speed = 2500,
                     Width = 100,
                     SpellName = "SyndraE",
                     MissileName = "SyndraEMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true,
                     IsFixedRange = true
                   },
              new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Syndra,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 850,
                     Speed = 2500,
                     Width = 100,
                     SpellName = "SyndraESphereMissile",
                     ExtraSpellName = new[] { "SyndraE5", "SyndraEQ" },
                     MissileName = "SyndraESphereMissile",
                     ExtraMissileName = new[] { "SyndraEMissile2", "SyndraEMissile3" },
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true,
                   },
				   
				#endregion Syndra
				
				#region TahmKench
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.TahmKench,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 2800,
                     Width = 90,
                     SpellName = "TahmKenchQ",
                     MissileName = "tahmkenchqmissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion TahmKench
				
				#region Taliyah
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Taliyah,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 3600,
                     Width = 100,
                     SpellName = "TaliyahQ",
                     MissileName = "TaliyahQMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Taliyah,
                     slot = SpellSlot.W,
                     DangerLevel = 4,
                     CastDelay = 600,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "TaliyahW",
                     MissileName = "TaliyahW"
                   },
				   
				#endregion Taliyah
				
				#region Talon
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Talon,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 2500,
                     Width = 80,
                     Angle = 20,
                     SpellName = "TalonW",
                     MissileName = "TalonWMissileOne",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     DetectByMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Talon,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 2500,
                     Speed = 3000,
                     Width = 80,
                     Angle = 20,
                     SpellName = "TalonWReturn",
                     MissileName = "TalonWMissileTwo",
                     Collisions = new []{ Collision.YasuoWall },
                     EndSticksToCaster = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Talon,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1500,
                     Speed = 2400,
                     Width = 100,
                     SpellName = "TalonR",
                     MissileName = "TalonRMisOne",
                     Collisions = new []{ Collision.YasuoWall },
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Talon,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 2500,
                     Speed = 4000,
                     Width = 100,
                     SpellName = "TalonRReturn",
                     MissileName = "TalonRMisTwo",
                     Collisions = new []{ Collision.YasuoWall },
                     EndSticksToCaster = true,
                     SticksToMissile = true
                   },
				   
				#endregion Talon
				
				#region Taric
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Taric,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 1000,
                     Range = 650,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "TaricE",
                     MissileName = "",
                     IsFixedRange = true,
                     SticksToCaster = true
                   },
				   
				#endregion Taric
				
				#region Thresh
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Thresh,
                     slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 500,
                     Range = 1100,
                     Speed = 1900,
                     Width = 70,
                     SpellName = "ThreshQ",
                     MissileName = "ThreshQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Thresh,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 125,
                     Range = 1075,
                     Speed = 2000,
                     Width = 110,
                     SpellName = "ThreshE",
                     MissileName = "ThreshEMissile1",
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Thresh
				
				#region Tristana
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Tristana,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 300,
                     Range = 900,
                     Speed = 1100,
                     Width = 270,
                     SpellName = "RocketJump",
                     ExtraSpellName = new[] { "TristanaW" },
                     MissileName = "RocketJump",
                   },
				   
				#endregion Tristana
				
				#region Trundle
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Trundle,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = int.MaxValue,
                     Width = 125,
                     SpellName = "TrundleCircle",
                     MissileName = "",
                   },
				   
				#endregion Trundle
				
				#region Tryndamere
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Tryndamere,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 650,
                     Speed = 900,
                     Width = 160,
                     SpellName = "TryndamereE",
                     MissileName = "",
                     SticksToCaster = true
                   },
				   
				#endregion Tryndamere
				
				#region TwistedFate
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.TwistedFate,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1450,
                     Speed = 1000,
                     Width = 40,
                     SpellName = "WildCards",
                     MissileName = "SealFateMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     DetectByMissile = true
                   },
				   
				#endregion TwistedFate
				
				#region Twitch
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Twitch,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 1400,
                     Width = 275,
                     SpellName = "TwitchVenomCask",
                     MissileName = "TwitchVenomCaskMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     DontAddExtraDuration = true,
                     ExtraDuration = 2850,
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Twitch,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1100,
                     Speed = 4000,
                     Width = 60,
                     SpellName = "TwitchSprayAndPrayAttack",
                     MissileName = "TwitchSprayAndPrayAttack",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
				   
				#endregion Twitch
				
				#region Urgot
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Urgot,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 150,
                     Range = 1000,
                     Speed = 1600,
                     Width = 60,
                     SpellName = "UrgotHeatseekingLineMissile",
                     MissileName = "UrgotHeatseekingLineMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Urgot,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 1500,
                     Width = 210,
                     SpellName = "UrgotPlasmaGrenade",
                     MissileName = "UrgotPlasmaGrenadeBoom",
                     Collisions = new []{ Collision.YasuoWall },
                   },
				   
				#endregion Urgot
				
				#region Varus
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Varus,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1800,
                     Speed = 1900,
                     Width = 70,
                     ExtraRange = 75,
                     SpellName = "VarusQ",
                     MissileName = "VarusQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     DetectByMissile = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Varus,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1500,
                     Width = 235,
                     SpellName = "VarusE",
                     MissileName = "VarusEMissile",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Varus,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1250,
                     Speed = 1950,
                     Width = 120,
                     SpellName = "VarusR",
                     MissileName = "VarusRMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Varus
				
				#region Veigar
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Veigar,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     CollideCount = 1,
                     Range = 950,
                     Speed = 2200,
                     Width = 70,
                     SpellName = "VeigarBalefulStrike",
                     MissileName = "VeigarBalefulStrikeMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Veigar,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 1250,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "VeigarDarkMatter",
                     MissileName = "VeigarDarkMatter",
                     ParticalName = "Veigar_Base_W_cas_"
                   },
               new SkillshotData
                   {
                     type = Type.Ring,
                     hero = Champion.Veigar,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 500,
                     Range = 700,
                     Speed = int.MaxValue,
                     Width = 80,
                     RingRadius = 350,
                     ExtraDuration = 3300,
                     SpellName = "VeigarEventHorizon",
                     MissileName = "",
                     DontAddExtraDuration = true,
                     DontCross = true
                   },
				   
				#endregion Veigar
				
				#region Velkoz
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Velkoz,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 251,
                     Range = 1100,
                     Speed = 1300,
                     Width = 50,
                     SpellName = "VelkozQ",
                     MissileName = "VelkozQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Velkoz,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1100,
                     Speed = 2100,
                     Width = 50,
                     SpellName = "VelkozQSplit",
                     MissileName = "VelkozQMissileSplit",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Velkoz,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1700,
                     Width = 88,
                     SpellName = "VelkozW",
                     MissileName = "VelkozWMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     StaticStart = true,
                     DontAddExtraDuration = true,
                     ExtraDuration = 750
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Velkoz,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1500,
                     Width = 225,
                     SpellName = "VelkozE",
                     MissileName = "VelkozEMissile",
                   },
				   
				#endregion Velkoz
				
				#region Vi
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Vi,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 750,
                     ExtraRange = 100,
                     Speed = 1500,
                     Width = 90,
                     SpellName = "ViQ",
                     MissileName = "ViQMissile",
                     Collisions = new []{ Collision.Heros },
                     SticksToCaster = true,
                     DetectByMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.Cone,
                     hero = Champion.Vi,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 770,
                     Speed = 2000,
                     Width = 90,
                     Angle = 65,
                     SpellName = "ViE",
                     MissileName = "ViEFx",
                     IsFixedRange = true,
                     DetectByMissile = true,
                     StaticStart = true
                   },
				   
				#endregion Vi
				
				#region Viktor
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Viktor,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 710,
                     Speed = 1050,
                     Width = 80,
                     SpellName = "Laser",
                     ExtraSpellName = new[] { "ViktorDeathRay" },
                     MissileName = "ViktorDeathRayMissile",
                     ExtraMissileName = new [] { "ViktorEAugMissile", "ViktorDeathRayMissile2" },
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Viktor,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 1500,
                     Range = 700,
                     Speed = int.MaxValue,
                     Width = 300,
                     SpellName = "ViktorGravitonField",
                     MissileName = "",
                     ExtraDuration = 2500,
                     DontAddExtraDuration = true
                   },
				   
				#endregion Viktor
				
				#region Vladimir
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Vladimir,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 550,
                     Speed = 4000,
                     Width = 60,
                     SpellName = "VladimirE",
                     MissileName = "VladimirEMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true,
                     DetectByMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Vladimir,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 10,
                     Range = 700,
                     Speed = int.MaxValue,
                     Width = 375,
                     SpellName = "VladimirHemoplague",
                     MissileName = "",
                   },
				   
				#endregion Vladimir
				
				#region Xerath
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Xerath,
                     slot = (SpellSlot)45,
                     DangerLevel = 2,
                     CastDelay = 530,
                     Range = 1600,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "XerathArcanopulse2",
                     MissileName = "XerathArcanopulse2",
					 //MinionName = "hiu",
					 //MinionBaseSkinName = "TestCubeRender10Vision",
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Xerath,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 700,
                     Range = 1100,
                     Speed = int.MaxValue,
                     Width = 260,
                     SpellName = "XerathArcaneBarrage2",
                     MissileName = "XerathArcaneBarrage2",
                     ParticalName = "Xerath_Base_W_aoe_green"
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Xerath,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1400,
                     Width = 60,
                     SpellName = "XerathMageSpear",
                     MissileName = "XerathMageSpearMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Xerath,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 650,
                     Range = 25000,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "XerathRMissileWrapper",
                     ExtraSpellName = new[] { "XerathLocusPulse" },
                     MissileName = "XerathLocusPulse",
                     ParticalName = "Xerath_Base_R_aoe_reticle_",
                   },
				   
				#endregion Xerath
				
				#region XinZhao
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.XinZhao,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 347,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 500,
                     SpellName = "XenZhaoParry",
                     MissileName = "",
                     StaticStart = true
                   },
				   
				#endregion XinZhao
				
				#region Yasuo
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Yasuo,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 400,
                     Range = 550,
                     Speed = int.MaxValue,
                     Width = 40,
                     SpellName = "YasuoQW",
                     ExtraSpellName = new[] { "YasuoQ2W" },
                     ParticalName = "Yasuo_Base_EQ_SwordGlow",
                     MissileName = "",
                     IsFixedRange = true,
                     StaticStart = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Yasuo,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 400,
                     Range = 440,
                     Speed = int.MaxValue,
                     Width = 275,
                     SpellName = "E Q",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Yasuo,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 400,
                     Range = 440,
                     Speed = int.MaxValue,
                     Width = 275,
                     SpellName = "E Q3",
                     MissileName = "",
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Yasuo,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 1000,
                     Width = 110,
                     SpellName = "yasuoq3w",
                     MissileName = "yasuoq3mis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
				   
				#endregion Yasuo
				
				#region Yorick
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Yorick,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 700,
                     Speed = 1800,
                     Width = 100,
                     SpellName = "YorickE",
                     MissileName = "YorickEMissile",
                     Collisions = new []{ Collision.YasuoWall },
                   },
				   
				#endregion Yorick
				
				#region Zac
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Zac,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 500,
                     Range = 550,
                     Speed = int.MaxValue,
                     Width = 120,
                     SpellName = "ZacQ",
                     MissileName = "ZacQ",
                     IsFixedRange = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Zac,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 2500,
                     Speed = 1350,
                     Width = 250,
                     SpellName = "ZacE2",
                     MissileName = "ZacE2",
                     ParticalName = "Zac_Base_E_LandPositionIndicator"
                   },
				   
				#endregion Zac
								
				#region Zed
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Zed,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1700,
                     Width = 50,
                     SpellName = "ZedQ",
                     MissileName = "ZedQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Zed,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 10,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 285,
                     SpellName = "ZedE",
                     MissileName = "",
                   },
				   
				#endregion Zed
					
				#region Ziggs
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ziggs,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1700,
                     Width = 125,
                     SpellName = "ZiggsQ",
                     ExtraSpellName = new[] { "ZiggsQBounce1", "ZiggsQBounce2" },
                     MissileName = "ZiggsQSpell",
                     ExtraMissileName = new[] { "ZiggsQSpell2", "ZiggsQSpell3" },
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ziggs,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1750,
                     Width = 275,
                     SpellName = "ZiggsW",
                     MissileName = "ZiggsW",
                     Collisions = new []{ Collision.YasuoWall },
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ziggs,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 4000,
                     Range = 1000,
                     Speed = int.MaxValue,
                     Width = 275,
                     SpellName = "Ziggs W Placement",
                     MissileName = "",
                     ParticalName = "Ziggs_Base_W_Countdown",
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ziggs,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 1550,
                     Width = 235,
                     SpellName = "ZiggsE",
                     MissileName = "ZiggsE2",
                     Collisions = new []{ Collision.YasuoWall },
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ziggs,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 0,
                     Speed = int.MaxValue,
                     Width = 70,
                     ExtraDuration = 10000,
                     SpellName = "Mines",
                     MissileName = "",
                     ParticalName = "Ziggs_Base_E_placedMine",
                     AllowDuplicates = true,
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Ziggs,
                     slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 400,
                     Range = 5000,
                     Speed = 1500,
                     Width = 500,
                     SpellName = "ZiggsR",
                     MissileName = "ZiggsRBoom",
                     DontCross = true
                   },
				   
				#endregion Ziggs
				
				#region Zilean
				
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Zilean,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 2000,
                     Width = 150,
                     SpellName = "ZileanQ",
                     MissileName = "ZileanQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     DontCross = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Zilean,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 150,
                     ExtraDuration = 3100,
                     SpellName = "Zilean Q Placement",
                     MissileName = "",
                     ParticalName = "Zilean_Base_Q_TimeBombGround",
                     DontCross = true
                   },
				   
				#endregion Zilean
				
				#region Zyra
				
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Zyra,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 850,
                     Range = 800,
                     Speed = int.MaxValue,
                     Width = 140,
                     SpellName = "ZyraQ",
                     MissileName = "ZyraQ",
                     Collisions = new []{ Collision.YasuoWall },
                     StaticStart = true,
                   },
               new SkillshotData
                   {
                     type = Type.LineMissile,
                     hero = Champion.Zyra,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 1150,
                     Width = 70,
                     SpellName = "ZyraE",
                     MissileName = "ZyraE",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     SticksToMissile = true
                   },
               new SkillshotData
                   {
                     type = Type.CircleMissile,
                     hero = Champion.Zyra,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 2200,
                     Range = 700,
                     Speed = int.MaxValue,
                     Width = 520,
                     SpellName = "ZyraR",
                     MissileName = "ZyraR",
                   },
				   
				#endregion Zyra
            };
    }
}