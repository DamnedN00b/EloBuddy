using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyYorick.Config.Modes.LastHit;

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
            if (!Q.IsReady() || !Settings.useQ || !(Settings.useQmana < Player.Instance.ManaPercent)) return;

            foreach (var minion in EntityManager.MinionsAndMonsters.EnemyMinions
                .Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion)))
                .Where(
                    minion => minion.IsValid && minion.Health < Player.Instance.GetSpellDamage(minion, SpellSlot.Q)))
            {
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Name != "YorickQ2")
                    SpellManager.Q.Cast();
                Player.IssueOrder(GameObjectOrder.AttackUnit, minion);
            }
        }
    }
}