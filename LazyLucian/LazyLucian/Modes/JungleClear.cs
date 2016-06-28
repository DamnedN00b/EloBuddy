using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Settings = LazyLucian.Config.Modes.JungleClear;

namespace LazyLucian.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var monsters =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Program.Player.ServerPosition, 500, false)
                    .Where(m => m.IsValidTarget() && m.Health > Program.Player.GetAutoAttackDamage(m, true)).ToList();

            if (!monsters.Any()) return;

            if (SpellManager.Q.IsReady() && Settings.UseQ && Program.Player.ManaPercent >= Settings.UseQmana &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking)))
            {
                SpellManager.Q.Cast(monsters.FirstOrDefault());
            }

            if (SpellManager.W.IsReady() && Settings.UseW && Program.Player.ManaPercent >= Settings.UseWmana &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking)))
            {
                SpellManager.W.Cast(monsters.FirstOrDefault());
            }
        }
    }
}