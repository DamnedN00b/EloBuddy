using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using Settings = LazyXayah.Config.ComboMenu;

// ReSharper disable IdentifierWordIsNotInDictionary

namespace LazyXayah.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                if (Settings.UseQ && Player.Instance.ManaPercent > Settings.Qmana)
                {
                    if (Settings.QHC == 0)
                    {
                        SpellManager.CastQ(HitChance.Low);
                    }
                    if (Settings.QHC == 1)
                    {
                        SpellManager.CastQ(HitChance.Medium);
                    }
                    if (Settings.QHC == 2)
                    {
                        SpellManager.CastQ(HitChance.High);
                    }
                }
                if (Settings.UseW && Player.Instance.ManaPercent > Settings.Wmana)
                {
                    SpellManager.CastW();
                }

                foreach (var t in EntityManager.Heroes.Enemies)
                {
                    if (Settings.comboMenu["Combo.UseR" + t.ChampionName].Cast<CheckBox>().CurrentValue)
                    {
                        SpellManager.CastRkillable(t);
                    }

                    if (Player.Instance.ManaPercent < Settings.Emana)
                    {
                        return;
                    }

                    if (Settings.comboMenu["Combo.UseE" + t.ChampionName].Cast<CheckBox>().CurrentValue)
                    {
                        SpellManager.CastEstun(t);
                    }

                    if (Settings.KSE)
                    {
                        SpellManager.CastEkill(t);
                    }
                }

                if (Player.Instance.ManaPercent > Settings.Emana)
                {
                    SpellManager.CastEmultiStun(Settings.AOEE);
                }

                SpellManager.CastRAOE(Settings.AOER);
            }
        }
    }
}
