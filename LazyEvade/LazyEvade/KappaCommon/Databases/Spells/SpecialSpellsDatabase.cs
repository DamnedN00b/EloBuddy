using System.Collections.Generic;
using EloBuddy;
using LazyEvade.KappaCommon.Databases.SpellData;

namespace LazyEvade.KappaCommon.Databases.Spells
{
    public static class SpecialSpellsDatabase
    {
        public static List<SpecialSpellData> List = new List<SpecialSpellData>
            {
                new SpecialSpellData
                    {
                        Hero = Champion.LeeSin,
                        Slot = SpellSlot.Q,
                        SpellName = "BlindMonkQTwo",
                        DisplayName = "2nd Cast",
                        CastDelay = 100,
                        DangerLevel = 2
                    },
                new SpecialSpellData
                    {
                        Hero = Champion.Tryndamere,
                        Slot = SpellSlot.W,
                        SpellName = "TryndamereW",
                        DisplayName = "Slow / Facing",
                        Range = 850,
                        CastDelay = 250,
                        DangerLevel = 3
                    },
            };
    }
}
