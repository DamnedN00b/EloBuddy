using System;
using System.Collections.Generic;
using EloBuddy;
using LazyEvade.KappaCommon.Databases.Spells;
using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Events;

namespace LazyEvade.KappaCommon.SpellDetector.Detectors
{
    public class EmpoweredAttackDetector
    {
        private static bool Loaded;
        static EmpoweredAttackDetector()
        {
            if (!Loaded)
            {
                Game.OnTick += Game_OnTick;
                Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
                Loaded = true;
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            DetectedEmpoweredAttacks.RemoveAll(a => a.Ended);

            foreach (var attack in DetectedEmpoweredAttacks)
                OnEmpoweredAttackDetected.Invoke(attack);
        }

        public static List<DetectedEmpoweredAttackData> DetectedEmpoweredAttacks = new List<DetectedEmpoweredAttackData>();

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var caster = sender as AIHeroClient;
            var target = args.Target as Obj_AI_Base;

            if (caster == null || target == null || !caster.IsValid || !target.IsValid)
                return;

            var infos = EmpowerdAttackDataDatabase.List.FindAll(s => s.Hero.Equals(caster.Hero));
            foreach (var info in infos)
            {
                var attackname = string.IsNullOrEmpty(info.AttackName) || info.AttackName.Equals(args.SData.Name, StringComparison.CurrentCultureIgnoreCase);
                var requirebuff = string.IsNullOrEmpty(info.RequireBuff) || caster.GetBuffCount(info.RequireBuff) >= info.RequiredBuffCount;
                var targetrequirebuff = string.IsNullOrEmpty(info.TargetRequiredBuff) || target.GetBuffCount(info.TargetRequiredBuff) >= info.TargetRequiredBuffCount;
                var donthavebuff = string.IsNullOrEmpty(info.DontHaveBuff) || !target.HasBuff(info.DontHaveBuff);
                if (attackname && requirebuff && targetrequirebuff && donthavebuff)
                {
                    var detected = new DetectedEmpoweredAttackData
                    {
                        Caster = caster,
                        Target = target,
                        Data = info
                    };

                    Add(detected);
                }
            }
        }

        private static void Add(DetectedEmpoweredAttackData data)
        {
            if (data == null || DetectedEmpoweredAttacks.Contains(data))
            {
                Console.WriteLine("Invalid DetectedEmpoweredAttackData");
                return;
            }

            OnEmpoweredAttackDetected.Invoke(data);
            DetectedEmpoweredAttacks.Add(data);
        }
    }
}
