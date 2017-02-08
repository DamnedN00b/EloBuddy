using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
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
            Obj_AI_Base enemyW = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var enemyE = TargetSelector.GetTarget(E.Range, DamageType.Physical);

            if (Events.Ghost != null && enemyQ == null)
            {
                if (Events.Ghost.Distance(Player.Instance.ServerPosition) < Q.Range)
                {
                    enemyQ = Events.Ghost;
                }
            }

            if (Events.Ghost != null && enemyW == null)
            {
                if (Events.Ghost.Distance(Player.Instance.ServerPosition) < W.Range)
                {
                    enemyW = Events.Ghost;
                }
            }

            
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
                                var qPoly = new Geometry.Polygon.Rectangle((Vector2) Player.Instance.ServerPosition,
                                    Player.Instance.ServerPosition.Extend(Events.Ghost.ServerPosition,
                                        Q.Range), Q.Width);

                                if (qPoly.IsInside(predPos.CastPosition) && predPos.HitChance >= HitChance.Medium)
                                {
                                    Q.Cast(predPos.CastPosition);
                                }
                            }
                        }

                        if (Settings.useQmode == 0 || (!E.IsReady() && Events.Ghost == null) && predPos.HitChance >= HitChance.Medium)
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
                if (enemyE == null)
                {
                    return;
                }
                {
                    var predPos = SpellManager.E.GetPrediction(enemyE);

                    if (enemyE.IsKillable() && predPos.HitChance > HitChance.Medium)
                    {
                        SpellManager.E.Cast(predPos.CastPosition);
                    }
                }
            }

            if (!R.IsReady() || !Settings.useR || !(Player.Instance.ManaPercent > Settings.useRmana) ||
                Player.Instance.CountEnemyChampionsInRange(R.Range) < Settings.useRenemySlider)
            {
                return;
            }
            {
                if (Events.Ghost != null && Settings.useRmode == 1)
                {
                    if (Player.Instance.ServerPosition.Distance(Events.Ghost.ServerPosition) <= R.Range)
                    {
                        R.Cast();
                    }
                }

                if (Settings.useRmode == 0)
                {
                    R.Cast();
                }
            }
        }
    }
}
