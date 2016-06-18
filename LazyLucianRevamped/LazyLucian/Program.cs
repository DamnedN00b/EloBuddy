using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace LazyLucian
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (ObjectManager.Player.BaseSkinName == ("Lucian"))
                Init.LoadMenu();
        }
    }
}