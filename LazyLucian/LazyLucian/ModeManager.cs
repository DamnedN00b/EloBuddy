using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using LazyLucian.Modes;

namespace LazyLucian
{
    public static class ModeManager
    {
        static ModeManager()
        {
            // Initialize properties
            Modes = new List<ModeBase>();

            Modes.AddRange(new ModeBase[]
            {
                new PermaActive(),
                new Combo(),
                new Harass(),
                new LaneClear(),
                new JungleClear(),
                new LastHit(),
                new Flee()
            });

            // Listen to events we need
            Game.OnUpdate += OnUpdate;
            Obj_AI_Base.OnSpellCast += CustomEvents.OnSpellCast;
            //Obj_AI_Base.OnProcessSpellCast += CustomEvents.OnProcessSpellCast;
            //Obj_AI_Base.OnBuffGain += CustomEvents.OnBuffGain;
            //Obj_AI_Base.OnBuffLose += CustomEvents.OnBuffLose;
            //Game.OnTick += Skin;
            //Obj_AI_Base.OnBuffGain += Buffs;
        }

        private static List<ModeBase> Modes { get; }
        /*
        private static void Skin(EventArgs args)
        {
            Player.SetSkinId(2);
        }
        
        private static void Buffs(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (sender.IsMe && sender.Type == GameObjectType.AIHeroClient)
            {
                Chat.Print(args.Buff.Name);
            }
        }
        */

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

        private static void OnUpdate(EventArgs args)
        {
            // Execute all modes
            Modes.ForEach(mode =>
            {
                try
                {
                    // Precheck if the mode should be executed
                    if (mode.ShouldBeExecuted())
                    {
                        // Execute the mode
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    // Please enable the debug window to see and solve the exceptions that might occur!
                    Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}