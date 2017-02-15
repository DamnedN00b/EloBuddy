using System.Collections.Generic;
using EloBuddy;
using LazyEvade.KappaCommon.Databases.SpellData;

namespace LazyEvade.KappaCommon.Databases.Spells
{
    public static class DangerBuffDataDatabase
    {
        public static List<DangerBuffData> List = new List<DangerBuffData>
            {
                new DangerBuffData
                    {
                        Hero = Champion.Kled,
                        Slot = SpellSlot.Q,
                        BuffName = "KledQMark",
                        DangerLevel = 4
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Karthus,
                        Slot = SpellSlot.R,
                        BuffName = "karthusfallenone",
                        DangerLevel = 5
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Karma,
                        Slot = SpellSlot.W,
                        BuffName = "karmaspiritbind",
                        DangerLevel = 3
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Leblanc,
                        Slot = SpellSlot.E,
                        BuffName = "leblancsoulshackle",
                        DangerLevel = 3
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Leblanc,
                        Slot = SpellSlot.R,
                        BuffName = "leblancsoulshacklem",
                        DangerLevel = 4
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Morgana,
                        Slot = SpellSlot.R,
                        BuffName = "soulshackles",
                        DangerLevel = 5
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Zed,
                        Slot = SpellSlot.R,
                        BuffName = "zedultexecute",
                        DangerLevel = 4
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Zilean,
                        Slot = SpellSlot.Q,
                        BuffName = "ZileanQEnemyBomb",
                        DangerLevel = 2
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Fizz,
                        Slot = SpellSlot.R,
                        BuffName = "fizzmarinerdoombomb",
                        DangerLevel = 5
                    },
                new DangerBuffData
                    {
                        Hero = Champion.Vladimir,
                        Slot = SpellSlot.R,
                        BuffName = "vladimirhemoplaguedebuff",
                        DangerLevel = 5
                    },
                /*TODO
                 * Add/Find more buffs
                 * RE-Check on LB 
                 * add Tristana E
                 * Add kled Q
                 */
            };
    }
}
