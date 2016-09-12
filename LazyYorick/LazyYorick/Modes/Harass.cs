using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyYorick.Config.Modes.Harass;

namespace LazyYorick.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            var enemyQ = TargetSelector.GetTarget(Player.Instance.GetAutoAttackRange(), DamageType.Physical);
            var enemyW = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var enemyE = TargetSelector.GetTarget(E.Range + 100, DamageType.Physical);

            if (Q.IsReady() && Settings.useQ && Player.Instance.ManaPercent > Settings.useQmana &&
                Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Name != "YorickQ2")
            {
                if (enemyQ != null)
                {
                    if (Settings.useQmode == 0)
                    {
                        if (enemyQ.IsKillable(Player.Instance.GetAutoAttackRange()))
                            Q.Cast();
                    }
                }
            }

            if (SpellManager.W.IsReady() && Settings.useW)
            {
                if (enemyW != null)
                {
                    var enemyWpred = Prediction.Position.PredictCircularMissile(enemyW, SpellManager.W.Range,
                        SpellManager.W.Radius, SpellManager.W.CastDelay, SpellManager.W.Speed,
                        Player.Instance.ServerPosition, true);

                    if (Settings.useWenemy && Player.Instance.ManaPercent > Settings.useWenemyMana)
                    {
                        if (enemyWpred.CastPosition.IsValid())
                            W.Cast(enemyWpred.CastPosition);
                    }

                    if (Settings.useWself && Player.Instance.ManaPercent >= Settings.useWselfMana &&
                        Player.Instance.HealthPercent >= Settings.useWselfHp &&
                        Player.Instance.CountEnemiesInRange(900) >= Settings.useWselfEnemiesAround)
                    {
                        W.Cast(Player.Instance.ServerPosition);
                    }
                }
            }

            if (!SpellManager.E.IsReady() || !Settings.useE || !(Player.Instance.ManaPercent > Settings.useEmana))
                return;
            if (enemyE == null) return;

            var enemyEpred = Prediction.Position.PredictCircularMissile(enemyE, E.Range, E.Radius, E.CastDelay,
                E.Speed);

            switch (Settings.useEmode)
            {
                case 0:
                    E.Cast(enemyEpred.CastPosition);
                    break;
                case 1:
                    if (Events.GhoulsInRange == 0) return;
                    E.Cast(enemyEpred.CastPosition);
                    break;
            }
        }
    }
}