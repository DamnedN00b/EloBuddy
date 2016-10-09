using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIvern.Config.Modes.Flee;

namespace LazyIvern.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (W.IsReady() && Settings.useW)
            {
                if (!Player.Instance.ServerPosition.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Grass) &&
                    Game.Time - Events.LastW > 3)
                {
                    var pos = Player.Instance.ServerPosition.Extend(Game.CursorPos, 150);
                    W.Cast(pos.To3D());
                }
            }

            if (E.IsReady() && Settings.useE)
            {
                E.Cast(Player.Instance);
            }
        }
    }
}