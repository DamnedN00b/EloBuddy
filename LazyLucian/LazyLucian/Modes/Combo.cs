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
                    !(enemy.IsKillable(Q.Range) && Q.IsReady()) && E.IsReady() && Settings.UseE)
                {
                    SpellManager.E.Cast((Vector3) Program.Player.Position.Extend(Game.CursorPos, SpellManager.E.Range));
                }

                if (SpellManager.Q.IsReady() && !Program.Player.Spellbook.IsCastingSpell &&
                    !(Settings.SpellWeaving &&
                      (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                       Orbwalker.IsAutoAttacking || CustomEvents.PassiveUp))
                    )
                {
                    if (Settings.UseQ && Program.Player.ManaPercent >= Settings.UseQmana &&
                        enemy.IsValidTarget(SpellManager.Q.Range))
                    {
                        SpellManager.Q.Cast(enemy);
                    }

                    if (Settings.UseQ1 && Program.Player.ManaPercent >= Settings.UseQ1mana &&
                        enemy.IsValidTarget(SpellManager.Q1.Range))
                    {
                        var predPos = SpellManager.Q1.GetPrediction(enemy);
                        var minions =
                            EntityManager.MinionsAndMonsters.EnemyMinions.Where(
                                mi => mi.Distance(Program.Player) <= Q.Range);
                        var champs = EntityManager.Heroes.Enemies.Where(ch => ch.Distance(Program.Player) <= Q.Range);
                        var monsters =
                            EntityManager.MinionsAndMonsters.Monsters.Where(mo => mo.Distance(Program.Player) <= Q.Range);
                        {
                            foreach (var minion in from minion in minions.OrderByDescending(x => x.Health)
                                let polygon = new Geometry.Polygon.Rectangle(
                                    (Vector2) Program.Player.ServerPosition,
                                    Program.Player.ServerPosition.Extend(minion.ServerPosition, SpellManager.Q1.Range),
                                    65f)
                                where polygon.IsInside(predPos.CastPosition)
                                select minion)
                            {
                                Q.Cast(minion);
                            }

                            foreach (var champ in from champ in champs
                                let polygon = new Geometry.Polygon.Rectangle(
                                    (Vector2) Program.Player.ServerPosition,
                                    Program.Player.ServerPosition.Extend(champ.ServerPosition, SpellManager.Q1.Range),
                                    65f)
                                where polygon.IsInside(predPos.CastPosition)
                                select champ)
                            {
                                Q.Cast(champ);
                            }

                            foreach (var monster in from monster in monsters
                                let polygon = new Geometry.Polygon.Rectangle(
                                    (Vector2) Program.Player.ServerPosition,
                                    Program.Player.ServerPosition.Extend(monster.ServerPosition, SpellManager.Q1.Range),
                                    65f)
                                where polygon.IsInside(predPos.CastPosition)
                                select monster)
                            {
                                Q.Cast(monster);
                            }
                        }
                    }
                }


                if (SpellManager.W.IsReady() && Settings.UseW && Program.Player.ManaPercent >= Settings.UseWmana &&
                    enemy.IsKillable(W.Range) && !Program.Player.Spellbook.IsCastingSpell &&
                    !(Settings.SpellWeaving &&
                      (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                       Orbwalker.IsAutoAttacking || CustomEvents.PassiveUp))
                    )
                {
                    var wPred = SpellManager.W.GetPrediction(enemy);
                    if (wPred.HitChance >= HitChance.Medium)
                        SpellManager.W.Cast(enemy.ServerPosition);
                    if (wPred.HitChance != HitChance.Collision || !wPred.CollisionObjects.Any()) return;
                    if (wPred.CollisionObjects.FirstOrDefault().Distance(enemy) <= 40)
                        SpellManager.W.Cast(enemy.ServerPosition);
                }


                if (SpellManager.R.IsReady() && Settings.UseR && enemy.IsKillable(R.Range) &&
                    (enemy.HasBuffOfType(BuffType.Snare) || enemy.HasBuffOfType(BuffType.Stun)) &&
                    !Program.Player.HasBuff("LucianR") &&
                    !(Settings.SpellWeaving &&
                      Program.Player.IsDashing()))
                {
                    SpellManager.R.Cast(enemy);
                }
            }
        }
    }
}