using EloBuddy;
using EloBuddy.SDK;
using LazyEvade.KappaCommon.Databases.SpellData;

namespace LazyEvade.KappaCommon.SpellDetector.DetectedData
{
    public class DetectedDangerBuffData
    {
        public AIHeroClient Caster;
        public Obj_AI_Base Target;
        public DangerBuffData Data;
        public BuffInstance Buff;
        public float StartTick = Core.GameTickCount;
        public float EndTick
        {
            get
            {
                if (this.Buff != null)
                {
                    return this.Buff.EndTime * 1000f;
                }
                return this.StartTick + 2000f;
            }
        }
        public float TicksLeft => this.EndTick - Core.GameTickCount;
        public bool Ended => this.TicksLeft <= 0 || this.Caster.IsDead || this.Target.IsDead;
    }
}
