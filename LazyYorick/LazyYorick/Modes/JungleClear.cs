using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace LazyYorick.Modes
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