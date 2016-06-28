using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Settings = LazyLucian.Config.Modes.Drawings;

namespace LazyLucian
{
    public static class Program
    {
        public const string ChampName = "Lucian";
        public static AIHeroClient Player = ObjectManager.Player;

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.ChampionName != ChampName)
            {
                return;
            }

            // Initialize the classes that we need
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();


            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (Settings.UseQ)
            {
                Circle.Draw(Color.LightYellow, SpellManager.Q.Range, Player.Position);
            }
            if (Settings.UseW)
            {
                Circle.Draw(Color.LightBlue, SpellManager.W.Range, Player.Position);
            }
            if (Settings.UseE)
            {
                Circle.Draw(Color.LightGray, SpellManager.E.Range, Player.Position);
            }
            if (Settings.UseR)
            {
                Circle.Draw(Color.AliceBlue, SpellManager.R.Range, Player.Position);
            }
        }
    }
}