using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable StringLiteralsWordIsNotInDictionary
// ReSharper disable IdentifierWordIsNotInDictionary

// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable InconsistentNaming

namespace LazyYorick
{
    public static class Config
    {
        private const string MenuName = "Lazy Yorick";
        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Enjoy Lazy Yorick :)");
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
                Flee.Initialize();

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
                private static readonly ComboBox _useQmode;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useWenemy;
                private static readonly Slider _useWenemyMana;
                private static readonly CheckBox _useWself;
                private static readonly Slider _useWselfMana;
                private static readonly Slider _useWselfHP;
                private static readonly Slider _useWselfEnemiesAround;
                private static readonly CheckBox _useE;
                private static readonly ComboBox _useEmode;
                private static readonly Slider _useEmana;
                private static readonly CheckBox _useR;
                private static readonly Slider _useRmana;

                static Combo()
                {
                    ComboMenu.AddGroupLabel("Combo");

                    _useQ = ComboMenu.Add("useQ", new CheckBox("Use Q"));
                    ComboMenu.AddSeparator(10);

                    _useQmode = ComboMenu.Add("useQmode", new ComboBox("Q Mode:", 1, "Always", "After Attack"));
                    _useQmana = ComboMenu.Add("useQmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(20);

                    _useW = ComboMenu.Add("useW", new CheckBox("Use W"));
                    ComboMenu.AddSeparator(10);

                    _useWenemy = ComboMenu.Add("useWenemy", new CheckBox("Use on Target"));
                    _useWenemyMana = ComboMenu.Add("useWenemyMana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(10);

                    _useWself = ComboMenu.Add("useWself", new CheckBox("Use on self"));
                    _useWselfMana = ComboMenu.Add("useWselfMana", new Slider("If Mana % > {0}", 0, 0, 100));
                    _useWselfHP = ComboMenu.Add("useWselfHP", new Slider("If HP % < {0}", 15, 0, 100));
                    _useWselfEnemiesAround = ComboMenu.Add("useWselfEnemiesAround",
                        new Slider("If Enemies around >= {0}", 1, 0, 5));
                    ComboMenu.AddSeparator(20);

                    _useE = ComboMenu.Add("useE", new CheckBox("Use E"));
                    ComboMenu.AddSeparator(10);

                    _useEmode = ComboMenu.Add("useEmode", new ComboBox("E Mode:", 1, "Always", "Only with Ghouls"));
                    _useEmana = ComboMenu.Add("useEmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(20);

                    _useR = ComboMenu.Add("useR", new CheckBox("Use R", false));
                    ComboMenu.AddSeparator(10);

                    _useRmana = ComboMenu.Add("useRmana", new Slider("If Mana % > {0}", 0, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static int useQmode => _useQmode.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static bool useWenemy => _useWenemy.CurrentValue;
                public static int useWenemyMana => _useWenemyMana.CurrentValue;
                public static bool useWself => _useWself.CurrentValue;
                public static int useWselfMana => _useWselfMana.CurrentValue;
                public static int useWselfHp => _useWselfHP.CurrentValue;
                public static int useWselfEnemiesAround => _useWselfEnemiesAround.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmode => _useEmode.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;
                public static bool useR => _useR.CurrentValue;
                public static int useRmana => _useRmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly ComboBox _useQmode;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useWenemy;
                private static readonly Slider _useWenemyMana;
                private static readonly CheckBox _useWself;
                private static readonly Slider _useWselfMana;
                private static readonly Slider _useWselfHP;
                private static readonly Slider _useWselfEnemiesAround;
                private static readonly CheckBox _useE;
                private static readonly ComboBox _useEmode;
                private static readonly Slider _useEmana;

                static Harass()
                {
                    HarassMenu.AddGroupLabel("Harass");

                    _useQ = HarassMenu.Add("useQ", new CheckBox("Use Q"));
                    HarassMenu.AddSeparator(10);

                    _useQmode = HarassMenu.Add("useQmode", new ComboBox("Q Mode:", 1, "Always", "After Attack"));
                    _useQmana = HarassMenu.Add("useQmana", new Slider("If Mana % > {0}", 60, 0, 100));
                    HarassMenu.AddSeparator(20);

                    _useW = HarassMenu.Add("useW", new CheckBox("Use W"));
                    HarassMenu.AddSeparator(10);

                    _useWenemy = HarassMenu.Add("useWenemy", new CheckBox("Use on Target"));
                    _useWenemyMana = HarassMenu.Add("useWenemyMana", new Slider("If Mana % > {0}", 60, 0, 100));
                    HarassMenu.AddSeparator(10);

                    _useWself = HarassMenu.Add("useWself", new CheckBox("Use on self"));
                    _useWselfMana = HarassMenu.Add("useWselfMana", new Slider("If Mana % > {0}", 0, 0, 100));
                    _useWselfHP = HarassMenu.Add("useWselfHP", new Slider("If HP % < {0}", 15, 0, 100));
                    _useWselfEnemiesAround = HarassMenu.Add("useWselfEnemiesAround",
                        new Slider("If Enemies around >= {0}", 1, 0, 5));
                    HarassMenu.AddSeparator(20);

                    _useE = HarassMenu.Add("useE", new CheckBox("Use E"));
                    HarassMenu.AddSeparator(10);

                    _useEmode = HarassMenu.Add("useEmode", new ComboBox("E Mode:", 1, "Always", "Only with Ghouls"));
                    _useEmana = HarassMenu.Add("useEmana", new Slider("If Mana % > {0}", 60, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static int useQmode => _useQmode.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static bool useWenemy => _useWenemy.CurrentValue;
                public static int useWenemyMana => _useWenemyMana.CurrentValue;
                public static bool useWself => _useWself.CurrentValue;
                public static int useWselfMana => _useWselfMana.CurrentValue;
                public static int useWselfHp => _useWselfHP.CurrentValue;
                public static int useWselfEnemiesAround => _useWselfEnemiesAround.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmode => _useEmode.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;

                static Flee()
                {
                    FleeMenu.AddGroupLabel("Flee");
                    _useW = FleeMenu.Add("useW", new CheckBox("Use W"));
                }

                public static bool useW => _useW.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly ComboBox _useQmode;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useE;
                private static readonly ComboBox _useEmode;
                private static readonly Slider _useEmana;

                static LaneClear()
                {
                    LaneClearMenu.AddGroupLabel("LaneClear");

                    _useQ = LaneClearMenu.Add("useQ", new CheckBox("Use Q"));
                    LaneClearMenu.AddSeparator(10);
                    _useQmode = LaneClearMenu.Add("useQmode",
                        new ComboBox("Q Mode:", 2, "Always", "After Attack", "Only killable"));
                    _useQmana = LaneClearMenu.Add("useQmana", new Slider("If Mana % > {0}", 40, 0, 100));
                    LaneClearMenu.AddSeparator(20);

                    _useE = LaneClearMenu.Add("useE", new CheckBox("Use E"));
                    LaneClearMenu.AddSeparator(10);

                    _useEmode = LaneClearMenu.Add("useEmode", new ComboBox("E Mode:", 1, "Always", "Only with Ghouls"));
                    _useEmana = LaneClearMenu.Add("useEmana", new Slider("If Mana % > {0}", 40, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static int useQmode => _useQmode.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmode => _useEmode.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly ComboBox _useQmode;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useE;
                private static readonly ComboBox _useEmode;
                private static readonly Slider _useEmana;

                static JungleClear()
                {
                    JungleClearMenu.AddGroupLabel("JungleClear");

                    _useQ = JungleClearMenu.Add("useQ", new CheckBox("Use Q"));
                    JungleClearMenu.AddSeparator(10);

                    _useQmode = JungleClearMenu.Add("useQmode",
                        new ComboBox("Q Mode:", 2, "Always", "After Attack", "Only killable"));
                    _useQmana = JungleClearMenu.Add("useQmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    JungleClearMenu.AddSeparator(20);

                    _useE = JungleClearMenu.Add("useE", new CheckBox("Use E"));
                    JungleClearMenu.AddSeparator(10);

                    _useEmode = JungleClearMenu.Add("useEmode", new ComboBox("E Mode:", 1, "Always", "Only with Ghouls"));
                    _useEmana = JungleClearMenu.Add("useEmana", new Slider("If Mana % > {0}", 0, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static int useQmode => _useQmode.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmode => _useEmode.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;

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

                    _skinID = SkinMenu.Add("skinID", new ComboBox("Skin:", 2, "Classic", "Undertaker", "Pentakill"));
                }

                public static bool useSkin => _useSkin.CurrentValue;
                public static int skinID => _skinID.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;

                static LastHit()
                {
                    LastHitMenu.AddGroupLabel("LastHit");

                    _useQ = LastHitMenu.Add("useQ", new CheckBox("Use Q"));
                    LastHitMenu.AddSeparator(10);

                    _useQmana = LastHitMenu.Add("useQmana", new Slider("If Mana % > {0}", 0, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class PermaActive
            {
                private static readonly CheckBox _useQks;
                private static readonly CheckBox _useEks;
                private static readonly CheckBox _useQghouls;
                private static readonly Slider _useQghoulsValue;

                static PermaActive()
                {
                    _useQghouls = PermaActiveMenu.Add("useQghouls", new CheckBox("Use Q to summon ghouls"));
                    _useQghoulsValue = PermaActiveMenu.Add("useQghoulsValue",
                        new Slider("If Graves around: {0}", 4, 3, 4));
                    PermaActiveMenu.AddSeparator(20);

                    _useQks = PermaActiveMenu.Add("useQks", new CheckBox("Use Q to ks"));
                    PermaActiveMenu.AddSeparator(10);

                    _useEks = PermaActiveMenu.Add("useEks", new CheckBox("Use E to ks"));
                }

                public static bool useQks => _useQks.CurrentValue;
                public static bool useEks => _useEks.CurrentValue;
                public static bool useQghouls => _useQghouls.CurrentValue;
                public static int useQghoulsValue => _useQghoulsValue.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Drawings
            {
                private static readonly CheckBox _disable;
                private static readonly ComboBox _drawMode;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                static Drawings()
                {
                    DrawMenu.AddGroupLabel("Drawings");

                    _disable = DrawMenu.Add("disable", new CheckBox("Disable all drawings", false));
                    DrawMenu.AddSeparator(10);

                    _drawMode = DrawMenu.Add("skinID", new ComboBox("Draw:", 0, "Only ready", "always"));
                    DrawMenu.AddSeparator(10);

                    _drawQ = DrawMenu.Add("drawQ", new CheckBox("Draw Q"));
                    _drawW = DrawMenu.Add("drawW", new CheckBox("Draw W"));
                    _drawE = DrawMenu.Add("drawE", new CheckBox("Draw E"));
                    _drawR = DrawMenu.Add("drawR", new CheckBox("Draw R"));
                }

                public static bool disable => _disable.CurrentValue;
                public static int drawMode => _drawMode.CurrentValue;
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