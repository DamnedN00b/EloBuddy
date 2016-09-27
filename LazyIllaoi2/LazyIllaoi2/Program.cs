using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace LazyIllaoi2
{
    /// <summary>
    /// </summary>
    public static class Program
    {
        public const string ChampName = "Illaoi";

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        /// <summary>
        ///     fires after <see cref="Loading" /> completed
        /// </summary>
        /// <param name="args"></param>
        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }

            SpellManager.Initialize();
            ModeManager.Initialize();
            Events.Initialize();
        }
    }
}