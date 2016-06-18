using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace LazyGraves
{
    internal class HarassHandler
    {
        public static AIHeroClient Player = ObjectManager.Player;

        public static void Harass()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(Player) < 2000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(1500, DamageType.Physical);
            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                    ObjectManager.Player.Position, 900);
            var aiMinions = minions as Obj_AI_Minion[] ?? minions.ToArray();

            if ((!target.IsValidTarget() && minions != null) ||
                Player.IsDashing() || target.HasBuffOfType(BuffType.Invulnerability)
                || target.IsDead || target.IsZombie || Orbwalker.IsAutoAttacking)
                return;


            if (Spells.Q.IsReady() &&
                Init.HarassMenu["useQ"].Cast<CheckBox>().CurrentValue &&
                Player.ManaPercent > Init.HarassMenu["qMana"].Cast<Slider>().CurrentValue)
            {
                var predPos = Prediction.Position.PredictLinearMissile(target, Spells.Q.Range - 100, Spells.Q.Width,
                    Spells.Q.CastDelay, Spells.Q.Speed, int.MaxValue, null);
                foreach (var m in from m in aiMinions.Where(m => m.Health < Player.GetSpellDamage(m, SpellSlot.Q))
                    let p = new Geometry.Polygon.Rectangle((Vector2) Player.ServerPosition,
                        Player.ServerPosition.Extend(m.ServerPosition, 900), Spells.Q.Width)
                    where p.IsInside(predPos.CastPosition)
                    select m)
                {
                    Spells.Q.Cast(m);
                }

                Spells.CastCollisionQ(target);
                if (!target.CanMove)
                    Spells.CastSimpleQ(target);
            }

            if (Spells.W.IsReady() &&
                Init.HarassMenu["useW"].Cast<CheckBox>().CurrentValue &&
                Init.HarassMenu["wMana"].Cast<Slider>().CurrentValue < Player.ManaPercent)
                Spells.CastWGrass();
        }
    }
}