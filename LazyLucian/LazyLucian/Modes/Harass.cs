using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using Settings = LazyLucian.Config.Modes.Harass;

namespace LazyLucian.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(Program.Player) <
                         SpellManager.Q1.Range + SpellManager.E.Range
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(SpellManager.Q1.Range + SpellManager.E.Range, DamageType.Physical);

            if (target == null || target.IsZombie ||
                target.HasBuffOfType(BuffType.Invulnerability))
                return;

            if (SpellManager.Q.IsReady() &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking))
                )
            {
                if (Settings.UseQ && Program.Player.ManaPercent >= Settings.UseQmana &&
                    target.IsValidTarget(SpellManager.Q.Range))
                {
                    SpellManager.Q.Cast(target);
                }

                if (Settings.UseQ1 && Program.Player.ManaPercent >= Settings.UseQ1mana &&
                    target.IsValidTarget(SpellManager.Q1.Range))
                {
                    var predPos = SpellManager.Q1.GetPrediction(target);
                    var minions =
                        EntityManager.MinionsAndMonsters.EnemyMinions.Where(mi => mi.Distance(Program.Player) <= Q.Range);
                    var champs = EntityManager.Heroes.Enemies.Where(ch => ch.Distance(Program.Player) <= Q.Range);
                    var monsters =
                        EntityManager.MinionsAndMonsters.Monsters.Where(mo => mo.Distance(Program.Player) <= Q.Range);
                    {
                        foreach (var minion in from minion in minions
                            let polygon = new Geometry.Polygon.Rectangle(
                                (Vector2) Program.Player.ServerPosition,
                                Program.Player.ServerPosition.Extend(minion.ServerPosition, SpellManager.Q1.Range), 65f)
                            where polygon.IsInside(predPos.CastPosition)
                            select minion)
                        {
                            Q.Cast(minion);
                        }

                        foreach (var champ in from champ in champs
                            let polygon = new Geometry.Polygon.Rectangle(
                                (Vector2) Program.Player.ServerPosition,
                                Program.Player.ServerPosition.Extend(champ.ServerPosition, SpellManager.Q1.Range), 65f)
                            where polygon.IsInside(predPos.CastPosition)
                            select champ)
                        {
                            Q.Cast(champ);
                        }

                        foreach (var monster in from monster in monsters
                            let polygon = new Geometry.Polygon.Rectangle(
                                (Vector2) Program.Player.ServerPosition,
                                Program.Player.ServerPosition.Extend(monster.ServerPosition, SpellManager.Q1.Range), 65f)
                            where polygon.IsInside(predPos.CastPosition)
                            select monster)
                        {
                            Q.Cast(monster);
                        }
                    }
                }
            }

            if (Settings.UseW && Program.Player.ManaPercent >= Settings.UseWmana && W.IsReady() &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking)) && target.IsValidTarget(SpellManager.W.Range))
            {
                SpellManager.W.Cast(target);
            }
        }
    }
}