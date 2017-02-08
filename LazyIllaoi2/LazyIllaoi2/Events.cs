using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using DrawSettings = LazyIllaoi2.Config.Modes.Drawings;
using SkinSettings = LazyIllaoi2.Config.Modes.Skins;
using ComboSettings = LazyIllaoi2.Config.Modes.Combo;
using HarassSettings = LazyIllaoi2.Config.Modes.Harass;
using JungleClearSettings = LazyIllaoi2.Config.Modes.JungleClear;
using LaneClearSettings = LazyIllaoi2.Config.Modes.LaneClear;

// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyIllaoi2
{
    internal static class Events
    {
        public static List<Obj_AI_Base> TentacleList = new List<Obj_AI_Base>();
        public static Obj_AI_Minion Ghost;
        public static AIHeroClient EnemyW;

        public static void LockQ()
        {
            if (EnemyW != null && SpellManager.W.IsReady() && EnemyW.ServerPosition.IsInTentacleRange())
            {
                Obj_AI_Base.OnProcessSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
                {
                    if (sender.IsMe && args.Slot == SpellSlot.Q)
                    {
                        args.Process = false;
                    }
                };
            }

        }

        static Events()
        {
            LockQ();

            Game.OnTick += delegate
            {
                Ghost = ObjectManager.Get<Obj_AI_Minion>()
                    .FirstOrDefault(x => x.IsValidTarget() && x.HasBuff("illaoiespirit"));

                if (SkinSettings.useSkin)
                {
                    Player.SetSkinId(SkinSettings.skinID);
                }

                EnemyW = TargetSelector.GetTarget(SpellManager.W.Range, DamageType.Physical);
            };
            
            Obj_AI_Base.OnSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                if (sender.IsMe && args.Slot == SpellSlot.W)
                {
                    Orbwalker.ResetAutoAttack();
                }
            };

            Orbwalker.OnPostAttack += delegate (AttackableUnit target, EventArgs args)
            {
                var enemy = target as AIHeroClient;
                var minion = target as Obj_AI_Minion;
                var monster = target as Obj_AI_Minion;

                if (SpellManager.W.IsReady())
                {
                    if (ComboSettings.useWmode == 1 && ComboSettings.useW &&
                        Player.Instance.ManaPercent > ComboSettings.useWmana &&
                        target?.Type == GameObjectType.AIHeroClient &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                    {
                        if (enemy != null && (ComboSettings.useWtentacles && enemy.ServerPosition.IsInTentacleRange()))
                        {
                            SpellManager.W.Cast();
                        }
                        else if (enemy != null && !ComboSettings.useWtentacles)
                        {
                            SpellManager.W.Cast();
                        }
                        return;
                    }

                    if (HarassSettings.useWmode == 1 && HarassSettings.useW &&
                        Player.Instance.Mana > HarassSettings.useWmana &&
                        target?.Type == GameObjectType.AIHeroClient &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                    {
                        if (enemy != null && (HarassSettings.useWtentacles && enemy.ServerPosition.IsInTentacleRange()))
                        {
                            SpellManager.W.Cast();
                        }
                        else if (enemy != null && !HarassSettings.useWtentacles)
                        {
                            SpellManager.W.Cast();
                        }
                        return;
                    }


                    if (JungleClearSettings.useWmode == 1 && JungleClearSettings.useW &&
                        Player.Instance.Mana > JungleClearSettings.useWmana &&
                        target?.Type == GameObjectType.obj_AI_Minion &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                    {
                        if (monster != null &&
                            (JungleClearSettings.useWtentacles && monster.ServerPosition.IsInTentacleRange()))
                        {
                            SpellManager.W.Cast();
                        }
                        else if (monster != null && !JungleClearSettings.useWtentacles)
                        {
                            SpellManager.W.Cast();
                        }
                        return;
                    }


                    if (LaneClearSettings.useWmode == 1 && LaneClearSettings.useW &&
                        Player.Instance.Mana > LaneClearSettings.useWmana &&
                        target?.Type == GameObjectType.obj_AI_Minion &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))

                        if (minion != null &&
                            (LaneClearSettings.useWtentacles && minion.ServerPosition.IsInTentacleRange()))
                        {
                            SpellManager.W.Cast();
                        }
                        else if (minion != null && !LaneClearSettings.useWtentacles)
                        {
                            SpellManager.W.Cast();
                        }
                    return;
                }

                Utility.CastItems();
            };

            GameObject.OnCreate += delegate (GameObject sender, EventArgs args)
            {
                var obj = sender as Obj_AI_Base;

                if (obj == null || !obj.IsValid || !obj.IsAlly)
                    return;

                if (obj.Name.ToLower().Equals("god"))
                {
                    Core.DelayAction(() => TentacleList.Add((Obj_AI_Minion)obj), 1500);
                }
            };

            GameObject.OnDelete +=
                delegate (GameObject sender, EventArgs args)
                {
                    TentacleList.RemoveAll(t => t.NetworkId.Equals(sender.NetworkId));
                };

            Drawing.OnDraw += delegate
            {
                if (DrawSettings.disable) return;

                if (DrawSettings.drawTentacles)
                {
                    foreach (var tentacle in TentacleList)
                    {
                        Circle.Draw(Color.DarkGreen, SpellManager.Q.Range, tentacle.ServerPosition);
                    }
                }

                if (DrawSettings.drawMode == 1)
                {
                    if (DrawSettings.drawQ)
                        Circle.Draw(SpellManager.Q.IsReady() ? Color.Green : Color.Red, SpellManager.Q.Range,
                            Player.Instance.Position);

                    if (DrawSettings.drawW)
                        Circle.Draw(SpellManager.W.IsReady() ? Color.Green : Color.Red, SpellManager.W.Range,
                            Player.Instance.Position);

                    if (DrawSettings.drawE)
                        Circle.Draw(SpellManager.E.IsReady() ? Color.Green : Color.Red, SpellManager.E.Range,
                            Player.Instance.Position);

                    if (DrawSettings.drawR)
                        Circle.Draw(SpellManager.R.IsReady() ? Color.Green : Color.Red, SpellManager.R.Range,
                            Player.Instance.Position);
                }
                else if (DrawSettings.drawMode == 0)
                {
                    if (DrawSettings.drawQ)
                        if (SpellManager.Q.IsReady())
                        {
                            Circle.Draw(Color.DarkBlue, SpellManager.Q.Range, Player.Instance.Position);
                        }

                    if (DrawSettings.drawW)
                        if (SpellManager.W.IsReady())
                        {
                            Circle.Draw(Color.DarkBlue, SpellManager.W.Range, Player.Instance.Position);
                        }

                    if (DrawSettings.drawE)
                        if (SpellManager.E.IsReady())
                        {
                            Circle.Draw(Color.DarkBlue, SpellManager.E.Range, Player.Instance.Position);
                        }

                    if (DrawSettings.drawR)
                        if (SpellManager.R.IsReady())
                        {
                            Circle.Draw(Color.DarkBlue, SpellManager.R.Range, Player.Instance.Position);
                        }
                }
            };
        }

        public static void Initialize()
        {
        }
    }
}