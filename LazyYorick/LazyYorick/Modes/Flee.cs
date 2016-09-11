using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyYorick.Config.Modes.Flee;

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
            if (!W.IsReady()) return;

            if (Settings.useW &&
                Player.Instance.CountEnemiesInRange(900) >= 1)
            {
                W.Cast(Player.Instance.ServerPosition);
            }
        }
    }
}