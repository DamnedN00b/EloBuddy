using EloBuddy.SDK;
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
                if (Settings.UseQ)
                {
                    SpellManager.CastQ();
                }
                if (Settings.UseW)
                {
                    SpellManager.CastW();
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
