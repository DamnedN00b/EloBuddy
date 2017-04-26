using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Settings = LazyXayah.Config.MiscMenu;

namespace LazyXayah.Modes
{
    public sealed class PermActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.HasBuff("recall") && !Player.Instance.IsDead;
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
            }
        }
    }
}
