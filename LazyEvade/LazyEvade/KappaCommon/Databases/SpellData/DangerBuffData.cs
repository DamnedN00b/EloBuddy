using EloBuddy;

namespace LazyEvade.KappaCommon.Databases.SpellData
{
    public class DangerBuffData
    {
        public Champion Hero;
        public SpellSlot Slot;
        public string BuffName;
        public int DangerLevel;
        public string MenuItemName => $"{this.Hero} {this.Slot} ({this.BuffName})";
    }
}
