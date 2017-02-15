using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using LazyEvade.KappaCommon.SpellDetector.Detectors;
using SharpDX;
using SharpDX.Direct3D9;
using System.Drawing;
using Font = System.Drawing.Font;

namespace LazyEvade.KappaCommon.Utility
{
    static class Extensions
    {
        /// <summary>
        ///     Returns true if you can deal damage to the target.
        /// </summary>
        public static Vector3 CenterVectors(this List<Vector3> vectors)
        {
            return vectors.ToArray().CenterVectors();
        }

        /// <summary>
        ///     Returns true if you can deal damage to the target.
        /// </summary>
        public static Vector3 CenterVectors(this IEnumerable<Vector3> vectors)
        {
            return vectors.ToArray().CenterVectors();
        }

        /// <summary>
        ///     Returns true if you can deal damage to the target.
        /// </summary>
        public static Vector3 CenterVectors(this Vector3[] vectors)
        {
            return vectors.Aggregate(Vector3.Zero, (current, vector) => current + vector) / vectors.Length;
        }

        public static bool IsChampion(this GameObject obj)
        {
            return obj != null && obj.IsValid && obj is AIHeroClient;
        }

        /// <summary>
        ///     Returns true if you can deal damage to the target.
        /// </summary>
        public static bool IsKillable(this Obj_AI_Base target, float range = -1f, bool SpellShields = false, bool UndyingBuffs = false, bool ReviveBuffs = false)
        {
            if (range.Equals(-1f))
                range = int.MaxValue;

            if (target == null)
                return false;

            if (target.HasBuff("SionPassiveZombie"))
                return false;

            if (!target.IsValidTarget(range))
                return false;

            if (ReviveBuffs)
                return !target.HasReviveBuff();

            if (target.IsZombie || target.IsDead || target.Health <= 0)
                return false;

            if (UndyingBuffs && (target.HasBuffOfType(BuffType.Invulnerability) || target.HasBuffOfType(BuffType.PhysicalImmunity) || (target.HasBuff("kindredrnodeathbuff") && target.HealthPercent <= 15) || target.IsInvulnerable))
                return false;

            if (SpellShields && (target.Buffs.Any(b => b.Name.ToLower().Contains("fioraw") || b.Name.ToLower().Contains("sivire")) || target.HasBuff("bansheesveil")))
                return false;

            var client = target as AIHeroClient;
            if (client != null && UndyingBuffs && client.HasUndyingBuff(true))
                return false;

            return true;
        }

        private static Dictionary<string, string> reviveBuffs = new Dictionary<string, string>
            {
            {"all", "willrevive" },
            {"Aatrox", "aatroxpassiveready" },
            {"Zac", "zacrebirthready" },
            {"Anivia", "rebirthready" }
            };

        public static bool HasReviveBuff(this Obj_AI_Base target)
        {
            if (target == null)
                return false;

            if (reviveBuffs.ContainsKey(target.BaseSkinName))
            {
                if (target.HasBuff(reviveBuffs[target.BaseSkinName]))
                {
                    return true;
                }
            }

            return target.HasBuff(reviveBuffs["all"]);
        }

        /// <summary>
        ///     Returns true if the target will die before the spell finish him.
        /// </summary>
        public static bool WillDie(this Obj_AI_Base target, Spell.SpellBase spell)
        {
            if (spell.CastDelay == 0)
                spell.CastDelay = 250;

            var incDmg = 0f;
            var delay = spell.CastDelay;

            var incSkillshots = SkillshotDetector.SkillshotsDetected.FindAll(s => s.WillHit(target));
            if (incSkillshots.Any())
                incDmg += incSkillshots.Sum(s => (s.Caster as AIHeroClient)?.GetSpellDamage(target, s.Data.slot) ?? 0);
            var incTargetedSpell = TargetedSpellDetector.DetectedTargetedSpells.FindAll(s => s.Target.IdEquals(target));
            if (incTargetedSpell.Any())
                incDmg += incTargetedSpell.Sum(s => s.Caster.GetSpellDamage(target, s.Data.slot));
            var incDangerBuff = DangerBuffDetector.DangerBuffsDetected.FindAll(s => s.Target.IdEquals(target));
            if (incDangerBuff.Any())
                incDmg += incDangerBuff.Sum(s => s.Caster.GetSpellDamage(target, s.Data.Slot));
            var incAA = EmpoweredAttackDetector.DetectedEmpoweredAttacks.FindAll(s => s.Target.IdEquals(target));
            if (incAA.Any())
                incDmg += incAA.Sum(s => s.Caster.GetAutoAttackDamage(target, true));

            return spell.GetHealthPrediction(target) <= 0f || target.PredictHealth(delay) <= incDmg;
        }

