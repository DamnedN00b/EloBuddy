using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = LazyIllaoi2._0.Config.Modes.Harass;

namespace LazyIllaoi2._0.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            Obj_AI_Base enemyQ = TargetSelector.GetTarget(Q.Range, DamageType.Physical);

            if (Events.Ghost != null && enemyQ == null)
            {
                enemyQ = Events.Ghost;
            }

            Obj_AI_Base enemyW = TargetSelector.GetTarget(W.Range, DamageType.Physical);

            if (Events.Ghost != null && enemyW == null)
            {
                enemyW = Events.Ghost;
            }

            var enemyE = TargetSelector.GetTarget(E.Range, DamageType.Physical);

            if (Q.IsReady() && Settings.useQ && Player.Instance.ManaPercent > Settings.useQmana)
            {
                if (enemyQ != null)
                {
                    if (enemyQ.IsKillable())
                    {
                        var predPos = Q.GetPrediction(enemyQ);

                        if (Settings.useQmode == 1)
                        {
                            if (Events.Ghost != null)
                            {
                                var qPoly = new Geometry.Polygon.Rectangle((Vector2)Player.Instance.ServerPosition,
                                    Player.Instance.ServerPosition.Extend(Events.Ghost.ServerPosition,
                                        SpellManager.Q.Range), Q.Width);

                                if (qPoly.IsInside(predPos.CastPosition))
                                {
                                    SpellManager.Q.Cast(predPos.CastPosition);
                                }
                            }
                        }

                        if (Settings.useQmode == 0 || (!E.IsReady() && Events.Ghost == null))
                        {
                            SpellManager.Q.Cast(predPos.CastPosition);
                        }
                    }
                }
            }

            if (SpellManager.W.IsReady() && Settings.useW && Player.Instance.ManaPercent > Settings.useWmana &&
                Settings.useWmode == 0)
            {
                if (enemyW != null)
                {
                    if (enemyW.IsKillable())
                    {
                        if (Settings.useWtentacles)
                        {
                            if (enemyW.ServerPosition.IsInTentacleRange())
                            {
                                SpellManager.W.Cast();
                            }
                        }

                        else
                        {
                            SpellManager.W.Cast();
                        }
                    }
                }
            }

            if (!SpellManager.E.IsReady() || !Settings.useE || !(Player.Instance.ManaPercent > Settings.useEmana))
                return;

            if (enemyE == null) return;
            {
                var predPos = SpellManager.E.GetPrediction(enemyE);

                if (enemyE.IsKillable())
                {
                    SpellManager.E.Cast(predPos.CastPosition);
                }
            }
        }
    }
}