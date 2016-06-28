using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using Settings = LazyLucian.Config.Modes.Flee;

namespace LazyLucian.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var target = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsValidTarget(500));
            var minion = EntityManager.MinionsAndMonsters.CombinedAttackable.FirstOrDefault(x => x.IsValidTarget(500));

            if (SpellManager.E.IsReady() && Settings.UseE)
            {
                SpellManager.E.Cast((Vector3) Program.Player.Position.Extend(Game.CursorPos, SpellManager.E.Range));
            }

            if (SpellManager.W.IsReady() && Settings.UseW && !Program.Player.IsDashing())
            {
                if (target.IsValidTarget())
                {
                    var tPred = Prediction.Position.PredictUnitPosition(target, 250);
                    SpellManager.W.Cast(tPred.To3D());
                }
                else if (target == null && minion.IsValidTarget())
                {
                    SpellManager.W.Cast(minion);
                }
            }

            if (!Program.Player.HasBuff("LucianWBuff"))
            {
                Orbwalker.ForcedTarget = CustomEvents.GetBuffedObjects().Count > 0
                    ? CustomEvents.GetBuffedObjects()[0]
                    : null;
            }
        }
    }
}