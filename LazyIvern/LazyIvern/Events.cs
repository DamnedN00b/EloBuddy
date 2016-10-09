using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using DrawSettings = LazyIvern.Config.Modes.Drawings;
using SkinSettings = LazyIvern.Config.Modes.Skins;
using ComboSettings = LazyIvern.Config.Modes.Combo;
using HarassSettings = LazyIvern.Config.Modes.Harass;
using JungleClearSettings = LazyIvern.Config.Modes.JungleClear;
using LaneClearSettings = LazyIvern.Config.Modes.LaneClear;

namespace LazyIvern
{
    internal static class Events
    {
        public static Obj_AI_Base Daisy;
        public static float LastW;

        static Events()
        {
            Game.OnTick += delegate
            {
                if (SkinSettings.useSkin)
                {
                    Player.SetSkinId(SkinSettings.skinID);
                }
            };

            Obj_AI_Base.OnProcessSpellCast += delegate(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                if (sender.IsMe && sender.IsValid && args.Slot == SpellSlot.W)
                {
                    LastW = Game.Time;
                }
            };

            Orbwalker.OnPostAttack += delegate(AttackableUnit target, EventArgs args) { Utility.CastItems(); };

            //player.onbuffgain ivernqallyjump

            GameObject.OnCreate += delegate(GameObject sender, EventArgs args)
            {
                var obj = sender as Obj_AI_Base;

                if (obj == null || !obj.IsValid || !obj.IsAlly)
                    return;

                if (obj.Name.ToLower().Equals("ivernminion"))
                {
                    Core.DelayAction(() => Daisy = obj, 200);
                }
            };

            GameObject.OnDelete += delegate (GameObject sender, EventArgs args)
            {
                var obj = sender as Obj_AI_Base;

                if (obj == null || !obj.IsValid || !obj.IsAlly)
                    return;

                if (obj.Name.ToLower().Equals("ivernminion"))
                {
                    Daisy = null;
                }
            };

            Drawing.OnDraw += delegate
            {
                if (DrawSettings.disable) return;

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