using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace LazyLucian
{
    public static class CustomEvents
    {
        public static readonly Item Youmuu = new Item((int)ItemId.Youmuus_Ghostblade);

        public static void OnSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            switch (args.Slot)
            {
                case SpellSlot.Q:
                    Orbwalker.ResetAutoAttack();
                    break;
            }
        }

        
        public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            switch (args.Slot)
            {
                case SpellSlot.R:
                    if (Program.Player.InventoryItems.HasItem(ItemId.Youmuus_Ghostblade))
                    {
                        Youmuu.Cast();
                    }
                    break;
            }
        }
        /*
        public static void OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {

        }

        public static void OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {

        }
        */

        public static List<Obj_AI_Base> GetBuffedObjects(IEnumerable<Obj_AI_Base> objectList = null)
        {
            var objects =
                ObjectManager.Get<Obj_AI_Base>()
                    .Where(o => o.IsValidTarget(Player.Instance.GetAutoAttackRange(o)) && o.HasBuff("LucianWDebuff"))
                    .ToList();
            return
                objects.Where(o => Program.Player.IsInAutoAttackRange(o))
                    .OrderBy(o => o.Distance(Program.Player))
                    .ToList();
        }
    }
}