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
    public class DangerBuffDetector
    {
        static DangerBuffDetector()
        {
            Game.OnTick += Game_OnTick;
        }

        public static List<DetectedDangerBuffData> DangerBuffsDetected = new List<DetectedDangerBuffData>();

        private static void Game_OnTick(EventArgs args)
        {
            DangerBuffsDetected.RemoveAll(b => b.Ended);
            foreach (var target in EntityManager.Heroes.AllHeroes)
            {
                var dangerbuffs = DangerBuffDataDatabase.List.FindAll(b => target.HasBuff(b.BuffName));
                if (!dangerbuffs.Any())
                    return;

                foreach (var data in dangerbuffs)
                {
                    var thebuff = target.GetBuff(data.BuffName);
                    var caster = thebuff?.Caster as AIHeroClient;
                    if (caster != null && caster.IsValid)
                    {
                        var detected = new DetectedDangerBuffData
                        {
                            Caster = caster,
                            Target = target,
                            Buff = thebuff,
                            Data = data
                        };

                        Add(detected);
                    }
                }
            }
        }

        public static void Add(DetectedDangerBuffData data)
        {
            if (data == null)
            {
                Console.WriteLine("Invalid DetectedDangerBuffData");
                return;
            }

            OnDangerBuffDetected.Invoke(data);

            if (!DangerBuffsDetected.Contains(data))
                DangerBuffsDetected.Add(data);
        }
    }
}
