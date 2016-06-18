using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace Lazy_Illaoi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (ObjectManager.Player.ChampionName == ("Illaoi"))
                Init.LoadMenu();
        }
    }
}