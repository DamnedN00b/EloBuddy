using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using LazyYorick.KappaEvade;

// ReSharper disable IdentifierWordIsNotInDictionary

namespace LazyYorick
{
    internal static class Events
    {
        /// <summary>
        ///     Handler for the InComingDamage event
        /// </summary>
        /// <param name="args">The arguments the event provides</param>
        public delegate void OnInComingDamage(InComingDamageEventArgs args);

        public static List<Obj_AI_Base> Graves = new List<Obj_AI_Base>();

        static Events()
        {

            Obj_AI_Base.OnPlayAnimation += delegate(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
            {
                {
                    if (!sender.IsMe || sender.IsDead) return;
                    if (args.Animation != "Spell1") return;
                    Chat.Say("/d");
                    Orbwalker.ResetAutoAttack();
                }
            };

        Orbwalker.OnPostAttack += delegate (AttackableUnit target, EventArgs args)
            {
                if (!SpellManager.Q.IsReady()) return;
                if (target.Type == GameObjectType.AIHeroClient || target.Type == GameObjectType.obj_AI_Minion && target.Health < Player.Instance.GetSpellDamage(target as Obj_AI_Base, SpellSlot.Q))
                    SpellManager.Q.Cast();
            };

            GameObject.OnCreate += delegate(GameObject sender, EventArgs args)
            {
                var marker = sender as Obj_AI_Base;
                {
                    if (marker == null || !marker.IsValid || !marker.Name.ToLower().Equals("yorickmarker"))
                        return;

                    if (!marker.IsAlly ||
                        !(marker.Distance(Player.Instance) < 900))
                        return;

                    Graves.Add((Obj_AI_Minion) marker);
                }
            };

            GameObject.OnDelete +=
                delegate(GameObject sender, EventArgs args)
                {
                    Graves.RemoveAll(t => t.NetworkId.Equals(sender.NetworkId));
                };

            Game.OnUpdate += delegate
            {
                // Used to Invoke the Incoming Damage Event When there is SkillShot Incoming
                foreach (var spell in Collision.NewSpells)
                {
                    foreach (
                        var ally in
                            EntityManager.Heroes.Allies.Where(a => !a.IsDead && a.IsValidTarget() && a.IsInDanger(spell))
                        )
                    {
                        OnIncomingDamage?.Invoke(new InComingDamageEventArgs(spell.Caster, ally,
                            spell.Caster.GetSpellDamage(ally, spell.Spell.Slot), InComingDamageEventArgs.Type.SkillShot));
                    }
                }
            };

            SpellsDetector.OnTargetedSpellDetected +=
                delegate(AIHeroClient sender, AIHeroClient target, GameObjectProcessSpellCastEventArgs args,
                    Database.TargetedSpells.Spell spell)
                {
                    // Used to Invoke the Incoming Damage Event When there is a TargetedSpell Incoming
                    if (target.IsAlly)
                        OnIncomingDamage?.Invoke(new InComingDamageEventArgs(sender, target,
                            sender.GetSpellDamage(target, spell.Slot), InComingDamageEventArgs.Type.TargetedSpell));
                };

            Obj_AI_Base.OnBasicAttack += delegate(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                // Used to Invoke the Incoming Damage Event When there is an AutoAttack Incoming
                var target = args.Target as AIHeroClient;
                var hero = sender as AIHeroClient;
                var turret = sender as Obj_AI_Turret;
                var minion = sender as Obj_AI_Minion;

                if (target == null || !target.IsAlly) return;

                if (hero != null)
                    OnIncomingDamage?.Invoke(new InComingDamageEventArgs(hero, target, hero.GetAutoAttackDamage(target),
                        InComingDamageEventArgs.Type.HeroAttack));
                if (turret != null)
                    OnIncomingDamage?.Invoke(new InComingDamageEventArgs(turret, target,
                        turret.GetAutoAttackDamage(target), InComingDamageEventArgs.Type.TurretAttack));
                if (minion != null)
                    OnIncomingDamage?.Invoke(new InComingDamageEventArgs(minion, target,
                        minion.GetAutoAttackDamage(target), InComingDamageEventArgs.Type.MinionAttack));
            };
            Obj_AI_Base.OnProcessSpellCast += delegate(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                var caster = sender as AIHeroClient;
                var target = args.Target as AIHeroClient;
                if (caster == null || target == null || !caster.IsEnemy || !target.IsAlly || args.IsAutoAttack())
                    return;
                if (!Database.TargetedSpells.TargetedSpellsList.Any(s => s.Hero == caster.Hero && s.Slot == args.Slot))
                {
                    OnIncomingDamage?.Invoke(new InComingDamageEventArgs(caster, target,
                        caster.GetSpellDamage(target, args.Slot), InComingDamageEventArgs.Type.TargetedSpell));
                }
            };
        }

        /// <summary>
        ///     Fires when There is In Coming Damage to an ally
        /// </summary>
        public static
            event OnInComingDamage OnIncomingDamage;

        public static
            void Initialize()
        {
        }

        public class InComingDamageEventArgs
        {
            public enum Type
            {
                TurretAttack,
                HeroAttack,
                MinionAttack,
                SkillShot,
                TargetedSpell
            }

            public Type DamageType;
            public float InComingDamage;
            public Obj_AI_Base Sender;
            public AIHeroClient Target;

            public InComingDamageEventArgs(Obj_AI_Base sender, AIHeroClient target, float damage, Type type)
            {
                Sender = sender;
                Target = target;
                InComingDamage = damage;
                DamageType = type;
            }
        }
    }
}