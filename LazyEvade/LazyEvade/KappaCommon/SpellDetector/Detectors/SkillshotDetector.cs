using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using LazyEvade.KappaCommon.Databases.SpellData;
using LazyEvade.KappaCommon.Databases.Spells;
using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Events;
using SharpDX;

namespace LazyEvade.KappaCommon.SpellDetector.Detectors
{
    public class SkillshotDetector
    {
        private static bool Loaded;
        static SkillshotDetector()
        {
            if (!Loaded)
            {
                Collision.Init();
                Game.OnTick += Game_OnTick;
                Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
                GameObject.OnCreate += GameObject_OnCreate;
                GameObject.OnDelete += GameObject_OnDelete;
                Spellbook.OnStopCast += Spellbook_OnStopCast;
                Loaded = true;
            }
        }

        public class LuxRPartical
        {
            public SkillshotData Data;
            public float StartTick = Core.GameTickCount;
            public AIHeroClient caster;
            public Vector3? Start;
            public Vector3? Mid;
            public Vector3? End;
            public bool FullyDetected
                =>
                    (this.caster != null && (this.Start != null || this.Mid != null || this.End != null))
                    || (this.Start != null && (this.Mid != null || this.End != null)) || (this.Mid != null && this.End != null);
        }

        public static List<LuxRPartical> DetectedLuxRParticals = new List<LuxRPartical>();

        private static void Spellbook_OnStopCast(Obj_AI_Base sender, SpellbookStopCastEventArgs args)
        {
            var caster = sender as AIHeroClient;
            if (caster == null || !caster.ChampionName.Equals("Sion"))
                return;

            SkillshotsDetected.RemoveAll(s => s.Caster.IdEquals(caster)); // Clear all sion Skills when he stops casting
        }

        private static void Game_OnTick(EventArgs args)
        {
            foreach (var LuxR in DetectedLuxRParticals)
            {
                var data = SkillshotDatabase.List.FirstOrDefault(s => s.hero.Equals(Champion.Lux) && s.slot.Equals(SpellSlot.R));
                if (data == null)
                {
                    continue;
                }

                if (SkillshotsDetected.Any(s => s.Caster.IdEquals(LuxR.caster) && s.Data.Equals(data)))
                {
                    continue;
                }

                Vector3? start = null;
                Vector3? end = null;

                if (start == null)
                {
                    if (LuxR.caster != null && LuxR.caster.IsHPBarRendered)
                    {
                        start = LuxR.caster.ServerPosition;
                    }
                    else
                    {
                        if (LuxR.Start.HasValue)
                        {
                            start = LuxR.Start;
                        }
                        else
                        {
                            if (LuxR.Mid.HasValue && LuxR.End.HasValue)
                            {
                                start = LuxR.End.Value.Extend(LuxR.Mid.Value, data.Range).To3DWorld();
                            }
                        }
                    }
                }

                if (end == null)
                {
                    if (LuxR.End.HasValue)
                    {
                        end = LuxR.End.Value;
                    }
                    else
                    {
                        if (LuxR.caster != null && LuxR.caster.IsHPBarRendered)
                        {
                            if (LuxR.End.HasValue)
                            {
                                end = LuxR.End.Value;
                            }
                            if (LuxR.Mid.HasValue)
                            {
                                end = LuxR.caster.ServerPosition.Extend(LuxR.Mid.Value, data.Range).To3DWorld();
                            }
                            else
                            {
                                if (LuxR.Start.HasValue)
                                {
                                    end = LuxR.caster.ServerPosition.Extend(LuxR.Start.Value, data.Range).To3DWorld();
                                }
                            }
                        }
                        else
                        {
                            if (LuxR.Start.HasValue && LuxR.Mid.HasValue)
                            {
                                end = LuxR.Start.Value.Extend(LuxR.Mid.Value, data.Range).To3DWorld();
                            }
                        }
                    }
                }

                if (start.HasValue && end.HasValue)
                {
                    if (!SkillshotsDetected.Any(s => s.Caster.IdEquals(LuxR.caster) && s.Data.Equals(data)))
                    {
                        var detected = new DetectedSkillshotData
                        {
                            Caster = LuxR.caster,
                            StartTick = Core.GameTickCount,
                            Start = start.Value.To2D(),
                            End = end.Value.To2D(),
                            Data = data
                        };

                        Add(detected);
                    }
                }
            }

            foreach (var skill in SkillshotsDetected)
                OnSkillShotDetected.Invoke(skill);

            DetectedLuxRParticals.RemoveAll(s => Core.GameTickCount - s.StartTick > s.Data.CastDelay);
            SkillshotsDetected.RemoveAll(s => s.Ended);
        }

