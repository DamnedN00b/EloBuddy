﻿using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using LazyIvern.Modes;

namespace LazyIvern
{
    public static class ModeManager
    {
        static ModeManager()
        {
            Modes = new List<ModeBase>();

            Modes.AddRange(new ModeBase[]
            {
                new PermActive(),
                new Combo(),
                new Harass(),
                new LaneClear(),
                new JungleClear(),
                new LastHit(),
                new Flee()
            });

            Game.OnUpdate += OnUpdate;
        }

        /// <summary>
        ///     Mode Initialization
        /// </summary>
        private static List<ModeBase> Modes { get; }

        public static void Initialize()
        {
        }

        /// <summary>
        ///     execute <see cref="LazyIvern.ModeManager.Modes" />
        /// </summary>
        /// <param name="args"></param>
        private static void OnUpdate(EventArgs args)
        {
            // Execute all modes

            Modes.ForEach(mode =>
            {
                try
                {
                    // Check if the mode should be executed
                    if (mode.ShouldBeExecuted())
                    {
                        // Execute the mode
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}