using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Spells;

namespace LazyIllaoi2
{
    public static class SpellManager
    {
        static SpellManager()
        {
            var q = SpellDatabase.GetSpellInfoList(Player.Instance).FirstOrDefault(s => s.Slot == SpellSlot.Q);
            var e = SpellDatabase.GetSpellInfoList(Player.Instance).FirstOrDefault(s => s.Slot == SpellSlot.E);
            if (q != null)
                Q = new Spell.Skillshot(SpellSlot.Q, (uint)q.Range, SkillShotType.Linear, (int)q.Delay, (int?)q.MissileSpeed, (int?)(q.Radius * 2));
            {
                Q.AllowedCollisionCount = int.MaxValue;
                Q.MinimumHitChance = HitChance.Medium;
            }

            W = new Spell.Active(SpellSlot.W, 400);

            if (e != null) E = new Spell.Skillshot(SpellSlot.E, (uint)e.Range, SkillShotType.Linear, (int)e.Delay, (int?)e.MissileSpeed, (int?)e.Radius * 2);
            {
                E.AllowedCollisionCount = -1;
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