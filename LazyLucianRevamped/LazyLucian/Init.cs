using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace LazyLucian
{
    internal class Init
    {
        public static Menu Menu, ComboMenu, HarassMenu, FarmMenu, MiscMenu, DrawMenu;

        public static void LoadMenu()
        {
            Bootstrap.Init(null);

            Menu = MainMenu.AddMenu("Lazy Lucian", "LazyLucian");
            Menu.AddGroupLabel("Lazy Lucian");
            Menu.AddLabel("by DamnedNooB");
            Menu.AddSeparator();

            //-------------------------------------------------------------------------------------------------------------------
            /*
            *       _____                _             __  __                  
            *      / ____|              | |           |  \/  |                 
            *     | |     ___  _ __ ___ | |__   ___   | \  / | ___ _ __  _   _ 
            *     | |    / _ \| '_ ` _ \| '_ \ / _ \  | |\/| |/ _ \ '_ \| | | |
            *     | |___| (_) | | | | | | |_) | (_) | | |  | |  __/ | | | |_| |
            *      \_____\___/|_| |_| |_|_.__/ \___/  |_|  |_|\___|_| |_|\__,_|
            *                                                                  
            *                                                                  
            */

            ComboMenu = Menu.AddSubMenu("Combo", "Combo");
            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.AddLabel("Q - Piercing Light");
            ComboMenu.Add("useQcombo", new CheckBox("Use in Combo"));
            ComboMenu.Add("useQextended", new CheckBox("Use extended Q in Combo"));
            ComboMenu.Add("qMana", new Slider("Min Mana to use: ", 20, 1));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("W - Ardent Blaze");
            ComboMenu.Add("useWaaRange", new CheckBox("Use in AA - Range"));
            ComboMenu.Add("useWalways", new CheckBox("Use out of AA - Range"));
            ComboMenu.Add("wMana", new Slider("Min Mana to use: ", 20, 1));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("E - Relentless Pursuit");
            ComboMenu.Add("useEcombo", new CheckBox("Use E Logic"));
            ComboMenu.Add("useEmouse", new CheckBox("Use E to Mouse"));
            ComboMenu.Add("eMana", new Slider("Min Mana to use: ", 20, 1));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("R - The Culling");
            ComboMenu.Add("useRkillable", new CheckBox("Use if target is killable"));
            ComboMenu.Add("useRlock", new CheckBox("Lock on Target"));
            //ComboMenu.Add("rMana", new Slider("Min Mana to use: ", 20, 1));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("Misc Settings (Combo)");
            ComboMenu.Add("spellWeaving", new CheckBox("Use Passive (Spellweaving)"));
            ComboMenu.Add("useYoumuu", new CheckBox("Use Youmuu's GhostBlade for The Culling"));

            //-------------------------------------------------------------------------------------------------------------------
            /*
            *      _    _                           __  __                  
            *     | |  | |                         |  \/  |                 
            *     | |__| | __ _ _ __ __ _ ___ ___  | \  / | ___ _ __  _   _ 
            *     |  __  |/ _` | '__/ _` / __/ __| | |\/| |/ _ \ '_ \| | | |
            *     | |  | | (_| | | | (_| \__ \__ \ | |  | |  __/ | | | |_| |
            *     |_|  |_|\__,_|_|  \__,_|___/___/ |_|  |_|\___|_| |_|\__,_|
            *                                                               
            *                                                               
            */

            HarassMenu = Menu.AddSubMenu("Harass", "Harass");
            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.AddLabel("Q - Piercing Light");
            HarassMenu.Add("useQharass", new CheckBox("Use in Harass"));
            HarassMenu.Add("useQextended", new CheckBox("Use extended Q in Harass"));
            HarassMenu.Add("qMana", new Slider("Min Mana to use: ", 20, 1));
            HarassMenu.AddSeparator();

            HarassMenu.AddLabel("W - Ardent Blaze");
            HarassMenu.Add("useWaaRange", new CheckBox("Use in AA - Range"));
            HarassMenu.Add("useWalways", new CheckBox("Use out of AA - Range"));
            HarassMenu.Add("wMana", new Slider("Min Mana to use: ", 20, 1));
            HarassMenu.AddSeparator();

            HarassMenu.AddLabel("Misc Settings (Harass)");
            //HarassMenu.Add("manaCheck", new CheckBox("")); // soon(TM)
            HarassMenu.Add("spellWeaving", new CheckBox("Use Passive (Spellweaving)"));

            //-------------------------------------------------------------------------------------------------------------------
            /*
            *      ______                     __  __                  
            *     |  ____|                   |  \/  |                 
            *     | |__ __ _ _ __ _ __ ___   | \  / | ___ _ __  _   _ 
            *     |  __/ _` | '__| '_ ` _ \  | |\/| |/ _ \ '_ \| | | |
            *     | | | (_| | |  | | | | | | | |  | |  __/ | | | |_| |
            *     |_|  \__,_|_|  |_| |_| |_| |_|  |_|\___|_| |_|\__,_|
            *                                                         
            *                                                         
            */

            FarmMenu = Menu.AddSubMenu("Farm", "Farm");
            FarmMenu.AddGroupLabel("Farm Settings");
            FarmMenu.AddLabel("Q - Piercing Light");
            FarmMenu.Add("useQfarm", new CheckBox("Use in LaneClear"));
            FarmMenu.Add("qManaLane", new Slider("Min Mana to use in LaneClear: ", 20, 1));
            FarmMenu.Add("qMinionsLane", new Slider("Min Minions to use in LaneClear: ", 3, 1, 5));
            FarmMenu.AddSeparator();
            FarmMenu.Add("useQjungle", new CheckBox("Use in JungleClear"));
            FarmMenu.Add("qManaJungle", new Slider("Min Mana to use in JungleClear: ", 20, 1));
            FarmMenu.AddSeparator();

            FarmMenu.AddLabel("W - Ardent Blaze");
            FarmMenu.Add("useWfarm", new CheckBox("Use in LaneClear"));
            FarmMenu.Add("wManaLane", new Slider("Min Mana to use in LaneClear: ", 20, 1));
            FarmMenu.AddSeparator();
            FarmMenu.Add("useWjungle", new CheckBox("Use in JungleClear"));
            FarmMenu.Add("wManaJungle", new Slider("Min Mana to use in JungleClear: ", 20, 1));
            FarmMenu.AddSeparator();

            FarmMenu.AddLabel("Misc Settings (Farm)");
            FarmMenu.Add("spellWeaving", new CheckBox("Use Passive (Spellweaving)"));

            //-------------------------------------------------------------------------------------------------------------------
            /*
            *      __  __ _            __  __                  
            *     |  \/  (_)          |  \/  |                 
            *     | \  / |_ ___  ___  | \  / | ___ _ __  _   _ 
            *     | |\/| | / __|/ __| | |\/| |/ _ \ '_ \| | | |
            *     | |  | | \__ \ (__  | |  | |  __/ | | | |_| |
            *     |_|  |_|_|___/\___| |_|  |_|\___|_| |_|\__,_|
            *                                                  
            *                                                  
            */

            MiscMenu = Menu.AddSubMenu("Misc", "Misc");
            MiscMenu.AddGroupLabel("Miscellaneous Settings");
            MiscMenu.AddLabel("Anti Gapcloser Settings");
            MiscMenu.Add("gapcloser", new CheckBox("Use E - to avoid non targeted"));
            MiscMenu.Add("gapcloserT", new CheckBox("Use E - to avoid targeted"));
            MiscMenu.AddSeparator();
            MiscMenu.AddGroupLabel("Other Settings");
            MiscMenu.Add("useKs", new CheckBox("Use KillSecure - Logic"));

            //-------------------------------------------------------------------------------------------------------------------
            /*
            *      _____                       __  __                  
            *     |  __ \                     |  \/  |                 
            *     | |  | |_ __ __ ___      __ | \  / | ___ _ __  _   _ 
            *     | |  | | '__/ _` \ \ /\ / / | |\/| |/ _ \ '_ \| | | |
            *     | |__| | | | (_| |\ V  V /  | |  | |  __/ | | | |_| |
            *     |_____/|_|  \__,_| \_/\_/   |_|  |_|\___|_| |_|\__,_|
            *                                                          
            *                                                          
            */

            DrawMenu = Menu.AddSubMenu("Draw", "Draw");
            DrawMenu.AddGroupLabel("Draw Settings");
            DrawMenu.AddLabel("Spell Ranges");
            DrawMenu.Add("drawQ", new CheckBox("Draw Q Range"));
            DrawMenu.Add("drawQextended", new CheckBox("Draw Extended Q Range"));
            DrawMenu.Add("drawW", new CheckBox("Draw W Range"));
            DrawMenu.Add("drawE", new CheckBox("Draw E Range"));
            DrawMenu.Add("drawR", new CheckBox("Draw R Range"));

            //-------------------------------------------------------------------------------------------------------------------
            /*
            *      ______               _       
            *     |  ____|             | |      
            *     | |____   _____ _ __ | |_ ___ 
            *     |  __\ \ / / _ \ '_ \| __/ __|
            *     | |___\ V /  __/ | | | |_\__ \
            *     |______\_/ \___|_| |_|\__|___/
            *                                   
            *                                   
            */

            Game.OnUpdate += Events.OnUpdate;
            Gapcloser.OnGapcloser += Events.OnGapCloser;
            Obj_AI_Base.OnProcessSpellCast += Events.OnProcessSpellCast;
            Obj_AI_Base.OnSpellCast += Events.OnCastSpell;
            Drawing.OnDraw += Events.OnDraw;
            //Orbwalker.OnPostAttack += Events.OnAfterAttack;
        }
    }
}