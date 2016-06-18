using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace Lazy_Illaoi
{
    internal class ComboHandler
    {
        public static AIHeroClient Player = ObjectManager.Player;

        public static void Combo() //such useful much wow
        {
            if (Player.IsDashing() || Orbwalker.IsAutoAttacking) return;
            {
                if (Init.ComboMenu["useQ"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastQ();
                }
                if (Init.ComboMenu["useW"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastW();
                }
                if (Init.ComboMenu["useE"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastE();
                }
                if (Init.ComboMenu["useR"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastR();
                }
            }
        }
    }
}