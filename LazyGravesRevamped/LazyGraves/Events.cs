using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace LazyGraves
{
    internal class Events
    {
        public static AIHeroClient Player = ObjectManager.Player;
        public static float Rtime { get; set; }
        public static float Etime { get; set; }
        public static float Wtime { get; set; }
        public static float Qtime { get; set; }
        public static int Shots { get; set; }

        public static void OnUpdate(EventArgs args)
        {
            if (Player.IsRecalling() || MenuGUI.IsChatOpen || Player.IsDead)
                return;

            Orbwalker.DisableAttacking = false;

            Helpers.SetMana();
            ComboHandler.Ks();

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                ComboHandler.Combo();
            }

            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                HarassHandler.Harass();
            }

            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                FarmHandler.JungleClear();
            }
            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                FarmHandler.LaneClear();
            }
        }

        public static void OnSpellCast(GameObject sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;

            if (args.Slot == SpellSlot.Q)
                Orbwalker.ResetAutoAttack();

            if (args.Slot == SpellSlot.E)
                Orbwalker.ResetAutoAttack();

            if (args.Slot == SpellSlot.R)
                Orbwalker.ResetAutoAttack();
        }

        public static void OnPreAttack(GameObject target, EventArgs args)
        {
            if (Player.HasBuff("GravesBasicAttackAmmo2") || Player.HasBuff("GravesBasicAttackAmmo1") ||
                !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) ||
                target.Type != GameObjectType.AIHeroClient || !Init.ComboMenu["disableAA"].Cast<CheckBox>().CurrentValue)
                return;

            if (Prediction.Position.Collision.LinearMissileCollision(
                target as Obj_AI_Base, Player.ServerPosition.To2D(), target.Position.To2D(), int.MaxValue,
                (int) target.BoundingRadius, 0))
            {
                Orbwalker.DisableAttacking = true;
            }
        }

        public static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Player.HasBuff("GravesBasicAttackAmmo2") || !Spells.E.IsReady() ||
                !Init.ComboMenu["useEreload"].Cast<CheckBox>().CurrentValue ||
                !(Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) ||
                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)))
                return;
            var direction = (Game.CursorPos - Player.ServerPosition).To2D().Normalized();

            for (var step = 0f; step < 360; step += 30)
            {
                for (var a = 450; a > 0; a -= 50)
                {
                    var currentAngle = step*(float) Math.PI/90;
                    var currentCheckPoint = Player.ServerPosition.To2D() +
                                            a*direction.Rotated(currentAngle);

                    if (NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Wall) ||
                        NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Building))
                        continue;
                    {
                        Spells.E.Cast((Vector3) currentCheckPoint);
                    }
                }
            }
        }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsValidTarget() || sender.IsAlly) return;

            if (Init.MiscMenu["gapcloserE"].Cast<CheckBox>().CurrentValue)
            {
                var direction = (e.End + Player.ServerPosition).To2D().Normalized();

                for (var step = 0f; step < 360; step += 30)
                {
                    for (var a = 200; a < 450; a += 50)
                    {
                        var currentAngle = step*(float) Math.PI/90;
                        var currentCheckPoint = Player.ServerPosition.To2D() +
                                                a*direction.Rotated(currentAngle);

                        if (!Helpers.IsSafePosition((Vector3) currentCheckPoint) ||
                            NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Wall) ||
                            NavMesh.GetCollisionFlags(currentCheckPoint).HasFlag(CollisionFlags.Building))
                            continue;
                        {
                            Spells.E.Cast((Vector3) currentCheckPoint);
                        }
                    }
                }
            }

            if (Init.MiscMenu["gapcloserW"].Cast<CheckBox>().CurrentValue &&
                Spells.W.IsReady() && Player.Distance(e.End) <= Spells.W.Range)
                Spells.W.Cast(e.End);
        }
    }
}