using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using LazyEvade.KappaCommon.Databases.Spells;
using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Events;

namespace LazyEvade.KappaCommon.SpellDetector.Detectors
{
    public class TargetedSpellDetector
    {
        private static bool Loaded;
        static TargetedSpellDetector()
        {
            if (!Loaded)
            {
                Game.OnTick += Game_OnTick;
                Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
                Loaded = true;
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            DetectedTargetedSpells.RemoveAll(s => s.Ended);

            foreach (var spell in DetectedTargetedSpells)
                OnTargetedSpellDetected.Invoke(spell);
        }

        public static List<DetectedTargetedSpellData> DetectedTargetedSpells = new List<DetectedTargetedSpellData>();

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var caster = sender as AIHeroClient;
            var target = args.Target as Obj_AI_Base;

            if (caster == null || target == null || !caster.IsValid || !target.IsValid)
                return;

            var data = TargetedSpellDatabase.List.FirstOrDefault(s => s.hero.Equals(caster.Hero) && s.slot.Equals(args.Slot));

            if (data == null)
            {
                //Console.WriteLine($"OnProcessTargetedSpell: {caster.ChampionName} - [{args.Slot}] - Not Detected");
                return;
            }

            var detected = new DetectedTargetedSpellData
            {
                Caster = caster,
                Target = target,
                Data = data
            };

            Add(detected);
        }

        private static void Add(DetectedTargetedSpellData data)
        {
            if (data == null || DetectedTargetedSpells.Contains(data))
            {
                Console.WriteLine("Invalid DetectedTargetedSpellData");
                return;
            }

            OnTargetedSpellDetected.Invoke(data);
            DetectedTargetedSpells.Add(data);
        }
    }
}
