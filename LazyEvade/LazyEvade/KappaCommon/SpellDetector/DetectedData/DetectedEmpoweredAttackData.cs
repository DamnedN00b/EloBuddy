using EloBuddy;
using EloBuddy.SDK;
using LazyEvade.KappaCommon.Databases.SpellData;

namespace LazyEvade.KappaCommon.SpellDetector.DetectedData
{
    public class DetectedEmpoweredAttackData
    {
        public AIHeroClient Caster;
        public Obj_AI_Base Target;
        public EmpoweredAttackData Data;
        public float StartTick = Core.GameTickCount;
        public float EndTick => this.StartTick + this.Caster.AttackCastDelay * 1000f;
        public float TicksLeft => this.EndTick - Core.GameTickCount;
        public bool Ended => this.TicksLeft <= 0;
    }
}
