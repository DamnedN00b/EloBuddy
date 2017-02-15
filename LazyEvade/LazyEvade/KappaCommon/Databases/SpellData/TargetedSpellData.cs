using EloBuddy;

namespace LazyEvade.KappaCommon.Databases.SpellData
{
    public class TargetedSpellData
    {
        public Champion hero;
        public SpellSlot slot;
        public int DangerLevel;
        public float CastDelay;
        public bool FastEvade;
        public string MenuItemName => $"{this.hero} {this.slot}";
    }
}
