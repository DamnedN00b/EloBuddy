using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = LazyIllaoi2.Config.Modes.JungleClear;

namespace LazyIllaoi2.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Q.IsReady() && Settings.useQ && Player.Instance.ManaPercent > Settings.useQmana)
            {
                var monster = EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(x => x.IsKillable(Q.Range));
                {
                    if (monster != null)
                        Q.Cast(monster.ServerPosition);
                }
            }

            if (W.IsReady() && Settings.useW && Settings.useWmode == 0 &&
                Player.Instance.ManaPercent > Settings.useQmana)
            {
                var monster = EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(x => x.IsKillable(W.Range));
                if (monster != null && (Settings.useWtentacles && monster.ServerPosition.IsInTentacleRange()))
                {
                    SpellManager.W.Cast();
                }
                else if (monster != null && !Settings.useWtentacles)
                {
                    SpellManager.W.Cast();
                }
            }
        }
    }
}