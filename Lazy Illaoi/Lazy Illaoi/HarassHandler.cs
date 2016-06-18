using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace Lazy_Illaoi
{
    internal class HarassHandler
    {
        public static AIHeroClient Player = ObjectManager.Player;

        public static void Harass() //such useful much wow
        {
            var saveMana = Player.Mana > Helpers.Rmana + Helpers.Wmana + Helpers.Qmana;
            if (Player.IsDashing() || Orbwalker.IsAutoAttacking || !saveMana) return;
            {
                if (Init.HarassMenu["useQ"].Cast<CheckBox>().CurrentValue &&
                    Player.Mana > Init.HarassMenu["qMana"].Cast<Slider>().CurrentValue)
                {
                    Spells.CastQ();
                }
                if (Init.HarassMenu["useW"].Cast<CheckBox>().CurrentValue && 
                    Player.Mana > Init.HarassMenu["wMana"].Cast<Slider>().CurrentValue)
                {
                    Spells.CastW();
                }
                if (Init.HarassMenu["useE"].Cast<CheckBox>().CurrentValue && 
                    Player.Mana > Init.HarassMenu["eMana"].Cast<Slider>().CurrentValue)
                {
                    Spells.CastE();
                }

                }
            }
        }
}