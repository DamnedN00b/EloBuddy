using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// ReSharper disable PrivateMembersMustHaveComments

namespace LazyIllaoi2
{
    internal static class Utility
    {
        public static readonly Item Tiamat = new Item(ItemId.Tiamat);
        public static readonly Item Hydra = new Item(ItemId.Ravenous_Hydra);
        public static readonly Item Titanic = new Item(ItemId.Titanic_Hydra);

        public static void CastItems()
        {
            if (Tiamat.IsOwned() && Tiamat.IsReady())
            {
                Tiamat.Cast();
                return;
            }
            if (Hydra.IsOwned() && Hydra.IsReady())
                Hydra.Cast();
            if (Tiamat.IsOwned() && Tiamat.IsReady())
            {
                Tiamat.Cast();
                return;
            }
            if (Titanic.IsOwned() && Titanic.IsReady())
                Titanic.Cast();
        }
    }
}