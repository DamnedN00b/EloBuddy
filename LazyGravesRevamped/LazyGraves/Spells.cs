using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using SharpDX;

namespace LazyGraves
{
    internal class Spells
    {
        public static AIHeroClient Player = ObjectManager.Player;
        public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 950, SkillShotType.Linear, 250, 2000, 60);
        public static Spell.Skillshot W = new Spell.Skillshot(SpellSlot.W, 1000, SkillShotType.Linear, 350, 1650, 150);
        public static Spell.Skillshot E = new Spell.Skillshot(SpellSlot.E, 450, SkillShotType.Linear);
        public static Spell.Skillshot R = new Spell.Skillshot(SpellSlot.R, 1000, SkillShotType.Linear, 250, 2100, 120);

        public static void CastSimpleQ(AIHeroClient target)
        {
            var predPos = Prediction.Position.PredictLinearMissile(target, Q.Range - 100, Q.Width, Q.CastDelay, Q.Speed,
                int.MaxValue, null);

            if (predPos.HitChance >= HitChance.Medium && Game.Time > Events.Etime + 250 &&
                Player.Mana > Helpers.Qmana + Helpers.Rmana)
            {
                Q.Cast(predPos.CastPosition);
            }
        }

        public static void CastCollisionQ(AIHeroClient target)
        {
            for (var i = 50; i < Q.Range - Player.Distance(target.ServerPosition); i += 50)
            {
                var predPosQ = Prediction.Position.PredictLinearMissile(target, Q.Range - 100, Q.Width, Q.CastDelay,
                    Q.Speed, int.MaxValue, null);
                var predPosT = predPosQ.CastPosition
                    .Extend(Player.ServerPosition.To2D(), -i).To3D();

                if (!NavMesh.GetCollisionFlags(predPosT).HasFlag(CollisionFlags.Wall) &&
                    !NavMesh.GetCollisionFlags(predPosT).HasFlag(CollisionFlags.Building) ||
                    Player.Distance(predPosT) > Q.Range)
                    continue;

                Q.Cast((Vector3) Player.ServerPosition.Extend(predPosT, Q.Range));
            }
        }

        public static void CastQkill(AIHeroClient target)
        {
            var predPos = Prediction.Position.PredictLinearMissile(target, Q.Range - 100, Q.Width, Q.CastDelay, Q.Speed,
                int.MaxValue, null);

            if (predPos.HitChance >= HitChance.Medium && Game.Time > Events.Etime + 250 &&
                target.Health + 20 < Player.GetSpellDamage(target, SpellSlot.Q))
            {
                Q.Cast(predPos.CastPosition);
            }
        }

        public static void CastWGrass()
        {
            if (!W.IsReady() ||
                Player.IsDashing())
                return;

            for (int[] i = {50}; i[0] < 400; i[0] += 50)
            {
                foreach (var pred in EntityManager.Heroes.Enemies.Where
                    (x =>
                        x.IsValidTarget(W.Range) &&
                        Helpers.IsInGrass(x)).Select(target =>
                            Prediction.Position.PredictUnitPosition(target, i[0]))
                    .Where(pred => Player.Distance((Vector3) pred) < W.Range))
                {
                    W.Cast((Vector3) pred);
                }
            }
        }

        public static void CastWkill(AIHeroClient target)
        {
            var predPos = Prediction.Position.PredictCircularMissile(target, W.Range, W.Width, W.CastDelay, W.Speed,
                null, true);

            if (predPos.HitChance >= HitChance.Medium && Game.Time > Events.Etime + 250 &&
                target.Health + 20 < Player.GetSpellDamage(target, SpellSlot.W))
            {
                W.Cast(predPos.CastPosition);
            }
        }

        public static void CastWslow(AIHeroClient target)
        {
            var predPos = Prediction.Position.PredictCircularMissile(target, W.Range, W.Width, W.CastDelay, W.Speed,
                null, true);

            if (predPos.HitChance >= HitChance.Medium &&
                target.HealthPercent < 20)
            {
                Q.Cast(predPos.CastPosition);
            }
        }

