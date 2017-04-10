using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = LazyIvern.Config.Modes.Combo;

namespace LazyIvern.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var enemyQ = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var enemyW = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var enemyE = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            var enemyJq = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.HasBuff("IvernQ") && x.IsKillable());

            if (enemyJq != null && Config.Modes.PermaActive.jumpTarget && !PermActive.Jumped && Config.Modes.PermaActive.jumpOnlyCombo &&
                Config.Modes.PermaActive.jumpEnemiesCount <= enemyQ.CountEnemyChampionsInRange(900) && !enemyQ.IsUnderHisturret())
            {
                Player.IssueOrder(GameObjectOrder.AttackUnit, enemyQ);
                PermActive.Jumped = true;
            }

            if (Q.IsReady() && Settings.useQ && Player.Instance.ManaPercent > Settings.useQmana)
            {
                if (enemyQ != null)
                {
                    if (enemyQ.IsKillable())
                    {
                        Q.Cast(enemyQ, HitChance.High);
                    }
                }
            }

            if (W.IsReady() && Settings.useW && Player.Instance.ManaPercent > Settings.useWmana)
            {
                if (enemyW != null)
                {
                    if (enemyW.IsKillable() &&
                        !Player.HasBuff("ivernwpassive") && Game.Time - Events.LastW > 3 &&
                        SpellManager.W.AmmoQuantity > Settings.keepWstacks &&
                        !Player.Instance.ServerPosition.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Grass))
                    {
                        var pos = Player.Instance.ServerPosition.Extend(enemyW.ServerPosition, 100);

                        W.Cast(Player.Instance.ServerPosition.Distance(enemyW.ServerPosition) <
                               Player.Instance.GetAutoAttackRange(enemyW)
                            ? Player.Instance.ServerPosition
                            : pos.To3D());
                    }
                }
            }

            if (E.IsReady() && Settings.useE && Player.Instance.ManaPercent > Settings.useEmana)
            {
                foreach (
                    var alliedUnit in
                        EntityManager.Heroes.Enemies.Where(x => x.IsKillable(SpellManager.E.Range + 300))
                            .SelectMany(enemy => EntityManager.Allies.Where(x => x.IsKillable(E.Range) && x.IsHPBarRendered && !x.IsMinion && !x.IsMonster && x.IsInRange(enemy, 300))))
                {
                    SpellManager.E.Cast(alliedUnit);
                }
            }
        }
    }
}
