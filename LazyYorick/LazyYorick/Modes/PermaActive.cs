using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
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
                if (Events.Graves.Count == Settings.useQghoulsValue && Settings.useQghouls)
                {
                    Core.DelayAction(() => Q.Cast(), 200);
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
                var enemyEpred2 in
                    from enemy in
                        EntityManager.Heroes.Enemies.Where(
                            x => x.IsKillable(Player.Instance.GetAutoAttackRange()))
                    let enemyEpred = Prediction.Position.PredictCircularMissile(enemy, E.Range, E.Radius,
                        E.CastDelay, E.Speed, Player.Instance.ServerPosition, true)
                    let enemyEpred2 = enemyEpred.CastPosition.Extend(Player.Instance.ServerPosition, 100)
                    where E.WillKill(enemy) && enemyEpred2.IsValid()
                    select enemyEpred2)
            {
                E.Cast((Vector3) enemyEpred2);
            }
        }
    }
}