using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = LazyXayah.Config.LaneClearMenu;

namespace LazyXayah.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                if (Settings.UseQ && SpellManager.Q.IsReady())
                {
                    SpellManager.Q.CastOnBestFarmPosition();
                }
            }
        }
    }
}
