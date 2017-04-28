using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierWordIsNotInDictionary
// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyXayah
{
    public static class Config
    {
        private const string MenuName = "Lazy Xayah";
        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());

            ComboMenu.Initializer();
            HarassMenu.Initializer();
            LaneClearMenu.Initializer();
            JungleClearMenu.Initializer();
            FleeMenu.Initializer();
            MiscMenu.Initializer();
            //LastHitMenu.Initializer();
            DrawMenu.Initializer();
            SkinMenu.Initializer();
        }

        public static void Initialize()
        {
        }

        public static class ComboMenu
        {
            public static readonly Menu comboMenu;
            public static bool UseQ => comboMenu["Combo.UseQ"].Cast<CheckBox>().CurrentValue;
            public static int Qmana => comboMenu["Combo.Qmana"].Cast<Slider>().CurrentValue;
            public static bool UseW => comboMenu["Combo.UseW"].Cast<CheckBox>().CurrentValue;
            public static int Wmana => comboMenu["Combo.Wmana"].Cast<Slider>().CurrentValue;
            public static int AOEE => comboMenu["Combo.AOEE"].Cast<Slider>().CurrentValue;
            public static bool KSE => comboMenu["Combo.KSE"].Cast<CheckBox>().CurrentValue;
            public static int Emana => comboMenu["Combo.Emana"].Cast<Slider>().CurrentValue;
            public static bool UseR => comboMenu["Combo.UseR"].Cast<CheckBox>().CurrentValue;
            public static int AOER => comboMenu["Combo.AOER"].Cast<Slider>().CurrentValue;
            public static int QHC => comboMenu["Combo.QHC"].Cast<ComboBox>().CurrentValue;

            public static void Initializer()
            {
            }

            static ComboMenu()
            {
                comboMenu = Menu.AddSubMenu("Combo");

                comboMenu.Add("label", new Label("Q usage:"));
                comboMenu.AddSeparator(10);
                comboMenu.Add("Combo.UseQ", new CheckBox("Use Q"));
                comboMenu.Add("Combo.Qmana", new Slider("if Mana more than {0} %"));
                comboMenu.Add("Combo.QHC", new ComboBox("Hitchance: ", 1, "Low", "Medium", "High"));

                comboMenu.AddSeparator();

                comboMenu.Add("label1", new Label("W usage:"));
                comboMenu.AddSeparator(10);
                comboMenu.Add("Combo.UseW", new CheckBox("Use W"));
                comboMenu.Add("Combo.Wmana", new Slider("if Mana more than {0} %", 25));

                comboMenu.AddSeparator();

                comboMenu.Add("label2", new Label("E usage:"));
                comboMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    comboMenu.Add("Combo.UseE" + enemy.ChampionName, new CheckBox("Stun " + enemy.ChampionName, false));
                    comboMenu.AddSeparator(10);
                }
                comboMenu.Add("Combo.AOEE", new Slider("Auto Stun {0} enemies", 2, 1, 6));
                comboMenu.AddSeparator(15);
                comboMenu.Add("Combo.KSE", new CheckBox("Try to KS with E"));
                comboMenu.Add("Combo.Emana", new Slider("Use E if Mana more than {0} %"));

                comboMenu.AddSeparator();

                comboMenu.Add("label3", new Label("R usage:"));
                comboMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    comboMenu.Add("Combo.UseR" + enemy.ChampionName, new CheckBox("Ult " + enemy.ChampionName + " if killable", false));
                    comboMenu.AddSeparator(10);
                }
                comboMenu.Add("Combo.AOER", new Slider("Auto Ult {0} enemies", 4, 1, 6));

                comboMenu.AddSeparator();
            }
        }

        public static class FleeMenu
        {
            private static readonly Menu fleeMenu;
            public static bool UseQ => fleeMenu["Flee.UseQ"].Cast<CheckBox>().CurrentValue;
            public static bool UseE => fleeMenu["Flee.UseE"].Cast<CheckBox>().CurrentValue;


            public static void Initializer()
            {
            }

            static FleeMenu()
            {
                fleeMenu = Menu.AddSubMenu("Flee");

                fleeMenu.Add("Flee.UseQ", new CheckBox("Use Q"));
                fleeMenu.Add("Flee.UseE", new CheckBox("Use E"));
            }
        }

        public static class HarassMenu
        {
            public static readonly Menu harassMenu;
            public static bool UseQ => harassMenu["Harass.UseQ"].Cast<CheckBox>().CurrentValue;
            public static int Qmana => harassMenu["Harass.Qmana"].Cast<Slider>().CurrentValue;
            public static bool UseW => harassMenu["Harass.UseW"].Cast<CheckBox>().CurrentValue;
            public static int Wmana => harassMenu["Harass.Wmana"].Cast<Slider>().CurrentValue;
            public static int AOEE => harassMenu["Harass.AOEE"].Cast<Slider>().CurrentValue;
            public static bool KSE => harassMenu["Harass.KSE"].Cast<CheckBox>().CurrentValue;
            public static int Emana => harassMenu["Harass.Emana"].Cast<Slider>().CurrentValue;
            public static int QHC => harassMenu["Harass.QHC"].Cast<ComboBox>().CurrentValue;

            public static void Initializer()
            {
            }

            static HarassMenu()
            {
                harassMenu = Menu.AddSubMenu("Harass");

                harassMenu.Add("label", new Label("Q usage:"));
                harassMenu.AddSeparator(10);
                harassMenu.Add("Harass.UseQ", new CheckBox("Use Q"));
                harassMenu.Add("Harass.Qmana", new Slider("if Mana more than {0} %"));
                harassMenu.Add("Harass.QHC", new ComboBox("Hitchance: ", 1, "Low", "Medium", "High"));

                harassMenu.AddSeparator();

                harassMenu.Add("label1", new Label("W usage:"));
                harassMenu.AddSeparator(10);
                harassMenu.Add("Harass.UseW", new CheckBox("Use W"));
                harassMenu.Add("Harass.Wmana", new Slider("if Mana more than {0} %", 25));

                harassMenu.AddSeparator();

                harassMenu.Add("label2", new Label("E usage:"));
                harassMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    harassMenu.Add("Harass.UseE" + enemy.ChampionName, new CheckBox("Stun " + enemy.ChampionName, false));
                    harassMenu.AddSeparator(10);
                }
                harassMenu.Add("Harass.AOEE", new Slider("Auto Stun {0} enemies", 2, 1, 6));
                harassMenu.AddSeparator(15);
                harassMenu.Add("Harass.KSE", new CheckBox("Try to KS with E"));
                harassMenu.Add("Harass.Emana", new Slider("Use E if Mana more than {0} %"));

                harassMenu.AddSeparator();
            }
        }

        public static class LaneClearMenu
        {
            private static readonly Menu laneClearMenu;
            public static bool UseQ => laneClearMenu["LC.UseQ"].Cast<CheckBox>().CurrentValue;
            public static int Qmana => laneClearMenu["LC.Qmana"].Cast<Slider>().CurrentValue;
            public static bool UseE => laneClearMenu["LC.UseE"].Cast<CheckBox>().CurrentValue;
            public static int Emana => laneClearMenu["LC.Emana"].Cast<Slider>().CurrentValue;
            public static int Eminions => laneClearMenu["LC.Eminions"].Cast<Slider>().CurrentValue;

            public static void Initializer()
            {
            }

            static LaneClearMenu()
            {
                laneClearMenu = Menu.AddSubMenu("LaneClear");

                laneClearMenu.Add("label", new Label("Q usage:"));
                laneClearMenu.AddSeparator(10);
                laneClearMenu.Add("LC.UseQ", new CheckBox("Use Q"));
                laneClearMenu.Add("LC.Qmana", new Slider("if Mana more than {0} %", 40));
                laneClearMenu.AddSeparator();
                laneClearMenu.Add("label1", new Label("E usage:"));
                laneClearMenu.AddSeparator(10);
                laneClearMenu.Add("LC.UseE", new CheckBox("Use E"));
                laneClearMenu.Add("LC.Eminions", new Slider("if it kills {0} minions", 3, 1, 7));
                laneClearMenu.Add("LC.Emana", new Slider("and Mana more than {0} %", 40));
            }
        }

        public static class JungleClearMenu
        {
            public static readonly Menu jungleClearMenu;
            public static bool UseQ => jungleClearMenu["JC.UseQ"].Cast<CheckBox>().CurrentValue;
            public static int Qmana => jungleClearMenu["JC.Qmana"].Cast<Slider>().CurrentValue;
            public static bool UseW => jungleClearMenu["JC.UseW"].Cast<CheckBox>().CurrentValue;
            public static int Wmana => jungleClearMenu["JC.Wmana"].Cast<Slider>().CurrentValue;

            public static void Initializer()
            {
            }

            static JungleClearMenu()
            {
                jungleClearMenu = Menu.AddSubMenu("JungleClear");

                jungleClearMenu.Add("label", new Label("Q usage:"));
                jungleClearMenu.AddSeparator(10);
                jungleClearMenu.Add("JC.UseQ", new CheckBox("Use Q"));
                jungleClearMenu.Add("JC.Qmana", new Slider("if Mana more than {0} %"));

                jungleClearMenu.Add("label2", new Label("W usage:"));
                jungleClearMenu.Add("JC.UseW", new CheckBox("Use W"));
                jungleClearMenu.Add("JC.Wmana", new Slider("if Mana more than {0} %", 40));

                //jungleClearMenu.Add("JC.UseE", new CheckBox("Use E")); TODO: check if passive rdy 
            }
        }

        
        public static class LastHitMenu
        {
            public static void Initializer()
            {
            }

            static LastHitMenu()
            {
            }
        }


        public static class MiscMenu
        {
            public static readonly Menu miscMenu;
            public static int AOEE => miscMenu["Misc.AOEE"].Cast<Slider>().CurrentValue;
            public static bool KSE => miscMenu["Misc.KSE"].Cast<CheckBox>().CurrentValue;
            public static bool UseR => miscMenu["Misc.UseR"].Cast<CheckBox>().CurrentValue;
            public static bool BlockR => miscMenu["Misc.BlockR"].Cast<CheckBox>().CurrentValue;
            public static int AOER => miscMenu["Misc.AOER"].Cast<Slider>().CurrentValue;

            public static void Initializer()
            {
            }

            static MiscMenu()
            {
                miscMenu = Menu.AddSubMenu("Misc");

                miscMenu.Add("label", new Label("Auto E usage:"));
                miscMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    miscMenu.Add("Misc.UseE" + enemy.ChampionName, new CheckBox("Auto Stun " + enemy.ChampionName, false));
                    miscMenu.AddSeparator(10);
                }
                miscMenu.Add("Misc.AOEE", new Slider("Auto Stun {0} enemies", 2, 1, 6));
                miscMenu.AddSeparator(15);
                miscMenu.Add("Misc.KSE", new CheckBox("Auto KS with E"));

                miscMenu.AddSeparator();

                miscMenu.Add("label1", new Label("Auto R usage:"));
                miscMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    miscMenu.Add("Misc.UseR" + enemy.ChampionName, new CheckBox("Ult " + enemy.ChampionName + " if killable", false));
                    miscMenu.AddSeparator(10);
                }
                miscMenu.Add("Misc.AOER", new Slider("Auto Ult {0} enemies", 4, 1, 6));
                miscMenu.Add("Misc.BlockR", new CheckBox("Block Movement in R animation", false));

                miscMenu.AddSeparator();
            }
        }

        public static class DrawMenu
        {
            private static readonly Menu drawMenu;

            public static bool Disable => drawMenu["Drawings.Disable"].Cast<CheckBox>().CurrentValue;
            public static int Mode => drawMenu["Drawings.Mode"].Cast<ComboBox>().CurrentValue;
            //public static bool ComboDamage => drawMenu["Drawings.ComboDamage"].Cast<CheckBox>().CurrentValue;
            public static bool Q => drawMenu["Drawings.Q"].Cast<CheckBox>().CurrentValue;
            public static bool W => drawMenu["Drawings.W"].Cast<CheckBox>().CurrentValue;
            public static bool E => drawMenu["Drawings.E"].Cast<CheckBox>().CurrentValue;
            public static bool R => drawMenu["Drawings.R"].Cast<CheckBox>().CurrentValue;
            public static bool Lines => drawMenu["Drawings.Line"].Cast<CheckBox>().CurrentValue;
            public static bool Polys => drawMenu["Drawings.Poly"].Cast<CheckBox>().CurrentValue;

            public static void Initializer()
            {
            }

            static DrawMenu()
            {
                drawMenu = Menu.AddSubMenu("Drawings");

                drawMenu.Add("Drawings.Disable", new CheckBox("Disable all drawings", false));
                drawMenu.AddSeparator(20);

                drawMenu.Add("Drawings.Mode", new ComboBox("Draw SpellRanges:", 0, "Only ready", "always"));
                drawMenu.AddSeparator(20);

                drawMenu.Add("Drawings.Q", new CheckBox("Draw Q Range"));
                drawMenu.Add("Drawings.W", new CheckBox("Draw W Range"));
                drawMenu.Add("Drawings.E", new CheckBox("Draw E Range"));
                drawMenu.Add("Drawings.R", new CheckBox("Draw R Range"));
                
                drawMenu.AddSeparator();

                drawMenu.Add("Drawings.Line", new CheckBox("Draw lines to feathers"));
                drawMenu.Add("Drawings.Poly", new CheckBox("Draw feather hitboxes", false));

                //drawMenu.Add("Drawings.ComboDamage", new CheckBox("Draw Combo damage"));
            }
        }

        public static class SkinMenu
        {
            private static readonly Menu skinMenu;
            public static int SkinId => skinMenu["SkinID"].Cast<ComboBox>().CurrentValue;
            private static bool Enabled => skinMenu["Skins.Enable"].Cast<CheckBox>().CurrentValue;

            public static void Initializer()
            {
            }

            static SkinMenu()
            {
                skinMenu = Menu.AddSubMenu("Skins");

                skinMenu.Add("Skins.Enable", new CheckBox("Use Skinhack", false)).OnValueChange += delegate
                {
                    if (Player.Instance.SkinId != SkinId)
                    {
                        Player.SetSkin(Player.Instance.BaseSkinName, SkinId);
                    }
                };
                skinMenu.AddSeparator(10);

                skinMenu.Add("SkinID", new ComboBox("Skin : ", new[] { "Classic", "Cosmic Dusk" })).OnValueChange
                    += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                    {
                        if (Enabled && Player.Instance.SkinId != SkinId)
                        {
                            Player.SetSkin(Player.Instance.BaseSkinName, args.NewValue);
                        }
                    };
            }
        }
    }
}
