using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Lazy_Illaoi
{
    internal class Helpers
    {
        public static AIHeroClient Player = ObjectManager.Player;
        public static float Qmana;
        public static float Wmana;
        public static float Emana;
        public static float Rmana;

        public static SpellSlot WardSlot()
        {
            var slot = SpellSlot.Unknown;
            if (Item.CanUseItem(3363) &&
                Item.HasItem(3363, Player)) //Blue trinket (upgraded)
            {
                slot = SpellSlot.Trinket;
            }
            else if (Item.CanUseItem(3361) &&
                     Item.HasItem(3361, Player)) //Yellow trinket (upgraded)
            {
                slot = SpellSlot.Trinket;
            }
            else if (Item.CanUseItem(3340) &&
                     Item.HasItem(3340, Player)) //Warding Totem
            {
                slot = SpellSlot.Trinket;
            }
            else if (Item.CanUseItem(2044) &&
                     Item.HasItem(2044, Player)) //SightWard
            {
                slot = Player.GetSpellSlotFromName("SightWard");
            }
            return slot;
        }

        /*
        public static SpellSlot StealthSlot() // Credits MrArticuno(EB)
        {
            var slot = SpellSlot.Unknown;
            if (Item.CanUseItem(3362) && Item.HasItem(3362, ObjectManager.Player))
            {
                slot = SpellSlot.Trinket;
            }
            else if (Item.CanUseItem(3364) && Item.HasItem(3364, ObjectManager.Player))
            {
                slot = SpellSlot.Trinket;
            }
            else if (Item.CanUseItem(2043) && Item.HasItem(2043, ObjectManager.Player))
            {
                slot = ObjectManager.Player.GetSpellSlotFromName("VisionWard");
            }
            return slot;
        }
        */

        public static void SetMana()
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) &&
                Player.HealthPercent < 20)
            {
                Qmana = 0;
                Wmana = 0;
                Emana = 0;
                Rmana = 0;
                return;
            }

            Qmana = Player.Spellbook.GetSpell(SpellSlot.Q).SData.Mana;
            Wmana = Player.Spellbook.GetSpell(SpellSlot.W).SData.Mana;
            Emana = Player.Spellbook.GetSpell(SpellSlot.E).SData.Mana;

            if (!Spells.R.IsReady())
                Rmana = Qmana -
                        Player.PARRegenRate*Player.Spellbook.GetSpell(SpellSlot.Q).Cooldown;
            else
                Rmana = Player.Spellbook.GetSpell(SpellSlot.R).SData.Mana;
        }

        /*
        public static void WardBush(Vector3 pos)
        {
            //throw new KappaException
        }
        */

        public static bool UnderAllyTurret(Vector3 pos)
        {
            return ObjectManager.Get<Obj_AI_Turret>().Any(t => t.IsAlly && !t.IsDead && pos.Distance(t) <= 900);
        }

        public static bool UnderEnemyTurret(Vector3 pos)
        {
            return ObjectManager.Get<Obj_AI_Turret>().Any(t => t.IsEnemy && !t.IsDead && pos.Distance(t) <= 900);
        }

        public static bool InSpawnPoint(Vector3 pos)
        {
            return ObjectManager.Get<Obj_SpawnPoint>().Any(x => pos.Distance(x) < 800 && x.IsEnemy);
        }

        public static int CountAlliesInRange(Vector3 pos)
        {
            var allies = EntityManager.Heroes.Allies.Count(
                allied => !allied.IsDead && allied.Distance(pos) <= 800);
            return allies;
        }

        public static bool IsSafePosition(Vector3 position)
        {
            var enemies = position.CountEnemiesInRange(800);
            var allies = CountAlliesInRange(position);
            var turrets = EntityManager.Turrets.Allies.Count(x => Player.Distance(x) < 800 && x.IsValid && !x.IsDead);
            var lowEnemies = GetLowaiAiHeroClients(position, 800).Count();

            if (UnderEnemyTurret(position)) return false;

            if (enemies == 1)
            {
                return true;
            }
            return allies + turrets > enemies - lowEnemies;
        }

        public static List<AIHeroClient> GetLowaiAiHeroClients(Vector3 position, float range)
        {
            return
                EntityManager.Heroes.Enemies.Where(
                    hero => hero.IsValidTarget() && (hero.Distance(position) <= range) && hero.HealthPercent <= 15)
                    .ToList();
        }

        public static float GetComboDamage(AIHeroClient target)
        {
            var damage = 0f;

            if (Spells.Q.IsReady())
            {
                damage += Player.GetSpellDamage(target, SpellSlot.Q);
            }
            if (Spells.R.IsReady())
            {
                //damage += Rdmg(target);
            }

            return damage;
        }
    }
}