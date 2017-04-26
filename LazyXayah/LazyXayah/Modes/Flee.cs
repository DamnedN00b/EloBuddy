using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using Settings = LazyXayah.Config.FleeMenu;

namespace LazyXayah.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var target = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsKillable(SpellManager.Q.Range));

            if (target != null)
            {
                if (SpellManager.Q.IsReady() && Settings.UseQ)
                {
                    var pred = Q.GetPrediction(target);
                    if (pred.HitChance > HitChance.Low)
                    {
                        SpellManager.Q.Cast(target);
                    }
                }

                if (SpellManager.E.IsReady() && Settings.UseE)
                {
                    SpellManager.CastEstun(target);
                }
            }
        }
    }
}
