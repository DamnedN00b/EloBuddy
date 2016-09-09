using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace LazyYorick
{
    public static class SpellManager
    {
        static SpellManager()
        {
            Q = new Spell.Active(SpellSlot.Q, (uint) Player.Instance.GetAutoAttackRange());
            W = new Spell.Skillshot(SpellSlot.W, 600, SkillShotType.Circular, 250, 1450, 250);
            {
                W.AllowedCollisionCount = int.MaxValue;
            }
            E = new Spell.Skillshot(SpellSlot.E, 700, SkillShotType.Cone, 0, 500, 60);
            {
                E.ConeAngleDegrees = 60;
                E.AllowedCollisionCount = int.MaxValue;
            }
            R = new Spell.Skillshot(SpellSlot.R, 700, SkillShotType.Circular, 250, 2000, 300);
            {
                R.AllowedCollisionCount = int.MaxValue;
            }
        }

        public static Spell.Active Q { get; set; }
        public static Spell.Skillshot W { get; set; }
        public static Spell.Skillshot E { get; set; }
        public static Spell.Skillshot R { get; set; }

        public static void Initialize()
        {
        }
    }
}