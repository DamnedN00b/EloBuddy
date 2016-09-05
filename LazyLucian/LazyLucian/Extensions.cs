using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace LazyLucian
{
    public static class Extensions
    {
        public static bool IsSafePosition(this Vector3 position)
        {
            var enemyTurrets =
                EntityManager.Turrets.Enemies.Count(turret => !turret.IsDead && turret.Distance(position) <= 950);
            var alliedTurrets =
                EntityManager.Turrets.Allies.Count(turret => !turret.IsDead && turret.Distance(position) <= 950);
            var allies = position.CountAlliesInRange(800);
            var lowAllies =
                EntityManager.Heroes.Enemies.Count(ally => ally.Distance(position) <= 800 && ally.HealthPercent < 30);
            var enemies = position.CountEnemiesInRange(1000);
            var lowEnemies =
                EntityManager.Heroes.Enemies.Count(enemy => enemy.Distance(position) <= 1000 && enemy.HealthPercent < 30);

            return allies + alliedTurrets - lowAllies + 1 > enemies - lowEnemies + enemyTurrets;
        }

        public static bool IsKillable(this Obj_AI_Base target, float range)
        {
            return !target.HasBuff("kindredrnodeathbuff") && !target.Buffs.Any(b => b.Name.ToLower().Contains("fioraw")) && !target.HasBuff("JudicatorIntervention")
                   && !target.HasBuff("ChronoShift") && !target.HasBuff("UndyingRage") && !target.IsInvulnerable && !target.IsZombie && !target.HasBuff("bansheesveil") && !target.IsDead
                   && !target.IsPhysicalImmune && target.Health > 0 && !target.HasBuffOfType(BuffType.Invulnerability) && !target.HasBuffOfType(BuffType.PhysicalImmunity) && target.IsValidTarget(range);
        }
    }
}