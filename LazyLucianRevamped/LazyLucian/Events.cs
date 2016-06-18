using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;

namespace LazyLucian
{
    internal class Events
    {
        public static bool PassiveUp;
        public static float LastRcast;

        public static void OnUpdate(EventArgs args)
        {
            if (ObjectManager.Player.IsRecalling() ||
                MenuGUI.IsChatOpen ||
                ObjectManager.Player.IsDead)
                return;

            Helpers.BushWard();

            if (Init.MiscMenu["useKs"].Cast<CheckBox>().CurrentValue)
            {
                Spells.Ks();
            }
            
            if (Init.ComboMenu["useRkillable"].Cast<CheckBox>().CurrentValue)
            {
                if (Spells.R.IsReady() && Game.Time - LastRcast > 5 /* &&
                    ObjectManager.Player.ManaPercent > Init.ComboMenu["rMana"].Cast<Slider>().CurrentValue*/
                    )
                {
                    Spells.CastR();
                }
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                ComboHandler.Combo();
            }
            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                HarassHandler.Harass();
            }
            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) || 
                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                FarmHandler.LaneClear();
                FarmHandler.JungleClear();
            }
          }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            var playerPosition = ObjectManager.Player.Position.To2D();
            var direction1 = (ObjectManager.Player.ServerPosition - sender.ServerPosition).To2D().Normalized();
            const int distance = 475;
            const int stepSize = 20;

            if (!Spells.E.IsReady() ||
                !(Init.MiscMenu["gapcloser"].Cast<CheckBox>().CurrentValue &&
                e.Type == Gapcloser.GapcloserType.Skillshot) ||
                !(Init.MiscMenu["gapcloserT"].Cast<CheckBox>().CurrentValue &&
                e.Type == Gapcloser.GapcloserType.Targeted) ||
                sender.IsAlly || !sender.IsValid())
                return;
            {
                for (var step = 0f; step < 360; step += stepSize)
                {
                    var currentAngel = step * (float)Math.PI / 90;
                    var currentCheckPoint = playerPosition +
                                            distance * direction1.Rotated(currentAngel);

                    if (!Helpers.IsSafePosition((Vector3)currentCheckPoint) ||
                        NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Wall) ||
                        NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Building))
                        continue;
                    {
                        Spells.E.Cast((Vector3)currentCheckPoint);
                    }
                }
            }
        }


        public static void OnCastSpell(GameObject sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            if (args.SData.IsAutoAttack())
            {
                PassiveUp = false;
            }
            switch (args.Slot)
            {
                case SpellSlot.Q:
                case SpellSlot.W:
                    Orbwalker.ResetAutoAttack();
                    break;
            }
        }
        /*
        public static void OnAfterAttack(AttackableUnit target, EventArgs args)
        {
            
        }
        */
        public static void OnProcessSpellCast(GameObject sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            {
               switch (args.Slot)
                {
                    case SpellSlot.Q:
                    case SpellSlot.W:
                    case SpellSlot.R:
                        PassiveUp = true;
                        LastRcast = Game.Time;
                        if (Helpers.Youmuu.IsReady() &&
                            Init.ComboMenu["useYoumuu"].Cast<CheckBox>().CurrentValue)
                        {
                            Helpers.Youmuu.Cast();
                        }
                        if (Init.ComboMenu["useRlock"].Cast<CheckBox>().CurrentValue)
                        {
                            Spells.LockR();
                        }
                        break;
                    case SpellSlot.E:
                        PassiveUp = true;
                        Orbwalker.ResetAutoAttack();
                        break;                    
                }
            }
        }

        public static void OnDraw(EventArgs args)
        {
            if (Init.DrawMenu["drawQ"].Cast<CheckBox>().CurrentValue && (Spells.Q.IsReady() && Spells.Q.IsLearned))
            {
                new Circle { Color = Color.Chartreuse, Radius = Spells.Q.Range }.Draw(ObjectManager.Player.Position);
            }
            if (Init.DrawMenu["drawQextended"].Cast<CheckBox>().CurrentValue && (Spells.Q.IsReady() && Spells.Q.IsLearned))
            {
                new Circle { Color = Color.Fuchsia, Radius = Spells.Q1.Range }.Draw(ObjectManager.Player.Position);
            }
            if (Init.DrawMenu["drawW"].Cast<CheckBox>().CurrentValue && (Spells.W.IsReady() && Spells.W.IsLearned))
            {
                new Circle { Color = Color.Black, Radius = Spells.W.Range }.Draw(ObjectManager.Player.Position);
            }
            if (Init.DrawMenu["drawE"].Cast<CheckBox>().CurrentValue && (Spells.E.IsReady() && Spells.E.IsLearned))
            {
                new Circle { Color = Color.Firebrick, Radius = Spells.E.Range }.Draw(ObjectManager.Player.Position);
            }
            if (Init.DrawMenu["drawR"].Cast<CheckBox>().CurrentValue && (Spells.R.IsReady() && Spells.R.IsLearned))
            {
                new Circle { Color = Color.DarkBlue, Radius = Spells.R.Range }.Draw(ObjectManager.Player.Position);
            }
        }

    }
}