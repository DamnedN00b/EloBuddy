using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIvern.Config.Modes.PermaActive;

namespace LazyIvern.Modes
{
    public sealed class PermActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.IsRecalling();
        }

        public override void Execute()
        {
            var enemyR = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var enemyQ = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.HasBuff("IvernQ") && x.IsKillable());

            if (enemyQ != null && Settings.jumpTarget && 
                Settings.jumpEnemiesCount <= enemyQ.CountEnemiesInRange(900) && !enemyQ.IsUnderHisturret())
                Player.IssueOrder(GameObjectOrder.AttackUnit, enemyQ);

            if (!R.IsReady() || Events.Daisy == null || !Settings.movePet) return;

            if (Settings.petTarget == 0)
            {
                if (enemyR == null) return;
                if (enemyR.IsKillable() && enemyR.Distance(Events.Daisy.ServerPosition) > Events.Daisy.AttackRange)
                    R.Cast(enemyR);
            }

            else if (Settings.petTarget == 1)
            {
                foreach (
                    var closestTarget in
                        EntityManager.Heroes.Enemies.OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .Where(closestTarget => closestTarget.IsKillable() &&
                                                    closestTarget.Distance(Events.Daisy.ServerPosition) >
                                                    Events.Daisy.AttackRange))
                {
                    R.Cast(closestTarget);
                }
            }
        }
    }
}