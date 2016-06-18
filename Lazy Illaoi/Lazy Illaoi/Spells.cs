using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Lazy_Illaoi
{
    internal class Spells
    {
        public static AIHeroClient Player = ObjectManager.Player;
        public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 850, SkillShotType.Linear, 750, int.MaxValue, 100);
        public static Spell.Active W = new Spell.Active(SpellSlot.W, 300);
        public static Spell.Skillshot E = new Spell.Skillshot(SpellSlot.E, 950, SkillShotType.Linear, 250, 1900, 50);
        public static Spell.Active R = new Spell.Active(SpellSlot.R, 450);


        public static void CastQ()
        {
            var target = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            var ghost = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(x => x.IsValidTarget(Q.Range) && x.HasBuff("illaoiespirit"));
            if (target != null)
            {
                var ePred = E.GetPrediction(target);
                //var saveMana = Player.Mana > Helpers.Rmana + Helpers.Wmana + Helpers.Qmana;


                if ((Init.ComboMenu["useEQ"].Cast<CheckBox>().CurrentValue && ePred.HitChance >= HitChance.Medium && E.IsReady()) || !Q.IsReady()) return;
            }

            if (target != null && ghost != null)
            {
                var predPos = Prediction.Position.PredictLinearMissile(target, Q.Range, Q.Width, Q.CastDelay, Q.Speed, int.MaxValue, null, true);
                var p = new Geometry.Polygon.Rectangle((Vector2) Player.ServerPosition,
                    Player.ServerPosition.Extend(ghost.ServerPosition, Q.Range), Q.Width);
                     if (p.IsInside(predPos.CastPosition))             
                {
                    Q.Cast(predPos.CastPosition);
                }
            }
            if (target == null || !target.IsValidTarget(Q.Range) && ghost != null)
            {
                if (ghost != null && Player.Distance(ghost.ServerPosition) <= Q.Range)
                Q.Cast(ghost);
            }

            if (target == null || ghost != null) return;
            {
                var predPos = Prediction.Position.PredictLinearMissile(target, Q.Range - target.BoundingRadius, Q.Width,
                    Q.CastDelay, Q.Speed, int.MaxValue, null, true);
            
                if ((target.Health < Player.GetSpellDamage(target, SpellSlot.Q) && predPos.HitChance >= HitChance.Medium) || // Cast on target
                    (predPos.HitChance >= HitChance.High))
                {
                    Q.Cast(predPos.CastPosition);
                }
                if ((!target.CanMove && !target.IsDashing())) // Cast on target
                {
                    Q.Cast(target.ServerPosition);
                }
            }
        }

        public static void CastW()
        {
            var target = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            var ghost = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(x => x.IsValidTarget(Q.Range) && x.HasBuff("illaoiespirit"));

            if (!W.IsReady()) return;

            if (target != null && (target.IsValidTarget(450) && !target.IsDead || !target.IsZombie))
            {
                var tentaclesNearTarget = Events.TentacleList.Count(x => x.Distance(target) <= Q.Range);
                if (tentaclesNearTarget != 0)
                    W.Cast();
            }
            
            if ((target != null && target.IsValidTarget(450)) || ghost == null) return;
            {
                var tentaclesNearGhost = Events.TentacleList.Count(x => x.Distance(ghost) <= Q.Range);
                if (tentaclesNearGhost != 0 && ghost.Distance(Player) <= 450)
                    W.Cast();
            }
        }

        public static void CastE()
        {
            var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            //var saveMana = Player.Mana > Helpers.Rmana + Helpers.Wmana + Helpers.Qmana;

            if (!E.IsReady() ||
                !target.IsValidTarget() || target.HasBuffOfType(BuffType.Invulnerability) || target.IsDead || target.IsZombie)
                return;

            var predPos = Prediction.Position.PredictLinearMissile(target, E.Range - target.BoundingRadius, E.Width,
                    E.CastDelay, E.Speed, 0, null);

            if (predPos.HitChance >= HitChance.High)
            {
                E.Cast(predPos.CastPosition);
            }
        }

        public static void CastR()
        {
            var ghost = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(x => x.HasBuff("illaoiespirit") && x.Distance(Player) < R.Range);
            var targets =
                EntityManager.Heroes.Enemies.Where(
                    x => x.IsValidTarget(R.Range) && !x.HasBuffOfType(BuffType.Invulnerability) && !x.IsDead && !x.IsZombie);
            
            if (!R.IsReady()) return;

            var aiHeroClients = targets as AIHeroClient[] ?? targets.ToArray();
            if ((aiHeroClients.Count() == 1 && ghost != null) || aiHeroClients.Count() >= Init.ComboMenu["useR#"].Cast<Slider>().CurrentValue)
            {
                R.Cast();
            }
                
        }
    }
}