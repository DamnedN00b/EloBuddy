using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace LazyYorick.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            //if (!Settings.UseQcs || !(Program.Player.ManaPercent > Settings.UseQcsMana)) return;

            foreach (var minion in EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, Q.Range).Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion))).Where(minion => Q.IsReady() && minion.IsValid && minion.Health < Player.Instance.GetSpellDamage(minion, SpellSlot.Q)))
            {
                SpellManager.Q.Cast();
            }
        }
    }
}