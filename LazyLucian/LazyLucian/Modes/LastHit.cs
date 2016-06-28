using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Settings = LazyLucian.Config.Modes.LastHit;

namespace LazyLucian.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady() &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking)))
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Program.Player.ServerPosition, SpellManager.Q.Range)
                        .Where(m => m.Health <= Program.Player.GetSpellDamage(m, SpellSlot.Q))
                        .ToList();

                {
                    if (!Program.Player.CanAttack && minions.Any())
                        SpellManager.Q.Cast(minions.FirstOrDefault());
                }
            }

            if (!Settings.UseW || !W.IsReady() ||
                Settings.SpellWeaving &&
                (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() || Orbwalker.IsAutoAttacking))
                return;
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Program.Player.ServerPosition, SpellManager.W.Range)
                        .Where(m => m.Health <= Program.Player.GetSpellDamage(m, SpellSlot.W))
                        .OrderBy(m => m.Distance(Program.Player.ServerPosition))
                        .ToList();

                {
                    if (!Program.Player.CanAttack && minions.Any())
                        SpellManager.W.Cast(minions.FirstOrDefault());
                }
            }
        }
    }
}