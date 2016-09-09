using System.Collections.Generic;
using EloBuddy;
// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyYorick.KappaEvade
{
    public static class Database
    {
        internal static class SkillShotSpells
        {
            public static readonly List<SSpell> SkillShotsSpellsList = new List<SSpell>
            {
               new SSpell
                  {
                     Type = Type.LineMissile,
                     Hero = Champion.Aatrox,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1075,
                     Speed = 1200,
                     Width = 100,
                     SpellName = "AatroxE",
                     MissileName = "AatroxEConeMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                  },
               new SSpell
                  {
                     Type = Type.LineMissile,
                     Hero = Champion.Ahri,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1750,
                     Width = 100,
                     SpellName = "AhriOrbofDeception",
                     MissileName = "AhriOrbMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     DetectByMissile = true
                   },
               new SSpell
                  {
                     Type = Type.LineMissile,
                     Hero = Champion.Ahri,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1750,
                     Width = 100,
                     SpellName = "AhriOrbReturn",
                     MissileName = "AhriOrbReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ahri,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1550,
                     Width = 60,
                     SpellName = "AhriSeduce",
                     MissileName = "AhriSeduceMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Amumu,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 2000,
                     Width = 80,
                     SpellName = "BandageToss",
                     MissileName = "SadMummyBandageToss",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Anivia,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1250,
                     Speed = 850,
                     Width = 110,
                     SpellName = "FlashFrost",
                     MissileName = "FlashFrostSpell",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Annie,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     Angle = 50,
                     CastDelay = 250,
                     Range = 625,
                     Speed = int.MaxValue,
                     Width = 80,
                     SpellName = "Incinerate",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Ashe,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     Angle = 10,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1500,
                     Width = 20,
                     SpellName = "Volley",
                     MissileName = "VolleyAttack",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     ForceRemove = true,
                     IsFixedRange = true,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ashe,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 15000,
                     Speed = 1600,
                     Width = 130,
                     SpellName = "EnchantedCrystalArrow",
                     MissileName = "EnchantedCrystalArrow",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.AurelionSol,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 850,
                     Width = 180,
                     SpellName = "AurelionSolQ",
                     MissileName = "AurelionSolQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.AurelionSol,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 300,
                     Range = 1420,
                     Speed = 4600,
                     Width = 120,
                     SpellName = "AurelionSolR",
                     MissileName = "AurelionSolRBeamMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Bard,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1600,
                     Width = 60,
                     SpellName = "BardQ",
                     MissileName = "BardQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Blitzcrank,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1800,
                     Width = 70,
                     SpellName = "RocketGrab",
                     MissileName = "RocketGrabMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Brand,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "BrandQ",
                     MissileName = "BrandQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Braum,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1200,
                     Width = 100,
                     SpellName = "BraumQ",
                     MissileName = "BraumQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Braum,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 1250,
                     Speed = 1125,
                     Width = 100,
                     SpellName = "BraumRWrapper",
                     MissileName = "braumrmissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Caitlyn,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 625,
                     Range = 1300,
                     Speed = 2200,
                     Width = 90,
                     SpellName = "CaitlynPiltoverPeacemaker",
                     MissileName = "CaitlynPiltoverPeacemaker",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Caitlyn,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 125,
                     Range = 950,
                     Speed = 2000,
                     Width = 80,
                     SpellName = "CaitlynEntrapment",
                     MissileName = "CaitlynEntrapmentMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Cassiopeia,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 825,
                     Speed = 2000,
                     Width = 20,
                     Angle = 65,
                     SpellName = "CassiopeiaR",
                     MissileName = "CassiopeiaR",
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Corki,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 500,
                     Range = 825,
                     Speed = 1125,
                     Width = 270,
                     SpellName = "PhosphorusBomb",
                     MissileName = "PhosphorusBombMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Corki,
                     Slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 175,
                     Range = 1300,
                     Speed = 2000,
                     Width = 40,
                     SpellName = "MissileBarrage",
                     MissileName = "MissileBarrageMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Corki,
                     Slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 175,
                     Range = 1500,
                     Speed = 2000,
                     Width = 40,
                     SpellName = "MissileBarrage2",
                     MissileName = "MissileBarrageMissile2",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Diana,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1400,
                     Width = 50,
                     SpellName = "DianaArc",
                     MissileName = "DianaArcArc",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.DrMundo,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "InfectedCleaverMissileCast",
                     MissileName = "InfectedCleaverMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Draven,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1400,
                     Width = 130,
                     SpellName = "DravenDoubleShot",
                     MissileName = "DravenDoubleShotMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Draven,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 15000,
                     Speed = 2000,
                     Width = 160,
                     SpellName = "DravenRCast",
                     MissileName = "DravenR",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ekko,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 300,
                     Range = 1000,
                     Speed = 1400,
                     Width = 60,
                     SpellName = "EkkoQ",
                     MissileName = "EkkoQMis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ekko,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 0,
                     Range = 1000,
                     Speed = 1650,
                     Width = 100,
                     SpellName = "",
                     MissileName = "EkkoQReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Elise,
                     Slot = SpellSlot.E,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 70,
                     SpellName = "EliseHumanE",
                     MissileName = "EliseHumanE",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ezreal,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "EzrealMysticShot",
                     MissileName = "EzrealMysticShotMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ezreal,
                     Slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1600,
                     Width = 80,
                     SpellName = "EzrealEssenceFlux",
                     MissileName = "EzrealEssenceFluxMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ezreal,
                     Slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 1000,
                     Range = 15000,
                     Speed = 2000,
                     Width = 160,
                     SpellName = "EzrealTrueshotBarrage",
                     MissileName = "EzrealTrueshotBarrage",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Fiora,
                     Slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 500,
                     Range = 800,
                     Speed = 3200,
                     Width = 70,
                     SpellName = "FioraW",
                     MissileName = "FioraWMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Fizz,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1275,
                     Speed = 1350,
                     Width = 120,
                     SpellName = "FizzMarinerDoom",
                     MissileName = "FizzMarinerDoomMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Galio,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1040,
                     Speed = 1200,
                     Width = 235,
                     SpellName = "GalioResoluteSmite",
                     MissileName = "GalioResoluteSmite",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Galio,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1280,
                     Speed = 1300,
                     Width = 160,
                     SpellName = "GalioRighteousGust",
                     MissileName = "GalioRighteousGust",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Gnar,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1185,
                     Speed = 2400,
                     Width = 60,
                     SpellName = "GnarQ",
                     MissileName = "GnarQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Gnar,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 500,
                     Range = 1150,
                     Speed = 2000,
                     Width = 90,
                     SpellName = "GnarQReturn",
                     MissileName = "GnarQMissileReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Gnar,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 500,
                     Range = 1150,
                     Speed = 2000,
                     Width = 90,
                     SpellName = "GnarBigQ",
                     MissileName = "GnarBigQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Gragas,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1750,
                     Width = 350,
                     SpellName = "GragasR",
                     MissileName = "GragasRBoom",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Graves,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 825,
                     Speed = 3000,
                     Width = 60,
                     SpellName = "GravesQLineSpell",
                     MissileName = "GravesQLineMis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Graves,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 2100,
                     Width = 100,
                     SpellName = "GravesChargeShot",
                     MissileName = "GravesChargeShotShot",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Heimerdinger,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1350,
                     Speed = 2500,
                     Width = 35,
                     SpellName = "Heimerdingerwm",
                     MissileName = "HeimerdingerWAttack2",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Heimerdinger,
                     Slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 325,
                     Range = 925,
                     Speed = 1750,
                     Width = 135,
                     SpellName = "HeimerdingerE",
                     MissileName = "HeimerdingerESpell",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Illaoi,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 750,
                     Range = 850,
                     Speed = int.MaxValue,
                     Width = 100,
                     SpellName = "IllaoiQ",
                     MissileName = "illaoiqmis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Illaoi,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1900,
                     Width = 50,
                     SpellName = "IllaoiE",
                     MissileName = "Illaoiemis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Irelia,
                     Slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 1200,
                     Speed = 1600,
                     Width = 120,
                     SpellName = "IreliaTranscendentBlades",
                     MissileName = "IreliaTranscendentBlades",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Janna,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 1700,
                     Speed = 900,
                     Width = 120,
                     SpellName = "JannaQ",
                     MissileName = "HowlingGaleSpell",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jayce,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1300,
                     Speed = 1450,
                     Width = 70,
                     SpellName = "jayceshockblast",
                     MissileName = "JayceShockBlastMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jayce,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1570,
                     Speed = 2350,
                     Width = 70,
                     SpellName = "JayceQAccel",
                     MissileName = "JayceShockBlastWallMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jhin,
                     Slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 750,
                     Range = 2550,
                     Speed = 5000,
                     Width = 40,
                     SpellName = "JhinW",
                     MissileName = "JhinWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jhin,
                     Slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 3500,
                     Speed = 5000,
                     Width = 80,
                     SpellName = "JhinRShotMis",
                     MissileName = "JhinRShotMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jhin,
                     Slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 3500,
                     Speed = 5000,
                     Width = 80,
                     SpellName = "JhinRShotMis4",
                     MissileName = "JhinRShotMis4",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jinx,
                     Slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 600,
                     Range = 1500,
                     Speed = 3300,
                     Width = 60,
                     SpellName = "JinxW",
                     MissileName = "JinxWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Jinx,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 600,
                     Range = 15000,
                     Speed = 1700,
                     Width = 140,
                     SpellName = "JinxR",
                     MissileName = "JinxR",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Kalista,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 350,
                     Range = 1300,
                     Speed = 2000,
                     Width = 70,
                     SpellName = "KalistaMysticShot",
                     MissileName = "kalistamysticshotmistrue",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Kalista,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 350,
                     Range = 1300,
                     Speed = 2000,
                     Width = 70,
                     SpellName = "KalistaMysticShot",
                     MissileName = "kalistamysticshotmis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Karma,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1050,
                     Speed = 1700,
                     Width = 90,
                     SpellName = "KarmaQ",
                     MissileName = "KarmaQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Karma,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1700,
                     Width = 100,
                     SpellName = "KarmaQMantra",
                     MissileName = "KarmaQMissileMantra",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Kassadin,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 700,
                     Speed = 1000,
                     Width = 20,
                     Angle = 70,
                     SpellName = "ForcePulse",
                     MissileName = "ForcePulse",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Kennen,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 180,
                     Range = 1175,
                     Speed = 1700,
                     Width = 50,
                     SpellName = "KennenShurikenHurlMissile1",
                     MissileName = "KennenShurikenHurlMissile1",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Khazix,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1700,
                     Width = 70,
                     SpellName = "KhazixW",
                     MissileName = "KhazixWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Khazix,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1700,
                     Width = 70,
                     SpellName = "khazixwlong",
                     MissileName = "KhazixWMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.KogMaw,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1125,
                     Speed = 1650,
                     Width = 70,
                     SpellName = "KogMawQ",
                     MissileName = "KogMawQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.KogMaw,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1360,
                     Speed = 1400,
                     Width = 120,
                     SpellName = "KogMawVoidOoze",
                     MissileName = "KogMawVoidOozeMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Leblanc,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 960,
                     Speed = 1750,
                     Width = 55,
                     SpellName = "LeblancSoulShackle",
                     MissileName = "LeblancSoulShackle",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Leblanc,
                     Slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 960,
                     Speed = 1750,
                     Width = 55,
                     SpellName = "LeblancSoulShackleM",
                     MissileName = "LeblancSoulShackleM",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.LeeSin,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1800,
                     Width = 60,
                     SpellName = "BlindMonkQOne",
                     MissileName = "BlindMonkQOne",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Leona,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 200,
                     Range = 975,
                     Speed = 2000,
                     Width = 70,
                     SpellName = "LeonaZenithBlade",
                     MissileName = "LeonaZenithBladeMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lissandra,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 825,
                     Speed = 2250,
                     Width = 75,
                     SpellName = "LissandraQ",
                     MissileName = "LissandraQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lissandra,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 825,
                     Speed = 2250,
                     Width = 75,
                     SpellName = "LissandraQShards",
                     MissileName = "LissandraQShards",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lissandra,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 1200,
                     Width = 125,
                     SpellName = "LissandraE",
                     MissileName = "LissandraEMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lucian,
                     Slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 300,
                     Range = 1000,
                     Speed = 1600,
                     Width = 80,
                     SpellName = "LucianW",
                     MissileName = "lucianwmissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lucian,
                     Slot = SpellSlot.R,
                     DangerLevel = 1,
                     CastDelay = 300,
                     Range = 1000,
                     Speed = 1600,
                     Width = 80,
                     SpellName = "LucianRMis",
                     MissileName = "lucianrmissileoffhand",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lucian,
                     Slot = SpellSlot.R,
                     DangerLevel = 1,
                     CastDelay = 300,
                     Range = 1000,
                     Speed = 1600,
                     Width = 80,
                     SpellName = "LucianRMis",
                     MissileName = "lucianrmissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lulu,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1450,
                     Width = 80,
                     SpellName = "LuluQ",
                     MissileName = "LuluQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lulu,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1450,
                     Width = 80,
                     SpellName = "LuluQPix",
                     MissileName = "LuluQMissileTwo",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Lux,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1300,
                     Speed = 1200,
                     Width = 70,
                     SpellName = "LuxLightBinding",
                     MissileName = "LuxLightBindingMis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Lux,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1300,
                     Width = 275,
                     SpellName = "LuxLightStrikeKugel",
                     MissileName = "LuxLightStrikeKugel",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.MissFortune,
                     Slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 3000,
                     Range = 1450,
                     Speed = int.MaxValue,
                     Width = 60,
                     Angle = 6,
                     SpellName = "MissFortuneBulletTime",
                     MissileName = "MissFortuneBullets",
                     Collisions = new []{ Collision.YasuoWall },
                     //ForceRemove = true,
                     IsFixedRange = true,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.MissFortune,
                     Slot = SpellSlot.R,
                     DangerLevel = 3,
                     CastDelay = 3000,
                     Range = 1450,
                     Speed = int.MaxValue,
                     Width = 70,
                     Angle = 6,
                     SpellName = "MissFortuneBulletTime",
                     MissileName = "MissFortuneBulletEMPTY",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Morgana,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1300,
                     Speed = 1200,
                     Width = 80,
                     SpellName = "DarkBindingMissile",
                     MissileName = "DarkBindingMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Nami,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 1000,
                     Range = 875,
                     Speed = int.MaxValue,
                     Width = 200,
                     SpellName = "NamiQ",
                     MissileName = "NamiQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Nami,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 500,
                     Range = 2750,
                     Speed = 850,
                     Width = 260,
                     SpellName = "NamiR",
                     MissileName = "NamiRMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Nautilus,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1250,
                     Speed = 2000,
                     Width = 90,
                     SpellName = "NautilusAnchorDrag",
                     MissileName = "NautilusAnchorDragMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions, Collision.Walls },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Nidalee,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1500,
                     Speed = 1300,
                     Width = 60,
                     SpellName = "JavelinToss",
                     MissileName = "JavelinToss",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Nocturne,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1125,
                     Speed = 1400,
                     Width = 60,
                     SpellName = "NocturneDuskbringer",
                     MissileName = "NocturneDuskbringer",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Olaf,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1600,
                     Width = 90,
                     SpellName = "OlafAxeThrowCast",
                     MissileName = "OlafAxeThrowCast",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Orianna,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 1000,
                     Speed = 1200,
                     Width = 80,
                     SpellName = "OriannasQ",
                     MissileName = "OrianaIzuna",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Orianna,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 2000,
                     Speed = 1200,
                     Width = 80,
                     SpellName = "OriannaQend",
                     MissileName = "",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Orianna,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0,
                     Range = 1500,
                     Speed = 1850,
                     Width = 85,
                     SpellName = "OriannasE",
                     MissileName = "orianaredact",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Poppy,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 300,
                     Range = 1200,
                     Speed = 1600,
                     Width = 100,
                     SpellName = "PoppyRSpell",
                     MissileName = "PoppyRMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Quinn,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 300,
                     Range = 1050,
                     Speed = 1550,
                     Width = 60,
                     SpellName = "QuinnQ",
                     MissileName = "QuinnQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.RekSai,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 500,
                     Range = 1625,
                     Speed = 1950,
                     Width = 60,
                     SpellName = "reksaiqburrowed",
                     MissileName = "RekSaiQBurrowedMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Rengar,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1500,
                     Width = 70,
                     SpellName = "RengarE",
                     MissileName = "RengarEFinal",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Riven,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 125,
                     Angle = 40,
                     SpellName = "rivenizunablade",
                     MissileName = "RivenLightsaberMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Riven,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 125,
                     Angle = 22,
                     SpellName = "rivenizunablade",
                     MissileName = "RivenWindslashMissileCenter",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Riven,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 125,
                     Angle = 22,
                     SpellName = "rivenizunablade",
                     MissileName = "RivenWindslashMissileLeft",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Riven,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 125,
                     Angle = 22,
                     SpellName = "rivenizunablade",
                     MissileName = "RivenWindslashMissileRight",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Rumble,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 2000,
                     Width = 60,
                     SpellName = "RumbleGrenade",
                     MissileName = "RumbleGrenade",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Ryze,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1700,
                     Width = 55,
                     SpellName = "RyzeQ",
                     MissileName = "RyzeQ",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Sejuani,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1600,
                     Width = 110,
                     SpellName = "SejuaniGlacialPrisonStart",
                     MissileName = "sejuaniglacialprison",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Shyvana,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 1700,
                     Width = 60,
                     SpellName = "ShyvanaFireball",
                     MissileName = "ShyvanaFireballMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Sion,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1800,
                     Width = 80,
                     SpellName = "SionE",
                     MissileName = "SionEMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Sivir,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1250,
                     Speed = 1350,
                     Width = 90,
                     SpellName = "SivirQ",
                     MissileName = "SivirQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Sivir,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1250,
                     Speed = 1350,
                     Width = 90,
                     SpellName = "SivirQReturn",
                     MissileName = "SivirQMissileReturn",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Skarner,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1500,
                     Width = 70,
                     SpellName = "SkarnerFracture",
                     MissileName = "SkarnerFractureMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Sona,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 2400,
                     Width = 140,
                     SpellName = "SonaR",
                     MissileName = "SonaR",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Soraka,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1750,
                     Width = 225,
                     SpellName = "SorakaQ",
                     MissileName = "SorakaQ",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange =false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Syndra,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 950,
                     Speed = 2000,
                     Width = 100,
                     SpellName = "syndrae5",
                     MissileName = "syndrae5",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Syndra,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 0,
                     Range = 950,
                     Speed = 2000,
                     Width = 100,
                     SpellName = "SyndraE",
                     MissileName = "SyndraE",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.TahmKench,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 2800,
                     Width = 90,
                     SpellName = "TahmKenchQ",
                     MissileName = "tahmkenchqmissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Taliyah,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 3600,
                     Width = 100,
                     SpellName = "TaliyahQ",
                     MissileName = "TaliyahQMis",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Taliyah,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 2000,
                     Range = 700,
                     Speed = 3000,
                     Width = 100,
                     Angle = 80,
                     SpellName = "TaliyahE",
                     MissileName = "TaliyahESoundMis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.Cone,
                     Hero = Champion.Talon,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1850,
                     Width = 80,
                     Angle = 20,
                     SpellName = "TalonRake",
                     MissileName = "talonrakemissiletwo",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Talon,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 800,
                     Speed = 1850,
                     Width = 80,
                     SpellName = "TalonRakeReturn",
                     MissileName = "talonrakemissiletwo",
                     Collisions = new []{ Collision.YasuoWall },
                     ForceRemove = true,
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Thresh,
                     Slot = SpellSlot.Q,
                     DangerLevel = 4,
                     CastDelay = 500,
                     Range = 1100,
                     Speed = 1900,
                     Width = 70,
                     SpellName = "ThreshQ",
                     MissileName = "ThreshQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.TwistedFate,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1450,
                     Speed = 1000,
                     Width = 40,
                     SpellName = "WildCards",
                     MissileName = "SealFateMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Twitch,
                     Slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 900,
                     Speed = 1400,
                     Width = 275,
                     SpellName = "TwitchVenomCask",
                     MissileName = "TwitchVenomCaskMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Urgot,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 125,
                     Range = 1000,
                     Speed = 1600,
                     Width = 60,
                     SpellName = "UrgotHeatseekingLineMissile",
                     MissileName = "UrgotHeatseekingLineMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Hero = Champion.Urgot,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1500,
                     Width = 210,
                     SpellName = "UrgotPlasmaGrenade",
                     MissileName = "UrgotPlasmaGrenadeBoom",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Varus,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1800,
                     Speed = 1900,
                     Width = 70,
                     SpellName = "VarusQ",
                     MissileName = "VarusQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false,
                     DetectByMissile = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Varus,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 1000,
                     Range = 925,
                     Speed = 1500,
                     Width = 235,
                     SpellName = "VarusE",
                     MissileName = "VarusEMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Varus,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1950,
                     Width = 120,
                     SpellName = "VarusR",
                     MissileName = "VarusRMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Veigar,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 950,
                     Speed = 2200,
                     Width = 70,
                     SpellName = "VeigarBalefulStrike",
                     MissileName = "VeigarBalefulStrikeMis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Velkoz,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1300,
                     Width = 50,
                     SpellName = "VelkozQ",
                     MissileName = "VelkozQMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Velkoz,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 2100,
                     Width = 55,
                     SpellName = "VelkozQSplit",
                     MissileName = "VelkozQMissileSplit",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Velkoz,
                     Slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1200,
                     Speed = 1700,
                     Width = 88,
                     SpellName = "VelkozW",
                     MissileName = "VelkozWMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Viktor,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1500,
                     Speed = 1050,
                     Width = 80,
                     SpellName = "Laser",
                     MissileName = "ViktorDeathRayMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Viktor,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1500,
                     Speed = 1050,
                     Width = 80,
                     SpellName = "Laser",
                     MissileName = "viktoreaugmissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Xerath,
                     Slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 1400,
                     Width = 60,
                     SpellName = "XerathMageSpear",
                     MissileName = "XerathMageSpearMissile",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Yasuo,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250,
                     Range = 1100,
                     Speed = 1000,
                     Width = 110,
                     SpellName = "yasuoq3w",
                     MissileName = "yasuoq3mis",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Zed,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 925,
                     Speed = 1700,
                     Width = 50,
                     SpellName = "ZedQ",
                     MissileName = "ZedQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Ziggs,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1700,
                     Width = 140,
                     SpellName = "ZiggsQ",
                     MissileName = "ZiggsQSpell",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Ziggs,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1700,
                     Width = 140,
                     SpellName = "ZiggsQBounce1",
                     MissileName = "ZiggsQSpell2",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Ziggs,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 850,
                     Speed = 1700,
                     Width = 140,
                     SpellName = "ZiggsQBounce2",
                     MissileName = "ZiggsQSpell3",
                     Collisions = new []{ Collision.YasuoWall, Collision.Heros, Collision.Minions },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Ziggs,
                     Slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 1000,
                     Speed = 1750,
                     Width = 275,
                     SpellName = "ZiggsW",
                     MissileName = "ZiggsW",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.CircleMissile,
                     Hero = Champion.Zilean,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250,
                     Range = 900,
                     Speed = int.MaxValue,
                     Width = 140,
                     SpellName = "ZileanQ",
                     MissileName = "ZileanQMissile",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = false
                   },
               new SSpell
                   {
                     Type = Type.LineMissile,
                     Hero = Champion.Zyra,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                     Range = 1150,
                     Speed = 1150,
                     Width = 70,
                     SpellName = "ZyraE",
                     MissileName = "ZyraE",
                     Collisions = new []{ Collision.YasuoWall },
                     IsFixedRange = true
                   }
            };

            public struct SSpell
            {
                public Type Type;
                public Champion Hero;
                public SpellSlot Slot;
                public int DangerLevel;
                public float Range;
                public float Angle;
                public float Width;
                public float Speed;
                public float CastDelay;
                public string MissileName;
                public string SpellName;
                public bool ForceRemove;
                public bool IsFixedRange;
                public bool DetectByMissile;
                public Collision[] Collisions;
            }

            public enum Type
            {
                LineMissile,
                CircleMissile,
                Cone
            }

            public enum Collision
            {
                YasuoWall,
                Minions,
                Heros,
                Walls
            }
        }

        internal static class TargetedSpells
        {
            public static readonly List<Spell> TargetedSpellsList = new List<Spell>
             {
              new Spell
                 {
                     Hero = Champion.Akali,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Anivia,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Annie,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Brand,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Caitlyn,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 1000
                 },
              new Spell
                 {
                     Hero = Champion.Cassiopeia,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Elise,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.FiddleSticks,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Gangplank,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Janna,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Jhin,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Kassadin,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Katarina,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Kayle,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Kindred,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Leblanc,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Malphite,
                     Slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Malzahar,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.MissFortune,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Nami,
                     Slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Nautilus,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Nunu,
                     Slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Pantheon,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Ryze,
                     Slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Shaco,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Syndra,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Teemo,
                     Slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Tristana,
                     Slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Tristana,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Vayne,
                     Slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Veigar,
                     Slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new Spell
                 {
                     Hero = Champion.Viktor,
                     Slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 }
             };

            public struct Spell
            {
                public Champion Hero;

                public SpellSlot Slot;

                public int DangerLevel;

                public float CastDelay;
            }
        }
    }
}
