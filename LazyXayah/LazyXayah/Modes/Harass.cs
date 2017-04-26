using EloBuddy.SDK;
using Settings = LazyXayah.Config.HarassMenu;

namespace LazyXayah.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {

            }
        }
    }
}
