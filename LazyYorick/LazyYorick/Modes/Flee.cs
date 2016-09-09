using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;

namespace LazyYorick.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (W.IsReady() &&
                (//Settings.UseWflee && Program.Player.ManaPercent >= Settings.UseWfleeMana &&
                    //Player.Instance.HealthPercent <= Settings.UseWselfHP && 
                    Player.Instance.CountEnemiesInRange(SpellManager.W.Width) > 1))
            {
                W.Cast(Player.Instance.ServerPosition);
            }
        }
    }
}