        /// <summary>
        ///     Returns true if the target will die before the spell finish him.
        /// </summary>
        public static bool WillDie(this Obj_AI_Base target, float delay = 250)
        {
            var incDmg = 0f;

            var incSkillshots = SkillshotDetector.SkillshotsDetected.FindAll(s => s.WillHit(target));
            if (incSkillshots.Any())
                incDmg += incSkillshots.Sum(s => (s.Caster as AIHeroClient)?.GetSpellDamage(target, s.Data.slot) ?? 0);
            var incTargetedSpell = TargetedSpellDetector.DetectedTargetedSpells.FindAll(s => s.Target.IdEquals(target));
            if (incTargetedSpell.Any())
                incDmg += incTargetedSpell.Sum(s => s.Caster.GetSpellDamage(target, s.Data.slot));
            var incDangerBuff = DangerBuffDetector.DangerBuffsDetected.FindAll(s => s.Target.IdEquals(target));
            if (incDangerBuff.Any())
                incDmg += incDangerBuff.Sum(s => s.Caster.GetSpellDamage(target, s.Data.Slot));
            var incAA = EmpoweredAttackDetector.DetectedEmpoweredAttacks.FindAll(s => s.Target.IdEquals(target));
            if (incAA.Any())
                incDmg += incAA.Sum(s => s.Caster.GetAutoAttackDamage(target, true));

            return target.PredictHealth((int)delay) <= incDmg;
        }

        /// <summary>
        ///     Returns true if the spell will kill the target.
        /// </summary>
        public static bool WillKill(this Spell.SpellBase spell, Obj_AI_Base target, float MultiplyDmgBy = 1, float ExtraDamage = 0, DamageType ExtraDamageType = DamageType.True)
        {
            return Player.Instance.GetSpellDamage(target, spell.Slot) * MultiplyDmgBy + Player.Instance.CalculateDamageOnUnit(target, ExtraDamageType, ExtraDamage) >= spell.GetHealthPrediction(target) && !target.WillDie(spell);
        }
        /// <summary>
        ///     Returns true if the spell will kill the target.
        /// </summary>
        public static bool WillKill(this Obj_AI_Base target, float rawDamage, float MultiplyDmgBy = 1, float ExtraDamage = 0, DamageType ExtraDamageType = DamageType.True)
        {
            return rawDamage * MultiplyDmgBy + Player.Instance.CalculateDamageOnUnit(target, ExtraDamageType, ExtraDamage) >= target.PredictHealth() && !target.WillDie();
        }

        public static bool CanKill(this AIHeroClient hero, AIHeroClient target)
        {
            return hero.GetAutoAttackDamage(target, true) >= target.TotalShieldHealth() && target.IsKillable(hero.GetAutoAttackRange(target));
        }

        public static IEnumerable<AIHeroClient> GetKillStealTargets(this Spell.SpellBase spell)
        {
            return EntityManager.Heroes.Enemies.OrderByDescending(TargetSelector.GetPriority).Where(o => spell.WillKill(o) && o.IsKillable());
        }

        public static AIHeroClient GetKillStealTarget(this Spell.SpellBase spell, float dmg = 0, DamageType damageType = DamageType.Mixed)
        {
            if (dmg > 0)
            {
                return EntityManager.Heroes.Enemies.OrderBy(TargetSelector.GetPriority).FirstOrDefault(t => t.IsKillable(spell.Range) && Player.Instance.CalculateDamageOnUnit(t, damageType, dmg) > spell.GetHealthPrediction(t));
            }
            return spell.GetKillStealTargets().FirstOrDefault(o => o.IsKillable(spell.Range));
        }

        /// <summary>
        ///     Returns a recreated name of the target.
        /// </summary>
        public static string Name(this Obj_AI_Base target)
        {
            if (ObjectManager.Get<Obj_AI_Base>().Count(o => o.BaseSkinName.Equals(target.BaseSkinName)) > 1)
            {
                return target.BaseSkinName + "(" + target.Name + ")";
            }
            return target.BaseSkinName;
        }

        /// <summary>
        ///     Creates a checkbox.
        /// </summary>
        public static CheckBox CreateCheckBox(this Menu m, string id, string name, bool defaultvalue = true)
        {
            return m.Add(id, new CheckBox(name, defaultvalue));
        }

        /// <summary>
        ///     Creates a slider.
        /// </summary>
        public static Slider CreateSlider(this Menu m, string id, string name, int defaultvalue = 0, int MinValue = 0, int MaxValue = 100)
        {
            return m.Add(id, new Slider(name, defaultvalue, MinValue, MaxValue));
        }

