using System;
using EloBuddy;
using EloBuddy.SDK;

namespace LazyYorick.Modes
{
    public sealed class PermActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return !Player.Instance.IsRecalling();
        }

        public override void Execute()
        {
            if (Events.Graves.Count >= 3 && Q.IsReady() //&& Settings.UseQghoulsAuto
                )
            {
                Q.Cast();
            }

            if (W.IsReady())
            {
                if ( //Settings.UseWself && Program.Player.ManaPercent >= Settings.UseWselfMana &&
                    Player.Instance.HealthPercent <= 20 //Settings.UseWselfMana 
                    && Player.Instance.CountEnemiesInRange(SpellManager.W.Width) > 1)
                {
                    W.Cast(Player.Instance.ServerPosition);
                }
            }
            
        }
    }
}