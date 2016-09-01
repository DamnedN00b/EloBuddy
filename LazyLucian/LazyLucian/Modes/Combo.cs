using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using SharpDX;
using Settings = LazyLucian.Config.Modes.Combo;

namespace LazyLucian.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            foreach (
                var enemy in
                    EntityManager.Heroes.Enemies.Where(
                        x =>
                            x.IsKillable(SpellManager.R.Range)).OrderBy(x => x.Distance(Program.Player)))
            {
                if (!(Settings.SpellWeaving &&
                      (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                       Orbwalker.IsAutoAttacking || CustomEvents.PassiveUp)) &&
                {
                    SpellManager.E.Cast((Vector3) Program.Player.Position.Extend(Game.CursorPos, SpellManager.E.Range));
                }

                {

                    {
                        {


                        }
                    }
                }

            }
        }
    }
}