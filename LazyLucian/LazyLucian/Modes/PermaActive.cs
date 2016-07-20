using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using Settings = LazyLucian.Config.Modes.PermaActive;

namespace LazyLucian.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.IsRecalling() && !Player.Instance.IsInShopRange();
        }

        public override void Execute()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(ObjectManager.Player) <
                         SpellManager.Q1.Range + SpellManager.E.Range
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(SpellManager.Q1.Range + SpellManager.E.Range, DamageType.Physical);

            if (target == null || target.IsZombie ||
                target.HasBuffOfType(BuffType.Invulnerability) ||
                !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;

            if (SpellManager.E.IsReady() && Q.IsReady(1000) &&
                target.Health < Program.Player.GetSpellDamage(target, SpellSlot.Q) + Program.Player.GetAutoAttackDamage(target)*2)
            {
                if (Settings.UseE && target.IsValidTarget(500 + SpellManager.E.Range) &&
                    Game.CursorPos.IsSafePosition())
                {
                    SpellManager.E.Cast((Vector3) Program.Player.Position.Extend(Game.CursorPos, SpellManager.E.Range));
                }
            }

            if (SpellManager.Q.IsReady() && target.Health < Program.Player.GetSpellDamage(target, SpellSlot.Q))

            {
                if (Settings.UseQ && target.IsValidTarget(SpellManager.Q.Range))
                {
                    SpellManager.Q.Cast(target);
                }

                if (Settings.UseQ1 && target.IsValidTarget(SpellManager.Q1.Range))
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

            if (SpellManager.W.IsReady() && Settings.UseW && target.IsValidTarget(SpellManager.W.Range) &&
                target.Health < Program.Player.GetSpellDamage(target, SpellSlot.W))
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