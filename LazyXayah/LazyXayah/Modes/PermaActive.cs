using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Settings = LazyXayah.Config.MiscMenu;

namespace LazyXayah.Modes
{
    public sealed class PermActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.HasBuff("recall") && !Player.Instance.IsDead;
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                foreach (var t in EntityManager.Heroes.Enemies)
                {
                    if (Settings.miscMenu["Misc.UseE" + t.ChampionName].Cast<CheckBox>().CurrentValue)
                    {
                        SpellManager.CastEstun(t);
                    }

                    if (Settings.KSE)
                    {
                        SpellManager.CastEkill(t);
                    }

                    if (Settings.miscMenu["Misc.UseR" + t.ChampionName].Cast<CheckBox>().CurrentValue)
                    {
                        SpellManager.CastRkillable(t);
                    }
                }

                SpellManager.CastEmultiStun(Settings.AOEE);

                SpellManager.CastRAOE(Settings.AOER);
            }
        }
    }
}
