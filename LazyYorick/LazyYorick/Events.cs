using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using DrawSettings = LazyYorick.Config.Modes.Drawings;
using SkinSettings = LazyYorick.Config.Modes.Skins;
using ComboSettings = LazyYorick.Config.Modes.Combo;
using HarassSettings = LazyYorick.Config.Modes.Harass;
using JungleClearSettings = LazyYorick.Config.Modes.JungleClear;
using LaneClearSettings = LazyYorick.Config.Modes.LaneClear;

// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyYorick
{
    internal static class Events
    {
        public static List<Obj_AI_Base> Graves = new List<Obj_AI_Base>();
        public static List<Obj_AI_Base> Ghouls = new List<Obj_AI_Base>();

        public static int GravesInRange =
            Graves.FindAll(x => x.IsValid && x.Distance(Player.Instance.ServerPosition) <= 900).Count;

        static Events()
        {
            Game.OnTick += delegate
            {
                if (SkinSettings.useSkin)
                {
                    Player.SetSkinId(SkinSettings.skinID);
                }
            };

            Obj_AI_Base.OnSpellCast += delegate(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                if (sender.IsMe && args.Slot == SpellSlot.Q &&
                    Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Name != "YorickQ2")
                {
                    Orbwalker.ResetAutoAttack();
                }
            };

            Orbwalker.OnPostAttack += delegate(AttackableUnit target, EventArgs args)
            {
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Name == "YorickQ2") return;

                if (SpellManager.Q.IsReady())
                {
                    if (ComboSettings.useQmode == 1 && target?.Type == GameObjectType.AIHeroClient &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                    {
                        SpellManager.Q.Cast();
                        return;
                    }

                    if (HarassSettings.useQmode == 1 && target?.Type == GameObjectType.AIHeroClient &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                    {
                        SpellManager.Q.Cast();
                        return;
                    }

                    if (JungleClearSettings.useQmode == 1 && target?.Type == GameObjectType.NeutralMinionCamp &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                    {
                        SpellManager.Q.Cast();
                        return;
                    }

                    if (LaneClearSettings.useQmode == 1 && target?.Type == GameObjectType.obj_AI_Minion &&
                        Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                    {
                        SpellManager.Q.Cast();
                        return;
                    }
                }

                Utility.CastItems();
            };

            GameObject.OnCreate += delegate(GameObject sender, EventArgs args)
            {
                var obj = sender as Obj_AI_Base;
                {
                    if (obj == null || !obj.IsValid || !obj.IsAlly)
                        return;

                    if (obj.Name.ToLower().Equals("yorickmarker"))
                    {
                        Core.DelayAction(() => Graves.Add((Obj_AI_Minion) obj), 200);
                    }

                    if (obj.Name.ToLower().Equals("yorickghoulmelee") || obj.Name.ToLower().Equals("yorickbigghoul"))
                    {
                        Core.DelayAction(() => Ghouls.Add((Obj_AI_Minion) obj), 200);
                        Graves.RemoveAll(x => x.IsValid);
                    }
                }
            };

            GameObject.OnDelete +=
                delegate(GameObject sender, EventArgs args)
                {
                    Graves.RemoveAll(t => t.NetworkId.Equals(sender.NetworkId));
                    Ghouls.RemoveAll(t => t.NetworkId.Equals(sender.NetworkId));
                };

            Drawing.OnDraw += delegate
            {
                if (DrawSettings.disable) return;

                switch (DrawSettings.drawMode)
                {
                    case 1:
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
                        break;
                    case 0:
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
                        break;
                }
            };
        }

        public static void Initialize()
        {
        }
    }
}