        public static List<DetectedSkillshotData> SkillshotsDetected = new List<DetectedSkillshotData>();

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            if (sender == null)
                return;

            var partical = sender as Obj_GeneralParticleEmitter;
            if (partical != null)
            {
                var pdata = SkillshotDatabase.List.FirstOrDefault(s => !string.IsNullOrEmpty(s.ParticalName) && partical.Name.StartsWith(s.ParticalName) && partical.Name.EndsWith(".troy"));
                if (pdata != null)
                {
                    SkillshotsDetected.RemoveAll(s => s.Data.Equals(pdata));
                }
            }

            var missile = sender as MissileClient;
            var caster = missile?.SpellCaster as AIHeroClient;
            if (missile == null || caster == null || missile.IsAutoAttack() || !missile.IsValid)
                return;

            if (SkillshotsDetected.Any(s => s.Caster != null && s.Missile != null && s.Missile.IdEquals(missile) && caster.IdEquals(s.Caster)))
            {
                SkillshotsDetected.RemoveAll(s => s.Caster != null && s.Missile != null && s.Missile.IdEquals(missile) && caster.IdEquals(s.Caster));
            }
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            if (sender == null)
                return;

            var partical = sender as Obj_GeneralParticleEmitter;
            if (partical != null)
            {
                var pdata = SkillshotDatabase.List.FirstOrDefault(s => partical.Name.EndsWith(".troy") && ((!string.IsNullOrEmpty(s.ParticalName) && partical.Name.StartsWith(s.ParticalName))
                || (!string.IsNullOrEmpty(s.MissileName) && partical.Name.StartsWith(s.MissileName))
                || (s.ExtraMissileName != null && s.ExtraMissileName.Any(x => partical.Name.StartsWith(x)))));

                if (pdata != null)
                {
                    var pcaster = EntityManager.Heroes.AllHeroes.OrderBy(e => e.Distance(partical)).FirstOrDefault(h => h.Hero.Equals(pdata.hero));
                    var correctObject = ObjectManager.Get<Obj_AI_Base>().OrderBy(o => o.Distance(partical)).FirstOrDefault(o => !string.IsNullOrEmpty(pdata.ParticalObjectName) && o.Name.Equals(pdata.ParticalObjectName));
                    if (correctObject != null)
                    {
                        var pdetected = new DetectedSkillshotData
                        {
                            Caster = pcaster,
                            Start = correctObject.Position.To2D(),
                            End = correctObject.Position.To2D(),
                            Data = pdata,
                            StartTick = Core.GameTickCount
                        };

                        Add(pdetected);
                    }
                    else
                    {
                        var start = partical.Position.To2D();
                        var end = partical.Position.To2D();
                        if (pcaster != null)
                        {
                            //start = pcaster.ServerPosition.To2D();
                            switch (pcaster.ChampionName)
                            {
                                case "Zac":
                                    if (start.Distance(end) > pdata.Range)
                                    {
                                        start = end.Extend(start, pdata.Range);
                                    }
                                    break;
                            }
                        }

                        var pdetected = new DetectedSkillshotData
                        {
                            Caster = pcaster,
                            Start = start,
                            End = end,
                            Data = pdata,
                            StartTick = Core.GameTickCount
                        };

                        Add(pdetected);
                    }
                }
                else
                {
                    var StartluxR =
                        SkillshotDatabase.List.FirstOrDefault(p => !string.IsNullOrEmpty(p.StartParticalName) && partical.Name.StartsWith(p.StartParticalName) && partical.Name.EndsWith(".troy"));
                    var MidluxR =
                        SkillshotDatabase.List.FirstOrDefault(p => !string.IsNullOrEmpty(p.StartParticalName) && partical.Name.StartsWith(p.MidParticalName) && partical.Name.EndsWith(".troy"));
                    var EndluxR =
                        SkillshotDatabase.List.FirstOrDefault(p => !string.IsNullOrEmpty(p.StartParticalName) && partical.Name.StartsWith(p.MidParticalName) && partical.Name.EndsWith(".troy"));

                    AIHeroClient pcaster;
                    if (StartluxR != null || MidluxR != null || EndluxR != null)
                    {
                        pcaster = EntityManager.Heroes.AllHeroes.OrderBy(h => h.Distance(partical)).FirstOrDefault(h => h.ChampionName.Equals("Lux"));
                        if (pcaster != null)
                        {
                            var alreadyDetected = DetectedLuxRParticals.FirstOrDefault(p => p.caster != null && !p.FullyDetected && p.caster.IdEquals(pcaster));
                            if (alreadyDetected != null)
                            {
                                if (alreadyDetected.Start == null && StartluxR != null)
                                {
                                    alreadyDetected.Start = partical.Position;
                                }
                                if (alreadyDetected.Mid == null && MidluxR != null)
                                {
                                    alreadyDetected.Mid = partical.Position;
                                }
                                if (alreadyDetected.End == null && EndluxR != null)
                                {
                                    alreadyDetected.End = partical.Position;
                                }
                            }
                            else
                            {
                                var addnew = new LuxRPartical
                                {
                                    caster = pcaster,
                                    Start = StartluxR != null ? partical.Position : (Vector3?)null,
                                    Mid = MidluxR != null ? partical.Position : (Vector3?)null,
                                    End = EndluxR != null ? partical.Position : (Vector3?)null,
                                    Data = SkillshotDatabase.List.FirstOrDefault(s => s.hero.Equals(Champion.Lux) && s.slot.Equals(SpellSlot.R))
                                };

                                DetectedLuxRParticals.Add(addnew);
                            }
                        }
                    }
                }
            }

