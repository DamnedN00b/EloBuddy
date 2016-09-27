using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIllaoi2.Config.Modes.Flee;

namespace LazyIllaoi2.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
        }
    }
}