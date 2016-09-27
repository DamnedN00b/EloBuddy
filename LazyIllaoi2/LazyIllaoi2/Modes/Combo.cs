using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = LazyIllaoi2.Config.Modes.Combo;

namespace LazyIllaoi2.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
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
                        var predPos = SpellManager.Q.GetPrediction(enemyQ);

                        if (Settings.useQmode == 1)
                        {
                            if (Events.Ghost != null)
                            {
                                var qPoly = new Geometry.Polygon.Rectangle((Vector2)Player.Instance.ServerPosition,
                                    Player.Instance.ServerPosition.Extend(Events.Ghost.ServerPosition,
                                        Q.Range), Q.Width);

                                if (qPoly.IsInside(predPos.CastPosition))
                                {
                                    Q.Cast(predPos.CastPosition);
                                }
                            }
                        }

                        if (Settings.useQmode == 0 || (!E.IsReady() && Events.Ghost == null))
                        {
                            Q.Cast(predPos.CastPosition);
                        }
                    }
                }
            }

            if (W.IsReady() && Settings.useW && Player.Instance.ManaPercent > Settings.useWmana &&
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
                                W.Cast();
                            }
                        }

                        else
                        {
                            W.Cast();
                        }
                    }
                }
            }

            if (E.IsReady() && Settings.useE && Player.Instance.ManaPercent > Settings.useEmana)
            {
                if (enemyE == null) return;
                {
                    var predPos = SpellManager.E.GetPrediction(enemyE);

                    if (enemyE.IsKillable())
                    {
                        E.Cast(predPos.CastPosition);
                    }
                }
            }

            if (!R.IsReady() || !Settings.useR || !(Player.Instance.ManaPercent > Settings.useRmana) ||
                Player.Instance.CountEnemiesInRange(R.Range) < Settings.useRenemySlider) return;
            {
                if (Events.Ghost != null && Settings.useRmode == 1)
                {
                    Chat.Print("case 2");

                    if (Player.Instance.ServerPosition.Distance(Events.Ghost.ServerPosition) <= R.Range)
                        Chat.Print("case 3");
                    R.Cast();
                }

                if (Settings.useRmode == 0)
                {
                    R.Cast();
                }
            }
        }
    }
}