            var missile = sender as MissileClient;
            var caster = missile?.SpellCaster;
            if (missile == null || caster == null || missile.IsAutoAttack() || !missile.IsValid)
                return;

            var missilename = missile.SData.Name;
            //Console.WriteLine($"{missilename} - mis - {missile.Slot}");

            var data = GetData(caster, null, missile);

            if (data == null)
            {
                //Console.WriteLine($"OnCreateSkillshots: {caster.ChampionName} - [{missile.Slot} | {missilename}] - Not Detected");
                return;
            }

            var Misstart = missile.StartPosition.To2D();
            var Misend = missile.EndPosition.To2D();

            if (data.hero.Equals(Champion.Shen) && data.slot.Equals(SpellSlot.Q))
            {
                Misstart = missile.Position.To2D();
                Misend = caster.ServerPosition.To2D();
                data.Range = Misstart.Distance(Misend);
            }

            var detected = new DetectedSkillshotData
            {
                Caster = caster,
                Missile = missile,
                Start = Misstart,
                End = Misend,
                Data = data,
                StartTick = Core.GameTickCount
            };

            Add(detected);
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var caster = sender as AIHeroClient;
            var target = args.Target as AIHeroClient;
            if (caster == null || !caster.IsValid)
                return;

            var spellname = args.SData.Name;
            //Console.WriteLine(spellname);

            var data = GetData(caster, args, null);

            if (data == null)
            {
                //Console.WriteLine($"OnProcessSkillshots: {caster.ChampionName} - [{args.Slot} | {spellname}] - Not Detected");
                return;
            }

            var start = args.Start.To2D();
            var end = args.End.To2D();
            if (data.StartsFromTarget && target != null)
            {
                if (data.hero == Champion.LeeSin && data.slot == SpellSlot.R)
                {
                    start = target.ServerPosition.To2D();
                    end = start.Extend(caster, -data.Range);
                }
            }

            if (data.RangeScaleWithMoveSpeed)
            {
                data.Range = caster.MoveSpeed * data.MoveSpeedScaleMod;

                if (data.hero == Champion.Warwick && data.slot == SpellSlot.R)
                {
                    data.Range = Math.Max(275, caster.MoveSpeed * data.MoveSpeedScaleMod);
                }

                end = start.Extend(end, data.Range);
            }

            if (data.hero.Equals(Champion.Taric) && data.slot.Equals(SpellSlot.E))
            {
                var taricAllies = EntityManager.Heroes.AllHeroes.Where(h => h.IsValidTarget() && h.Team.Equals(caster.Team) && !h.IdEquals(caster) && h.HasBuff("taricwleashactive"));
                foreach (var ally in taricAllies)
                {
                    var taricAllyE = new DetectedSkillshotData
                    {
                        Caster = ally,
                        Target = target,
                        Start = ally.ServerPosition.To2D(),
                        End = ally.ServerPosition.To2D().Extend(end, data.Range),
                        Data = data,
                        StartTick = Core.GameTickCount
                    };

                    Add(taricAllyE);
                }
            }

