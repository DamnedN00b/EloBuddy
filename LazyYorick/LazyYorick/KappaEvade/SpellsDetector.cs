using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Constants;
using SharpDX;
// ReSharper disable IdentifierWordIsNotInDictionary

namespace LazyYorick.KappaEvade
{
    internal static class SpellsDetector
    {
        public delegate void TargetedSpellDetected(AIHeroClient sender, AIHeroClient target, GameObjectProcessSpellCastEventArgs args, Database.TargetedSpells.Spell spell);

        public static event TargetedSpellDetected OnTargetedSpellDetected;

        public delegate void SkillShotDetected(
            AIHeroClient sender,
            GameObjectProcessSpellCastEventArgs args,
            Database.SkillShotSpells.SSpell spell,
            Vector3 start,
            Vector3 end,
            float range,
            float width,
            MissileClient missile);

        public static event SkillShotDetected OnSkillShotDetected;

        public static void Init()
        {
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            GameObject.OnCreate += GameObject_OnCreate;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            if (sender == null)
                return;

            var missile = sender as MissileClient;
            var caster = missile?.SpellCaster as AIHeroClient;
            if (caster == null || !missile.IsValid || missile.IsAutoAttack() || !caster.IsEnemy)
                return;

            //Chat.Print("OnCreate Detected " + missile.SData.Name + " " + missile.SData.MissileSpeed + " " + missile.SData.CastRange);
            if (Database.SkillShotSpells.SkillShotsSpellsList.Any(s => s.Hero == caster.Hero && missile.SData.Name.ToLower() == s.MissileName.ToLower()))
            {
                //Chat.Print("OnCreate Added " + missile.SData.Name);
                var spell = Database.SkillShotSpells.SkillShotsSpellsList.FirstOrDefault(s => s.Hero == caster.Hero && missile.SData.Name.ToLower() == s.MissileName.ToLower());
                if (!spell.DetectByMissile) return;
                OnSkillShotDetected?.Invoke(caster, null, spell, missile.StartPosition, missile.EndPosition, spell.Range, spell.Width, missile);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var caster = sender as AIHeroClient;
            var hero = args.Target as AIHeroClient;
            if (caster == null || !caster.IsEnemy)
                return;

            if (Database.SkillShotSpells.SkillShotsSpellsList.Any(s => s.Hero == caster.Hero && s.Slot == args.Slot && args.SData.Name.Equals(s.SpellName, StringComparison.CurrentCultureIgnoreCase)))
            {
                //Chat.Print("OnProcessSpellCast Detected " + args.SData.Name);
                var spell = Database.SkillShotSpells.SkillShotsSpellsList.FirstOrDefault(s => s.Hero == caster.Hero && s.Slot == args.Slot && args.SData.Name.Equals(s.SpellName, StringComparison.CurrentCultureIgnoreCase));
                if (spell.DetectByMissile) return;
                OnSkillShotDetected?.Invoke(caster, args, spell, args.Start, args.End, spell.Range, spell.Width, null);
            }

            if (hero == null)
                return;
            if (Database.TargetedSpells.TargetedSpellsList.Any(s => s.Hero == caster.Hero && s.Slot == args.Slot))
            {
                var spell = Database.TargetedSpells.TargetedSpellsList.FirstOrDefault(s => s.Hero == caster.Hero && s.Slot == args.Slot);
                OnTargetedSpellDetected?.Invoke(caster, hero, args, spell);
            }
        }
    }
}
