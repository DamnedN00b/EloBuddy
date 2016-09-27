using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable StringLiteralsWordIsNotInDictionary
// ReSharper disable IdentifierWordIsNotInDictionary

// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable InconsistentNaming

namespace LazyIllaoi2
{
    public static class Config
    {
        private const string MenuName = "Lazy Illaoi";
        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Enjoy Lazy Illaoi :)");
            Menu.AddLabel("Good luck, have fun!");

            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            /// <summary>
            ///     <see cref="Initialize" /> <see cref="Menu" /> for each Mode
            /// </summary>
            private static readonly Menu
                ComboMenu,
                HarassMenu,
                LaneClearMenu,
                JungleClearMenu,
                LastHitMenu,
                FleeMenu,
                SkinMenu,
                DrawMenu,
                PermaActiveMenu;

            static Modes()
            {
                ComboMenu = Menu.AddSubMenu("Combo");
                HarassMenu = Menu.AddSubMenu("Harass");
                LaneClearMenu = Menu.AddSubMenu("LaneClear");
                JungleClearMenu = Menu.AddSubMenu("JungleClear");
                LastHitMenu = Menu.AddSubMenu("LastHit");
                FleeMenu = Menu.AddSubMenu("Flee");
                DrawMenu = Menu.AddSubMenu("Drawings");
                SkinMenu = Menu.AddSubMenu("Skins");
                PermaActiveMenu = Menu.AddSubMenu("PermaActive");

                // Initialize all modes
                // Combo
                Combo.Initialize();

                // Harass
                Harass.Initialize();

                //LaneClear
                LaneClear.Initialize();

                //JungleClear
                JungleClear.Initialize();

                //LastHit
                LastHit.Initialize();

                //Flee
                Flee.Initialize(); // Illaoi does not simply flee... :°)

                //Skins
                Skins.Initialize();

                //PermaActive
                PermaActive.Initialize();

                //Drawings
                Drawings.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly ComboBox _useQmode;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useWtentacles;
                private static readonly ComboBox _useWmode;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _useE;
                private static readonly Slider _useEmana;
                private static readonly CheckBox _useR;
                private static readonly ComboBox _useRmode;
                private static readonly Slider _useRenemySlider;
                private static readonly Slider _useRmana;

                static Combo()
                {
                    ComboMenu.AddGroupLabel("Combo");

                    _useQ = ComboMenu.Add("useQ", new CheckBox("Use Q"));
                    ComboMenu.AddSeparator(20);

                    _useQmode = ComboMenu.Add("useQmode", new ComboBox("Q Mode:", 1, "Always", "Only with Ghost"));
                    ComboMenu.AddSeparator(20);

                    _useQmana = ComboMenu.Add("useQmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(50);

                    _useW = ComboMenu.Add("useW", new CheckBox("Use W"));
                    ComboMenu.AddSeparator(20);

                    _useWtentacles = ComboMenu.Add("useWtentacles", new CheckBox("Only with Tentacles in Range"));
                    ComboMenu.AddSeparator(20);

                    _useWmode = ComboMenu.Add("useWmode", new ComboBox("W Mode:", 1, "Always", "After Attack"));
                    ComboMenu.AddSeparator(20);

                    _useWmana = ComboMenu.Add("useWmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(50);

                    _useE = ComboMenu.Add("useE", new CheckBox("Use E"));
                    ComboMenu.AddSeparator(20);

                    _useEmana = ComboMenu.Add("useEmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(50);

                    _useR = ComboMenu.Add("useR", new CheckBox("Use R", false));
                    ComboMenu.AddSeparator(20);

                    _useRmode = ComboMenu.Add("useRmode", new ComboBox("R Mode:", 1, "Always", "Only with Ghost"));
                    ComboMenu.AddSeparator(20);

                    _useRenemySlider = ComboMenu.Add("useR#", new Slider("If enemies >= {0}", 1, 1, 5));
                    ComboMenu.AddSeparator(20);

                    _useRmana = ComboMenu.Add("useRmana", new Slider("If Mana % > {0}", 0, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmode => _useQmode.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static bool useWtentacles => _useWtentacles.CurrentValue;
                public static int useWmode => _useWmode.CurrentValue;
                public static int useWmana => _useWmana.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;
                public static bool useR => _useR.CurrentValue;
                public static int useRmode => _useRmode.CurrentValue;
                public static int useRenemySlider => _useRenemySlider.CurrentValue;
                public static int useRmana => _useRmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly ComboBox _useQmode;
                private static readonly CheckBox _useW;
                private static readonly ComboBox _useWmode;
                private static readonly CheckBox _useWtentacles;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _useE;
                private static readonly Slider _useEmana;

                static Harass()
                {
                    HarassMenu.AddGroupLabel("Harass");

                    _useQ = HarassMenu.Add("useQ", new CheckBox("Use Q"));
                    HarassMenu.AddSeparator(20);

                    _useQmode = HarassMenu.Add("useQmode", new ComboBox("Q Mode:", 1, "Always", "Only with Ghost"));
                    HarassMenu.AddSeparator(20);

                    _useQmana = HarassMenu.Add("useQmana", new Slider("If Mana % > {0}", 60, 0, 100));
                    HarassMenu.AddSeparator(50);

                    _useW = HarassMenu.Add("useW", new CheckBox("Use W"));
                    HarassMenu.AddSeparator(20);

                    _useWtentacles = HarassMenu.Add("useWtentacles", new CheckBox("Only with Tentacles in Range"));
                    HarassMenu.AddSeparator(20);

                    _useWmode = HarassMenu.Add("useWmode", new ComboBox("W Mode:", 1, "Always", "After Attack"));
                    HarassMenu.AddSeparator(20);

                    _useWmana = HarassMenu.Add("useWmana", new Slider("If Mana % > {0}", 60, 0, 100));
                    HarassMenu.AddSeparator(50);

                    _useE = HarassMenu.Add("useE", new CheckBox("Use E"));
                    HarassMenu.AddSeparator(20);

                    _useEmana = HarassMenu.Add("useEmana", new Slider("If Mana % > {0}", 60, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmode => _useQmode.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static bool useWtentacles => _useWtentacles.CurrentValue;
                public static int useWmode => _useWmode.CurrentValue;
                public static int useWmana => _useWmana.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                static Flee()
                {
                    FleeMenu.AddGroupLabel("Illoi does not simply flee :°)");
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQminions;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useWtentacles;
                private static readonly ComboBox _useWmode;
                private static readonly Slider _useWmana;

                static LaneClear()
                {
                    LaneClearMenu.AddGroupLabel("LaneClear");

                    _useQ = LaneClearMenu.Add("useQ", new CheckBox("Use Q"));
                    LaneClearMenu.AddSeparator(20);

                    _useQmana = LaneClearMenu.Add("useQmana", new Slider("If Mana % > {0}", 60, 0, 100));
                    LaneClearMenu.AddSeparator(20);

                    _useQminions = LaneClearMenu.Add("useQminions", new Slider("If {0} minions hit", 3, 1, 7));
                    LaneClearMenu.AddSeparator(50);

                    _useW = LaneClearMenu.Add("useW", new CheckBox("Use W"));
                    LaneClearMenu.AddSeparator(20);

                    _useWtentacles = LaneClearMenu.Add("useWtentacles", new CheckBox("Only with Tentacles in Range"));
                    LaneClearMenu.AddSeparator(20);

                    _useWmode = LaneClearMenu.Add("useWmode", new ComboBox("W Mode:", 0, "Always", "Afterattack"));
                    LaneClearMenu.AddSeparator(20);

                    _useWmana = LaneClearMenu.Add("useWmana", new Slider("If Mana % > {0}", 80, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static int useQminions => _useQminions.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static bool useWtentacles => _useWtentacles.CurrentValue;
                public static int useWmode => _useWmode.CurrentValue;
                public static int useWmana => _useWmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useWtentacles;
                private static readonly ComboBox _useWmode;
                private static readonly Slider _useWmana;

                static JungleClear()
                {
                    JungleClearMenu.AddGroupLabel("JungleClear");

                    _useQ = JungleClearMenu.Add("useQ", new CheckBox("Use Q"));
                    JungleClearMenu.AddSeparator(20);

                    _useQmana = JungleClearMenu.Add("useQmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    JungleClearMenu.AddSeparator(50);

                    _useW = JungleClearMenu.Add("useW", new CheckBox("Use W"));
                    JungleClearMenu.AddSeparator(20);

                    _useWtentacles = JungleClearMenu.Add("useWtentacles", new CheckBox("Only with Tentacles in Range"));
                    JungleClearMenu.AddSeparator(20);

                    _useWmode = JungleClearMenu.Add("useWmode", new ComboBox("W Mode:", 0, "Always", "Afterattack"));
                    JungleClearMenu.AddSeparator(20);

                    _useWmana = JungleClearMenu.Add("useWmana", new Slider("If Mana % > {0}", 0, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static bool useWtentacles => _useWtentacles.CurrentValue;
                public static int useWmode => _useWmode.CurrentValue;
                public static int useWmana => _useWmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Skins
            {
                private static readonly CheckBox _useSkin;
                private static readonly ComboBox _skinID;

                static Skins()
                {
                    _useSkin = SkinMenu.Add("useSkin", new CheckBox("Use Skin"));
                    SkinMenu.AddSeparator(10);

                    _skinID = SkinMenu.Add("skinID", new ComboBox("Skin:", 1, "Classic", "Purple thing"));
                }

                public static bool useSkin => _useSkin.CurrentValue;
                public static int skinID => _skinID.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                static LastHit()
                {
                    LastHitMenu.AddGroupLabel("Nothing here :/");
                }

                public static void Initialize()
                {
                }
            }

            public static class PermaActive
            {

                static PermaActive()
                {
                    PermaActiveMenu.AddGroupLabel("KS Soon(TM)");
                }

                public static void Initialize()
                {
                }
            }

            public static class Drawings
            {
                private static readonly CheckBox _disable;
                private static readonly ComboBox _drawMode;
                private static readonly CheckBox _drawTentacles;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                static Drawings()
                {
                    DrawMenu.AddGroupLabel("Drawings");

                    _disable = DrawMenu.Add("disable", new CheckBox("Disable all drawings", false));
                    DrawMenu.AddSeparator(50);

                    _drawTentacles = DrawMenu.Add("drawTentacles", new CheckBox("Draw Tentacle Range"));
                    DrawMenu.AddSeparator(20);

                    _drawMode = DrawMenu.Add("skinID", new ComboBox("Draw:", 0, "Only ready", "always"));
                    DrawMenu.AddSeparator(20);

                    _drawQ = DrawMenu.Add("drawQ", new CheckBox("Draw Q"));
                    _drawW = DrawMenu.Add("drawW", new CheckBox("Draw W"));
                    _drawE = DrawMenu.Add("drawE", new CheckBox("Draw E"));
                    _drawR = DrawMenu.Add("drawR", new CheckBox("Draw R"));
                }

                public static bool disable => _disable.CurrentValue;
                public static int drawMode => _drawMode.CurrentValue;
                public static bool drawTentacles => _drawTentacles.CurrentValue;
                public static bool drawQ => _drawQ.CurrentValue;
                public static bool drawW => _drawW.CurrentValue;
                public static bool drawE => _drawE.CurrentValue;
                public static bool drawR => _drawR.CurrentValue;

                public static void Initialize()
                {
                }
            }
        }
    }
}