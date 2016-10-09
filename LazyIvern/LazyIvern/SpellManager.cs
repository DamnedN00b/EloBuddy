using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace LazyIvern
{
    public static class SpellManager
    {
        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1100, SkillShotType.Linear, 250, 1300, 65);
            {
                Q.AllowedCollisionCount = 0;
                Q.MinimumHitChance = HitChance.High;
            }

            W = new Spell.SimpleSkillshot(SpellSlot.W, 1200);

            E = new Spell.Targeted(SpellSlot.E, 750); // 285 width

            R = new Spell.Targeted(SpellSlot.R, 750);
        }

        public static Spell.Skillshot Q { get; set; }
        public static Spell.SimpleSkillshot W { get; set; }
        public static Spell.Targeted E { get; set; }
        public static Spell.Targeted R { get; set; }

        public static void Initialize()
        {
        }
    }
}