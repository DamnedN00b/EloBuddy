using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIllaoi2.Config.Modes.PermaActive;

namespace LazyIllaoi2.Modes
{
    public sealed class PermActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.IsRecalling();
        }

        public override void Execute()
        {
        }
    }
}