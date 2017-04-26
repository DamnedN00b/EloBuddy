using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using Settings = LazyXayah.Config.ComboMenu;

// ReSharper disable IdentifierWordIsNotInDictionary
// ReSharper disable InconsistentNaming

namespace LazyXayah
{
    public static class SpellManager
    {
        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1100, SkillShotType.Linear, 300, 700, 60, DamageType.Physical)
            {
                AllowedCollisionCount = int.MaxValue
            };

            W = new Spell.Active(SpellSlot.W, 1100);

            E = new Spell.Active(SpellSlot.E, 1100);

            R = new Spell.Skillshot(SpellSlot.R, 1200, SkillShotType.Cone, 0, int.MaxValue)
            {
                ConeAngleDegrees = 35
            };

            Flash = new Spell.Skillshot(Player.Instance.GetSpellSlotFromName("SummonerFlash"), 425, SkillShotType.Linear);
        }

        public static Spell.Skillshot Q { get; set; }
        public static Spell.Active W { get; set; }
        public static Spell.Active E { get; set; }
        public static Spell.Skillshot R { get; set; }
        public static Spell.Skillshot Flash { get; set; }

        public static void Initialize()
        {
        }

        public static void CastQ()
        {
            var target = TargetSelector.GetTarget(Q.Range - 50, DamageType.Physical, null, true);

            if (Q.IsReady() && target.IsKillable(Q.Range))
            {
                if (Q.GetPrediction(target).HitChance > HitChance.Low)
                {
                    Q.Cast(target);
                }
            }
        }

        public static void CastW()
        {
            var target = TargetSelector.GetTarget(W.Range, DamageType.Physical, null, true);

            if (!Q.IsReady() && W.IsReady() && target.IsKillable(Player.Instance.GetAutoAttackRange(target)))
            {
                W.Cast();
            }
        }

        public static void CastEstun(Obj_AI_Base target)
        {
            if (target != null && E.IsReady())
            {
                if (target.IsStunable())
                {
                    E.Cast();
                }
            }
        }

        public static void CastEkill(Obj_AI_Base target)
        {
            if (target != null && E.IsReady())
            {
                if (Misc.GetFeatherDamage(target) > target.Health && target.IsKillable(-1f, false, true, true))
                {
                    E.Cast();
                }
            }
        }

        public static void CastEmultiStun(int count)
        {
            if (E.IsReady())
            {
                var eTargets = new HashSet<Obj_AI_Base>();

                foreach (var e in EntityManager.Heroes.Enemies.Where(e => e.IsStunable()))
                {
                    eTargets.Add(e);
                }

                if (eTargets.Count >= count)
                {
                    E.Cast();
                }
            }
        }

        private class rHits
        {
            public Vector3 castPos;
            public int hits;
            public Geometry.Polygon poly;
        }

        public static void CastRAOE(int count)
        {
            var targets = EntityManager.Heroes.Enemies.FindAll(e => e.IsKillable(R.Range, true));
            if (targets.Count >= count)
            {
                var results =
                    targets.Select(t => new Geometry.Polygon.Sector(Player.Instance.ServerPosition, R.GetPrediction(t).CastPosition, (float)(R.ConeAngleDegrees * Math.PI / 180), R.Range))
                        .Select(sector => new rHits { castPos = sector.CenterOfPolygon().To3D(), poly = sector, hits = targets.Count(sector.IsInside) })
                        .ToList();

                var bestHits = results.OrderByDescending(e => e.hits).FirstOrDefault(r => r.hits >= 4);
                if (bestHits != null)
                {
                    if (Config.MiscMenu.BlockR)
                    {
                        Orbwalker.DisableMovement = true;
                        R.Cast(bestHits.castPos);
                        Core.DelayAction(() => Orbwalker.DisableMovement = false, 1000);
                    }
                    else
                    {
                        R.Cast(bestHits.castPos);
                    }
                }
            }
        } // credits: Definitely not Kappa

        public static void CastRkillable(AIHeroClient target)
        {
            if (target != null && target.Health < Misc.ComboDamage(target))
            {
                var pred = R.GetPrediction(target);

                if (pred.HitChance > HitChance.Medium)
                {
                    if (Config.MiscMenu.BlockR)
                    {
                        Orbwalker.DisableMovement = true;
                        R.Cast(pred.CastPosition);
                        Core.DelayAction(() => Orbwalker.DisableMovement = false, 1000);
                    }
                    else
                    {
                        R.Cast(pred.CastPosition);
                    }
                }
            }
        }
    }
}