            if (data.SpellName.Equals("SiegeLaserAffixShot"))
            {
                var turret = EntityManager.Turrets.AllTurrets.FirstOrDefault(t => t.Team.Equals(caster.Team) && t.Buffs.Any(b => b.Caster.IdEquals(caster)));
                if (turret == null)
                {
                    return;
                }

                start = turret.ServerPosition.To2D();
                end = start.Extend(args.End.To2D(), data.Range);
            }

            var detected = new DetectedSkillshotData
            {
                Caster = caster,
                Target = target,
                Start = start,
                End = end,
                Data = data,
                StartTick = Core.GameTickCount
            };


            Add(detected);
        }

        private static void Add(DetectedSkillshotData data)
        {
            if (data == null)
            {
                Console.WriteLine("Invalid DetectedSkillshotData");
                return;
            }

            if (!data.Data.AllowDuplicates)
            {
                if (SkillshotsDetected.Any(s => s.Missile != null && data.Missile == null && s.Caster != null && data.Caster != null && s.Caster.IdEquals(data.Caster) && s.Data.Equals(data.Data)))
                {
                    // Already Detected by Missile
                    return;
                }

                var replaceByMissile =
                    SkillshotsDetected.FirstOrDefault(s => s.Missile == null && data.Missile != null && s.Caster != null && data.Caster != null && s.Caster.IdEquals(data.Caster) && s.Data.Equals(data.Data));
                if (replaceByMissile != null)
                {
                    // Add the Missile
                    replaceByMissile.Missile = data.Missile;
                    replaceByMissile.End = data.Missile.EndPosition.To2D();
                    replaceByMissile.Start = data.Missile.StartPosition.To2D();
                    return;
                }

                if (SkillshotsDetected.Any(s => s.Caster != null && !s.DetectedMissile && s.Caster.IdEquals(data.Caster) && s.Data.Equals(data.Data)))
                    return;
            }

            OnSkillShotDetected.Invoke(data);
            SkillshotsDetected.Add(data);
        }

