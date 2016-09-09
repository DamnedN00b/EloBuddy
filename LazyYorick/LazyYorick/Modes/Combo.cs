using System;
using System.Linq;
using System.Runtime.InteropServices;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using SharpDX;

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
            var enemyQ = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var enemyW = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var enemyE = TargetSelector.GetTarget(E.Range + 100, DamageType.Physical);
            var enemyR = TargetSelector.GetTarget(W.Range, DamageType.Physical);

            if (SpellManager.W.IsReady())
            {
                if (enemyW != null)
                {
                    var enemyWpred = Prediction.Position.PredictCircularMissile(enemyW, SpellManager.W.Range,
                        SpellManager.W.Radius, SpellManager.W.CastDelay, SpellManager.W.Speed,
                        Player.Instance.ServerPosition, true);

                    if (//Settings.UseWenemy && Program.Player.ManaPercent >= Settings.UseWselfMana &&
                        enemyWpred.CastPosition.IsValid())
                    {
                        W.Cast(enemyWpred.CastPosition);
                    }
                }
            }

            if (SpellManager.E.IsReady())
            {
                if (enemyE != null)
                {
                    var enemyEpred = Prediction.Position.PredictConeSpell(enemyE, E.Range, 60, 250, 1200, (Vector3?) enemyE.ServerPosition.Extend(Player.Instance, 150));

                    if (//Settings.UseEenemy && Program.Player.ManaPercent >= Settings.UseEmana &&
                        (enemyEpred.CastPosition.IsValid() && enemyE.IsKillable(E.Range + 120)))
                    {
                        E.Cast(enemyEpred.CastPosition);
                    }
                }
            }

            if (SpellManager.R.IsReady())
                if (enemyR != null)
            {
                if (//Settings.UseR &&
                    enemyR.IsKillable())
            {
                    SpellManager.R.Cast(enemyR);
                }
            }
        }
    }
}