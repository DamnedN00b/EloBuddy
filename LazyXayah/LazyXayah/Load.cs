using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace LazyXayah
{
    internal static class Load
    {
        private static void Main()
        {
            Loading.OnLoadingComplete += OnLoad;

        }

        private static void OnLoad(EventArgs args)
        {
            if (Player.Instance.ChampionName.ToLower() != "xayah")
            {
                return;
            }

            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();
            Events.Initialize();
        }
    }
}
