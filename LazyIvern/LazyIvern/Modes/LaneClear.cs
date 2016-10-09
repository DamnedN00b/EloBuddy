using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIvern.Config.Modes.LaneClear;

namespace LazyIvern.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (E.IsReady() && Settings.useE && Player.Instance.ManaPercent > Settings.useEmana)
            {
                var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(x => x.IsKillable(125));
                if (minions.Count() > 3)
                {
                    SpellManager.E.Cast(Player.Instance);
                }
            }
        }
    }
}