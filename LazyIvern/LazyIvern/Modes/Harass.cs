using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = LazyIvern.Config.Modes.Harass;

namespace LazyIvern.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            
        }

    }
}