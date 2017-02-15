using System;
using EloBuddy.SDK;
using SharpDX;

namespace LazyEvade.KappaCommon.Utility
{
    public class CustomGeometry
    {
        public class Arc
        {
            public Vector2 Start { get; }
            public Vector2 End { get; }

            public int HitBox { get; }
            private float Distance { get; }

            public Arc(Vector2 start, Vector2 end, int hitbox)
            {
                this.Start = start;
                this.End = end;
                this.HitBox = hitbox;
                this.Distance = this.Start.Distance(this.End);
            }

            public Geometry.Polygon ToSDKPolygon(int offset = 0)
            {
                offset += this.HitBox;
                var result = new Geometry.Polygon();

                var innerRadius = -0.1562f * this.Distance + 687.31f;
                var outerRadius = 0.35256f * this.Distance + 133f;

                outerRadius = outerRadius / (float)Math.Cos(2 * Math.PI / 22);

                var innerCenters = CircleCircleIntersection(this.Start, this.End, innerRadius, innerRadius);
                var outerCenters = CircleCircleIntersection(this.Start, this.End, outerRadius, outerRadius);

                var innerCenter = innerCenters[0];
                var outerCenter = outerCenters[0];

                var direction = (this.End - outerCenter).Normalized();
                var end = (this.Start - outerCenter).Normalized();
                var maxAngle = (float)(direction.AngleBetween(end) * Math.PI / 180);

                var step = -maxAngle / 22;
                for (var i = 0; i < 22; i++)
                {
                    var angle = step * i;
                    var point = outerCenter + (outerRadius + 15 + offset) * direction.Rotated(angle);
                    result.Add(point);
                }

                direction = (this.Start - innerCenter).Normalized();
                end = (this.End - innerCenter).Normalized();
                maxAngle = (float)(direction.AngleBetween(end) * Math.PI / 180);
                step = maxAngle / 22;
                for (var i = 0; i < 22; i++)
                {
                    var angle = step * i;
                    var point = innerCenter + Math.Max(0, innerRadius - offset - 100) * direction.Rotated(angle);
                    result.Add(point);
                }

                return result;
            }
        }

        public class Ring
        {
            public Vector2 Center;
            public float Radius;
            public float RingRadius;

            public Ring(Vector2 center, float radius, float ringRadius)
            {
                this.Center = center;
                this.Radius = radius;
                this.RingRadius = ringRadius;
            }

            public Geometry.Polygon ToSDKPolygon(int offset = 0)
            {
                var result = new Geometry.Polygon();

                var outRadius = (offset + this.Radius + this.RingRadius) / (float)Math.Cos(2 * Math.PI / 22);
                var innerRadius = this.Radius - this.RingRadius - offset;

                for (var i = 0; i <= 22; i++)
                {
                    var angle = i * 2 * Math.PI / 22;
                    var point = new Vector2(this.Center.X - outRadius * (float)Math.Cos(angle), this.Center.Y - outRadius * (float)Math.Sin(angle));
                    result.Add(point);
                }

                for (var i = 0; i <= 22; i++)
                {
                    var angle = i * 2 * Math.PI / 22;
                    var point = new Vector2(this.Center.X + innerRadius * (float)Math.Cos(angle), this.Center.Y - innerRadius * (float)Math.Sin(angle));
                    result.Add(point);
                }

                return result;
            }
        }

        public static Vector2[] CircleCircleIntersection(Vector2 center1, Vector2 center2, float radius1, float radius2)
        {
            var D = center1.Distance(center2);
            if (D > radius1 + radius2 || (D <= Math.Abs(radius1 - radius2)))
            {
                return new Vector2[] { };
            }

            var A = (radius1 * radius1 - radius2 * radius2 + D * D) / (2 * D);
            var H = (float)Math.Sqrt(radius1 * radius1 - A * A);
            var Direction = (center2 - center1).Normalized();
            var PA = center1 + A * Direction;
            var S1 = PA + H * Direction.Perpendicular();
            var S2 = PA - H * Direction.Perpendicular();
            return new[] { S1, S2 };
        }
    }
}
