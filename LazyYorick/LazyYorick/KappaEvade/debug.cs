// ReSharper disable StringLiteralsWordIsNotInDictionary
namespace LazyYorick.KappaEvade
{
    class Debug
    {
        /*
    public static Menu EvadeMenu, SkillShots, Targeted;

    public static void Init()
    {
        //if (Player.Instance.Hero != Champion.Yasuo) return;

        EvadeMenu = MainMenu.AddMenu("KappaEvade", "KappaEvade");
        SkillShots = EvadeMenu.AddSubMenu("SkillShots");
        Targeted = EvadeMenu.AddSubMenu("TargetedSpells");

        EvadeMenu.AddGroupLabel("YASUO EVADE");
        Targeted.AddGroupLabel("TARGETED Spells");
        Targeted.Add("W", new CheckBoxValue("Use W"));
        Targeted.Add("impact", new CheckBoxValue("Block Before Impact"));
        Targeted.Add("rnd", new CheckBoxValue("Randomize Delay"));
        Targeted.Add("combo", new CheckBoxValue("Block In Combo Mode ONLY"));
        Targeted.Add("dl", new Slider("Min Danger Level To Block {0}", 1, 0, 5));
        var min = Targeted.Add("min", new Slider("Min Delay {0} (In MilliSeconds)", 0, 0, 500));
        var max = Targeted.Add("max", new Slider("Max Delay {0} (In MilliSeconds)", 250, 0, 1000));

        min.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
            {
                max.MinValue = args.NewValue;
                if (args.NewValue > max.CurrentValue)
                {
                    max.CurrentValue = args.NewValue + 1;
                }
            };

        SkillShots.AddGroupLabel("SKILLSHOTS");
        SkillShots.Add("W", new CheckBoxValue("Use W"));
        SkillShots.Add("combo", new CheckBoxValue("Block In Combo Mode ONLY"));
        SkillShots.Add("dl", new Slider("Min Danger Level To Block {0}", 1, 0, 5));
        SkillShots.Add("range", new Slider("Extra spell Range {0}", 50, 0, 150));
        SkillShots.Add("width", new Slider("Extra spell Width {0}", 15, 0, 75));

        Targeted.AddSeparator();
        SkillShots.AddSeparator();
        foreach (var enemy in EntityManager.Heroes.Enemies)
        {
            foreach (var spell in Database.TargetedSpells.TargetedSpellsList.Where(s => s.hero == enemy.Hero))
            {
                Targeted.Add(enemy.NetworkId + spell.slot, new CheckBoxValue("Enable " + enemy.ChampionName + " (" + enemy.Name + ")" + " - " + spell.slot, spell.DangerLevel > 1));
                Targeted.Add(enemy.NetworkId + spell.slot + "dl", new Slider(enemy.ChampionName + " (" + enemy.Name + ")" + " " + spell.slot + " Danger Level {0}", spell.DangerLevel, 0, 5));
                Targeted.AddSeparator(1);
            }

            foreach (var spell in Database.SkillShotSpells.SkillShotsSpellsList.Where(s => s.hero == enemy.Hero))
            {
                SkillShots.Add(enemy.NetworkId + spell.slot + "draw", new CheckBoxValue("Draw " + enemy.ChampionName + " (" + enemy.Name + ")" + " - " + spell.slot));
                SkillShots.Add(enemy.NetworkId + spell.slot, new CheckBoxValue("Enable " + enemy.ChampionName + " (" + enemy.Name + ")" + " - " + spell.slot, spell.DangerLevel > 1));
                SkillShots.Add(enemy.NetworkId + spell.slot + "dl", new Slider(enemy.ChampionName + " (" + enemy.Name + ")" + " " + spell.slot + " Danger Level {0}", spell.DangerLevel, 0, 5));
                SkillShots.AddSeparator(1);
            }
        }

        Game.OnTick += Game_OnTick;
        SpellsDetector.OnTargetedSpellDetected += SpellsDetector_OnTargetedSpellDetected;
    }

    private static void SpellsDetector_OnTargetedSpellDetected(Obj_AI_Base sender, Obj_AI_Base target, GameObjectProcessSpellCastEventArgs args, Database.TargetedSpells.TSpell spell)
    {
        var W = Player.GetSpell(SpellSlot.W);
        if (sender == null || !sender.IsEnemy || !target.IsMe || !Targeted.CheckBoxValue("W") || !W.IsReady)
            return;

        if (Targeted.slider(sender.NetworkId + spell.slot + "dl") >= Targeted.slider("dl") && Targeted.CheckBoxValueValue(sender.NetworkId + spell.slot))
        {
            var impact = (args.Start.Distance(Player.Instance) / args.SData.MissileSpeed) * 1000 + (spell.CastDelay - Game.Ping);
            var delay = Targeted.CheckBoxValue("impact") ? impact : Targeted.CheckBoxValue("rnd") ? new Random().Next(Targeted.slider("min"), Targeted.slider("max")) : Targeted.slider("max");
            Chat.Print(delay);
            EloBuddy.SDK.Core.DelayAction(() => Player.CastSpell(W.Slot, Player.Instance.ServerPosition.Extend(args.Start, 200).To3D()), (int)delay);
        }
    }

    private static void Game_OnTick(EventArgs args)
    {
        var W = Player.GetSpell(SpellSlot.W);

        foreach (var spell in KappaEvade.DetectedSpells.Where(s => s.spell.Collisions.Contains(Database.SkillShotSpells.Collision.YasuoWall) && Player.Instance.IsInDanger(s)))
        {
            if (SkillShots.slider(spell.Caster.NetworkId + spell.spell.slot + "dl") >= SkillShots.slider("dl") && SkillShots.CheckBoxValue("W") && W.IsReady
                && SkillShots.CheckBoxValue(spell.Caster.NetworkId + spell.spell.slot))
            {
                Player.CastSpell(W.Slot, Player.Instance.ServerPosition.Extend(spell.Start, 200).To3D());
            }
        }
    }
        */
    }
}
