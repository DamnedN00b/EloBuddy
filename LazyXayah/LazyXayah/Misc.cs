using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

// ReSharper disable StringLiteralsWordIsNotInDictionary
// ReSharper disable IdentifierWordIsNotInDictionary

namespace LazyXayah
{
    internal static class Misc
    {
        #region Damages


        public static float GetFeatherDamage(Obj_AI_Base target)
        {
            if (target != null)
            {
                return Events.FeatherPolys.Any() ? Events.FeatherPolys.Where(p => p.IsInside(target.ServerPosition)).Sum(p => EDmg(target)) : 0;
            }
            return 0;
        }

        public static float ComboDamage(Obj_AI_Base target)
        {
            var damage = 0f;

            // AA

            damage += Player.Instance.GetAutoAttackDamage(target, true);

            // Q
            if (SpellManager.Q.IsReady())
            {
                damage += QDmg(target);
            }

            // E
            if (SpellManager.E.IsReady())
            {
                damage += GetFeatherDamage(target);
            }

            // R
            if (SpellManager.R.IsReady())
            {
                damage += RDmg(target);
            }

            return damage;
        }

        public static float QDmg(Obj_AI_Base target)
        {
            return Player.Instance.CalculateDamageOnUnit(target, DamageType.Physical,
                (new float[] { 0 , 80 , 120 , 160 , 200 , 240 }[SpellManager.Q.Level] + Player.Instance.TotalAttackDamage));
        }

        public static float EDmg(Obj_AI_Base target)
        {
            return Player.Instance.CalculateDamageOnUnit(target, DamageType.Physical,
             (new float[] { 0, 50 , 60 , 70 , 80 , 90 }[SpellManager.E.Level] + (Player.Instance.TotalAttackDamage * 0.6f) * (Player.Instance.FlatCritChanceMod * 0.5f)));
        }

        public static float RDmg(Obj_AI_Base target)
        {
            return Player.Instance.CalculateDamageOnUnit(target, DamageType.Physical,
                (new float[] { 0, 100 , 150 , 200 }[SpellManager.R.Level] + Player.Instance.FlatPhysicalDamageMod));
        }

        #endregion
    }
}
