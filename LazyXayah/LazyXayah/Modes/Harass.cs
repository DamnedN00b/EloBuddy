using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using Settings = LazyXayah.Config.HarassMenu;

namespace LazyXayah.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
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

                if (Player.Instance.ManaPercent < Settings.Emana)
                {
                    return;
                }

                foreach (var t in EntityManager.Heroes.Enemies)
                {
                    if (Settings.harassMenu["Harass.UseE" + t.ChampionName].Cast<CheckBox>().CurrentValue)
                    {
                        SpellManager.CastEstun(t);
                    }

                    if (Settings.KSE)
                    {
                        SpellManager.CastEkill(t);
                    }
                }

                SpellManager.CastEmultiStun(Settings.AOEE);
            }
        }
    }
}
