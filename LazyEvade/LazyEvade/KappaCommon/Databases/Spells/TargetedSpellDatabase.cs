using System.Collections.Generic;
using EloBuddy;
using LazyEvade.KappaCommon.Databases.SpellData;

namespace LazyEvade.KappaCommon.Databases.Spells
{
    public static class TargetedSpellDatabase
    {
        public static readonly List<TargetedSpellData> List = new List<TargetedSpellData>
             {
              new TargetedSpellData
                 {
                     hero = Champion.Akali,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Alistar,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Anivia,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Annie,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Brand,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250,
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Brand,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Caitlyn,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 1000
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Camille,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 450
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Cassiopeia,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Chogath,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Darius,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Diana,
                     slot = SpellSlot.R,
                     DangerLevel = 2,
                     CastDelay = 250,
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Elise,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Evelynn,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.FiddleSticks,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 100
                 },
              new TargetedSpellData
                 {
                     hero = Champion.FiddleSticks,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Gangplank,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 0
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Garen,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Illaoi,
                     slot = SpellSlot.W,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Irelia,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 0,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Janna,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.JarvanIV,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Jax,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Jayce,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Jayce,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Jhin,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Kassadin,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Katarina,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Katarina,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Kayle,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Khazix,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Leblanc,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Lulu,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Lissandra,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.LeeSin,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Malphite,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Malzahar,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 100
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Malzahar,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Maokai,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.MasterYi,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.MissFortune,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Mordekaiser,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 0,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Nami,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Nautilus,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Nocturne,
                     slot = SpellSlot.E,
                     DangerLevel = 5,
                     CastDelay = 2000
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Nunu,
                     slot = SpellSlot.E,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Olaf,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Pantheon,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Pantheon,
                     slot = SpellSlot.W,
                     DangerLevel = 4,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Poppy,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Quinn,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Rammus,
                     slot = SpellSlot.E,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Ryze,
                     slot = SpellSlot.W,
                     DangerLevel = 3,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Ryze,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Shaco,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Singed,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 0,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Skarner,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 0,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Swain,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 0
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Syndra,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.TahmKench,
                     slot = SpellSlot.W,
                     DangerLevel = 4,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Teemo,
                     slot = SpellSlot.Q,
                     DangerLevel = 3,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Tristana,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Urgot,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Urgot,
                     slot = SpellSlot.R,
                     DangerLevel = 4,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Vi,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Vayne,
                     slot = SpellSlot.E,
                     DangerLevel = 4,
                     CastDelay = 250,
                     FastEvade = true
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Veigar,
                     slot = SpellSlot.R,
                     DangerLevel = 5,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Viktor,
                     slot = SpellSlot.Q,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Vladimir,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Volibear,
                     slot = SpellSlot.W,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Warwick,
                     slot = SpellSlot.Q,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.MonkeyKing,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.XinZhao,
                     slot = SpellSlot.E,
                     DangerLevel = 2,
                     CastDelay = 250
                 },
              new TargetedSpellData
                 {
                     hero = Champion.Yasuo,
                     slot = SpellSlot.E,
                     DangerLevel = 1,
                     CastDelay = 200
                 }
             };
    }
}
