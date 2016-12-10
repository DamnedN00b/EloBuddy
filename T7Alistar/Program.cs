using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

// ReSharper disable IdentifierWordIsNotInDictionary
// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace T7_Alistar
{
    internal class Program
    {
        private const string ChampionName = "Alistar";
        private static Menu _menu, _combo, _harass, _laneclear, _misc, _draw, _jungleclear;
        private static readonly Spell.Targeted Ignt = new Spell.Targeted(Myhero.FindSummonerSpellSlotFromName("summonerdot"), 600);
        private static readonly Spell.Targeted Flash = new Spell.Targeted(Myhero.FindSummonerSpellSlotFromName("summonerflash"), 400);
        public static AIHeroClient Myhero => ObjectManager.Player;
        public static Item Potion { get; private set; }
        public static Item Biscuit { get; private set; }

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoad;
        }

        private static void OnLoad(EventArgs args)
        {
            if (Player.Instance.ChampionName != ChampionName)
            {
                return;
            }
            Chat.Print("<font color='#0040FF'>T7</font><font color='#346FC2'> " + ChampionName + "</font> : Loaded!(v1.2) (Updated for Rework by DamnedNooB)");
            Chat.Print(
                "<font color='#04B404'>By </font><font color='#FF0000'>T</font><font color='#FA5858'>o</font><font color='#FF0000'>y</font><font color='#FA5858'>o</font><font color='#FF0000'>t</font><font color='#FA5858'>a</font><font color='#0040FF'>7</font><font color='#FF0000'> <3 </font>");
            Drawing.OnDraw += OnDraw;
            Obj_AI_Base.OnLevelUp += OnLvlUp;
            Gapcloser.OnGapcloser += OnGapcloser;
            Interrupter.OnInterruptableSpell += OnInterrupt;
            Game.OnTick += OnTick;
            Potion = new Item((int) ItemId.Health_Potion);
            Biscuit = new Item((int) ItemId.Total_Biscuit_of_Rejuvenation);
            Player.LevelSpell(SpellSlot.Q);
            AttackableUnit.OnDamage += OnDamage;
            DatMenu();
        }

        private static void OnTick(EventArgs args)
        {
            if (Myhero.IsDead)
            {
                return;
            }

            var flags = Orbwalker.ActiveModesFlags;

            if (flags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo();
            }

            if (flags.HasFlag(Orbwalker.ActiveModes.Harass) && Myhero.ManaPercent > _harass["HMIN"].Cast<Slider>().CurrentValue)
            {
                Harass();
            }

            if (flags.HasFlag(Orbwalker.ActiveModes.LaneClear) && Myhero.ManaPercent > _laneclear["LMIN"].Cast<Slider>().CurrentValue)
            {
                Laneclear();
            }

            if (flags.HasFlag(Orbwalker.ActiveModes.JungleClear) && Myhero.ManaPercent > Slider(_jungleclear, "JMIN"))
            {
                Jungleclear();
            }

            Misc();
        }

        private static void OnLvlUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }

            var u = SpellSlot.Unknown;
            var q = SpellSlot.Q;
            var w = SpellSlot.W;
            var e = SpellSlot.E;
            var r = SpellSlot.R;

            /*>>*/
            SpellSlot[] sequence1 = { u, w, e, q, q, r, q, w, q, w, r, w, w, e, e, r, e, e, u };

            if (Check(_misc, "autolevel"))
            {
                Player.LevelSpell(sequence1[Myhero.Level]);
            }
        }

        #region Insec

        private static void Insec()
        {
            if (!Key(_misc, "INSECKEY"))
            {
                return;
            }

            var maxRange = Flash.Range + DemSpells.W.Range - 5;

            switch (Comb(_misc, "INSECMODE"))
            {
                case 0:
                    if (Flash.IsReady() && DemSpells.W.IsReady() && DemSpells.Q.IsReady() &&
                        Myhero.CountEnemiesInRange(1500) >= Slider(_misc, "AOEMIN"))
                    {
                        var enemies = EntityManager.Heroes.Enemies.Where(x => !x.IsDead && x.IsEnemy && x.IsValidTarget(maxRange - 20));

                        var aiHeroClients = enemies as IList<AIHeroClient> ?? enemies.ToList();
                        if (aiHeroClients.Count() == 1)
                        {
                            var enemy = aiHeroClients.ToList().FirstOrDefault();

                            if (enemy.CountEnemiesInRange(180) >= Slider(_misc, "AOEMIN"))
                            {
                                WQinsec(enemy);
                            }
                        }
                        else if (aiHeroClients.Count() > 1)
                        {
                            foreach (var enemy in aiHeroClients.OrderBy(x => x.Distance(Myhero.Position)).Where(enemy => enemy.CountEnemiesInRange(180) > Slider(_misc, "AOEMIN")))
                            {
                                WQinsec(enemy);
                            }
                        }
                    }
                    break;
                case 1:
                    var closestTurret = EntityManager.Turrets.Allies.Where(x => x.Health > 50 && x.Distance(Myhero.Position) < 1400).OrderBy(x => x.Distance(Myhero.Position)).FirstOrDefault();

                    var closestEnemy =
                        EntityManager.Heroes.Enemies.Where(x => !x.IsDead && x.Health > 50 && x.IsValidTarget(Flash.Range + 60)).OrderBy(x => x.Distance(Myhero.Position)).FirstOrDefault();

                    if (Flash.IsReady() && DemSpells.W.IsReady() && closestTurret != null && closestEnemy != null)
                    {
                        if (closestEnemy.Distance(closestTurret.Position) < 1400)
                        {
                            var distance = closestEnemy.Distance(closestTurret.Position);

                            var flashloc = closestTurret.Position.Extend(closestEnemy.Position, distance + 60).To3D();

                            if (Flash.Cast(flashloc))
                            {
                                Core.DelayAction(() => DemSpells.W.Cast(closestEnemy), 50);
                            }
                        }
                    }
                    break;
            }
        }

        #endregion Insec

        private static void Combo()
        {
            var target = TargetSelector.GetTarget(1200, DamageType.Physical, Player.Instance.Position);

            if (target != null && !target.IsInvulnerable)
            {
                var delay = Math.Max(0, target.Distance(Myhero.Position) - 365) / 1.2f - 25;
                var currentPos = target.Position;
                var knockbackPos = Myhero.Position.Extend(target.Position, 650);

                if (Check(_combo, "CE") && DemSpells.E.IsLearned && DemSpells.E.IsReady() &&
                    target.IsValidTarget(DemSpells.E.Range) && Myhero.Mana >= DemSpells.E.ManaCost)
                {
                    DemSpells.E.Cast();
                }

                if (Check(_combo, "CQ") && Check(_combo, "CW") && (DemSpells.Q.IsLearned && DemSpells.W.IsLearned) && (DemSpells.Q.IsReady() && DemSpells.W.IsReady()) &&
                    target.IsValidTarget(DemSpells.W.Range) && Myhero.Mana >= WQcost())
                {
                    if (DemSpells.Q.IsInRange(target.Position))
                    {
                        DemSpells.Q.Cast();
                    }

                    if (DemSpells.W.Cast(target))
                    {
                        Core.DelayAction(() => DemSpells.Q.Cast(), (int) delay);
                    }
                }
                else if (Check(_combo, "CQ") && DemSpells.Q.IsLearned && DemSpells.Q.IsReady() && target.IsValidTarget(DemSpells.Q.Range) &&
                         Myhero.CountEnemiesInRange(DemSpells.Q.Range) >= Slider(_combo, "CQMIN"))
                {
                    DemSpells.Q.Cast();
                }
                else if (Check(_combo, "CW") && DemSpells.W.IsLearned && DemSpells.W.IsReady() && target.IsValidTarget(DemSpells.W.Range) && EntityManager.Heroes.Allies.Any())
                {
                    var closestAlly = EntityManager.Heroes.Allies.Where(x => !x.IsDead && x.IsAlly && x.Distance(target.Position) < 1200).OrderBy(x => x.Distance(target.Position)).FirstOrDefault();

                    if (closestAlly.Distance(knockbackPos.To3D()) < closestAlly.Distance(currentPos) ||
                        knockbackPos.CountAlliesInRange(1000) > 0)
                    {
                        DemSpells.W.Cast(target);
                    }
                }
            }
        }

        private static void Harass()
        {
            var target = TargetSelector.GetTarget(1200, DamageType.Physical, Player.Instance.Position);

            if (target != null && target.IsValidTarget() && !target.IsInvulnerable)
            {
                if (Check(_harass, "HQ") && DemSpells.Q.IsLearned && DemSpells.Q.IsReady() &&
                    Myhero.CountEnemiesInRange(DemSpells.Q.Range) > Slider(_harass, "HQMIN"))
                {
                    DemSpells.Q.Cast();
                }

                if (Check(_harass, "HW") && DemSpells.W.IsLearned && DemSpells.W.IsReady() &&
                    target.Position.CountEnemiesInRange(1000) <= Slider(_harass, "HWMAX"))
                {
                    DemSpells.W.Cast(target);
                }

                if (Check(_harass, "HE") && DemSpells.E.IsLearned && DemSpells.E.IsReady() && target.IsValidTarget(DemSpells.E.Range))
                {
                    DemSpells.E.Cast();
                }
            }
        }

        private static void Laneclear()
        {
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Myhero.Position, 1000);

            if (minions != null)
            {
                var objAiMinions = minions as IList<Obj_AI_Minion> ?? minions.ToList();
                if (Check(_laneclear, "LQ") && DemSpells.Q.IsLearned && DemSpells.Q.IsReady() &&
                    objAiMinions.Count(x => x.Distance(Myhero.Position) < DemSpells.Q.Range) >= Slider(_laneclear, "LQMIN"))
                {
                    DemSpells.Q.Cast();
                }

                if (Check(_laneclear, "LE") && DemSpells.E.IsLearned && DemSpells.E.IsReady() &&
                    objAiMinions.Count(x => x.Distance(Myhero.Position) < DemSpells.E.Range) >= Slider(_laneclear, "LEMIN"))
                {
                    DemSpells.E.Cast();
                }
            }
        }

        private static void Jungleclear()
        {
            var monsters = EntityManager.MinionsAndMonsters.GetJungleMonsters(Myhero.Position, 850f);

            if (monsters != null)
            {
                var objAiMinions = monsters as IList<Obj_AI_Minion> ?? monsters.ToList();
                if (Check(_jungleclear, "JWQ") && (DemSpells.W.IsLearned && DemSpells.W.IsReady()) && (DemSpells.Q.IsLearned && DemSpells.Q.IsReady()) &&
                    Myhero.Mana >= WQcost())
                {
                    foreach (var delay in from monster in objAiMinions.Where(x => !x.IsDead && x.IsValidTarget(DemSpells.W.Range) && x.Health > 100)
                                          let delay = Math.Max(0, monster.Distance(Myhero.Position) - 365) / 1.2f - 25
                                          where objAiMinions.Count(x => !x.IsDead && x.Distance(monster.Position) < DemSpells.Q.Range) >= Slider(_jungleclear, "JWQMIN")
                                          where DemSpells.W.Cast(monster)
                                          select delay)
                    {
                        Core.DelayAction(() => DemSpells.Q.Cast(), (int) delay);
                    }
                }

                if (Check(_jungleclear, "JQ") && DemSpells.Q.IsLearned && DemSpells.Q.IsReady() &&
                    objAiMinions.Count(x => !x.IsDead && x.IsValidTarget(DemSpells.Q.Range)) >= Slider(_jungleclear, "JQMIN"))
                {
                    DemSpells.Q.Cast();
                }

                if (Check(_jungleclear, "JE") && DemSpells.E.IsLearned && DemSpells.E.IsReady() &&
                    objAiMinions.Any(x => !x.IsDead && x.IsValidTarget(DemSpells.E.Range)))
                {
                    DemSpells.E.Cast();
                }
            }
        }

        private static void Misc()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Magical, Player.Instance.Position);

            //var allies = EntityManager.Heroes.Allies.Where(x => !x.IsDead && x.IsAlly && !x.IsMe && x.Distance(Myhero.Position) < DemSpells.E.Range);
            var enemies = EntityManager.Heroes.Enemies.Where(x => !x.IsDead && x.IsEnemy && x.Distance(Myhero.Position) < 1500);

            if (Check(_misc, "skinhax"))
            {
                Myhero.SetSkinId(_misc["skinID"].Cast<ComboBox>().CurrentValue);
            }

            if (target != null && target.IsValidTarget() && !target.IsInvulnerable)
            {
                //var delay = Math.Max(0, target.Distance(Myhero.Position) - 365) / 1.2f - 25;

                if (Check(_misc, "KSQ") && DemSpells.Q.IsLearned && DemSpells.Q.IsReady() && target.IsValidTarget(DemSpells.Q.Range) &&
                    QDamage(target) > target.Health && !target.HasUndyingBuff() && !target.IsZombie && !target.IsInvulnerable)
                {
                    DemSpells.Q.Cast();
                }

                /* if (check(misc, "KSWQ") && (DemSpells.Q.IsLearned && DemSpells.W.IsLearned) && (DemSpells.Q.IsReady() && DemSpells.W.IsReady()) &&
                    target.IsValidTarget(DemSpells.W.Range) && myhero.Mana >= WQcost() &&
                    (QDamage(target) + WDamage(target)) > (target.Health + target.TotalMagicalDamage))
                {
                    if (DemSpells.Q.IsInRange(target.Position)) DemSpells.Q.Cast();

                    if (DemSpells.W.Cast(target))
                    {
                        Core.DelayAction(() => DemSpells.Q.Cast(), (int)delay);
                    }
                }*/

                if (Check(_misc, "autoign") && Ignt.IsReady() && target.IsValidTarget(Ignt.Range) &&
                    Myhero.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Ignite) > target.Health)
                {
                    Ignt.Cast(target);
                }
            }

            if (Check(_misc, "AUTOPOT") && (!Myhero.HasBuff("RegenerationPotion") || !Myhero.HasBuff("ItemMiniRegenPotion")) &&
                Myhero.HealthPercent <= Slider(_misc, "POTMIN"))
            {
                if (Item.HasItem(Potion.Id) && Item.CanUseItem(Potion.Id))
                {
                    Potion.Cast();
                }

                else if (Item.HasItem(Biscuit.Id) && Item.CanUseItem(Biscuit.Id))
                {
                    Biscuit.Cast();
                }
            }

            if (Key(_misc, "RKEY") && Comb(_misc, "RMODE") == 0 && DemSpells.R.IsLearned && DemSpells.R.IsReady() && Myhero.HealthPercent <= Slider(_misc, "RMINH") &&
                Myhero.CountEnemiesInRange(1000) > 0)
            {
                if (enemies.Count(x => x.Distance(Myhero.Position) < 500) >= Slider(_misc, "RMINE"))
                {
                    DemSpells.R.Cast();
                }
            }

            Insec();
        }

        private static void OnDraw(EventArgs args)
        {
            if (Myhero.IsDead)
            {
                return;
            }

            if (Check(_draw, "drawQ") && DemSpells.Q.Level > 0 && !Myhero.IsDead && !Check(_draw, "nodraw"))
            {
                if (Check(_draw, "drawonlyrdy"))
                {
                    Circle.Draw(DemSpells.Q.IsOnCooldown ? Color.Transparent : Color.Fuchsia, DemSpells.Q.Range, Myhero.Position);
                }

                else if (!Check(_draw, "drawonlyrdy"))
                {
                    Circle.Draw(Color.Fuchsia, DemSpells.Q.Range, Myhero.Position);
                }
            }

            if (Check(_draw, "drawW") && DemSpells.W.Level > 0 && !Myhero.IsDead && !Check(_draw, "nodraw"))
            {
                if (Check(_draw, "drawonlyrdy"))
                {
                    Circle.Draw(DemSpells.W.IsOnCooldown ? Color.Transparent : Color.Fuchsia, DemSpells.W.Range, Myhero.Position);
                }

                else if (!Check(_draw, "drawonlyrdy"))
                {
                    Circle.Draw(Color.Fuchsia, DemSpells.W.Range, Myhero.Position);
                }
            }

            if (Check(_draw, "drawE") && DemSpells.E.Level > 0 && !Myhero.IsDead && !Check(_draw, "nodraw"))
            {
                if (Check(_draw, "drawonlyrdy"))
                {
                    Circle.Draw(DemSpells.E.IsOnCooldown ? Color.Transparent : Color.Fuchsia, DemSpells.E.Range, Myhero.Position);
                }

                else if (!Check(_draw, "drawonlyrdy"))
                {
                    Circle.Draw(Color.Fuchsia, DemSpells.E.Range, Myhero.Position);
                }
            }

            if (Check(_draw, "DRAWMODES"))
            {
                Drawing.DrawText(Drawing.WorldToScreen(Myhero.Position).X - 50,
                    Drawing.WorldToScreen(Myhero.Position).Y + 25,
                    System.Drawing.Color.White,
                    "Auto R: ");
                Drawing.DrawText(Drawing.WorldToScreen(Myhero.Position).X,
                    Drawing.WorldToScreen(Myhero.Position).Y + 25,
                    Key(_misc, "RKEY") ? System.Drawing.Color.Green : System.Drawing.Color.Red,
                    Key(_misc, "RKEY") ? "ON" : "OFF");
                Drawing.DrawText(Drawing.WorldToScreen(Myhero.Position).X - 50,
                    Drawing.WorldToScreen(Myhero.Position).Y + 40,
                    System.Drawing.Color.White,
                    "Insec: ");
                Drawing.DrawText(Drawing.WorldToScreen(Myhero.Position).X - 9,
                    Drawing.WorldToScreen(Myhero.Position).Y + 40,
                    Key(_misc, "INSECKEY") ? System.Drawing.Color.Green : System.Drawing.Color.Red,
                    Key(_misc, "INSECKEY") ? "ON" : "OFF");
            }

            if (Check(_draw, "DRAWINSEC"))
            {
                switch (Comb(_misc, "INSECMODE"))
                {
                    case 0:
                        Circle.Draw(Color.Yellow, (Flash.Range + DemSpells.W.Range - 5), Myhero.Position);
                        break;
                    case 1:
                        Circle.Draw(Color.Yellow, Flash.Range, Myhero.Position);
                        break;
                }
            }
        }

        private static void OnGapcloser(Obj_AI_Base sender, Gapcloser.GapcloserEventArgs args)
        {
            if (sender != null && !sender.IsMe && sender.IsEnemy)
            {
                if (Check(_misc, "QGAP") && DemSpells.Q.IsLearned && DemSpells.Q.IsReady() && sender.Distance(Myhero.Position) < DemSpells.Q.Range)
                {
                    DemSpells.Q.Cast();
                }
                else if (Check(_misc, "WGAP") && DemSpells.W.IsLearned && DemSpells.W.IsReady() && sender.IsValidTarget(DemSpells.W.Range))
                {
                    DemSpells.W.Cast(sender);
                }
            }
        }

        private static void OnInterrupt(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (sender != null && !sender.IsMe && sender.IsEnemy)
            {
                switch (Comb(_misc, "INTDANGER"))
                {
                    case 0:
                        if (args.DangerLevel >= DangerLevel.Low)
                        {
                            if (Check(_misc, "QINT") && DemSpells.Q.IsReady() && sender.IsValidTarget(DemSpells.Q.Range))
                            {
                                DemSpells.Q.Cast();
                            }

                            else if (Check(_misc, "WINT") && DemSpells.W.IsReady() && sender.IsValidTarget(DemSpells.W.Range))
                            {
                                DemSpells.W.Cast(sender);
                            }
                        }
                        break;
                    case 1:
                        if (args.DangerLevel >= DangerLevel.Medium)
                        {
                            if (Check(_misc, "QINT") && DemSpells.Q.IsReady() && sender.IsValidTarget(DemSpells.Q.Range))
                            {
                                DemSpells.Q.Cast();
                            }

                            else if (Check(_misc, "WINT") && DemSpells.W.IsReady() && sender.IsValidTarget(DemSpells.W.Range))
                            {
                                DemSpells.W.Cast(sender);
                            }
                        }
                        break;
                    case 2:
                        if (args.DangerLevel == DangerLevel.High)
                        {
                            if (Check(_misc, "QINT") && DemSpells.Q.IsReady() && sender.IsValidTarget(DemSpells.Q.Range))
                            {
                                DemSpells.Q.Cast();
                            }

                            else if (Check(_misc, "WINT") && DemSpells.W.IsReady() && sender.IsValidTarget(DemSpells.W.Range))
                            {
                                DemSpells.W.Cast(sender);
                            }
                        }
                        break;
                }
            }
        }

        private static void OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs args)
        {
            if (!Key(_misc, "RKEY") || Comb(_misc, "RMODE") != 1 || !DemSpells.R.IsReady() ||
                Myhero.CountEnemiesInRange(1200) == 0)
            {
                return;
            }

            if (args.Target.NetworkId != Myhero.NetworkId ||
                !args.Target.IsMe)
            {
                return;
            }

            var player = args.Target;
            var damageDealt = (int) Math.Floor((args.Damage / player.MaxHealth) * 100);

            if ((damageDealt >= Slider(_misc, "RMIND") || player.HealthPercent < Slider(_misc, "RMINH")) && !player.IsDead && player.IsMe && player.IsAlly && player.NetworkId == Myhero.NetworkId &&
                Myhero.CountEnemiesInRange(700) >= Slider(_misc, "RMINE"))
            {
                DemSpells.R.Cast();
            }
        }

        private static void DatMenu()
        {
            _menu = MainMenu.AddMenu("T7 " + ChampionName, ChampionName.ToLower());
            _combo = _menu.AddSubMenu("Combo", "combo");
            _harass = _menu.AddSubMenu("Harass", "harass");
            _laneclear = _menu.AddSubMenu("Laneclear", "lclear");
            _jungleclear = _menu.AddSubMenu("Jungleclear", "jclear");
            _draw = _menu.AddSubMenu("Drawings", "draw");
            _misc = _menu.AddSubMenu("Misc", "misc");

            _menu.AddGroupLabel("Welcome to T7 " + ChampionName + " And Thank You For Using!");
            _menu.AddLabel("Version 1.2 10/12/2016");
            _menu.AddLabel("Author: Toyota7");
            _menu.AddSeparator();
            _menu.AddLabel("Please Report Any Bugs And If You Have Any Requests do not PM me because im inactive :°)");

            _combo.AddLabel("Spells");
            _combo.Add("CQ", new CheckBox("Use Q"));
            _combo.Add("CQMIN", new Slider("Min Enemies To Hit With Q", 1, 1, 5));
            _combo.AddSeparator();
            _combo.Add("CW", new CheckBox("Use W"));
            _combo.AddSeparator();
            _combo.Add("CE", new CheckBox("Use E"));
            _combo.AddSeparator();
            _combo.Add("Cignt", new CheckBox("Use Ignite", false));

            _harass.AddLabel("Spells");
            _harass.Add("HQ", new CheckBox("Use Q"));
            _harass.Add("HQMIN", new Slider("Min Enemies To Hit With Q", 1, 1, 5));
            _harass.AddSeparator();
            _harass.Add("HW", new CheckBox("Use W"));
            _harass.Add("HWMAX", new Slider("Dont Use W If More Than X Enemies Nearby", 2, 1, 4));
            _harass.AddSeparator();
            _harass.Add("HE", new CheckBox("Use E"));
            _harass.AddSeparator();
            _harass.Add("HMIN", new Slider("Min Mana % To Harass", 50));

            _laneclear.AddGroupLabel("Spells");
            _laneclear.Add("LQ", new CheckBox("Use Q"));
            _laneclear.Add("LQMIN", new Slider("Min Minions To Hit With Q", 3, 1, 10));
            _laneclear.AddSeparator();
            _laneclear.Add("LE", new CheckBox("Use E"));
            _laneclear.Add("LEMIN", new Slider("Min Minions To Hit With E", 3, 1, 10));
            _laneclear.AddSeparator();
            _laneclear.Add("LMIN", new Slider("Min Mana % To Laneclear", 50));

            _jungleclear.AddGroupLabel("Spells");
            _jungleclear.Add("JQ", new CheckBox("Use Q", false));
            _jungleclear.Add("JQMIN", new Slider("Min Minions To Hit With Q", 2, 1, 4));
            _jungleclear.AddSeparator();
            _jungleclear.Add("JWQ", new CheckBox("Use WQ Combo"));
            _jungleclear.Add("JWQMIN", new Slider("Min Minions To Hit With WQ", 2, 1, 4));
            _jungleclear.AddSeparator();
            _jungleclear.Add("JE", new CheckBox("Use E"));
            _jungleclear.AddSeparator();
            _jungleclear.Add("JMIN", new Slider("Min Mana % To Jungleclear", 10));

            _draw.Add("nodraw", new CheckBox("Disable All Drawings", false));
            _draw.AddSeparator();
            _draw.Add("drawQ", new CheckBox("Draw Q Range"));
            _draw.Add("drawW", new CheckBox("Draw W Range"));
            _draw.Add("drawE", new CheckBox("Draw E Range"));
            _draw.AddSeparator();
            _draw.Add("drawonlyrdy", new CheckBox("Draw Only Ready Spells", false));
            _draw.Add("DRAWMODES", new CheckBox("Draw Status Of All Modes"));
            _draw.Add("DRAWINSEC", new CheckBox("Draw Insec Ranges"));

            _misc.AddSeparator();
            _misc.AddGroupLabel("R usage");
            _misc.Add("RKEY", new KeyBind("Auto R Hotkey", false, KeyBind.BindTypes.PressToggle, 'J'));
            _misc.Add("RMODE", new ComboBox("R Mode", 1, "Min Health & Enemies", "% Damage Dealt"));
            _misc.AddLabel("R Mode Settings:", 6);
            _misc.AddLabel("Min Health");
            _misc.Add("RMINH", new Slider("My Health Is Less Than X%", 25, 1));
            _misc.AddLabel("Min Enemies");
            _misc.Add("RMINE", new Slider("More Than X Enemies Nearby", 1, 1, 5));
            _misc.AddLabel("Min Damage Dealt %");
            _misc.Add("RMIND", new Slider("Min % Damage Dealt By Enemy", 80, 1));
            _misc.AddSeparator();
            _misc.AddLabel("_____________________________________________________________________________");
            _misc.AddSeparator();
            _misc.AddGroupLabel("Insec");
            _misc.Add("INSECKEY", new KeyBind("Insec Key", false, KeyBind.BindTypes.HoldActive, 'I'));
            _misc.Add("INSECMODE", new ComboBox("Insec Mode", 0, "Flash + WQ", "Flash + W"));
            _misc.Add("AOEMIN", new Slider("Min Enemies To Hit With Flash + WQ", 2, 1, 5));
            _misc.AddSeparator();
            _misc.AddLabel("_____________________________________________________________________________");
            _misc.AddSeparator();
            _misc.AddGroupLabel("Killsteal");
            _misc.Add("KSQ", new CheckBox("Killsteal with Q", false));
            //  misc.Add("KSWQ", new CheckBox("Killsteal with WQ Combo", false));
            _misc.Add("autoign", new CheckBox("Auto Ignite If Killable"));
            _misc.AddSeparator();
            _misc.AddGroupLabel("Anti-Gapcloser");
            _misc.Add("QGAP", new CheckBox("Use Q On Gapclosers"));
            _misc.Add("WGAP", new CheckBox("Use W On Gapclosers"));
            _misc.AddSeparator();
            _misc.AddGroupLabel("Interrupter");
            _misc.Add("QINT", new CheckBox("Use Q To Interrupt"));
            _misc.Add("WINT", new CheckBox("Use W To Interrupt"));
            _misc.Add("INTDANGER", new ComboBox("Min Danger Level To Interrupt", 1, "Low", "Medium", "High"));
            _misc.AddSeparator();
            _misc.Add("AUTOPOT", new CheckBox("Auto Potion"));
            _misc.Add("POTMIN", new Slider("Min Health % To Activate Pot", 25, 1));
            _misc.AddSeparator();
            _misc.AddGroupLabel("Auto Level Up Spells");
            _misc.Add("autolevel", new CheckBox("Activate Auto Level Up Spells"));
            _misc.AddSeparator();
            _misc.AddGroupLabel("Skin Hack");
            _misc.Add("skinhax", new CheckBox("Activate Skin hack"));
            _misc.Add("skinID", new ComboBox("Skin Hack", 8, "Default", "Black", "Unchained", "Matador", "Longhorn", "Golden", "Infernal", "Sweeper", "Marauder"));
        }

        #region Extensions

        private static bool Check(Menu submenu, string sig)
        {
            return submenu[sig].Cast<CheckBox>().CurrentValue;
        }

        private static int Slider(Menu submenu, string sig)
        {
            return submenu[sig].Cast<Slider>().CurrentValue;
        }

        private static int Comb(Menu submenu, string sig)
        {
            return submenu[sig].Cast<ComboBox>().CurrentValue;
        }

        private static bool Key(Menu submenu, string sig)
        {
            return submenu[sig].Cast<KeyBind>().CurrentValue;
        }

        /*    private static float ComboDamage(AIHeroClient target)
        {
            if (target != null)
            {
                float TotalDamage = 0;

                if (DemSpells.Q.IsLearned && DemSpells.Q.IsReady()) { TotalDamage += QDamage(target); }

                if (DemSpells.W.IsLearned && DemSpells.W.IsReady()) { TotalDamage += WDamage(target); }

                if (Item1.IsOwned() && Item1.IsReady() && Item1.IsInRange(target.Position))
                { TotalDamage += myhero.GetItemDamage(target, Item1.Id); }

                return TotalDamage;
            }
            return 0;
        }*/

        private static float QDamage(AIHeroClient target)
        {
            var qDamage = new[] { 0, 60, 105, 150, 195, 240 }[DemSpells.Q.Level] +
                          (0.5f * Myhero.FlatMagicDamageMod);

            return Myhero.CalculateDamageOnUnit(target, DamageType.Magical, qDamage);
        }

        /*
        private static float WDamage(Obj_AI_Base target)
        {
            var wDamage = new[] { 0, 55, 110, 165, 220, 275 }[DemSpells.W.Level] +
                          (0.7f * Myhero.FlatMagicDamageMod);

            return Myhero.CalculateDamageOnUnit(target, DamageType.Magical, wDamage);
        }
*/

        private static int WQcost()
        {
            var cost = new[] { 0, 65, 70, 75, 80, 85 }[DemSpells.Q.Level] + new[] { 0, 65, 70, 75, 80, 85 }[DemSpells.W.Level];
            return cost;
        }

        private static void WQinsec(Obj_AI_Base target)
        {
            if (Myhero.Mana < WQcost())
            {
                return;
            }

            if (target != null)
            {
                var delay = Math.Max(0, target.Distance(Myhero.Position) - 365) / 1.2f - 25;

                if (Flash.Cast(Myhero.Position.Extend(target.Position, Flash.Range).To3D()))
                {
                    Core.DelayAction(delegate
                    {
                        if (DemSpells.Q.IsInRange(target.Position))
                        {
                            DemSpells.Q.Cast();
                        }

                        if (DemSpells.W.Cast(target))
                        {
                            Core.DelayAction(() => DemSpells.Q.Cast(), (int) delay);
                        }
                    }, 100);
                }
            }
        }

        #endregion Extensions
    }

    public static class DemSpells
    {
        static DemSpells()
        {
            Q = new Spell.Active(SpellSlot.Q, 365);
            W = new Spell.Targeted(SpellSlot.W, 650);
            E = new Spell.Active(SpellSlot.E, 300);
            R = new Spell.Active(SpellSlot.R);
        }

        public static Spell.Active Q { get; }
        public static Spell.Targeted W { get; }
        public static Spell.Active E { get; }
        public static Spell.Active R { get; }
    }
}
