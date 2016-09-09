using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace LazyYorick.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            //if (!Settings.UseQcs || !(Program.Player.ManaPercent > Settings.UseQcsMana)) return;

            foreach (var minion in EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, Q.Range)
                .Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion)))
                .Where(
                    minion =>
                        Q.IsReady() && Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Name != "YorickQ2" &&
                        minion.IsValid && minion.Health < Player.Instance.GetSpellDamage(minion, SpellSlot.Q)))
            {
                SpellManager.Q.Cast();
            }
        }
    }
}