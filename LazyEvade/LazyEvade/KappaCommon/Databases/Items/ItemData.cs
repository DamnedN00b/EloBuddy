using EloBuddy;
using EloBuddy.SDK;
using LazyEvade.KappaCommon.Utility;
using SharpDX;

namespace LazyEvade.KappaCommon.Databases.Items
{
    public enum ItemCastType
    {
        Active, Targeted, Position
    }

    public class ItemData
    {
        public ItemData(ItemId id, ItemCastType type, float range, float speed, float castDelay)
        {
            item = new Item(id, range);
            this.CastDelay = castDelay;
            this.Speed = speed;
            this.CastType = type;
        }
        public ItemData(int id, ItemCastType type, float range, float speed, float castDelay)
        {
            item = new Item(id, range);
            this.CastDelay = castDelay;
            this.Speed = speed;
            this.CastType = type;
        }

        public Item item;
        public float CastDelay;
        public float Speed;
        public ItemCastType CastType;
        public bool Ready => this.item.IsReady() && this.item.IsOwned(Player.Instance);

        public void Cast()
        {
            if (Ready && this.CastType.Equals(ItemCastType.Active))
            {
                this.item.Cast();
            }
        }

        public void Cast(Obj_AI_Base target)
        {
            if (!Ready || !target.IsValidTarget(this.item.Range))
                return;

            switch (CastType)
            {
                case ItemCastType.Active:
                    {
                        this.item.Cast();
                    }
                    break;
                case ItemCastType.Targeted:
                    {
                        this.item.Cast(target);
                    }
                    break;
                case ItemCastType.Position:
                    {
                        var travelTime = (int)((Player.Instance.Distance(target) / this.Speed * 1000f) + this.CastDelay);
                        var castpos = target.PredictPosition(travelTime);
                        Cast(castpos);
                    }
                    break;
            }
        }

        public void Cast(Vector3 target)
        {
            if (Ready && this.item.IsInRange(target))
            {
                this.item.Cast(target);
            }
        }
    }
}
