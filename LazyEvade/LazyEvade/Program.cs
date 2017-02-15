using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Detectors;
using LazyEvade.KappaCommon.SpellDetector.Events;
using SharpDX;
using Color = System.Drawing.Color;

namespace LazyEvade
{
    internal class Program
    {
        public static Menu Menu;
        public static Menu SubMenu { get; set; }

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            Menu = MainMenu.AddMenu("LazyEvade", "lazyevade");
            SubMenu = Menu.AddSubMenu("Block", "block");

            SubMenu.Add("enabled", new CheckBox("Enabled\n (ツ)_/¯"));

            SpellBlocker.Init();
        }
    }

    public static class SpellBlocker
    {
        public static Spell.SpellBase Q, W, E, R, R1;
        public static List<string> Hooks = new List<string>
        {
            "NautilusAnchorDragMissile",
            "RocketGrabMissile",
            "ThreshQMissile",
            "SadMummyBandageToss"
        };

        public static List<string> Shots = new List<string>
        {
            "AhriSeduceMissile",
            "BrandQMissile",
            "EliseHumanE",
            "Illaoiemis",
            "BlindMonkQOne",
            "JavelinToss",
            "RengarEEmpMis",
            "tahmkenchqmissile",
            "XerathMageSpearMissile",
            "DarkBindingMissile"
        };

        public static void Init()
        {
            OnSkillShotDetected.OnDetect += OnSkillShotDetected_OnDetect;
        }

        public static void OnSkillShotDetected_OnDetect(DetectedSkillshotData args)
        {
            if (args.Caster == null || !args.Caster.IsEnemy || !args.WillHit(Player.Instance) || !Program.SubMenu["enabled"].Cast<CheckBox>().CurrentValue)
            {
                return;
            }

            var hero = args.Caster as AIHeroClient;
            var player = Player.Instance;

            #region Skillshots

            foreach (var shot in Shots.Where(shot => args.Data.MissileName == shot))
            {
                if (player.BaseSkinName == "Zyra")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    E = new Spell.SimpleSkillshot(SpellSlot.E);
                    {
                        if (hero != null && W.IsReady() && E.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                            E.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Sivir")
                {
                    E = new Spell.Active(SpellSlot.E);
                    {
                        if (hero != null && E.IsReady())
                        {
                            E.Cast();
                        }
                    }
                }

                if (player.BaseSkinName == "Heimerdinger")
                {
                    Q = new Spell.SimpleSkillshot(SpellSlot.Q);
                    {
                        if (hero != null && Q.IsReady())
                        {
                            Q.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Leblanc")
                {
                    R = new Spell.Active(SpellSlot.R);
                    R1 = new Spell.SimpleSkillshot(SpellSlot.R);
                    {
                        if (hero != null && R.IsReady())
                        {
                            if (player.Spellbook.Spells[3].Name == "LeblancR")
                            {
                                R.Cast();
                                R1.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                            }
                            else
                            {
                                R1.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                            }
                        }
                    }
                }

                if (player.BaseSkinName == "Shaco")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Fiora")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast(hero.ServerPosition);
                        }
                    }
                }

                if (player.BaseSkinName == "Fizz")
                {
                    W = new Spell.Active(SpellSlot.E);
                    {
                        if (hero != null && E.IsReady() && E.ToggleState != 1)
                        {
                            E.Cast();
                        }
                    }
                }

                if (player.BaseSkinName == "Malzahar")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "MonkeyKing")
                {
                    W = new Spell.Active(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast();
                        }
                    }
                }

                if (player.BaseSkinName == "Yasuo")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 5));
                        }
                    }
                }

                if (player.BaseSkinName == "Nocturne")
                {
                    E = new Spell.Active(SpellSlot.E);
                    {
                        if (hero != null && E.IsReady())
                        {
                            E.Cast();
                        }
                    }
                }
            }

            #endregion

            #region Hooks

            foreach (var hook in Hooks.Where(hook => args.Data.MissileName == hook))
            {
                if (player.BaseSkinName == "Zyra")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    E = new Spell.SimpleSkillshot(SpellSlot.E);
                    {
                        if (hero != null && W.IsReady() && E.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                            E.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Sivir")
                {
                    E = new Spell.Active(SpellSlot.E);
                    {
                        if (hero != null && E.IsReady())
                        {
                            E.Cast();
                        }
                    }
                }

                if (player.BaseSkinName == "Anivia")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            Core.DelayAction(() => W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 50)), (int)player.Distance(hero) / 2);
                        }
                    }
                }

                if (player.BaseSkinName == "Heimerdinger")
                {
                    Q = new Spell.SimpleSkillshot(SpellSlot.Q);
                    {
                        if (hero != null && Q.IsReady())
                        {
                            Q.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Leblanc")
                {
                    R = new Spell.Active(SpellSlot.R);
                    R1 = new Spell.SimpleSkillshot(SpellSlot.R);
                    {
                        if (hero != null && R.IsReady())
                        {
                            if (player.Spellbook.Spells[3].Name == "LeblancR")
                            {
                                R.Cast();
                                R1.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                            }
                            else
                            {
                                R1.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 50));
                            }
                        }
                    }
                }

                if (player.BaseSkinName == "Shaco")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Fiora")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast(hero.ServerPosition);
                        }
                    }
                }

                if (player.BaseSkinName == "Fizz")
                {
                    E = new Spell.Active(SpellSlot.E);
                    {
                        if (hero != null && E.IsReady() && E.ToggleState != 1)
                        {
                            E.Cast();
                        }
                    }
                }

                if (player.BaseSkinName == "Malzahar")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 80));
                        }
                    }
                }

                if (player.BaseSkinName == "Trundle")
                {
                    E = new Spell.SimpleSkillshot(SpellSlot.E, 1000);
                    {
                        if (hero != null && E.IsReady())
                        {
                            Core.DelayAction(() => E.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 50)), (int)player.Distance(hero) / 2);
                        }
                    }
                }

                if (player.BaseSkinName == "MonkeyKing")
                {
                    W = new Spell.Active(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast();
                        }
                    }
                }

                if (player.BaseSkinName == "Yasuo")
                {
                    W = new Spell.SimpleSkillshot(SpellSlot.W);
                    {
                        if (hero != null && W.IsReady())
                        {
                            W.Cast((Vector3)player.ServerPosition.Extend(hero.ServerPosition, 5));
                        }
                    }
                }

                if (player.BaseSkinName == "Nocturne")
                {
                    E = new Spell.Active(SpellSlot.E);
                    {
                        if (hero != null && E.IsReady())
                        {
                            E.Cast();
                        }
                    }
                }
            }

            #endregion
        }
    }
}
