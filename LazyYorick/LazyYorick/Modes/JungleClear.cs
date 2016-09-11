using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = LazyYorick.Config.Modes.JungleClear;

namespace LazyYorick.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Q.IsReady() && Settings.useQ && Settings.useQmana < Player.Instance.ManaPercent &&
                Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Name != "YorickQ2")
            {
                if (Settings.useQmode == 0)
                {
                    foreach (var minion in EntityManager.MinionsAndMonsters.EnemyMinions
                        .Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion)))
                        .Where(minion => minion.IsValid))
                    {
                        SpellManager.Q.Cast();
                        Player.IssueOrder(GameObjectOrder.AttackUnit, minion);
                    }
                }
                else if (Settings.useQmode == 2)
                {
                    foreach (var minion in EntityManager.MinionsAndMonsters.Monsters
                        .Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion)))
                        .Where(
                            minion =>
                                minion.IsValid && minion.Health < Player.Instance.GetSpellDamage(minion, SpellSlot.Q)))
                    {
                        SpellManager.Q.Cast();
                        Player.IssueOrder(GameObjectOrder.AttackUnit, minion);
                    }
                }
            }

            if (!E.IsReady() || !(Settings.useEmana < Player.Instance.ManaPercent)) return;

            if (Settings.useEmode == 0)
            {
                foreach (
                    var minion in
                        EntityManager.MinionsAndMonsters.Monsters
                            .Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion)))
                            .Where(minion => minion.IsValid))
                {
                    SpellManager.E.Cast(minion);
                }
            }
            else if (Settings.useEmode == 1)
            {
                if (Events.Ghouls.Count == 0) return;

                foreach (
                    var minion in
                        EntityManager.MinionsAndMonsters.Monsters
                            .Where(minion => minion.IsKillable(Player.Instance.GetAutoAttackRange(minion)))
                            .Where(minion => minion.IsValid))
                {
                    SpellManager.E.Cast((Vector3) minion.ServerPosition.Extend(Player.Instance.ServerPosition, 100));
                }
            }
        }
    }
}