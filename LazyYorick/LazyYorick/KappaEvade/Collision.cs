using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
// ReSharper disable StringLiteralsWordIsNotInDictionary
// ReSharper disable IdentifierWordIsNotInDictionary

namespace LazyYorick.KappaEvade
{
    internal class Collision
    {
        public static List<KappaEvade.ActiveSpells> NewSpells = new List<KappaEvade.ActiveSpells>();

        public static GameObject YasuoWall;

        public static void Init()
        {
            Game.OnTick += Game_OnTick;
            GameObject.OnCreate += delegate (GameObject sender, EventArgs args)
            {
                if (sender.IsAlly)
                {
                    if (sender.Name.Contains("Yasuo_Base_W_windwall") && !sender.Name.Contains("_activate.troy"))
                    {
                        YasuoWall = sender;
                    }
                }
            };
            GameObject.OnDelete += delegate (GameObject sender, EventArgs args)
            {
                if (sender.IsAlly)
                {
                    if (sender.Name.Contains("Yasuo_Base_W_windwall") && !sender.Name.Contains("_activate.troy"))
                    {
                        YasuoWall = null;
                    }
                }
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        private static void Game_OnTick(EventArgs args)
        {
            var objects = new List<Obj_AI_Base>();
            objects.Clear();
            NewSpells.Clear();
            foreach (var spell in KappaEvade.DetectedSpells)
            {
                var range = spell.Range;
                var endpos = spell.End;
                var poly = spell.ToPolygon();
                objects.AddRange(EntityManager.Heroes.AllHeroes.OrderBy(s => s.Distance(spell.Start)).Where(o => o != null && o.Team != spell.Caster.Team && o.IsValidTarget() && poly.IsInside(o) && spell.Spell.Collisions.Contains(Database.SkillShotSpells.Collision.Heros)));
                objects.AddRange(EntityManager.MinionsAndMonsters.Combined.OrderBy(s => s.Distance(spell.Start)).Where(o => o != null && o.Team != spell.Caster.Team && o.IsValidTarget() && poly.IsInside(o) && spell.Spell.Collisions.Contains(Database.SkillShotSpells.Collision.Minions)));
                objects.AddRange(EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderBy(s => s.Distance(spell.Start)).Where(o => o != null && o.Team != spell.Caster.Team && o.IsValidTarget() && poly.IsInside(o) && spell.Spell.Collisions.Contains(Database.SkillShotSpells.Collision.Minions)));
                if (spell.Spell.Collisions.Contains(Database.SkillShotSpells.Collision.YasuoWall) && YasuoWall != null)
                {
                    objects.Add((Obj_AI_Base)YasuoWall);
                }
                var collide = objects.OrderBy(o => o.Distance(spell.Start)).FirstOrDefault(o => o != null && o.IsValidTarget() && new Geometry.Polygon.Circle(o.ServerPosition, o.BoundingRadius + o.BoundingRadius * 0.15f).Points.Any(p => poly.IsInside(p)));

                if (collide != null)
                {
                    range = collide.Distance(spell.Start);
                    endpos = spell.Start.Extend(spell.End, range).To3D();
                }

                var newspell = new KappaEvade.ActiveSpells { Spell = spell.Spell, ArriveTime = spell.ArriveTime, Caster = spell.Caster, Range = range, End = endpos, Start = spell.Start, Width = spell.Width, Missile = spell.Missile, EndTime = spell.EndTime };
                NewSpells.Add(newspell);
            }
            NewSpells.RemoveAll(s => Game.Time - s.EndTime > 0);
        }
    }
}
