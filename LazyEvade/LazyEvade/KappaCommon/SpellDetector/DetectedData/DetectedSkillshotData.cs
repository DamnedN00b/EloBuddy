using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using LazyEvade.KappaCommon.Databases.SpellData;
using LazyEvade.KappaCommon.Utility;
using SharpDX;
using Type = LazyEvade.KappaCommon.Databases.SpellData.Type;

namespace LazyEvade.KappaCommon.SpellDetector.DetectedData
{
    public class DetectedSkillshotData
    {
        public Obj_AI_Base Caster;
        public Obj_AI_Base Target;
        public MissileClient Missile;
        public SkillshotData Data;
        public Vector2 Start;
        public Vector2 End;
        public Vector2 Direction => (this.End - this.Start).Normalized();
        public Vector2? CollidePoint;
        public Obj_AI_Base CollideTarget;
        public Obj_AI_Base[] CollideTargets;
        public bool DetectedMissile => this.Missile != null;

        public bool IsGlobal
        {
            get
            {
                return this.Data.Range >= 4000;
            }
        }

        public bool IsVisible
            => CurrentPosition.IsOnScreen() || CurrentPosition.IsInRange(Player.Instance, 5000) || CollideEndPosition.IsOnScreen() || CollideEndPosition.IsInRange(Player.Instance, 5000);

        public float MaxTravelTime(Vector2 target)
        {
            return (this.Start.Distance(target) / this.Data.Speed * 1000f) + this.Data.CastDelay + this.Data.ExtraDuration;
        }
        public float MaxTravelTime(Obj_AI_Base target)
        {
            return this.MaxTravelTime(target.ServerPosition.To2D());
        }

        public float TravelTime(Vector2 target)
        {
            var correct = (this.CurrentPosition.Distance(target) / this.Data.Speed * 1000f) + this.Data.CastDelay;
            if (this.DetectedMissile)
                return correct;

            return correct - this.TicksPassed;
        }

        public float TravelTime(Obj_AI_Base target)
        {
            return this.TravelTime(target.ServerPosition.To2D());
        }

        public float TimeToCollide => this.TravelTime(this.CollideEndPosition);
        public float StartTick;
        public float EndTick => this.StartTick + this.MaxTravelTime(this.CollideEndPosition);
        public float TicksLeft => this.EndTick - Core.GameTickCount;
        public float TicksPassed => Core.GameTickCount - this.StartTick;
        public bool Ended => (Core.GameTickCount - this.EndTick > 0 || TicksPassed > 66666) || (DetectedMissile && this.Missile.IsDead) || this.Target != null && this.Target.IsDead;

        public bool WillHit(Obj_AI_Base target, float time = -1f)
        {
            if (!target.IsValidTarget())
                return false;

            time = time.Equals(-1) ? Math.Max(this.TravelTime(target), 0) : time;
            var pred = target.PredictPosition((int)time);
            return this.WillHit(pred.To2D());
        }
        public bool WillHit(Vector2 target)
        {
            if (!target.IsValid())
                return false;

            return this.Polygon != null && this.Polygon.IsInside(target);
        }

        public Vector2 CurrentPosition
        {
            get
            {
                if (this.DetectedMissile)
                {
                    if (this.Data.SticksToMissile)
                    {
                        return this.Missile.Position.Extend(this.Start, -this.Data.Width / 2f);
                    }
                }
                if (this.Caster != null)
                {
                    if (this.Data.SticksToCaster)
                    {
                        return this.Caster.ServerPosition.To2D();
                    }
                }
                if (this.Target != null)
                {
                    if (this.Data.StartsFromTarget)
                    {
                        return this.Target.ServerPosition.To2D();
                    }
                }

                if (this.Data.StaticStart)
                {
                    return this.Start;
                }

                return this.Start;
            }
        }

