using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using DrawSettings = LazyXayah.Config.DrawMenu;
using SkinSettings = LazyXayah.Config.SkinMenu;

// ReSharper disable IdentifierWordIsNotInDictionary

// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyXayah
{
    internal static class Events
    {
        public static HashSet<Obj_AI_Base> FeatherList = new HashSet<Obj_AI_Base>();
        public static HashSet<Geometry.Polygon.Rectangle> FeatherPolys = new HashSet<Geometry.Polygon.Rectangle>();

        static Events()
        {
            Game.OnUpdate += delegate
            {
                FeatherPolys = new HashSet<Geometry.Polygon.Rectangle>();

                FeatherList.RemoveWhere(x => !x.IsAlive());

                foreach (var obj in FeatherList)
                {
                    FeatherPolys.Add(new Geometry.Polygon.Rectangle(Player.Instance.ServerPosition, obj.ServerPosition, 60));
                }
            };

            GameObject.OnCreate += delegate(GameObject sender, EventArgs args)
            {
                if (sender != null && !sender.IsEnemy)
                {
                    var obj = sender as Obj_AI_Base;
                    if (obj != null && obj.Name == ("Feather"))
                    {
                        FeatherList.Add(obj);
                    }
                }
            };

            GameObject.OnDelete += delegate(GameObject sender, EventArgs args)
            {
                if (sender != null && !sender.IsEnemy)
                {
                    var obj = sender as Obj_AI_Base;
                    if (obj != null && obj.Name == ("Feather"))
                    {
                        FeatherList.RemoveWhere(x => x.NetworkId == obj.NetworkId);
                        FeatherList.RemoveWhere(x => !x.IsAlive());
                    }
                }
            };

            Drawing.OnDraw += delegate
            {
                if (DrawSettings.Disable)
                {
                    return;
                }

                foreach (var f in FeatherList)
                {
                    var pposX = Player.Instance.ServerPosition.WorldToScreen().X;
                    var pposY = Player.Instance.ServerPosition.WorldToScreen().Y;
                    var fposX = f.ServerPosition.WorldToScreen().X;
                    var fposY = f.ServerPosition.WorldToScreen().Y;

                    if (SkinSettings.SkinId == 0)
                    {
                        Drawing.DrawCircle(f.Position, 50, Color.Purple);
                        if (DrawSettings.Lines)
                        {
                            Drawing.DrawLine(pposX, pposY, fposX, fposY, 3, Color.Purple);
                        }
                    }
                    else
                    {
                        Drawing.DrawCircle(f.Position, 50, Color.MediumBlue);
                        if (DrawSettings.Lines)
                        {
                            Drawing.DrawLine(pposX, pposY, fposX, fposY, 3, Color.MediumBlue);
                        }
                    }
                }

                foreach (var p in FeatherPolys.Where(p => DrawSettings.Polys))
                {
                    p.Draw(SkinSettings.SkinId == 0 ? Color.Purple : Color.MediumBlue);
                }

                if (DrawSettings.Mode == 1)
                {
                    if (DrawSettings.Q)
                    {
                        Circle.Draw(SpellManager.Q.IsReady() ? SharpDX.Color.Green : SharpDX.Color.Red, SpellManager.Q.Range,
                            Player.Instance.Position);
                    }

                    if (DrawSettings.W)
                    {
                        Circle.Draw(SpellManager.W.IsReady() ? SharpDX.Color.Green : SharpDX.Color.Red, SpellManager.W.Range,
                            Player.Instance.Position);
                    }

                    if (DrawSettings.E)
                    {
                        Circle.Draw(SpellManager.E.IsReady() ? SharpDX.Color.Green : SharpDX.Color.Red, SpellManager.E.Range,
                            Player.Instance.Position);
                    }

                    if (DrawSettings.R)
                    {
                        Circle.Draw(SpellManager.R.IsReady() ? SharpDX.Color.Green : SharpDX.Color.Red, SpellManager.R.Range,
                            Player.Instance.Position);
                    }
                }
                else if (DrawSettings.Mode == 0)
                {
                    if (DrawSettings.Q)
                    {
                        if (SpellManager.Q.IsReady())
                        {
                            Circle.Draw(SharpDX.Color.DarkBlue, SpellManager.Q.Range, Player.Instance.Position);
                        }
                    }

                    if (DrawSettings.W)
                    {
                        if (SpellManager.W.IsReady())
                        {
                            Circle.Draw(SharpDX.Color.DarkBlue, SpellManager.W.Range, Player.Instance.Position);
                        }
                    }

                    if (DrawSettings.E)
                    {
                        if (SpellManager.E.IsReady())
                        {
                            Circle.Draw(SharpDX.Color.DarkBlue, SpellManager.E.Range, Player.Instance.Position);
                        }
                    }

                    if (DrawSettings.R)
                    {
                        if (SpellManager.R.IsReady())
                        {
                            Circle.Draw(SharpDX.Color.DarkBlue, SpellManager.R.Range, Player.Instance.Position);
                        }
                    }
                }
            };
        }

        public static void Initialize()
        {
        }
    }
}
