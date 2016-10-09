using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIvern.Config.Modes.JungleClear;

namespace LazyIvern.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {

        }
    }
}