using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyXayah.Config.JungleClearMenu;

namespace LazyXayah.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                
            }
        }
    }
}
