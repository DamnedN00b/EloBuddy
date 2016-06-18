using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace LazyGraves
{
    internal class ComboHandler
    {
        public static AIHeroClient Player = ObjectManager.Player;

        public static void Combo()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(Player) < 2000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(1500, DamageType.Physical);

            if (!target.IsValidTarget() ||
                Player.IsDashing() || target.HasBuffOfType(BuffType.Invulnerability)
                || target.IsDead || target.IsZombie || Orbwalker.IsAutoAttacking)
                return;

            var tHp = target.Health + 20;

            if (tHp < Player.GetSpellDamage(target, SpellSlot.W) &&
                Spells.W.IsReady() && Init.ComboMenu["useW"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastWkill(target);
            }

            else if (tHp < Player.GetSpellDamage(target, SpellSlot.Q) &&
                     Spells.Q.IsReady())
            {
                if (Init.ComboMenu["useQ"].Cast<CheckBox>().CurrentValue)
                    Spells.CastQkill(target);

                //if (Spells.E.IsReady() && Init.ComboMenu["useE"].Cast<CheckBox>().CurrentValue)
                  //  Spells.CastEq();
            }

            else if (tHp < Player.GetSpellDamage(target, SpellSlot.R) &&
                     Spells.R.IsReady() && Init.ComboMenu["useR"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastRkill(target);
            }

            else if (tHp < Helpers.Rdmg(target) + Player.GetSpellDamage(target, SpellSlot.Q) &&
                     Spells.R.IsReady() && Spells.Q.IsReady() && Init.ComboMenu["useQR"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastQrCombo(target);
            }

            else
            {
                if (Spells.Q.IsReady() && Init.ComboMenu["useQ"].Cast<CheckBox>().CurrentValue)
                    Spells.CastCollisionQ(target);
                if (!target.CanMove)
                    Spells.CastSimpleQ(target);

                if (Init.ComboMenu["useW"].Cast<CheckBox>().CurrentValue)
                {
                    if (Spells.W.IsReady())
                        Spells.CastWGrass();
                    Spells.CastWslow(target);
                }
            }

            if (Init.ComboMenu["useE"].Cast<CheckBox>().CurrentValue)
                if (Spells.E.IsReady())
                    Spells.CastE();
        }

        public static void Ks()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(Player) < 2000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(1500, DamageType.Physical);

            if (!target.IsValidTarget() ||
                Player.IsDashing() || target.HasBuffOfType(BuffType.Invulnerability)
                || target.IsDead || target.IsZombie || Orbwalker.IsAutoAttacking)
                return;

            var tHp = target.Health + 20;

            if (tHp < Player.GetSpellDamage(target, SpellSlot.W) &&
                Spells.W.IsReady() && Init.ComboMenu["useW"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastWkill(target);
            }

            else if (tHp < Player.GetSpellDamage(target, SpellSlot.Q) &&
                     Spells.Q.IsReady())
            {
                if (Init.ComboMenu["useQ"].Cast<CheckBox>().CurrentValue)
                    Spells.CastQkill(target);

                //if (Spells.E.IsReady() && Init.ComboMenu["useE"].Cast<CheckBox>().CurrentValue)
                  //  Spells.CastEq();
            }

            else if (tHp < Player.GetSpellDamage(target, SpellSlot.R) &&
                     Spells.R.IsReady() && Init.ComboMenu["useR"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastRkill(target);
            }

            else if (tHp < Helpers.Rdmg(target) + Player.GetSpellDamage(target, SpellSlot.Q) &&
                     Spells.R.IsReady() && Spells.Q.IsReady() && Init.ComboMenu["useQR"].Cast<CheckBox>().CurrentValue)
            {
                Spells.CastQrCombo(target);
            }
        }
    }
}