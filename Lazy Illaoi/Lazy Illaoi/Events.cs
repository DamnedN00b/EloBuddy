using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;

namespace Lazy_Illaoi
{
    internal class Events
    {
        public static AIHeroClient Player = ObjectManager.Player;
        public static List<Obj_AI_Minion> TentacleList = new List<Obj_AI_Minion>();

        public static void OnUpdate(EventArgs args)
        {
            if (Player.IsRecalling() || MenuGUI.IsChatOpen || Player.IsDead)
                return;

            Orbwalker.DisableAttacking = false;

            Helpers.SetMana();

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                ComboHandler.Combo();
            }

            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                HarassHandler.Harass();
            }

            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                FarmHandler.LaneClear();
                FarmHandler.JungleClear();
            }
        }

        public static void OnPostAttack(AttackableUnit unit, EventArgs args)
        {
            var tentaclesNear = TentacleList.FindAll(x => x.Distance(unit) <= Spells.Q.Range).Count;
            switch (Orbwalker.ActiveModesFlags)
            {
                case Orbwalker.ActiveModes.Combo:
                {
                    if (unit.Type == GameObjectType.AIHeroClient)
                    {
                        if (Init.ComboMenu["useW"].Cast<CheckBox>().CurrentValue)
                            if (Spells.W.IsReady())
                            {
                                if (unit.IsValidTarget(450))
                                {
                                    Spells.W.Cast();
                                }
                            }
                    }
                    break;
                }
                case Orbwalker.ActiveModes.Harass:
                {
                    if (unit.Type == GameObjectType.AIHeroClient)
                    {
                        if (Init.ComboMenu["useW"].Cast<CheckBox>().CurrentValue)
                            if (Spells.W.IsReady() && tentaclesNear > 0)
                            {
                                if (unit.IsValidTarget(450))
                                {
                                    Spells.W.Cast();
                                }
                            }
                    }
                    break;
                }
            }
        }

        public static void OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            throw new NotImplementedException();
        }

        public static void OnSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;

            switch (args.Slot)
            {
                case SpellSlot.W:
                    Orbwalker.ResetAutoAttack();
                    break;
            }
        }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsValid() || sender.IsAlly) return;
            var tentaclesNearGapcloser = TentacleList.Count(x => x.Distance(e.End) < Spells.Q.Range);

            if (Init.MiscMenu["gapcloserQ"].Cast<CheckBox>().CurrentValue &&
                e.End.Distance(Player.ServerPosition) <= Spells.Q.Range && Spells.Q.IsReady())
            {
                Spells.Q.Cast(e.End);
            }

            if (!Init.MiscMenu["gapcloserW"].Cast<CheckBox>().CurrentValue || !Spells.W.IsReady()) return;
            {
                if (tentaclesNearGapcloser > 0)
                {
                    Spells.W.Cast();
                }
            }
        }

        public static void OnCreateObj(GameObject sender, EventArgs args)
        {
            var minion = sender as Obj_AI_Minion;
            {
                if (minion == null || !minion.IsValid)
                    return;

                if (minion.IsAlly && minion.BaseSkinName.ToLower().Equals("illaoiminion"))
                    TentacleList.Add(minion);
            }
        }

        public static void OnDeleteObj(GameObject sender, EventArgs args)
        {
            {
                TentacleList.RemoveAll(t => t.NetworkId.Equals(sender.NetworkId));
            }
        }

        public static void OnDraw(EventArgs args)
        {
            if (Init.DrawMenu["drawT"].Cast<CheckBox>().CurrentValue)
            {
                foreach (var tentacle in TentacleList.Where(t => t.IsValid && t.IsVisible && t.IsHPBarRendered))
                {
                    new Circle { Color = Color.DarkViolet, Radius = Spells.Q.Range }.Draw(tentacle.Position);
                }
            }
            if (Init.DrawMenu["drawQ"].Cast<CheckBox>().CurrentValue && (Spells.Q.IsReady() && Spells.Q.IsLearned))
            {
                new Circle { Color = Color.Chartreuse, Radius = Spells.Q.Range }.Draw(Player.Position);
            }
            if (Init.DrawMenu["drawW"].Cast<CheckBox>().CurrentValue && (Spells.W.IsReady() && Spells.W.IsLearned))
            {
                new Circle { Color = Color.Black, Radius = 450 }.Draw(Player.Position);
            }
            if (Init.DrawMenu["drawE"].Cast<CheckBox>().CurrentValue && (Spells.E.IsReady() && Spells.E.IsLearned))
            {
                new Circle { Color = Color.Firebrick, Radius = Spells.E.Range }.Draw(Player.Position);
            }
            if (Init.DrawMenu["drawR"].Cast<CheckBox>().CurrentValue && (Spells.R.IsReady() && Spells.R.IsLearned))
            {
                new Circle { Color = Color.DarkBlue, Radius = Spells.R.Range }.Draw(Player.Position);
            }

        }
    }
}