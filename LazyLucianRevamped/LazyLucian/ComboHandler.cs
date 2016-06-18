using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace LazyLucian
{
    internal class ComboHandler
    {
        public static void Combo()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(ObjectManager.Player) < 2000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(Spells.Q1.Range+Spells.E.Range, DamageType.Physical);

            if (target == null ||
                
                (Init.ComboMenu["spellWeaving"].Cast<CheckBox>().CurrentValue &&
                (Events.PassiveUp || Helpers.HasPassiveBuff())) ||
                Orbwalker.IsAutoAttacking ||
                ObjectManager.Player.IsDashing() ||
                target.IsZombie ||
                target.HasBuffOfType(BuffType.Invulnerability))
                return;


            if (Spells.Q.IsReady() &&
                ObjectManager.Player.ManaPercent > Init.ComboMenu["qMana"].Cast<Slider>().CurrentValue)
            {
                if (Init.ComboMenu["useQcombo"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastQ();
                }
                if (Init.ComboMenu["useQextended"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastExtendedQ();
                }
            }

            if (Spells.W.IsReady() &&
                ObjectManager.Player.ManaPercent > Init.ComboMenu["wMana"].Cast<Slider>().CurrentValue)
            {
                if (Init.ComboMenu["useWaaRange"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastWinRange();
                }
                if (Init.ComboMenu["useWalways"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastWcombo();
                }
            }

            if (!Spells.E.IsReady() ||
                !(ObjectManager.Player.ManaPercent > Init.ComboMenu["eMana"].Cast<Slider>().CurrentValue))
                return;
            if (Init.ComboMenu["useEcombo"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastEcombo();
            }
            if (Init.ComboMenu["useEmouse"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastEmouse();
            }


        }
    }
}