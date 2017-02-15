using EloBuddy;

namespace LazyEvade.KappaCommon.Databases.SpellData
{
    public class EmpoweredAttackData
    {
        public Champion Hero;
        public SpellSlot Slot;
        public string AttackName;
        public string DisplayName;
        public string RequireBuff;
        public string DontHaveBuff;
        public string TargetRequiredBuff;
        public int RequiredBuffCount;
        public int TargetRequiredBuffCount;
        public int DangerLevel;
        public bool CrowdControl;
        public string MenuItemName => $"{this.Hero} {this.Slot} ({(!string.IsNullOrEmpty(DisplayName) ? DisplayName : !string.IsNullOrEmpty(AttackName) ? AttackName : !string.IsNullOrEmpty(RequireBuff) ? RequireBuff : TargetRequiredBuff)})";
    }
}
