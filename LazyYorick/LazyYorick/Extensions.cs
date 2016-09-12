using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

// ReSharper disable WordCanBeSurroundedWithMetaTags

// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyYorick
{
    public static class Extensions
    {
        /// <summary>
        ///     Returns <see langword="true" /> if you can deal damage to the
        ///     target.
        /// </summary>
        public static bool IsKillable(this AIHeroClient target)
        {
            return !target.HasBuff("kindredrnodeathbuff") && !target.HasUndyingBuff(true) &&
                   !target.Buffs.Any(b => b.Name.ToLower().Contains("fioraw")) &&
                   !target.HasBuff("JudicatorIntervention") && !target.IsZombie
                   && !target.HasBuff("ChronoShift") && !target.HasBuff("UndyingRage") && !target.IsInvulnerable &&
                   !target.IsZombie && !target.HasBuff("bansheesveil") && !target.IsDead
                   && !target.IsPhysicalImmune && target.Health > 0 && !target.HasBuffOfType(BuffType.Invulnerability) &&
                   !target.HasBuffOfType(BuffType.PhysicalImmunity) && target.IsValidTarget();
        }

        /// <summary>
        ///     Returns <see langword="true" /> if you can deal damage to the
        ///     target.
        /// </summary>
        public static bool IsKillable(this Obj_AI_Base target, float range)
        {
            return !target.HasBuff("kindredrnodeathbuff") && !target.Buffs.Any(b => b.Name.ToLower().Contains("fioraw")) &&
                   !target.HasBuff("JudicatorIntervention") && !target.IsZombie
                   && !target.HasBuff("ChronoShift") && !target.HasBuff("UndyingRage") && !target.IsInvulnerable &&
                   !target.IsZombie && !target.HasBuff("bansheesveil") && !target.IsDead
                   && !target.IsPhysicalImmune && target.Health > 0 && !target.HasBuffOfType(BuffType.Invulnerability) &&
                   !target.HasBuffOfType(BuffType.PhysicalImmunity) && target.IsValidTarget(range);
        }

        /// <summary>
        ///     Returns <see langword="true" /> if you can deal damage to the
        ///     target.
        /// </summary>
        public static bool IsKillable(this Obj_AI_Base target)
        {
            return !target.HasBuff("kindredrnodeathbuff") && !target.Buffs.Any(b => b.Name.ToLower().Contains("fioraw")) &&
                   !target.HasBuff("JudicatorIntervention") && !target.IsZombie
                   && !target.HasBuff("ChronoShift") && !target.HasBuff("UndyingRage") && !target.IsInvulnerable &&
                   !target.IsZombie && !target.HasBuff("bansheesveil") && !target.IsDead
                   && !target.IsPhysicalImmune && target.Health > 0 && !target.HasBuffOfType(BuffType.Invulnerability) &&
                   !target.HasBuffOfType(BuffType.PhysicalImmunity) && target.IsValidTarget();
        }

        /// <summary>
        ///     Casts <paramref name="spell" /> with selected hitchance.
        /// </summary>
        public static void Cast(this Spell.Skillshot spell, Obj_AI_Base target, HitChance hitChance)
        {
            if (target == null || !spell.IsReady() || !target.IsKillable(spell.Range)) return;

            var pred = spell.GetPrediction(target);
            if (pred.HitChance >= hitChance || target.IsCc())
            {
                spell.Cast(pred.CastPosition);
            }
        }

        /// <summary>
        ///     Casts <paramref name="spell" /> with selected hitchance.
        /// </summary>
        public static void Cast(this Spell.SpellBase spell, Obj_AI_Base target, HitChance hitChance)
        {
            if (target == null || !spell.IsReady() || !target.IsKillable(spell.Range)) return;

            var pred = spell.GetPrediction(target);
            if (pred.HitChance >= hitChance || target.IsCc())
            {
                spell.Cast(pred.CastPosition);
            }
        }

        public static PredictionResult GetPrediction(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            var skillshot = spell as Spell.Skillshot;
            return skillshot?.GetPrediction(target);
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <see cref="Obj_AI_Base" /> is
        ///     UnderEnemyTurret.
        /// </summary>
        public static bool UnderEnemyTurret(this Obj_AI_Base target)
        {
            return
                EntityManager.Turrets.AllTurrets.Any(
                    t =>
                        !t.IsDead && t.Team != target.Team && t.IsValidTarget() &&
                        t.IsInRange(target, t.GetAutoAttackRange(target) + (target.BoundingRadius*2)));
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <see cref="Vector3" /> is
        ///     UnderEnemyTurret.
        /// </summary>
        public static bool UnderEnemyTurret(this Vector3 pos)
        {
            return
                EntityManager.Turrets.Enemies.Any(
                    t =>
                        !t.IsDead && t.IsValidTarget() &&
                        t.IsInRange(pos, t.GetAutoAttackRange(Player.Instance) + (Player.Instance.BoundingRadius*2)));
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <see cref="Vector2" /> is
        ///     UnderEnemyTurret.
        /// </summary>
        public static bool UnderEnemyTurret(this Vector2 pos)
        {
            return
                EntityManager.Turrets.Enemies.Any(
                    t => !t.IsDead && t.IsValidTarget() && t.IsInRange(pos, 1400 + (Player.Instance.BoundingRadius*2)));
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <see cref="Obj_AI_Base" /> is
        ///     UnderAlliedTurret.
        /// </summary>
        public static bool UnderAlliedTurret(this Obj_AI_Base target)
        {
            return
                EntityManager.Turrets.AllTurrets.Any(
                    t =>
                        !t.IsDead && t.Team == target.Team && t.IsValidTarget() &&
                        t.IsInRange(target, t.GetAutoAttackRange(target) + (target.BoundingRadius*2)));
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <see cref="Vector3" /> is
        ///     UnderAlliedTurret.
        /// </summary>
        public static bool UnderAlliedTurret(this Vector3 pos)
        {
            return
                EntityManager.Turrets.Allies.Any(
                    t => !t.IsDead && t.IsInRange(pos, 1400 + (Player.Instance.BoundingRadius*2)));
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <see cref="Vector2" /> is
        ///     UnderAlliedTurret.
        /// </summary>
        public static bool UnderAlliedTurret(this Vector2 pos)
        {
            return
                EntityManager.Turrets.Allies.Any(
                    t => !t.IsDead && t.IsInRange(pos, 1400 + (Player.Instance.BoundingRadius*2)));
        }

        /// <summary>
        ///     Returns <see langword="true" /> if the <paramref name="spell" />
        ///     will kill the target.
        /// </summary>
        public static bool WillKill(this Spell.SpellBase spell, Obj_AI_Base target, float multiplyDmgBy = 1,
            float extraDamage = 0, DamageType extraDamageType = DamageType.True)
        {
            return Player.Instance.GetSpellDamage(target, spell.Slot)*multiplyDmgBy +
                   Player.Instance.CalculateDamageOnUnit(target, extraDamageType, extraDamage) >=
                   Prediction.Health.GetPrediction(target, spell.CastDelay + Game.Ping);
        }

        /// <summary>
        ///     Returns <see langword="true" /> if <paramref name="target" /> Is
        ///     CC'D.
        /// </summary>
        public static bool IsCc(this Obj_AI_Base target)
        {
            return !target.CanMove || target.HasBuffOfType(BuffType.Charm) || target.HasBuffOfType(BuffType.Knockback) ||
                   target.HasBuffOfType(BuffType.Knockup) || target.HasBuffOfType(BuffType.Fear)
                   || target.HasBuffOfType(BuffType.Snare) || target.HasBuffOfType(BuffType.Stun) ||
                   target.HasBuffOfType(BuffType.Suppression) || target.HasBuffOfType(BuffType.Taunt)
                   || target.HasBuffOfType(BuffType.Sleep);
        }

        public static Geometry.Polygon GetPoly(this Vector3 castPos)
        {
            const int eRadius = 100;
            var startPos = Player.Instance.ServerPosition.Extend(castPos, Player.Instance.Distance(castPos) - 100);
            var endPos = Player.Instance.ServerPosition.Extend(castPos, Player.Instance.Distance(castPos) + 400);
            var direction = (endPos - startPos).Normalized();

            var pos1 = (startPos - direction.Perpendicular() * (eRadius -20)).To3D();

            var pos3 = (startPos + direction.Perpendicular() * (eRadius -20)).To3D();

            var pos2 = (endPos + (endPos - startPos).Normalized() + direction.Perpendicular() * (eRadius + 50)).To3D();

            var pos4 = (endPos + (endPos - startPos).Normalized() - direction.Perpendicular() * (eRadius + 50)).To3D();

            var poly = new Geometry.Polygon();
            poly.Add(pos1);
            poly.Add(pos3);
            poly.Add(pos2);
            poly.Add(pos4);
            return poly;
        }
    }
}