        /// <summary>
        ///     Creates a KeyBind.
        /// </summary>
        public static KeyBind CreateKeyBind(this Menu m, string id, string name, bool defaultvalue, KeyBind.BindTypes BindType, uint key1 = 27U, uint key2 = 27U)
        {
            return m.Add(id, new KeyBind(name, defaultvalue, BindType, key1, key2));
        }

        /// <summary>
        ///     Returns KeyBind Value.
        /// </summary>
        public static bool KeyBindValue(this Menu m, string id)
        {
            return m[id].Cast<KeyBind>().CurrentValue;
        }

        /// <summary>
        ///     Returns ComboBox Value.
        /// </summary>
        public static int ComboBoxValue(this Menu m, string id)
        {
            return m[id].Cast<ComboBox>().CurrentValue;
        }

        /// <summary>
        ///     Returns CheckBox Value.
        /// </summary>
        public static bool CheckBoxValue(this Menu m, string id)
        {
            try
            {
                return m[id].Cast<CheckBox>().CurrentValue;
            }
            catch (Exception)
            {
                Console.WriteLine($"Wrong ID:- Menu: {m.DisplayName} - ID: {id}");
                return false;
            }
        }

        /// <summary>
        ///     Returns Slider Value.
        /// </summary>
        public static int SliderValue(this Menu m, string id)
        {
            try
            {
                return m[id].Cast<Slider>().CurrentValue;
            }
            catch (Exception)
            {
                Console.WriteLine($"Wrong ID:- Menu: {m.DisplayName} - ID: {id}");
                return 0;
            }
        }

        /// <summary>
        ///     Returns true if the target is big minion (Siege / Super Minion).
        /// </summary>
        public static bool IsBigMinion(this Obj_AI_Base target)
        {
            return target.BaseSkinName.ToLower().Contains("siege") || target.BaseSkinName.ToLower().Contains("super");
        }

        /// <summary>
        ///     Prediects the target Position on the given time
        /// </summary>
        public static Vector3 PredictPosition(this Obj_AI_Base target, float Time = 250)
        {
            if (Time == 250)
                Time += Game.Ping;
            return Prediction.Position.PredictUnitPosition(target, (int)Time).To3D();
        }

        public static float PredictHealth(this Obj_AI_Base target, int Time = 250)
        {
            if (Time == 250)
                Time += Game.Ping;
            return Prediction.Health.GetPrediction(target, Time);
        }

        public static float GetCurrentDamage(this float[] damages, float[] mods, SpellSlot slot, float scale, int index = -1)
        {
            index = index == -1 ? Player.Instance.Spellbook.GetSpell(slot).Level - 1 : index;

            if (index < 0)
                return 0;

            var dmg = damages[index];
            var mod = mods[index];
            var currentdmg = dmg + (scale * mod);

            return currentdmg;
        }

        private static Text text;

        public static Vector2 HpBarPos(this Obj_AI_Base target) => new Vector2(target.HPBarPosition.X, target.HPBarPosition.Y - 5);

        public static void DrawDamage(this Obj_AI_Base target, float dmg)
        {
            if (text == null)
                text = new Text(string.Empty, new Font("Tahoma", 9, FontStyle.Bold)) { Color = System.Drawing.Color.White };

            if (!target.IsHPBarRendered || !target.HpBarPos().IsOnScreen())
                return;

            var y2 = target.BaseSkinName.Equals("Annie") ? 12 : target.BaseSkinName.Equals("Jhin") ? 14 : 0;

            var twoThirdhealth = (target.TotalShieldHealth() / 3) * 2;
            float x = target.HpBarPos().X;
            float y = target.HpBarPos().Y - y2 - 12;

            text.Color = System.Drawing.Color.White;

            if (dmg >= target.Health)
            {
                text.Color = System.Drawing.Color.Red;
            }
            else
            {
                if (dmg > twoThirdhealth)
                {
                    text.Color = System.Drawing.Color.Yellow;
                }
            }

            text.TextValue = (int)dmg + " / " + (int)target.Health;
            text.Position = new Vector2(x, y);
            text.Draw();
        }

        public static DangerLevel[] DangerLevels = { DangerLevel.Low, DangerLevel.Medium, DangerLevel.High, };

        /// <summary>
        ///     Casts spell with selected hitchancepercent.
        /// </summary>
        public static void Cast(this Spell.Skillshot spell, Obj_AI_Base target, float hitchancepercent)
        {
            if (target != null && spell.IsReady() && target.IsKillable(spell.Range))
            {
                var pred = spell.GetPrediction(target);
                if (pred.HitChancePercent >= hitchancepercent)
                {
                    spell.Cast(pred.CastPosition);
                }
            }
        }
    }
}