        public static void CastE()
        {
            foreach (
                var unit in
                    EntityManager.Heroes.Enemies.Where(x => x.IsInAutoAttackRange(Player) && x.IsAttackingPlayer)
                        .Where(
                            unit =>
                                Player.HealthPercent < unit.HealthPercent && Helpers.GetComboDamage(unit) < unit.Health)
                )
            {
                for (var step = 0f; step < 360; step += 30)
                {
                    for (var a = 450; a > 0; a -= 50)
                    {
                        var currentAngle = step*(float) Math.PI/90;
                        var extended = unit.ServerPosition.Extend(Player, a);
                        var direction = extended.Normalized();
                        var currentCheckPoint = Player.ServerPosition.To2D() +
                                            a * direction.Rotated(currentAngle);

                        if (!Helpers.IsSafePosition((Vector3) currentCheckPoint) ||
                            NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Wall) ||
                            NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Building))
                            continue;
                        {
                            E.Cast((Vector3) currentCheckPoint);
                        }
                    }
                }
            }

            foreach (
                var unit in
                    EntityManager.Heroes.Enemies.Where(
                        x =>
                            !Player.IsInAutoAttackRange(Player) &&
                            x.IsValidTarget(E.Range + Player.GetAutoAttackRange()))
                        .Where(
                            unit =>
                                Player.HealthPercent > unit.HealthPercent && Helpers.GetComboDamage(unit) < unit.Health &&
                                Player.Distance(unit) > Player.GetAutoAttackRange()))
            {
                if (!unit.IsValidTarget() || !E.IsReady() || !Q.IsReady() ||
                    Player.IsDashing() || unit.HasBuffOfType(BuffType.Invulnerability)
                    || unit.IsDead || unit.IsZombie)
                    return;

                for (var step = 0f; step < 360; step += 30)
                {
                    for (var a = 450; a > 0; a -= 50)
                    {
                        var currentAngle = step*(float) Math.PI/90;
                        var extended = Player.ServerPosition.Extend(unit, a);
                        var direction = extended.Normalized();
                        var currentCheckPoint = Player.ServerPosition.To2D() +
                                            a * direction.Rotated(currentAngle);

                        if (!Helpers.IsSafePosition((Vector3) currentCheckPoint) ||
                            NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Wall) ||
                            NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Building))
                            continue;
                        {
                            E.Cast((Vector3) currentCheckPoint);
                        }
                    }
                }
            }
        }

        /*
        public static void CastEq()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(Player) < 2000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(R.Range, DamageType.Physical);

            if (!target.IsValidTarget() || !E.IsReady() || !Q.IsReady() ||
                Player.IsDashing() || target.HasBuffOfType(BuffType.Invulnerability)
                || target.IsDead || target.IsZombie)
                return;

            if (!(target.HealthPercent < Player.GetSpellDamage(target, SpellSlot.Q)) ||
                !(Helpers.DashtoQpos(target).IsValid() && Helpers.DashtoQpos(target).Distance(Player) <= E.Range) ||
                !Helpers.IsSafePosition(Helpers.DashtoQpos(target))) return;

            E.Cast(Helpers.DashtoQpos(target));
        }
        */

        public static void CastRkill(AIHeroClient target)
        {
            var predPos = Prediction.Position.PredictLinearMissile(target, R.Range, R.Width, R.CastDelay, R.Speed,
                int.MaxValue,
                null, true);
            var predPosCone = Prediction.Position.PredictConeSpell(target, 500, 90, R.CastDelay, R.Speed,
                predPos.CastPosition,
                true);

            if (Helpers.Rdmg(target) > target.Health + 20 &&
                (predPosCone.HitChance > HitChance.Medium || predPos.HitChance > HitChance.Medium))
            {
                R.Cast(predPos.CastPosition);
            }
        }

        public static void CastQrCombo(AIHeroClient target)
        {
            var predPosQ = Prediction.Position.PredictLinearMissile(target, Q.Range - 100, Q.Width, Q.CastDelay, Q.Speed,
                int.MaxValue, null);
            var predPosR = Prediction.Position.PredictLinearMissile(target, R.Range, R.Width, R.CastDelay, R.Speed,
                int.MaxValue,
                null, true);
            var predPosCone = Prediction.Position.PredictConeSpell(target, 500, 150, R.CastDelay, R.Speed,
                predPosR.CastPosition,
                true);

            if ((((Helpers.GetComboDamage(target)) > target.Health + 20) &&
                 predPosQ.HitChance >= HitChance.Medium &&
                 (predPosR.HitChance >= HitChance.Medium || predPosCone.HitChance >= HitChance.Medium) &&
                 Player.Mana > Helpers.Rmana + Helpers.Qmana))
                return;

            {
                Q.Cast(predPosQ.CastPosition);
                Core.DelayAction(() => R.Cast(predPosR.CastPosition), 250);
            }
        }
    }
}