using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using LazyEvade.KappaCommon.Databases.Spells;
using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Events;

namespace LazyEvade.KappaCommon.SpellDetector.Detectors
{
    public class SpecialSpellDetector
    {
        public static List<DetectedSpecialSpellData> DetectedSpecialSpells = new List<DetectedSpecialSpellData>();
        private static bool Loaded;
        static SpecialSpellDetector()
        {
            if (Loaded)
                return;

            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnProcessSpellCast;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            GameObject.OnCreate += GameObject_OnCreate;
            Game.OnTick += Game_OnTick;

            Loaded = true;
        }

        private static void Game_OnTick(EventArgs args)
        {
            foreach (var s in DetectedSpecialSpells)
                OnSpecialSpellDetected.Invoke(s);

            DetectedSpecialSpells.RemoveAll(s => s.Ended);
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var partical = sender as Obj_GeneralParticleEmitter;
            if (partical == null)
                return;

            var data = SpecialSpellsDatabase.List.FirstOrDefault(s => !string.IsNullOrEmpty(s.ParticalName) && s.ParticalName.Equals(partical.Name));
            if (data == null)
                return;

            var correctObject = ObjectManager.Get<Obj_AI_Base>().OrderBy(o => o.Distance(partical)).FirstOrDefault(o => !string.IsNullOrEmpty(data.TargetName) && o.Name.Equals(data.TargetName));
            if (correctObject == null)
            {
                return;
            }

            var caster = EntityManager.Heroes.AllHeroes.OrderBy(e => e.Distance(correctObject)).FirstOrDefault(h => h.Hero.Equals(data.Hero));
            if (caster == null)
            {
                return;
            }

            var detected = new DetectedSpecialSpellData
            {
                Caster = caster,
                Object = correctObject,
                Position = correctObject.Position,
                Data = data,
                StartTick = Core.GameTickCount
            };

            Add(detected);
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var caster = sender as AIHeroClient;
            if (caster == null)
                return;

            var casterData = SpecialSpellsDatabase.List.FindAll(s => s.Hero.Equals(caster.Hero));
            if (casterData == null || !casterData.Any())
                return;

            var target = args.Target as Obj_AI_Base;
            if (target != null)
            {
                var targetSpell = casterData.FirstOrDefault(s => !string.IsNullOrEmpty(s.TargetName) && s.TargetName.Equals(target.Name));
                if (targetSpell != null && target.Buffs.Any(b => b.Caster.IdEquals(caster)) && target.Health <= targetSpell.TargetHealth)
                {
                    var detected = new DetectedSpecialSpellData
                    {
                        Caster = caster,
                        Object = target,
                        Position = target.Position,
                        Data = targetSpell,
                        StartTick = Core.GameTickCount
                    };

                    Add(detected);
                    return;
                }

                var spellData = casterData.FirstOrDefault(s => !string.IsNullOrEmpty(s.SpellName) && s.SpellName.Equals(args.SData.Name));
                if (spellData != null)
                {
                    var detected = new DetectedSpecialSpellData
                    {
                        Caster = caster,
                        Target = target,
                        Data = spellData,
                        Position = args.End,
                        StartTick = Core.GameTickCount
                    };

                    Add(detected);
                    return;
                }
            }

            var spelldata = casterData.FirstOrDefault(s => !string.IsNullOrEmpty(s.SpellName) && s.SpellName.Equals(args.SData.Name, StringComparison.CurrentCultureIgnoreCase));
            if (spelldata == null)
                return;

            var detectedData = new DetectedSpecialSpellData
            {
                Caster = caster,
                Data = spelldata,
                Position = caster.ServerPosition,
                StartTick = Core.GameTickCount
            };

            Add(detectedData);
        }

        internal static void Add(DetectedSpecialSpellData data)
        {
            if (data == null)
                return;

            if (DetectedSpecialSpells.Any(s => s.Position.Equals(data.Position) || s.Object.IdEquals(data.Object)))
            {
                Console.WriteLine($"Already Detected {data.Data.Hero.ToString() + data.Data.Slot}");
                return;
            }

            OnSpecialSpellDetected.Invoke(data);
            DetectedSpecialSpells.Add(data);
        }
    }
}
