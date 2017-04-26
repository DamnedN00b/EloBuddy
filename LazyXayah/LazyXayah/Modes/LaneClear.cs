using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = LazyXayah.Config.LaneClearMenu;

namespace LazyXayah.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (!Orbwalker.IsAutoAttacking)
            {
                if (Settings.UseQ && SpellManager.Q.IsReady() && Player.Instance.ManaPercent > Settings.Qmana)
                {
                    SpellManager.Q.CastOnBestFarmPosition();
                }

                if (!Settings.UseE || !SpellManager.E.IsReady() || Player.Instance.ManaPercent < Settings.Emana)
                {
                    return;
                }

                var minions = new HashSet<Obj_AI_Minion>();

                foreach (var m in EntityManager.MinionsAndMonsters.EnemyMinions.Where(x => x.IsValidTarget(SpellManager.E.Range) && Misc.EDmg(x) > x.Health))
                {
                    minions.Add(m);
                }

                if (minions.Count >= Settings.Eminions)
                {
                    SpellManager.E.Cast();
                }
            }
        }
    }
}
