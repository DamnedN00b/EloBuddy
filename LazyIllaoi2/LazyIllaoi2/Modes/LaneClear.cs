using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIllaoi2.Config.Modes.LaneClear;

namespace LazyIllaoi2.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Q.IsReady() && Settings.useQ && Player.Instance.ManaPercent > Settings.useQmana)
            {
                
                    Q.CastOnBestFarmPosition(Settings.useQminions);
            }

            if (W.IsReady() && Settings.useW && Player.Instance.ManaPercent > Settings.useQmana && Settings.useWmode == 0)
            {
                var minion = EntityManager.MinionsAndMonsters.EnemyMinions.FirstOrDefault(x => x.IsKillable(W.Range));
                if (minion != null && (Settings.useWtentacles && minion.ServerPosition.IsInTentacleRange()))
                {
                    SpellManager.W.Cast();
                }
                else if (minion != null && !Settings.useWtentacles)
                {
                    SpellManager.W.Cast();
                }
            }
        }
    }
}