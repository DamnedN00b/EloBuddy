using EloBuddy.SDK;

namespace LazyLucian.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Targeted Q => SpellManager.Q;
        protected Spell.Skillshot Q1 => SpellManager.Q1;
        protected Spell.Skillshot W => SpellManager.W;
        protected Spell.Skillshot E => SpellManager.E;
        protected Spell.Skillshot R => SpellManager.R;
        public abstract bool ShouldBeExecuted();
        public abstract void Execute();
    }
}