using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace LazyGraves
{
    internal class Init
    {
        public static Menu Menu, ComboMenu, HarassMenu, FarmMenu, MiscMenu, DrawMenu;

        public static void LoadMenu()
        {
            Bootstrap.Init(null);

            Menu = MainMenu.AddMenu("Lazy Graves", "LazyGraves");
            Menu.AddGroupLabel("Lazy Graves");
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
            ComboMenu.AddLabel("Q - BuckShot");
            ComboMenu.Add("useQ", new CheckBox("Use Q Logic"));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("W - Smoke Grenade");
            ComboMenu.Add("useW", new CheckBox("Use W Logic"));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("E - True Grit");
            ComboMenu.Add("useE", new CheckBox("Use Logic"));
            ComboMenu.Add("useEreload", new CheckBox("Use to reload"));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("Boom");
            ComboMenu.Add("useQR", new CheckBox("Use Fast Q-R Combo"));
            ComboMenu.Add("useR", new CheckBox("Use to kill"));
            ComboMenu.AddSeparator();

            ComboMenu.AddLabel("Misc");
            ComboMenu.Add("disableAA", new CheckBox("Disable AA if Collision"));

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

            HarassMenu.AddLabel("Q - Buckshot");
            HarassMenu.Add("useQ", new CheckBox("Use in Harass"));
            HarassMenu.Add("qMana", new Slider("Min Mana to use: ", 20, 1));
            HarassMenu.AddSeparator();

            HarassMenu.AddLabel("W - Smoke Grenade");
            HarassMenu.Add("useW", new CheckBox("Use in AA - Range"));
            HarassMenu.Add("wMana", new Slider("Min Mana to use: ", 20, 1));
            HarassMenu.AddSeparator();

            //HarassMenu.AddLabel("E - True Grit");
            //HarassMenu.Add("useEreload", new CheckBox("Use to reload"));
            //HarassMenu.Add("eMana", new Slider("Min Mana to use: ", 20, 1));
            HarassMenu.AddSeparator();


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

            FarmMenu.AddLabel("Q - Buckshot");
            FarmMenu.Add("useQlane", new CheckBox("Use in LaneClear"));
            FarmMenu.Add("qManaLane", new Slider("Min Mana to use in LaneClear: ", 20, 1));
            FarmMenu.Add("qMinionsLane", new Slider("Min Minions to use in LaneClear: ", 3, 1, 6));
            FarmMenu.AddSeparator();

            FarmMenu.Add("useQjungle", new CheckBox("Use in JungleClear"));
            FarmMenu.AddSeparator();
            
            FarmMenu.AddLabel("E - True Grit");
            FarmMenu.Add("useEreload", new CheckBox("Use in LaneClear"));
            FarmMenu.Add("eManaLane", new Slider("Min Mana to use in LaneClear: ", 20));
            FarmMenu.AddSeparator();
            /* 
            FarmMenu.Add("useEjungle", new CheckBox("Use in JungleClear"));
            FarmMenu.AddSeparator();
            */

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

            MiscMenu.Add("gapcloserW", new CheckBox("Use W - Smoke Grenade on Gapcloser"));
            MiscMenu.Add("gapcloserE", new CheckBox("Use E - True Grit against Gapcloser"));
            MiscMenu.AddSeparator();


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
            /*
                        DrawMenu = Menu.AddSubMenu("Draw", "Draw");
                        DrawMenu.AddGroupLabel("Draw Settings");
                        DrawMenu.AddLabel("Spell Ranges");
                        DrawMenu.Add("drawQ", new CheckBox("Draw Q Range"));
                        DrawMenu.Add("drawQextended", new CheckBox("Draw Extended Q Range"));
                        DrawMenu.Add("drawW", new CheckBox("Draw W Range"));
                        DrawMenu.Add("drawE", new CheckBox("Draw E Range"));
                        DrawMenu.Add("drawR", new CheckBox("Draw R Range"));
            */
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
            Orbwalker.OnPostAttack += Events.OnPostAttack;
            Orbwalker.OnPreAttack += Events.OnPreAttack;
            Obj_AI_Base.OnSpellCast += Events.OnSpellCast;
            Gapcloser.OnGapcloser += Events.OnGapCloser;
        }
    }
}