        public Vector2 EndPosition
        {
            get
            {
                var endpos = Vector2.Zero;

                if (this.Data.DodgeFrom != null && this.Data.DodgeFrom.Any())
                {
                    var obj = ObjectManager.Get<Obj_GeneralParticleEmitter>().FirstOrDefault(o => o.IsValid && this.Data.DodgeFrom.Contains(o.Name));
                    if (obj != null)
                    {
                        endpos = obj.Position.To2D();
                    }
                }

                if (this.Caster != null)
                {
                    var direction = (this.Caster.Direction().Distance(this.Caster) < 100 ? this.Caster.Direction() : this.Caster.Path.LastOrDefault().To2D());
                    if (this.Data.EndIsCasterDirection)
                    {
                        endpos = direction;
                    }
                    if (this.Data.EndSticksToCaster)
                    {
                        endpos = this.Caster.ServerPosition.To2D();
                    }
                    if (this.Data.SpellName.Equals("SionR"))
                    {
                        this.Data.Speed = this.Caster.MoveSpeed;
                        endpos = this.CurrentPosition.Extend(this.Start, -this.Data.Range);
                    }
                    if (this.Data.SticksToCaster)
                    {
                        if (this.Data.SpellName == "TaricE")
                        {
                            return this.CurrentPosition + this.Direction * this.Data.Range;
                        }
                    }
                }

                if (this.DetectedMissile)
                {
                    if (this.Data.EndSticksToMissile)
                    {
                        endpos = this.Missile.Position.To2D();
                    }
                }

                if (this.Target != null)
                {
                    if (!string.IsNullOrEmpty(this.Data.TargetName) && this.Target.Name.Equals(this.Data.TargetName))
                    {
                        endpos = this.Target.Position.To2D();
                    }
                }

                if (endpos.IsZero)
                {
                    endpos = this.Start.Distance(this.End) > this.Data.Range ? this.Start.Extend(this.End, this.Data.Range) : this.End;
                }
                Vector2 result;

                if (this.Data.IsFixedRange)
                {
                    result = this.Start.Extend(endpos, this.Data.Range);
                }
                else
                {
                    result = this.Data.ExtraRange > 0 && this.Data.ExtraRange < float.MaxValue && this.Data.ExtraRange < int.MaxValue ? endpos.Extend(this.Start, -this.Data.ExtraRange) : endpos;
                }

                if (IsGlobal && this.Data.type == Type.LineMissile)
                {
                    result = this.CurrentPosition + this.Direction * (this.Data.Range / 2f);
                }

                if (this.Data.StaticEnd)
                {
                    result = this.End;
                }

                return result;
            }
        }

        public Vector2 CollideEndPosition
        {
            get
            {
                if (this.CollidePoint.HasValue)
                {
                    return this.CollidePoint.Value;
                }

                return this.EndPosition;
            }
        }

        public Geometry.Polygon Polygon
        {
            get
            {
                var extraWidth = Player.Instance.BoundingRadius / 2f;
                var width = this.Data.Width + extraWidth;
                if (this.Data.type == Type.LineMissile)
                {
                    return new Geometry.Polygon.Rectangle(this.CurrentPosition, this.CollideEndPosition, width);
                }
                if (this.Data.type == Type.CircleMissile)
                {
                    return new Geometry.Polygon.Circle(this.CollideEndPosition, width);
                }
                if (this.Data.type == Type.Cone)
                {
                    return new Geometry.Polygon.Sector(this.CurrentPosition, this.CollideEndPosition, (float)(this.Data.Angle * Math.PI / 180), this.Data.Range);
                }
                if (this.Data.type == Type.Ring)
                {
                    return new CustomGeometry.Ring(CollideEndPosition, width, this.Data.RingRadius).ToSDKPolygon();
                }
                if (this.Data.type == Type.Arc)
                {
                    return new CustomGeometry.Arc(CurrentPosition, CollideEndPosition, (int)ObjectManager.Player.BoundingRadius).ToSDKPolygon();
                }
                return null;
            }
        }

        public Geometry.Polygon OriginalPolygon
        {
            get
            {
                var extraWidth = Player.Instance.BoundingRadius / 2f;
                var width = this.Data.Width + extraWidth;
                if (this.Data.type == Type.LineMissile)
                {
                    return new Geometry.Polygon.Rectangle(this.CurrentPosition, this.EndPosition, width);
                }
                if (this.Data.type == Type.CircleMissile)
                {
                    return new Geometry.Polygon.Circle(this.EndPosition, width);
                }
                if (this.Data.type == Type.Cone)
                {
                    return new Geometry.Polygon.Sector(this.CurrentPosition, this.End, (float)(this.Data.Angle * Math.PI / 180), this.Data.Range);
                }
                return null;
            }
        }
    }
}