        internal static SkillshotData GetData(Obj_AI_Base caster, GameObjectProcessSpellCastEventArgs args, MissileClient missile)
        {
            SkillshotData result = null;
            var hero = caster as AIHeroClient;

            List<SkillshotData> AllData = SkillshotDatabase.List.FindAll(s => hero != null ? s.hero.Equals(Champion.Unknown) || s.hero.Equals(hero.Hero) : !string.IsNullOrEmpty(s.CasterName) && caster.BaseSkinName.StartsWith(s.CasterName));
            if (AllData == null || !AllData.Any())
                return result;

            if (missile == null)
            {
                var slotData = AllData.FindAll(s => s.slot.Equals(args.Slot) || s.slot.Equals(SpellSlot.Unknown));
                if (slotData != null && slotData.Any())
                {
                    var spellname = args.SData.Name;
                    var data =
                        slotData.FirstOrDefault(
                            s =>
                            !string.IsNullOrEmpty(s.SpellName) && s.SpellName.Equals(spellname, StringComparison.CurrentCultureIgnoreCase)
                            || s.ExtraSpellName != null && s.ExtraSpellName.Any(x => x.Equals(spellname, StringComparison.CurrentCultureIgnoreCase)));

                    if (data != null && !data.DetectByMissile && (string.IsNullOrEmpty(data.RequireBuff) || caster.GetBuffCount(data.RequireBuff) >= data.RequireBuffCount) && (data.StartsFromTarget && args.Target != null || !data.StartsFromTarget))
                    {
                        result = data;
                    }
                }
            }
            else
            {
                var missilename = missile.SData.Name;
                var data =
                    AllData.FirstOrDefault(
                        s =>
                        !string.IsNullOrEmpty(s.MissileName) && s.MissileName.Equals(missilename, StringComparison.CurrentCultureIgnoreCase)
                        || s.ExtraMissileName != null && s.ExtraMissileName.Any(x => x.Equals(missilename, StringComparison.CurrentCultureIgnoreCase)));

                if (data != null && (string.IsNullOrEmpty(data.RequireBuff) || caster.GetBuffCount(data.RequireBuff) >= data.RequireBuffCount) && !data.StartsFromTarget)
                {
                    result = data;
                }
            }
            return result;
        }
    }

    internal static class Collision
    {
        internal static void Init()
        {
            Game.OnTick += Game_OnPreTick;
        }

        private static void Game_OnPreTick(EventArgs args)
        {
            foreach (var skill in SkillshotDetector.SkillshotsDetected.Where(s => s.IsVisible))
            {
                Check(skill);
            }
        }

        public static void Check(DetectedSkillshotData skill)
        {
            var collideobjects = new List<Obj_AI_Base>();
            var collidePoints = new List<Vector2>();
            collideobjects.Clear();
            collidePoints.Clear();

            var collisionData = skill.Data.Collisions;

            skill.CollidePoint = null;
            skill.CollideTarget = null;
            skill.CollideTargets = null;

            if (collisionData == null || !collisionData.Any())
                return;

            var polygon = skill.OriginalPolygon;

            if (polygon == null)
                return;

            bool CollideWithWals = false;
            if (collisionData.Contains(Databases.SpellData.Collision.Heros))
            {
                var heros = EntityManager.Heroes.AllHeroes.Where(h => h.Team != skill.Caster.Team && !h.IsMe && h.IsValidTarget() && polygon.IsInside(h)).ToList();
                if (heros != null && heros.Any())
                {
                    collideobjects.AddRange(heros);
                    collidePoints.AddRange(heros.Select(h => h.ServerPosition.To2D()));
                }
            }

            if (collisionData.Contains(Databases.SpellData.Collision.Minions))
            {
                var minions = EntityManager.MinionsAndMonsters.Combined.Where(h => h.Team != skill.Caster.Team && !h.IsWard() && h.IsValidTarget() && polygon.IsInside(h)).ToList();
                if (minions != null && minions.Any())
                {
                    collideobjects.AddRange(minions);
                    collidePoints.AddRange(minions.Select(h => h.ServerPosition.To2D()));
                }
            }

            if (collisionData.Contains(Databases.SpellData.Collision.Walls))
            {
                var wallsDetected = CellsAnalyze(skill.Start, polygon).Select(c => c.WorldPosition.To2D()).ToList();
                if (wallsDetected != null && wallsDetected.Any())
                {
                    collidePoints.AddRange(wallsDetected);
                    CollideWithWals = true;
                }
            }

            var orderedPoints = collidePoints.OrderBy(vector2 => vector2.Distance(skill.Start)).ToArray();
            var orderedObjects = collideobjects.OrderBy(obj => obj.Distance(skill.Start)).ToArray();

            if (CollideWithWals)
            {
                if (orderedPoints.Any())
                {
                    var range = orderedPoints[0].Distance(skill.Start);
                    skill.CollidePoint = skill.Start.Extend(skill.EndPosition, range);
                }
            }
            else
            {
                if (orderedPoints.Any())
                {
                    var range = orderedPoints[0].Distance(skill.Start);
                    if (skill.Data.CanCollide)
                    {
                        if (orderedPoints.Length > skill.Data.CollideCount)
                        {
                            var point = orderedPoints[skill.Data.CollideCount];
                            range = point.Distance(skill.Start);
                            var obj = orderedObjects.FirstOrDefault(o => o.ServerPosition.To2D().Equals(point));
                            if (obj != null)
                            {
                                range -= obj.BoundingRadius;
                            }

                            skill.CollidePoint = skill.Start.Extend(skill.EndPosition, range);
                        }
                    }
                    else
                    {
                        skill.CollidePoint = skill.Start.Extend(skill.EndPosition, range);
                    }
                }
            }

            if (orderedObjects.Any())
            {
                skill.CollideTargets = orderedObjects;
                skill.CollideTarget = orderedObjects[0];
            }
        }

        private static IEnumerable<NavMeshCell> CellsAnalyze(Vector2 pos, EloBuddy.SDK.Geometry.Polygon poly)
        {
            var sourceGrid = pos.ToNavMeshCell();
            var cellCount = 50f;
            var startPos = new NavMeshCell(sourceGrid.GridX - (short)Math.Floor(cellCount), sourceGrid.GridY - (short)Math.Floor(cellCount));

            var cells = new List<NavMeshCell> { startPos };
            for (var y = startPos.GridY; y < startPos.GridY + cellCount; y++)
            {
                for (var x = startPos.GridX; x < startPos.GridX + cellCount; x++)
                {
                    if (x == startPos.GridX && y == startPos.GridY)
                    {
                        continue;
                    }
                    if (x == sourceGrid.GridX && y == sourceGrid.GridY)
                    {
                        if (poly.IsInside(sourceGrid.WorldPosition))
                            cells.Add(sourceGrid);
                    }
                    else
                    {
                        if (poly.IsInside(new NavMeshCell(x, y).WorldPosition))
                            cells.Add(new NavMeshCell(x, y));
                    }
                }
            }
            return cells.Where(c => c.WorldPosition.IsBuilding() || c.WorldPosition.IsWall());
        }
    }
}
