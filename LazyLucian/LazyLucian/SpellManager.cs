using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace LazyLucian
{
    public static class SpellManager
    {
        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Targeted(SpellSlot.Q, 500);
            Q1 = new Spell.Skillshot(SpellSlot.Q, 950, SkillShotType.Linear, 250, int.MaxValue, 65);
            W = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Linear, 250, 1600, 80);
            E = new Spell.Skillshot(SpellSlot.E, 445, SkillShotType.Linear);
            R = new Spell.Skillshot(SpellSlot.R, 1400, SkillShotType.Linear, 250, 1200, 70);

            W.MinimumHitChance = HitChance.Medium;
            R.MinimumHitChance = HitChance.High;
        }

        public static Spell.Targeted Q { get; private set; }
        public static Spell.Skillshot Q1 { get; private set; }
        public static Spell.Skillshot W { get; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}