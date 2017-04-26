using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;

// ReSharper disable IdentifierWordIsNotInDictionary

// ReSharper disable WordCanBeSurroundedWithMetaTags

// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyXayah
{
    public static class Extensions
    {
        private static readonly Dictionary<string, string> ReviveBuffs = new Dictionary<string, string>
        {
            { "all", "willrevive" },
            { "Aatrox", "aatroxpassiveready" },
            { "Zac", "zacrebirthready" },
            { "Anivia", "rebirthready" }
        };
        private static Text _text;

        /// <summary>
        ///     Returns <see langword="true" /> if you can deal damage to the
        ///     target.
        /// </summary>
        public static bool IsKillable(this Obj_AI_Base target, float range = -1f, bool spellShields = false, bool undyingBuffs = false, bool reviveBuffs = false)
        {
            if (range.Equals(-1f))
            {
                range = int.MaxValue;
            }

            if (target == null)
            {
                return false;
            }

            if (target.HasBuff("SionPassiveZombie"))
            {
                return false;
            }

            if (!target.IsValidTarget(range))
            {
                return false;
            }

            if (reviveBuffs)
            {
                return !target.HasReviveBuff();
            }

            if (target.IsZombie || target.IsDead || target.Health <= 0)
            {
                return false;
            }

            if (undyingBuffs &&
                (target.HasBuffOfType(BuffType.Invulnerability) || target.HasBuffOfType(BuffType.PhysicalImmunity) || (target.HasBuff("kindredrnodeathbuff") && target.HealthPercent <= 15) ||
                 target.IsInvulnerable))
            {
                return false;
            }

            if (spellShields && (target.Buffs.Any(b => b.Name.ToLower().Contains("fioraw") || b.Name.ToLower().Contains("sivire")) || target.HasBuff("bansheesveil")))
            {
                return false;
            }

            var client = target as AIHeroClient;

            return client == null || !undyingBuffs || !client.HasUndyingBuff(true);
        }

        public static bool HasReviveBuff(this Obj_AI_Base target)
        {
            if (target == null)
            {
                return false;
            }

            if (ReviveBuffs.ContainsKey(target.BaseSkinName))
            {
                if (target.HasBuff(ReviveBuffs[target.BaseSkinName]))
                {
                    return true;
                }
            }

            return target.HasBuff(ReviveBuffs["all"]);
        }

        public static float PredictHealth(this Obj_AI_Base target, int time = 250)
        {
            if (time == 250)
            {
                time += Game.Ping;
            }
            return Prediction.Health.GetPrediction(target, time);
        }

        public static Vector2 HpBarPos(this Obj_AI_Base target) => new Vector2(target.HPBarPosition.X, target.HPBarPosition.Y - 5);

        public static void DrawDamage(this Obj_AI_Base target, double dmg)
        {
            if (_text == null)
            {
                _text = new Text(string.Empty, new Font("Tahoma", 9, FontStyle.Bold)) { Color = Color.White };
            }

            if (!target.IsHPBarRendered || !target.HpBarPos().IsOnScreen())
            {
                return;
            }

            var y2 = target.BaseSkinName.Equals("Annie") ? 12 : target.BaseSkinName.Equals("Jhin") ? 14 : 0;

            var twoThirdhealth = (target.TotalShieldHealth() / 3) * 2;
            var x = target.HpBarPos().X;
            var y = target.HpBarPos().Y - y2 - 12;

            _text.Color = Color.White;

            if (dmg >= target.Health)
            {
                _text.Color = Color.Red;
            }
            else
            {
                if (dmg > twoThirdhealth)
                {
                    _text.Color = Color.Yellow;
                }
            }

            _text.TextValue = (int)dmg + " / " + (int)target.Health;
            _text.Position = new Vector2(x, y);
            _text.Draw();
        } //Credits: DefinitelyNotKappa

        public static float RBuffTime(this AIHeroClient unit)
        {
            var buff = unit?.Buffs.Where(b => b != null && (b.IsKnockback || b.IsKnockup)).OrderBy(b => b.EndTime).FirstOrDefault();

            if (buff != null)
            {
                return buff.EndTime - Game.Time;
            }

            return 1000f;
        }

        public static bool IsUnderEnemyTurret(this Vector3 position)
        {
            return EntityManager.Turrets.Enemies.Any(t => t.IsValidTarget() && t.IsInRange(position, t.GetAutoAttackRange() + 50));
        }

        public static bool IsUnderAlliedTurret(this Vector3 position)
        {
            return EntityManager.Turrets.Allies.Any(t => t.IsValidTarget() && t.IsInRange(position, t.GetAutoAttackRange() + 50));
        }

        public static bool HasRbuff(this AIHeroClient unit)
        {
            return unit.HasBuffOfType(BuffType.Knockup) || unit.HasBuffOfType(BuffType.Knockback);
        }

        public static bool IsStunable(this Obj_AI_Base unit)
        {
            return Events.FeatherPolys.Count(x => unit != null && x.IsInside(unit.ServerPosition)) > 2 &&
                   unit.IsKillable(-1f, true, true, true);
        }
    }
}
