using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace LazyIllaoi2
{
    public static class SpellManager
    {
        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 800, SkillShotType.Linear, 750, int.MaxValue, 100);
            {
                Q.AllowedCollisionCount = int.MaxValue;
                Q.MinimumHitChance = HitChance.Medium;
            }

            W = new Spell.Active(SpellSlot.W, 400);

            E = new Spell.Skillshot(SpellSlot.E, 900, SkillShotType.Linear, 250, 1900, 50);
            {
                E.AllowedCollisionCount = 0;
                E.MinimumHitChance = HitChance.High;
            }

            R = new Spell.Active(SpellSlot.R, 450);
        }

        public static Spell.Skillshot Q { get; set; }
        public static Spell.Active W { get; set; }
        public static Spell.Skillshot E { get; set; }
        public static Spell.Active R { get; set; }

        public static void Initialize()
        {
        }
    }
}