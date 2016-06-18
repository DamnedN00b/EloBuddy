using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace LazyGraves
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (ObjectManager.Player.BaseSkinName == ("Graves"))
                Init.LoadMenu();
        }
    }
}