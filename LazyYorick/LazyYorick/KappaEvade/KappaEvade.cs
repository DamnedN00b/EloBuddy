using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;
// ReSharper disable IdentifierWordIsNotInDictionary
// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyYorick.KappaEvade
{
    internal static class KappaEvade
    {
        public static void Init()
        {
            Logger.Send("KappaEvade Loaded", Logger.LogLevel.Info);
            SpellsDetector.Init();
            Collision.Init();
            SpellsDetector.OnSkillShotDetected += SpellsDetector_OnSkillShotDetected;
            //Drawing.OnDraw += Drawing_OnDraw;
            GameObject.OnDelete += GameObject_OnDelete;
            Game.OnTick += Game_OnTick;
            //GameObject.OnCreate += GameObject_OnCreate;
            //debug.Init();
        }

        public static bool IsInDanger(this Obj_AI_Base target, ActiveSpells spell)
        {
            var hitBox = new Geometry.Polygon.Circle(target.ServerPosition, target.BoundingRadius + 10);
            return hitBox.Points.Any(p => spell.ToPolygon().IsInside(p));
        }

        public static Geometry.Polygon.Sector CreateCone(Vector3 center, Vector3 direction, float angle, float range)
        {
            return new Geometry.Polygon.Sector(center, direction, (float)(angle * Math.PI / 180), range);
        }

        public static Geometry.Polygon ToPolygon(this ActiveSpells spell)
        {
            switch (spell.Spell.Type)
            {
                case Database.SkillShotSpells.Type.LineMissile:
                    return new Geometry.Polygon.Rectangle(spell.Start, spell.End, spell.Width);
                case Database.SkillShotSpells.Type.CircleMissile:
                    return new Geometry.Polygon.Circle(spell.End, spell.Width);
                case Database.SkillShotSpells.Type.Cone:
                    return CreateCone(spell.Start, spell.End, spell.Spell.Angle, spell.Range);
            }
            return new Geometry.Polygon();
        }

        public struct ActiveSpells
        {
            public AIHeroClient Caster;
            public Vector3 Start;
            public Vector3 End;
            public float Range;
            public float Width;
            public Database.SkillShotSpells.SSpell Spell;
            public float EndTime;
            public GameObject Missile;
            public float ArriveTime;
        }

        public static List<ActiveSpells> DetectedSpells = new List<ActiveSpells>();

        public static List<ActiveSpells> DetectedMissiles = new List<ActiveSpells>();

        /*
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            var caster = missile?.SpellCaster as AIHeroClient;
            if (caster == null || !caster.IsMe || !missile.IsValid)
            {
                return;
            }

            if (Database.SkillShotSpells.SkillShotsSpellsList.Any(s => (s.Hero == caster.Hero && string.Equals(s.MissileName, missile.SData.Name, StringComparison.CurrentCultureIgnoreCase))))
            {
                var spell = Database.SkillShotSpells.SkillShotsSpellsList.FirstOrDefault(s => (s.Hero == caster.Hero && string.Equals(s.MissileName, missile.SData.Name, StringComparison.CurrentCultureIgnoreCase)));

                if (DetectedSpells.All(s => !spell.MissileName.Equals(s.Spell.MissileName, StringComparison.CurrentCultureIgnoreCase) && caster.NetworkId != s.Caster.NetworkId))
                {
                    var endpos = missile.StartPosition.Extend(missile.EndPosition, spell.Range).To3D();

                    if (spell.Type == Database.SkillShotSpells.Type.LineMissile || spell.Type == Database.SkillShotSpells.Type.CircleMissile)
                    {
                        var rect = new Geometry.Polygon.Rectangle(missile.StartPosition, endpos, spell.Width);
                        var collide =
                            ObjectManager.Get<Obj_AI_Base>()
                                .OrderBy(m => m.Distance(sender))
                                .FirstOrDefault(
                                    s =>
                                    s.Team != sender.Team
                                    && (((s.IsMinion || s.IsMonster || s is Obj_AI_Minion) && !s.IsWard() && spell.Collisions.Contains(Database.SkillShotSpells.Collision.Minions))
                                        || s is AIHeroClient && spell.Collisions.Contains(Database.SkillShotSpells.Collision.Heros)) && rect.IsInside(s) && s.IsValidTarget());

                        if (collide != null)
                        {
                            endpos = collide.ServerPosition;
                        }
                    }

                    if (spell.Type == Database.SkillShotSpells.Type.Cone)
                    {
                        var sector = new Geometry.Polygon.Sector(missile.StartPosition, endpos, spell.Angle, spell.Range);
                        var collide =
                            ObjectManager.Get<Obj_AI_Base>()
                                .OrderBy(m => m.Distance(sender))
                                .FirstOrDefault(
                                    s =>
                                    s.Team != sender.Team
                                    && (((s.IsMinion || s.IsMonster || s is Obj_AI_Minion) && !s.IsWard() && spell.Collisions.Contains(Database.SkillShotSpells.Collision.Minions))
                                        || s is AIHeroClient && spell.Collisions.Contains(Database.SkillShotSpells.Collision.Heros)) && sector.IsInside(s) && s.IsValidTarget());

                        if (collide != null)
                        {
                            endpos = collide.ServerPosition;
                        }
                    }
                    //Chat.Print("OnCreate " + missile.SData.Name);
                    DetectedSpells.Add(
                        new ActiveSpells
                        {
                            Spell = spell,
                            Start = missile.StartPosition,
                            End = missile.EndPosition,
                            Width = spell.Width,
                            EndTime = (endpos.Distance(missile.StartPosition) / spell.Speed) + (spell.CastDelay / 1000) + Game.Time,
                            Missile = missile,
                            Caster = caster,
                            ArriveTime = (missile.StartPosition.Distance(Player.Instance) / spell.Speed) - (spell.CastDelay / 1000)
                        });
                }
            }
        }
        */

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        private static void Game_OnTick(EventArgs args)
        {
            DetectedSpells.RemoveAll(s => Game.Time - s.EndTime >= 0);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            if (sender == null)
                return;
            var missile = sender as MissileClient;
            var caster = missile?.SpellCaster as AIHeroClient;
            if (missile == null || caster == null || missile.IsAutoAttack() || !missile.IsValid)
                return;
            //Chat.Print("OnDelete Detected " + missile.SData.Name);
            if (DetectedSpells.Any(s => s.Caster != null && s.Spell.MissileName.Equals(missile.SData.Name, StringComparison.CurrentCultureIgnoreCase) && caster.NetworkId == s.Caster.NetworkId))
            {
                //Chat.Print("OnDelete Remove " + missile.SData.Name);
                DetectedSpells.RemoveAll(s => s.Caster != null && s.Spell.MissileName.Equals(missile.SData.Name, StringComparison.CurrentCultureIgnoreCase) && caster.NetworkId.Equals(s.Caster.NetworkId));
            }
        }
        /*
        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        private static void Drawing_OnDraw(EventArgs args)
        {
            foreach (var spell in Collision.NewSpells //.Where(s => debug.SkillShots.checkbox(s.Caster.ID() + s.spell.slot + "draw"))
            )
            {
                if (spell.Missile != null)
                {
                    Circle.Draw(SharpDX.Color.GreenYellow, spell.Width, spell.Missile);
                }

                var c = Player.Instance.IsInDanger(spell) ? Color.Red : Color.AliceBlue;
                spell.ToPolygon().Draw(c, 2);
            }
        }
        */

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="spell"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="range"></param>
        /// <param name="width"></param>
        /// <param name="missile"></param>
        private static void SpellsDetector_OnSkillShotDetected(AIHeroClient sender, GameObjectProcessSpellCastEventArgs args, Database.SkillShotSpells.SSpell spell, Vector3 start, Vector3 end, float range, float width, MissileClient missile)
        {
            var spellrange = range;
            var endpos = spell.IsFixedRange ? start.Extend(end, spellrange).To3D() : end;

            if (spell.Type == Database.SkillShotSpells.Type.CircleMissile && end.Distance(start) < range)
            {
                endpos = end;
            }

            var newactive = new ActiveSpells
            {
                Start = start,
                End = endpos,
                Range = spellrange,
                Width = width,
                Spell = spell,
                EndTime = (endpos.Distance(start) / spell.Speed) + (spell.CastDelay / 1000) + Game.Time,
                Caster = sender,
                Missile = missile,
                ArriveTime = (start.Distance(Player.Instance) / spell.Speed) - (spell.CastDelay / 1000)
            };

            if (!DetectedSpells.Contains(newactive))
            {
                DetectedSpells.Add(newactive);
            }
        }
    }
}
