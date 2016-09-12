using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyYorick.Config.Modes.LaneClear;

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
                    foreach (var minion in EntityManager.MinionsAndMonsters.EnemyMinions
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

            if (!E.IsReady() || !Settings.useE || !(Settings.useEmana < Player.Instance.ManaPercent)) return;

            switch (Settings.useEmode)
            {
                case 0:
                {
                    var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsKillable(E.Range));
                    var circFarmLoc =
                        EntityManager.MinionsAndMonsters.GetCircularFarmLocation(
                            EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsKillable(E.Range)), E.Width,
                            (int) E.Range);
                    var poly = circFarmLoc.CastPosition.GetPoly();
                    if (minions.Count(m => poly.IsInside(m.Position)) >= 3)
                    {
                        E.Cast(circFarmLoc.CastPosition);
                    }
                    break;
                }
                case 1:
                {
                    if (Events.GhoulsInRange == 0) return;

                    var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsKillable(E.Range));
                    var circFarmLoc =
                        EntityManager.MinionsAndMonsters.GetCircularFarmLocation(
                            EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsKillable(E.Range)), E.Width,
                            (int) E.Range);
                    var poly = circFarmLoc.CastPosition.GetPoly();
                    if (minions.Count(m => poly.IsInside(m.Position)) >= 3)
                    {
                        E.Cast(circFarmLoc.CastPosition);
                    }
                    break;
                }
            }
        }
    }
}