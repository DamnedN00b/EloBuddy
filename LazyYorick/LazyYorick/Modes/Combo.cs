using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Color = System.Drawing.Color;
using Settings = LazyYorick.Config.Modes.Combo;

// ReSharper disable IdentifierWordIsNotInDictionary

namespace LazyYorick.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var enemyQ = TargetSelector.GetTarget(Player.Instance.GetAutoAttackRange(), DamageType.Physical);
            var enemyW = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var enemyE = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var enemyR = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var ghouls = Events.Ghouls.Count;

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

            if (W.IsReady() && Settings.useW)
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

                    if (Settings.useWself && Player.Instance.ManaPercent > Settings.useWselfMana &&
                        Player.Instance.HealthPercent < Settings.useWselfHp &&
                        Player.Instance.CountEnemiesInRange(900) >= Settings.useWselfEnemiesAround)
                    {
                        W.Cast(Player.Instance.ServerPosition);
                    }
                }
            }

            if (E.IsReady() && Settings.useE && Player.Instance.ManaPercent > Settings.useEmana)
            {
                if (enemyE != null)
                {
                    var enemyPred = Prediction.Position.PredictUnitPosition(enemyE, E.CastDelay);
                    var ePredPoly =
                        Player.Instance.ServerPosition.Extend(enemyPred, Player.Instance.Distance(enemyPred.To3D()))
                            .To3D()
                            .GetPoly();

                    if (Settings.useEmode == 0)
                    {
                        if (ePredPoly.IsInside(enemyPred) &&
                            (ePredPoly.CenterOfPolygon().Distance(Player.Instance) - 180) <= 700)
                            E.Cast(enemyPred.To3D());
                    }
                    else if (Settings.useEmode == 1)
                    {
                        if (ghouls == 0) return;
                        if (ePredPoly.IsInside(enemyPred) &&
                            (ePredPoly.CenterOfPolygon().Distance(Player.Instance) - 180) <= 700)
                            E.Cast(enemyPred.To3D());
                    }
                }
            }

            if (!R.IsReady()) return;
            if (enemyR == null) return;
            if (!Settings.useR || !(Player.Instance.ManaPercent > Settings.useRmana)) return;

            if (enemyR.IsKillable(SpellManager.R.Range))
                SpellManager.R.Cast(enemyR);
        }
    }
}