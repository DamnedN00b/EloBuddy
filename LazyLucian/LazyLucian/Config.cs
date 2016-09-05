using System;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable InconsistentNaming

namespace LazyLucian
{
    public static class Config
    {
        private const string MenuName = "Lazy Lucian";
        private static readonly Menu Menu;
        private static readonly Menu DrawMenu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Enjoy LazyLucian :)");
            Menu.AddLabel("Good luck, have fun!");

            Modes.Initialize();

            DrawMenu = Menu.AddSubMenu("Drawings");
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu ComboMenu,
                HarassMenu,
                LaneClearMenu,
                JungleClearMenu,
                LastHitMenu,
                FleeMenu,
                SkinMenu,
                PermaActiveMenu;

            static Modes()
            {
                ComboMenu = Menu.AddSubMenu("Combo");
                HarassMenu = Menu.AddSubMenu("Harass");
                LaneClearMenu = Menu.AddSubMenu("LaneClear");
                JungleClearMenu = Menu.AddSubMenu("JungleClear");
                LastHitMenu = Menu.AddSubMenu("LastHit");
                FleeMenu = Menu.AddSubMenu("Flee");
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
                //LastHit.Initialize();

                //Flee
                Flee.Initialize();

                //PermaActive
                PermaActive.Initialize();


            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _spellWeaving;
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useQ1;
                private static readonly Slider _useQ1mana;
                private static readonly CheckBox _useW;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _useE;
                private static readonly Slider _useEmana;
                private static readonly CheckBox _useR;

                static Combo()
                {
                    ComboMenu.AddGroupLabel("Combo");
                    _useQ = ComboMenu.Add("comboUseQ", new CheckBox("Use Q on Target"));
                    _useQmana = ComboMenu.Add("comboUseQmana", new Slider("Mana %"));
                    ComboMenu.AddSeparator(10);
                    _useQ1 = ComboMenu.Add("comboUseQ1", new CheckBox("Use extended Q"));
                    _useQ1mana = ComboMenu.Add("comboUseQ1mana", new Slider("Mana %"));
                    ComboMenu.AddSeparator(10);
                    _useW = ComboMenu.Add("comboUseW", new CheckBox("Use W"));
                    _useWmana = ComboMenu.Add("comboUseWmana", new Slider("Mana %"));
                    ComboMenu.AddSeparator(10);
                    _useE = ComboMenu.Add("comboUseE", new CheckBox("Use E to MousePosition"));
                    _useEmana = ComboMenu.Add("comboUseEmana", new Slider("Mana %"));
                    ComboMenu.AddSeparator(10);
                    _useR = ComboMenu.Add("comboUseR", new CheckBox("Use R on stunned/rooted enemies", false));
                        // Default false
                    ComboMenu.AddSeparator(10);
                    _spellWeaving = ComboMenu.Add("comboSpellWeaving", new CheckBox("Use SpellWeaving"));
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static int UseQmana => _useQmana.CurrentValue;
                public static bool UseQ1 => _useQ1.CurrentValue;
                public static int UseQ1mana => _useQ1mana.CurrentValue;
                public static bool UseW => _useW.CurrentValue;
                public static int UseWmana => _useWmana.CurrentValue;
                public static bool UseE => _useE.CurrentValue;
                public static int UseEmana => _useEmana.CurrentValue;
                public static bool UseR => _useR.CurrentValue;
                public static bool SpellWeaving => _spellWeaving.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _spellWeaving;
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useQ1;
                private static readonly Slider _useQ1mana;
                private static readonly CheckBox _useW;
                private static readonly Slider _useWmana;

                static Harass()
                {
                    HarassMenu.AddGroupLabel("Harass");
                    _useQ = HarassMenu.Add("harassUseQ", new CheckBox("Use Q"));
                    _useQmana = HarassMenu.Add("harassUseQmana", new Slider("Mana %"));
                    HarassMenu.AddSeparator(10);
                    _useQ1 = HarassMenu.Add("harassUseQ1", new CheckBox("Use extended Q"));
                    _useQ1mana = HarassMenu.Add("harassUseQ1mana", new Slider("Mana %"));
                    HarassMenu.AddSeparator(10);
                    _useW = HarassMenu.Add("harassUseW", new CheckBox("Use W"));
                    _useWmana = HarassMenu.Add("harassUseWmana", new Slider("Mana %"));
                    HarassMenu.AddSeparator(10);
                    _spellWeaving = HarassMenu.Add("harassSpellWeaving", new CheckBox("Use SpellWeaving"));
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static int UseQmana => _useQmana.CurrentValue;
                public static bool UseQ1 => _useQ1.CurrentValue;
                public static int UseQ1mana => _useQ1mana.CurrentValue;
                public static bool UseW => _useW.CurrentValue;
                public static int UseWmana => _useWmana.CurrentValue;

                public static bool SpellWeaving => _spellWeaving.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;

                static Flee()
                {
                    FleeMenu.AddGroupLabel("Flee");
                    _useW = FleeMenu.Add("fleeUseW", new CheckBox("Use W to get speed buff"));
                    FleeMenu.AddSeparator(10);
                    _useE = FleeMenu.Add("fleeUseE", new CheckBox("Use E to mouse"));
                    FleeMenu.AddSeparator(10);
                }

                public static bool UseW => _useW.CurrentValue;
                public static bool UseE => _useE.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _spellWeaving;

                static LaneClear()
                {
                    LaneClearMenu.AddGroupLabel("LaneClear");
                    _useQ = LaneClearMenu.Add("laneClearUseQ", new CheckBox("Use Q"));
                    _useQmana = LaneClearMenu.Add("laneClearUseQmana", new Slider("Mana %"));
                    LaneClearMenu.AddSeparator(10);
                    _useW = LaneClearMenu.Add("laneClearUseW", new CheckBox("Use W"));
                    _useWmana = LaneClearMenu.Add("laneClearUseWmana", new Slider("Mana %"));
                    LaneClearMenu.AddSeparator(10);
                    _spellWeaving = LaneClearMenu.Add("laneClearSpellWeaving", new CheckBox("Use SpellWeaving"));
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static int UseQmana => _useQmana.CurrentValue;
                public static bool UseW => _useW.CurrentValue;
                public static int UseWmana => _useWmana.CurrentValue;

                public static bool SpellWeaving => _spellWeaving.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _spellWeaving;

                static JungleClear()
                {
                    JungleClearMenu.AddGroupLabel("JungleClear");
                    _useQ = JungleClearMenu.Add("jungleClearUseQ", new CheckBox("Use Q"));
                    _useQmana = JungleClearMenu.Add("jungleClearUseQmana", new Slider("Mana %"));
                    JungleClearMenu.AddSeparator(10);
                    _useW = JungleClearMenu.Add("jungleClearUseW", new CheckBox("Use W"));
                    _useWmana = JungleClearMenu.Add("jungleClearUseWmana", new Slider("Mana %"));
                    JungleClearMenu.AddSeparator(10);
                    _spellWeaving = JungleClearMenu.Add("jungleClearSpellWeaving", new CheckBox("Use SpellWeaving"));
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static int UseQmana => _useQmana.CurrentValue;
                public static bool UseW => _useW.CurrentValue;
                public static int UseWmana => _useWmana.CurrentValue;

                public static bool SpellWeaving => _spellWeaving.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Skins
            {
                // ReSharper disable once NotAccessedField.Local
                private static readonly ComboBox SkinID;

                static Skins()
                {
                    SkinMenu.AddGroupLabel("Skins");
                    SkinMenu.Add("useSkin", new CheckBox("Use Skin"));
                    SkinID = SkinMenu.Add("skinID", new ComboBox("Currently used:", 3, "Classic Lucian", "Hired Gun Lucian", "Striker Lucian", "Chroma Yellow", "Chroma Red"
                        ,"Chroma Blue", "PROJECT: Lucian" ));
                    SkinMenu.AddSeparator(10);
                }

                public static void DoMagic(EventArgs args)
                {
                    if (SkinMenu["useSkin"].Cast<CheckBox>().CurrentValue)
                    {
                        Player.SetSkinId(SkinMenu["skinID"].Cast<ComboBox>().CurrentValue);
                    }
                }

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _spellWeaving;

                static LastHit()
                {
                    LastHitMenu.AddGroupLabel("LastHit");
                    _useQ = LastHitMenu.Add("lastHitUseQ", new CheckBox("Use Q"));
                    LastHitMenu.AddSeparator(10);
                    _useW = LastHitMenu.Add("lastHitUseW", new CheckBox("Use W"));
                    LastHitMenu.AddSeparator(10);
                    _spellWeaving = LastHitMenu.Add("lastHitSpellWeaving", new CheckBox("Use SpellWeaving"));
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static bool UseW => _useW.CurrentValue;

                public static bool SpellWeaving => _spellWeaving.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class PermaActive
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useQ1;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;

                static PermaActive()
                {
                    PermaActiveMenu.AddGroupLabel("PermaActive");

                    _useQ = PermaActiveMenu.Add("permaActiveUseQ", new CheckBox("Use Q to secure Kills"));
                    PermaActiveMenu.AddSeparator(10);

                    _useQ1 = PermaActiveMenu.Add("permaActiveUseQ1", new CheckBox("Use extended Q to secure Kills"));
                    PermaActiveMenu.AddSeparator(10);

                    _useW = PermaActiveMenu.Add("permaActiveUseW", new CheckBox("Use W to secure Kills"));
                    PermaActiveMenu.AddSeparator(10);

                    _useE = PermaActiveMenu.Add("permaActiveUseE",
                        new CheckBox("Use E to get in range for securing Kills"));
                    PermaActiveMenu.AddSeparator(10);
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static bool UseQ1 => _useQ1.CurrentValue;
                public static bool UseW => _useW.CurrentValue;
                public static bool UseE => _useE.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Drawings
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                static Drawings()
                {
                    DrawMenu.AddGroupLabel("Drawings");
                    _useQ = DrawMenu.Add("drawQ", new CheckBox("Draw Q"));
                    _useW = DrawMenu.Add("drawW", new CheckBox("Draw W"));
                    _useE = DrawMenu.Add("drawE", new CheckBox("Draw E"));
                    _useR = DrawMenu.Add("drawR", new CheckBox("Draw R"));
                }

                public static bool UseQ => _useQ.CurrentValue;
                public static bool UseW => _useW.CurrentValue;
                public static bool UseE => _useE.CurrentValue;
                public static bool UseR => _useR.CurrentValue;

                public static void Initialize()
                {
                }
            }
        }
    }
}