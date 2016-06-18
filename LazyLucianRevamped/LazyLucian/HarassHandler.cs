using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace LazyLucian
{
    internal class HarassHandler
    {
        public static void Harass()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(ObjectManager.Player) < 2000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(Spells.W.Range, DamageType.Physical);

            if (target == null ||
                (Init.HarassMenu["spellWeaving"].Cast<CheckBox>().CurrentValue && Events.PassiveUp) ||
                Orbwalker.IsAutoAttacking ||
                target.IsZombie ||
                ObjectManager.Player.IsDashing())
                return;


            if (Spells.Q.IsReady() &&
                ObjectManager.Player.ManaPercent > Init.HarassMenu["qMana"].Cast<Slider>().CurrentValue)
            {
                if (Init.HarassMenu["useQharass"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastQ();
                }
                if (Init.HarassMenu["useQextended"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastExtendedQ();
                }
            }

            if (!Spells.W.IsReady() ||
                ObjectManager.Player.ManaPercent < Init.HarassMenu["wMana"].Cast<Slider>().CurrentValue)
                return;
            {
                if (Init.HarassMenu["useWaaRange"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastWinRange();
                }
                if (Init.HarassMenu["useWalways"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastWcombo();
                }
            }
        }
    }
}