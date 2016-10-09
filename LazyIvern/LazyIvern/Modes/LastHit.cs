using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIvern.Config.Modes.LastHit;

namespace LazyIvern.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
        }
    }
}