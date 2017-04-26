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
            //HarassMenu.Initializer();
            //LaneClearMenu.Initializer();
            //JungleClearMenu.Initializer();
            //FleeMenu.Initializer();
            //MiscMenu.Initializer();
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
            public static bool UseW => comboMenu["Combo.UseW"].Cast<CheckBox>().CurrentValue;
            public static int AOEE => comboMenu["Combo.AOEE"].Cast<Slider>().CurrentValue;
            public static bool KSE => comboMenu["Combo.KSE"].Cast<CheckBox>().CurrentValue;
            public static bool UseR => comboMenu["Combo.UseR"].Cast<CheckBox>().CurrentValue;
            public static bool BlockR => comboMenu["Combo.BlockR"].Cast<CheckBox>().CurrentValue;
            public static int AOER => comboMenu["Combo.AOER"].Cast<Slider>().CurrentValue;

            public static void Initializer()
            {
            }

            static ComboMenu()
            {
                comboMenu = Menu.AddSubMenu("Combo");

                comboMenu.Add("label3", new Label("Q usage:"));
                comboMenu.AddSeparator(10);
                comboMenu.Add("Combo.UseQ", new CheckBox("Use Q"));

                comboMenu.AddSeparator();

                comboMenu.Add("label6", new Label("W usage:"));
                comboMenu.AddSeparator(10);
                comboMenu.Add("Combo.UseW", new CheckBox("Use W"));

                comboMenu.AddSeparator();

                comboMenu.Add("label4", new Label("E usage:"));
                comboMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    comboMenu.Add("Combo.UseE" + enemy.ChampionName, new CheckBox("Stun " + enemy.ChampionName, false));
                    comboMenu.AddSeparator(10);
                }
                comboMenu.Add("Combo.AOEE", new Slider("Auto Stun {0} enemies", 2, 1, 6));
                comboMenu.AddSeparator(15);
                comboMenu.Add("Combo.KSE", new CheckBox("Try to KS with E"));

                comboMenu.AddSeparator();

                comboMenu.Add("label5", new Label("R usage:"));
                comboMenu.AddSeparator(10);
                foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(obj => obj.Team != Player.Instance.Team))
                {
                    comboMenu.Add("Combo.UseR" + enemy.ChampionName, new CheckBox("Ult " + enemy.ChampionName + " if killable", false));
                    comboMenu.AddSeparator(10);
                }
                comboMenu.Add("Combo.AOER", new Slider("Auto Ult {0} enemies", 4, 1, 6));
                comboMenu.Add("Combo.BlockR", new CheckBox("Block Movement in R animation", false));

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
            private static readonly Menu harassMenu;

            public static void Initializer()
            {
            }

            static HarassMenu()
            {
                harassMenu = Menu.AddSubMenu("Harass");

            }
        }

        public static class LaneClearMenu
        {
            private static readonly Menu laneClearMenu;

            public static void Initializer()
            {
            }

            static LaneClearMenu()
            {
                laneClearMenu = Menu.AddSubMenu("LaneClear");
            }
        }

        public static class JungleClearMenu
        {
            private static readonly Menu jungleClearMenu;

            public static void Initializer()
            {
            }

            static JungleClearMenu()
            {
                jungleClearMenu = Menu.AddSubMenu("JungleClear");
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
            private static readonly Menu miscMenu;

            public static void Initializer()
            {
            }

            static MiscMenu()
            {
                miscMenu = Menu.AddSubMenu("Misc");

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
