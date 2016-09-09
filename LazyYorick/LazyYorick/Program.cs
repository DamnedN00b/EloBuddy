using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace LazyYorick
{
    /// <summary>
    /// </summary>
    public static class Program
    {
        public const string ChampName = "Yorick";
        public static AIHeroClient Player = ObjectManager.Player;

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        /// <summary>
        /// fires after Loading completed
        /// </summary>
        /// <param name="args"></param>
        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.ChampionName != ChampName)
            {
                return;
            }

            // Initialize the classes that we need
            SpellManager.Initialize();
            ModeManager.Initialize();
            Events.Initialize();

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }

        /// <summary>
        /// Drawing.OnDraw
        /// </summary>
        /// <param name="args"></param>
        private static void OnDraw(EventArgs args)
        {
            Circle.Draw(Color.LightYellow, SpellManager.Q.Range, Player.Position);
        }
    }
}