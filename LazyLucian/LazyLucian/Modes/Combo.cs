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
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(ObjectManager.Player) <
                         SpellManager.Q1.Range + SpellManager.E.Range
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(SpellManager.Q1.Range + SpellManager.E.Range, DamageType.Physical);

            if (target == null || target.IsZombie ||
                target.HasBuffOfType(BuffType.Invulnerability))
                return;

            if (SpellManager.E.IsReady() && Settings.UseE && Program.Player.ManaPercent >= Settings.UseEmana &&
                target.IsValidTarget(500 + SpellManager.E.Range))

                if (!(Settings.SpellWeaving &&
                      (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                       Orbwalker.IsAutoAttacking || CustomEvents.PassiveUp)) &&
                    !(Program.Player.Distance(target) <= SpellManager.Q.Range && Q.IsReady()))
                {
                    SpellManager.E.Cast((Vector3) Program.Player.Position.Extend(Game.CursorPos, SpellManager.E.Range));
                }

            CastQw();
            
            if (SpellManager.R.IsReady() && Settings.UseR && target.IsValidTarget(SpellManager.R.Range) &&
                (target.HasBuffOfType(BuffType.Snare) || target.HasBuffOfType(BuffType.Stun)) &&
                !Program.Player.HasBuff("LucianR") &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking)))
            {
                SpellManager.R.Cast(target);
            }
        }

        public void CastQw()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(ObjectManager.Player) <
                         SpellManager.Q1.Range + SpellManager.E.Range
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(SpellManager.Q1.Range + SpellManager.E.Range, DamageType.Physical);

            if (target == null || target.IsZombie ||
                target.HasBuffOfType(BuffType.Invulnerability) || !(SpellManager.E.IsOnCooldown))
                return;

            if (SpellManager.Q.IsReady() && !Program.Player.Spellbook.IsCastingSpell &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking || CustomEvents.PassiveUp))
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

            if (SpellManager.W.IsReady() && Settings.UseW && Program.Player.ManaPercent >= Settings.UseWmana &&
                target.IsValidTarget(600) && !Program.Player.Spellbook.IsCastingSpell &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking || CustomEvents.PassiveUp))
                )
            {
                var wPred = SpellManager.W.GetPrediction(target);
                if (wPred.HitChance >= HitChance.Medium)
                    SpellManager.W.Cast(target.ServerPosition);
                if (wPred.HitChance != HitChance.Collision || !wPred.CollisionObjects.Any()) return;
                if (wPred.CollisionObjects.FirstOrDefault().Distance(target) <= 40)
                    SpellManager.W.Cast(target.ServerPosition);
            }
        }
    }
}