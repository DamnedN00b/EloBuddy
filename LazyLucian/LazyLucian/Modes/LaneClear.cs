using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using Settings = LazyLucian.Config.Modes.LaneClear;

namespace LazyLucian.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady() && Program.Player.ManaPercent >= Settings.UseQmana &&
                !(Settings.SpellWeaving &&
                  (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() ||
                   Orbwalker.IsAutoAttacking)))
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Program.Player.ServerPosition, SpellManager.Q1.Range);
                var aiMinions = minions as Obj_AI_Minion[] ?? minions.ToArray();

                foreach (var m in from m in aiMinions
                    let p = new Geometry.Polygon.Rectangle((Vector2) Program.Player.ServerPosition,
                        Program.Player.ServerPosition.Extend(m.ServerPosition, SpellManager.Q1.Range), 65)
                    where aiMinions.Count(x =>
                        p.IsInside(x.ServerPosition)) >= 3
                    select m)
                {
                    SpellManager.Q.Cast(m);
                    break;
                }
            }

            if (!Settings.UseW || !W.IsReady() || !(Program.Player.ManaPercent >= Settings.UseWmana) ||
                Settings.SpellWeaving &&
                (Program.Player.HasBuff("LucianPassiveBuff") || Program.Player.IsDashing() || Orbwalker.IsAutoAttacking))
                return;
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Program.Player.ServerPosition, SpellManager.W.Range)
                        .Where(m => m.IsValidTarget(SpellManager.W.Range))
                        .OrderBy(m => m.Distance(Program.Player.ServerPosition))
                        .ToList();
                if (minions.Any())
                {
                    SpellManager.W.Cast(minions.FirstOrDefault());
                }
            }
        }
    }
}