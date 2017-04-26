using System.Linq;
using EloBuddy.SDK;

namespace LazyXayah.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                
            }
        }
    }
}
