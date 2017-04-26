using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyXayah.Config.JungleClearMenu;

namespace LazyXayah.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                var monster = EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(x => x.IsValidTarget(Player.Instance.GetAutoAttackRange(x)));

                if (monster != null)
                {
                    if (Settings.UseQ && SpellManager.Q.IsReady() && Player.Instance.ManaPercent > Settings.Qmana)
                    {
                        SpellManager.Q.Cast(monster);
                    }
                    if (Settings.UseW && SpellManager.W.IsReady() && Player.Instance.ManaPercent > Settings.Wmana)
                    {
                        SpellManager.W.Cast();
                    }
                }
            }
        }
    }
}
