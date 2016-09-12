using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyYorick.Config.Modes.PermaActive;

namespace LazyYorick.Modes
{
    public sealed class PermActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.IsRecalling();
        }

        public override void Execute()
        {
            if (Q.IsReady())
            {
                if (Events.GravesInRange >= Settings.useQghoulsValue && Settings.useQghouls)
                {
                    Core.DelayAction(() => Q.Cast(), 500);
                }

                if (Settings.useQks)
                {
                    foreach (
                        var enemy in
                            EntityManager.Heroes.Enemies.Where(x => x.IsKillable(Player.Instance.GetAutoAttackRange())))
                    {
                        if (Q.WillKill(enemy))
                            Q.Cast();
                        Player.IssueOrder(GameObjectOrder.AttackUnit, enemy);
                    }
                }
            }

            if (!E.IsReady() || !Settings.useEks) return;

            foreach (
                var enemyPred in
                    from enemy in EntityManager.Heroes.Enemies.Where(x => x.IsKillable(E.Range) && E.WillKill(x))
                    select Prediction.Position.PredictUnitPosition(enemy, E.CastDelay)
                    into enemyPred
                    let ePredPoly =
                        Player.Instance.ServerPosition.Extend(enemyPred, Player.Instance.Distance(enemyPred.To3D()))
                            .To3D()
                            .GetPoly()
                    where ePredPoly.IsInside(enemyPred) &&
                          (ePredPoly.CenterOfPolygon().Distance(Player.Instance) - 180) <= 700
                    select enemyPred)
            {
                E.Cast(enemyPred.To3D());
            }
        }
    }
}