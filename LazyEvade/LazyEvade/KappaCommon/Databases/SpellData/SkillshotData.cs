using EloBuddy;

namespace LazyEvade.KappaCommon.Databases.SpellData
{
    public class SkillshotData
    {
        public Type type;
        public Champion hero;
        public SpellSlot slot;
        public GameType GameType;
        public int CollideCount;
        public int DangerLevel;
        public int RequireBuffCount;
        public float ExplodeWidth;
        public float MoveSpeedScaleMod;
        public float MissileAccel;
        public float MissileMaxSpeed;
        public float MissileMinSpeed;
        public float ExtraDuration;
        public float RingRadius;
        public float Range;
        public float ExtraRange;
        public float Angle;
        public float Width;
        public float Speed;
        public float CastDelay;
        public string CasterName;
        public string TargetName;
        public string MissileName;
        public string ParticalName;
        public string StartParticalName;
        public string MidParticalName;
        public string EndParticalName;
        public string ParticalObjectName;
        public string SpellName;
        public string RequireBuff;
        public string[] ExtraSpellName;
        public string[] ExtraMissileName;
        public string[] DodgeFrom;
        public bool AllowDuplicates;
        public bool HasExplodingEnd;
        public bool StaticStart;
        public bool StaticEnd;
        public bool EndSticksToMissile;
        public bool RangeScaleWithMoveSpeed;
        public bool DontCross;
        public bool DontAddExtraDuration;
        public bool TakeClosestPath;
        public bool EndIsCasterDirection;
        public bool ForceRemove;
        public bool IsFixedRange;
        public bool DetectByMissile;
        public bool EndSticksToCaster;
        public bool SticksToCaster;
        public bool SticksToMissile;
        public bool FastEvade;
        public bool StartsFromTarget;
        public Collision[] Collisions;

        public string MenuItemName => $"{(this.hero.Equals(Champion.Unknown) ? "All" : this.hero.ToString())} {(this.slot.Equals(SpellSlot.Unknown) ? "Special" : this.slot.ToString())} ({(!string.IsNullOrEmpty(this.SpellName) ? this.SpellName : !string.IsNullOrEmpty(this.MissileName) ? this.MissileName : this.ParticalName)})";
        public bool CanCollide => this.CollideCount > 0 && this.CollideCount < int.MaxValue;
    }

    public enum Type
    {
        LineMissile,
        CircleMissile,
        Cone,
        Arc,
        Ring
    }

    public enum Collision
    {
        YasuoWall,
        Minions,
        Heros,
        Walls,
        Caster
    }
}
